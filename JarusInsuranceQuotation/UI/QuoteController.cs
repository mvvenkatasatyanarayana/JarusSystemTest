using JarusInsuranceQuotation.Api.Data;
using JarusInsuranceQuotation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JarusInsuranceQuotation.UI
{
    [Route("[controller]/[action]")]
    public class QuoteController : Controller
    {
        private readonly IConfiguration _configuration;
        private const string API_BASE_URL = "ApiBaseUrl";
        private readonly string BASE_URL;
        public QuoteController(IConfiguration configuration)
        {
            BASE_URL = configuration[API_BASE_URL];
        }

        public async Task<IActionResult> Index()
        {
            var quote = new Quote();
            using (var httpClient = new HttpClient())
            {
                var url = $"{BASE_URL}quoteapi/getquote";
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    quote = JsonConvert.DeserializeObject<Quote>(apiResponse);
                }
            }
            ViewBag.BaseUrl = BASE_URL;

            return View(quote);
        }

        public async Task<IActionResult> FindPeople(string firstName, string lastName)
        {
            var persons = new List<Person>();
            using (var httpClient = new HttpClient())
            {
                var url = $"{BASE_URL}quoteapi/findpeople?firstName={firstName}&lastName={lastName}";
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    persons = JsonConvert.DeserializeObject<List<Person>>(apiResponse);
                }
            }
            var personsViewData = new ViewDataDictionary(
                new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
            {
                Model = new SearchResults() { Persons = persons }
            };

            PartialViewResult partialView = new PartialViewResult()
            {
                ViewName = "_SearchResults",
                ViewData = personsViewData
            };


            return partialView;
        }

        public async Task<IActionResult> GetAdditionalInsurers(string personIds)
        {
            var persons = new List<AdditionalInsured>();
            if (!string.IsNullOrWhiteSpace(personIds))
            {

                using (var httpClient = new HttpClient())
                {
                    var url = $"{BASE_URL}quoteapi/getadditionalinsurers?personIds={personIds}";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        persons = JsonConvert.DeserializeObject<List<AdditionalInsured>>(apiResponse);
                    }
                }
            }
            var additionalInsurersViewData = new ViewDataDictionary(
                new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
            {
                Model = new AdditionalInsuredResult() { AdditionalInsuredList = persons }
            };

            PartialViewResult partialView = new PartialViewResult()
            {
                ViewName = "_AdditionalInsured",
                ViewData = additionalInsurersViewData
            };


            return partialView;
        }
    }
}