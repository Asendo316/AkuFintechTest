using AcuTestRestAPI.Contracts;
using AcuTestRestAPI.Contracts.v1.Requests.user.fileupload;
using AcuTestRestAPI.Contracts.v1.Response.abs;
using AcuTestRestAPI.Contracts.v1.Response.file;
using AcuTestRestAPI.Domain.v1.files;
using AcuTestRestAPI.Services.Interfaces.v1.user.file;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Controllers.v1.user.file
{
    public class CompareFilesController : Controller
    {
        private readonly ICompareFilesService _compareFilesService;
        DateTime currentDate = DateTime.Today;
        private readonly UserManager<IdentityUser> _userManager;



        public CompareFilesController(ICompareFilesService compareFilesService, UserManager<IdentityUser> userManager)
        {
            _compareFilesService = compareFilesService;
            _userManager = userManager;
        }



        /// <summary>
        /// Get All Compared Documents
        /// </summary>
        /// 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.History.GetAllHistory)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _compareFilesService.GetAllComparedFileHistory());
        }

        /// <summary>
        /// Get Comparism History For Professor
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.History.GetUserHistory)]
        public async Task<IActionResult> GetAllComparismForUser([FromRoute]string profileId)
        {
            var history = await _compareFilesService.GetAllComparedFilesByUser(profileId);
            if (history == null)
                return NotFound(new GenericResponse { Status = "Failed", Message = "Oops, No History for this Professor" });
            return Ok(history);
        }

        /// <summary>
        /// Compare Student Document
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(ApiRoutes.CompareFiles.CompareLiveDoc)]
        public async Task<IActionResult> CompareStudentFiles([FromForm] CompareFileRequest compareFileRequest)
        {
            // Getting Name
            string firstStudentName = compareFileRequest.FirstStudentName;
            string secondStudentName = compareFileRequest.SecondStudentName;

            // Getting Files
            var fileOne = compareFileRequest.FirstStudentFile;
            var fileTwo = compareFileRequest.SecondStudentFile;

            double percentageSimilarity;
            string file1, file2;

            // Saving Files on Server
            var extension = Path.GetExtension(fileOne.FileName);
            var extension2 = Path.GetExtension(fileTwo.FileName);

            if (fileOne.Length > 0 && extension.ToLower().Equals(".txt"))
            {

                if (fileTwo.Length > 0 && extension2.ToLower().Equals(".txt"))
                {
                    file1 = await getFileDataAsync(fileOne);
                    file2 = await getFileDataAsync(fileTwo);
                    percentageSimilarity = CalculateSimilarity(file1, file2);

                    var user =  HttpContext.Session.GetString("Id");


                    var comparism = new ComparedFiles
                    {
                        CreatorId = user,
                        FirstStudentName = firstStudentName,
                        FirstStudentFile = file1,
                        SecondStudentName = secondStudentName,
                        SecondStudentFile = file2,
                        PercentageSimilarity = percentageSimilarity * 100 +" %"
                    };

                    await _compareFilesService.CreateNewComparismRecord(comparism);
                }
                else
                {
                    return Ok(new GenericResponse { Status = "Error", Message = "Please select first Student File or Upload Valid Text File" });
                }
            }
            else
            {
                return Ok(new GenericResponse { Status = "Error", Message = "Please select first Student File or Upload Valid Text File" });
            }



            return Ok(new ComparismResponse
            {
                FirstStudentName = firstStudentName,
                FirstStudentFileContent = file1,
                SecondStudentName = secondStudentName,
                SecondStudentFileContent = file2,
                PercentageSimilarity = percentageSimilarity * 100 + "%"
            });
        }

        /// <summary>
        /// Rerun Comparism
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.History.RerunComparism)]
        public async Task<IActionResult> RerunCOmparism([FromRoute]Guid historyId)
        {
            var history = await _compareFilesService.GetComparismByIdAsync(historyId);
            double percentageSimilarity;
            string file1, file2;
            if (history != null)
            {

                file1 = history.FirstStudentFile;
                file2 = history.SecondStudentFile;
                percentageSimilarity = CalculateSimilarity(file1, file2);

            }
            else
            {
                return NotFound(new GenericResponse { Status = "Failed", Message = "Oops, No History for this Professor" });
            }

            return Ok(new ComparismResponse
            {
                FirstStudentName = history.FirstStudentName,
                FirstStudentFileContent = file1,
                SecondStudentName = history.SecondStudentName,
                SecondStudentFileContent = file2,
                PercentageSimilarity = percentageSimilarity * 100 + "%"
            });
        }


        /**
         * Extract File Data
         * */
        private async Task<string> getFileDataAsync(IFormFile file)
        {
            var result1 = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result1.AppendLine(await reader.ReadLineAsync());
            }
            var fileData = result1.ToString();

            return fileData;
        }


        private double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }


        private int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
    }
}
