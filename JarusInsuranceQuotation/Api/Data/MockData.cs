using System;
using System.Collections.Generic;
using System.Linq;
namespace JarusInsuranceQuotation.Api.Data
{
    public static class MockData
    {
        public static Quote GetDummyQuoteData()
        {
            return new Quote()
            {
                StatusId = 1,
                Statuses = GetDummyStatuses().ToList(),
                Applicant = "James Feather LLC",
                Basic = "$ 680.00",
                Preffered = "$ 850.00",
                Premier = "$ 1050.00",
                QuoteId = "Q97304",
                QuoteDate = DateTime.Now,
                EffectiveDate = DateTime.Now
            };
        }

        public static IEnumerable<Person> GetDummyPersonData()
        {
            return new List<Person>()
            {
                new Person()
                {
                    FirstName = "James",
                    LastName = "Feather",
                    Prefix = "Mr.",
                    PersonId = 1,
                    DateOfBirth = new DateTime(1980,1,3)
                },

                new Person()
                {
                    FirstName = "John",
                    LastName = "Krakow",
                    Prefix = "Mr.",
                    PersonId = 2,
                    DateOfBirth = new DateTime(1980,1,3)
                },

                new Person()
                {
                    FirstName = "Red",
                    LastName = "Hemmington",
                    Prefix = "Mr.",
                    PersonId = 3,
                    DateOfBirth = new DateTime(1980,1,3)
                }
            };
        }

        public static IEnumerable<AdditionalInsured> GetAdditionalInsurersData()
        {
            Random random = new Random();

            return new List<AdditionalInsured>()
            {
                new AdditionalInsured(){
                    AdditonalInsuredId = 1,
                    QuoteId = "Q97304",
                    Coverage = random.Next(10, 100),
                    Person = new Person()
                    {
                        FirstName = "James",
                        LastName = "Feather",
                        Prefix = "Mr.",
                        PersonId = 1,
                        DateOfBirth = new DateTime(1980,1,3)
                    }
                },
                new AdditionalInsured()
                {
                    AdditonalInsuredId = 2,
                    QuoteId = "Q97305",
                    Coverage = random.Next(10, 100),
                    Person = new Person()
                    {
                        FirstName = "John",
                        LastName = "Krakow",
                        Prefix = "Mr.",
                        PersonId = 2,
                        DateOfBirth = new DateTime(1980,1,3)
                    }
                },
                new AdditionalInsured()
                {
                    AdditonalInsuredId = 3,
                    QuoteId = "Q97306",
                    Coverage = random.Next(10, 100),
                    Person = new Person()
                    {
                        FirstName = "Red",
                        LastName = "Hemmington",
                        Prefix = "Mr.",
                        PersonId = 3,
                        DateOfBirth = new DateTime(1980,1,3)
                    }
                }
            };
        }

        public static IEnumerable<Status> GetDummyStatuses()
        {
            return new List<Status>()
            {
                new Status()
                {
                    StatusId = 1,
                    Description = "Pending"
                },
                new Status()
                {
                    StatusId = 2,
                    Description = "Issued"
                }
            };
        }
    }
}
