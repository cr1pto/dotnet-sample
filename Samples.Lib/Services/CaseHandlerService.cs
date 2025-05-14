using Microsoft.EntityFrameworkCore;
using Samples.Lib.Entities;

namespace Samples.Lib.Services
{
    public class CaseHandlerService : ICaseHandlerService
    {
        private readonly SampleDbContext _sampleDbContext;

        public CaseHandlerService(SampleDbContext sampleDbContext)
        {
            _sampleDbContext = sampleDbContext;
        }

        public async Task<Case> CreateCase(Case caseEntity, CancellationToken cancellationToken)
        {
            var legalCase = _sampleDbContext.Cases.Add(caseEntity);

            await _sampleDbContext.SaveChangesAsync(cancellationToken);

            return legalCase.Entity;
        }

        public async Task<bool> DeleteCase(Guid id, CancellationToken cancellationToken)
        {
            var legalCase = _sampleDbContext.Cases.Where(c => c.Id == id).ExecuteDeleteAsync();

            var response = await _sampleDbContext.SaveChangesAsync(cancellationToken);

            return response > 0;
        }

        public async Task<Case> GetCaseById(Guid id, CancellationToken cancellationToken)
        {
            var legalCase = await _sampleDbContext.Cases.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);

            return legalCase;
        }

        public async Task<IEnumerable<Case>> GetCases(CancellationToken cancellationToken)
        {
            var defendant = await _sampleDbContext.Defendants.FirstOrDefaultAsync(cancellationToken);
            var legalCases = await _sampleDbContext.Cases.Take(500).ToListAsync(cancellationToken);

            return legalCases;
        }

        public async Task<IEnumerable<Case>> GetCasesByAttorneyId(Guid attorneyId, CancellationToken cancellationToken)
        {
            var legalCases = await _sampleDbContext.Cases.Include(c => c.DefenseAttorneys).Include(c => c.DistrictAttorneys).Where(c => c.Id == attorneyId).ToListAsync(cancellationToken);

            return legalCases;
        }

        public async Task<IEnumerable<Case>> GetCasesByDefendantId(Guid defendantId, CancellationToken cancellationToken)
        {
            var legalCases = await _sampleDbContext.Cases.Include(d => d.Defendant).Where(c => c.Id == defendantId).ToListAsync(cancellationToken);

            return legalCases;
        }

        public async Task<IEnumerable<Case>> GetCasesByJudgeId(Guid judgeId, CancellationToken cancellationToken)
        {
            var legalCases = await _sampleDbContext.Cases.Include(j => j.Judge).Where(c => c.Judge.Id == judgeId).ToListAsync(cancellationToken);

            return legalCases;
        }

        public async Task<IEnumerable<Case>> GetCasesByJurorId(Guid jurorId, CancellationToken cancellationToken)
        {
            var cases = await _sampleDbContext.Cases.Include(j => j.Jury).Where(c => c.Id == jurorId).ToListAsync(cancellationToken);

            return cases;
        }

        public async Task<Case> UpdateCase(Case caseEntity, CancellationToken cancellationToken)
        {
            _sampleDbContext.Entry<Case>(caseEntity).CurrentValues.SetValues(caseEntity);

            var legalCase = _sampleDbContext.Cases.Update(caseEntity);

            await _sampleDbContext.SaveChangesAsync(cancellationToken);

            return caseEntity;
        }
    }

    public interface ICaseHandlerService
    {
        Task<IEnumerable<Case>> GetCases(CancellationToken cancellationToken);
        Task<Case> GetCaseById(Guid id, CancellationToken cancellationToken);
        Task<Case> CreateCase(Case caseEntity, CancellationToken cancellationToken);
        Task<Case> UpdateCase(Case caseEntity, CancellationToken cancellationToken);
        Task<bool> DeleteCase(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Case>> GetCasesByAttorneyId(Guid attorneyId, CancellationToken cancellationToken);
        Task<IEnumerable<Case>> GetCasesByDefendantId(Guid defendantId, CancellationToken cancellationToken);
        Task<IEnumerable<Case>> GetCasesByJudgeId(Guid judgeId, CancellationToken cancellationToken);
        Task<IEnumerable<Case>> GetCasesByJurorId(Guid jurorId, CancellationToken cancellationToken);
    }
}
