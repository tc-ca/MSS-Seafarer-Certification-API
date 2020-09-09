using Microsoft.EntityFrameworkCore;
using SeafarersAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafarersAPI.Data.Repositories
{
    public class SubmissionRepository
    {
        public SubmissionContext context;
        public SubmissionRepository()
        {
            if(context== null)
            {
                context = new SubmissionContext();
            }
        }

        public List<Submission> GetSubmissions()
        {
            return context.Submissions.ToList();
        }

        public Submission GetSubmissionById(int submissionId)
        {
            var submission = context.Submissions.Where(x => x.SubmissionId == submissionId).SingleOrDefault();

            return submission;
        }

        public List<Submission> GetSubmissionsByCDNnumber(string cdn_number)
        {
            return context.Submissions.Where(x => x.CdnNumber == cdn_number).ToList();
        }

        public Submission GetSubmissionByConfirmationNumber(int confirmationNumber)
        {
            return context.Submissions.Where(x => x.ConfirmationNumber == confirmationNumber).SingleOrDefault();
        }

        public void SaveSubmission(Submission submission)
        {
            context.Submissions.Add(submission);
            context.SaveChanges();
        }

        public void DeleteSubmissionById(int submissionId)
        {
            var submission = new Submission { SubmissionId = submissionId };

            context.Entry(submission).State = EntityState.Deleted;
            context.SaveChanges();
        }

    }
}
