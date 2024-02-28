using Dryva.Enrollment.Enums;
using System;

namespace Dryva.Enrollment.Models
{

    public class Driver : EntityBase, IClient
    {
        public string MakeAndModel { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string PlateNumber { get; set; }

        public bool IsOwner { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhoneNumber { get; set; }

        public string NOKNames { get; set; }
        public string NOKAddress { get; set; }
        public string NOKPhoneNumber { get; set; }
        public string NOKRelationship { get; set; }

        public string AccountNumber { get; set; }
        public BankAccountTypes? AccountType { get; set; }

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

        public byte[] PdfDocuments { get; set; }

    }
}
