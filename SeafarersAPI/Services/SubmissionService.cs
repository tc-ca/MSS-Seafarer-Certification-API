using SeafarersAPI.Data.Models;
using SeafarersAPI.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SeafarersAPI.Services
{
    public class SubmissionService
    {
        SubmissionRepository repo;

        public SubmissionService()
        {
            repo = new SubmissionRepository();
        }

        public IEnumerable<Submission> GetSubmissions(int startingIndex, int amountToGet)
        {
            return repo.GetList(startingIndex, amountToGet).ToList();

        }

        public Submission GetSubmissionById(int submissionId)
        {
            return repo.GetSubmissionById(submissionId);

        }

        public List<Submission> GetSubmissionsByCDNnumber(string cdnNumber)
        {
            return repo.GetSubmissionsByCDNnumber(cdnNumber).ToList();
        }

        public Submission GetSubmissionByConfirmationNumber(int confirmationNumber)
        {
            return repo.GetSubmissionByConfirmationNumber(confirmationNumber);
        }

        public void SaveSubmission(Submission submission)
        {
            repo.Save(submission);
        }

        public void DeleteSubmissionById(int submissionId)
        {
            var submission = repo.GetSubmissionById(submissionId);
            repo.Delete(submission);
        }
    }
}
