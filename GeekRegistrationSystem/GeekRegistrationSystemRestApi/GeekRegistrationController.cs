using System.Collections.Generic;
using System.Web.Http;
using GeekRegistrationSystemCore;

namespace GeekRegistrationSystemRestApi
{
    public class GeekRegistrationController : ApiController
    {
        private readonly ICandidateRepo _candidateRepo;

        public GeekRegistrationController(ICandidateRepo candidateRepo)
        {
            _candidateRepo = candidateRepo;
        }

        [Route("api/getcadidates")]
        [HttpGet]
        public List<CandidateDetails> GetCandidateDetails()
        {
            return _candidateRepo.GetCandidateDetails();
        }

        [Route("api/getcadidates/{technology}")]
        public List<CandidateDetails> GetCandidateDetailsByTechnology([FromUri]string Technology)
        {
            return _candidateRepo.GetCandidateByTechnology(Technology);
        }

        [Route("api/register")]
        public string RegisterCandidate([FromBody]CandidateDetails candidate)
        {
            _candidateRepo.RegisterCandidate(candidate);
            return "Candidate Registered";
        }
    }
}