using NUnit.Framework;
using SeafarersAPI.Data.Models;
using SeafarersAPI.Services;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;



namespace API_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SubmissionService service = new SubmissionService();

            var submission = service.GetSubmissionById(1);


            //string jsonString = JsonSerializer.Serialize(submission);

            //Console.WriteLine(jsonString);
            Assert.Pass();

        }
    }
}