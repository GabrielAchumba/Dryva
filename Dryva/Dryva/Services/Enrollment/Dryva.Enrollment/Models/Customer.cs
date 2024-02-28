using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Models
{
    public class Customer : EntityBase, IClient
    {
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

        public byte[] LeftThumbImage { get; set; }
        public byte[] LeftIndexImage { get; set; }
        public byte[] LeftThumbMinutia { get; set; }
        public byte[] LeftIndexMinutia { get; set; }

        public byte[] RightThumbImage { get; set; }
        public byte[] RightIndexImage { get; set; }
        public byte[] RightThumbMinutia { get; set; }
        public byte[] RightIndexMinutia { get; set; }

        public byte[] Photograph { get; set; }
        public byte[] Signature { get; set; }

    }
}
