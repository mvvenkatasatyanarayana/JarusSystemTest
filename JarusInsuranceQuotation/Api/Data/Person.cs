using System;

namespace JarusInsuranceQuotation.Api.Data
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string FullName { get { return $"{Prefix} {FirstName} {LastName}"; } }
        public DateTime DateOfBirth { get; set; }
    }
}
