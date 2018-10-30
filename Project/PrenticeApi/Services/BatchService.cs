using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrenticeApi.Dtos;
using PrenticeApi.Models;

namespace PrenticeApi.Services
{
    public interface IBatchService
    {
        Task InitiateBatchAsync(BatchDto batchDto, ClaimsPrincipal principal);
    }

    public class BatchService : IBatchService
    {
        private DataContext _context;

        public BatchService(DataContext context)
        {
            _context = context;
        }

        public async Task InitiateBatchAsync(BatchDto batchDto, ClaimsPrincipal principal)
        {
            var termType = await _context.TermTypes
                                .SingleOrDefaultAsync(x => x.TermTypeId == batchDto.TermTypeId);

            var batchProgramType = await _context.ProgramTypes
                                .SingleOrDefaultAsync(x => x.ProgramTypeId == batchDto.ProgramTypeId);

            var batch = new Batch
            {
                Name = batchDto.Name,
                ProgramType = batchProgramType,
                StartDate = batchDto.StartDate,
                EndDate = batchDto.EndDate,
                UserId = principal.Identity.Name
            };

            List<BatchTerm> batchTermList = new List<BatchTerm>();
            for (int i = 0; i < batchProgramType.Terms; i++)
            {
                batchTermList.Add(
                new BatchTerm
                {
                    Batch = batch,
                    TermType = termType
                });
            }

            _context.Batches.Add(batch);
            batchTermList.ForEach(
                x => _context.BatchTerms.Add(x)
            );
            // _context.BatchTerms.Add(batchTerm);

            await _context.SaveChangesAsync();
        }
    }
}