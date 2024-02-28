using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.Mobile.Aggregator.Test
{
    public class Combined
    {
        public List<Customer> customers { get; set; }
        public List<State> state { get; set; }
    }

    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
    public class Customer
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public long? Csn { get; set; }

        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string ResidentialCity { get; set; }
        public string ResidentialState { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string MaritalStatus { get; set; }
        public string LGAOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
        public string Country { get; set; }
    }
}
