using Microsoft.EntityFrameworkCore;
using SeafarersAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeafarersAPI.Data.Repositories
{
    public class SubmissionRepository : IRepository<Submission>
    {
        public SubmissionContext context;
        public SubmissionRepository()
        {
            if(context == null)
            {
                context = new SubmissionContext();
            }
        }

        public IEnumerable<Submission> GetList(int startIndex, int amountToGet)
        {
            return context.Submissions.Skip(startIndex).Take(amountToGet).ToList();
        }

        public int Save(Submission submission)
        {
            // TODO: Add locking mechanism or we'll run into concurrency issues
            context.Submissions.Add(submission);
            return context.SaveChanges();
        }

        public int Delete(Submission submission)
        {
            // TODO: Add locking mechanism or we'll run into concurrency issues
            context.Entry(submission).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public Submission GetSubmissionById(int submissionId)
        {
            return this.GetSubmissionsByFilter(x => x.SubmissionId == submissionId).SingleOrDefault();
        }

        public IEnumerable<Submission> GetSubmissionsByCDNnumber(string cdnNumber)
        {
            return this.GetSubmissionsByFilter(x => x.CdnNumber == cdnNumber);
        }

        public Submission GetSubmissionByConfirmationNumber(int confirmationNumber)
        {
            return this.GetSubmissionsByFilter(x => x.ConfirmationNumber == confirmationNumber).SingleOrDefault();
        }

        private IEnumerable<Submission> GetSubmissionsByFilter(Func<Submission, bool> filter)
        {
            return context.Submissions.Where(filter);
        }
    }
}
