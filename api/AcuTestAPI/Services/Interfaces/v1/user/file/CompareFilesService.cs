using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcuTestAPI.Data;
using AcuTestRestAPI.Domain.v1.files;
using Microsoft.EntityFrameworkCore;

namespace AcuTestRestAPI.Services.Interfaces.v1.user.file
{
    public class CompareFilesService : ICompareFilesService
    {

        private readonly DataContext _dataContext;

        public CompareFilesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateNewComparismRecord(ComparedFiles comparedFiles)
        {
            await _dataContext.ComparedFiles.AddAsync(comparedFiles);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<List<ComparedFiles>> GetAllComparedFileHistory()
        {
            return await _dataContext.ComparedFiles.ToListAsync();
        }

        public async Task<List<ComparedFiles>> GetAllComparedFilesByUser(string profileId)
        {
            return await _dataContext.ComparedFiles.Where(x => x.CreatorId == profileId.Trim()).ToListAsync();
        }

        public async Task<ComparedFiles> GetComparismByIdAsync(Guid historyId)
        {
            return await _dataContext.ComparedFiles.SingleOrDefaultAsync(x => x.Id == historyId);
        }

        public async Task<bool> DeleteComparedFilesByIdAsync(Guid historyId)
        {
            var post = await GetComparismByIdAsync(historyId);

            if (post == null)
                return false;

            _dataContext.ComparedFiles.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
