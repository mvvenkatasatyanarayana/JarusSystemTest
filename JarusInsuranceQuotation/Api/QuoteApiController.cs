using JarusInsuranceQuotation.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JarusInsuranceQuotation.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuoteApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Quote> GetQuote()
        {
            var quote = MockData.GetDummyQuoteData();
            return quote;
        }

        [HttpGet]
        public ActionResult<List<Person>> FindPeople(string firstName, string lastName)
        {
            var persons = MockData.GetDummyPersonData().ToList();
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return persons;
            return persons.Where(_ => (firstName != null && _.FirstName.Contains(firstName,System.StringComparison.OrdinalIgnoreCase) || (lastName != null && _.LastName.Contains(lastName, System.StringComparison.OrdinalIgnoreCase)))).ToList();
            
        }

        [HttpGet]
        public ActionResult<List<AdditionalInsured>> GetAdditionalInsurers(string personIds)
        {
            var ids = personIds.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var additionalInsurers = MockData.GetAdditionalInsurersData().ToList();
            return additionalInsurers.Where(_ => ids.Contains(_.Person.PersonId.ToString())).ToList();

        }

    }
}
