using SeafarersAPI.Data.Models;
using SeafarersAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafarersAPI.Services
{
    public class SubmissionService
    {
        SubmissionRepository repo;

        public SubmissionService()
        {
            repo = new SubmissionRepository();
        }



        public List<Submission> GetSubmissions()
        {
            return repo.GetSubmissions();

        }

        public Submission GetSubmissionById(int submissionId)
        {
            return repo.GetSubmissionById(submissionId);

        }

        public List<Submission> GetSubmissionsByCDNnumber(string cdn_number)
        {
            return repo.GetSubmissionsByCDNnumber(cdn_number);
        }

        public Submission GetSubmissionByConfirmationNumber(int confirmationNumber)
        {
            return repo.GetSubmissionByConfirmationNumber(confirmationNumber);
        }

        public void SaveSubmission(Submission submission)
        {
            repo.SaveSubmission(submission);
        }

        public void DeleteSubmissionById(int submissionId)
        {
            repo.DeleteSubmissionById(submissionId);
        }



    }
}
