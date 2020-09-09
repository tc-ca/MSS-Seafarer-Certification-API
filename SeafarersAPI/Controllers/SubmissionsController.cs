﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeafarersAPI.Data.Models;
using SeafarersAPI.Services;

namespace SeafarersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        SubmissionService submissionService = new SubmissionService();
        MTA_Service mtaService = new MTA_Service();

        // GET: api/Submissions
        [HttpGet]
        public List<Submission> Get()
        {
            return submissionService.GetSubmissions();
        }

        // GET: api/Submissions/2
        [HttpGet("{id}", Name = "Get")]
        public Submission GetBySubmissionID(int id)
        {
            return submissionService.GetSubmissionById(id);
        }

        // POST: api/Submissions
        [HttpPost]
        public void Post([FromBody] Submission submission )
        {
            if(submission.Documents.Count>0)
            {
                //TODO: check how we can save mutiple files on MTA.
                // For now, let's asume that there is only one file to store
                //var document = submission.Documents.First();
                //int documentID=mtaService.SaveFileOnMTA(document.Data.ToString());  // Data is byte[]
            }

            submissionService.SaveSubmission(submission);
        }

        // PUT: api/Submissions/2
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var lenghth=value.Length;
        }


        // api/Submissions/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            submissionService.DeleteSubmissionById(id);
        }
    }
}
