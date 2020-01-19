using AcuTestRestAPI.Domain.v1.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Services.Interfaces.v1.user.file
{
    public interface ICompareFilesService
    {
        Task<List<ComparedFiles>> GetAllComparedFileHistory();

        Task<bool> CreateNewComparismRecord(ComparedFiles comparedFiles);

        Task<ComparedFiles> GetComparismByIdAsync(Guid historyId);

        Task<List<ComparedFiles>> GetAllComparedFilesByUser(String profileId);

        Task<bool> DeleteComparedFilesByIdAsync(Guid historyId);
    }
}
