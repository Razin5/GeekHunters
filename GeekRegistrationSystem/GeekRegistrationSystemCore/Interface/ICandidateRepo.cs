using System.Collections.Generic;

namespace GeekRegistrationSystemCore
{
    public interface ICandidateRepo
    {
        void RegisterCandidate(CandidateDetails candidateDetails);

        List<CandidateDetails> GetCandidateDetails();

        List<CandidateDetails> GetCandidateByTechnology(string technology);
    }
}
