using System;

namespace Dryva.Enrollment.Models
{
    public interface IClient
    {
        string Address { get; set; }
        DateTime? BirthDate { get; set; }
        string BloodGroup { get; set; }
        string ResidentialCity { get; set; }
        string Country { get; set; }
        long? Csn { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string Gender { get; set; }
        string Genotype { get; set; }
        byte[] LeftIndexImage { get; set; }
        byte[] LeftIndexMinutia { get; set; }
        byte[] LeftThumbImage { get; set; }
        byte[] LeftThumbMinutia { get; set; }
        string LGAOfOrigin { get; set; }
        string MaritalStatus { get; set; }
        string OtherName { get; set; }
        string PhoneNumber { get; set; }
        byte[] Photograph { get; set; }
        byte[] RightIndexImage { get; set; }
        byte[] RightIndexMinutia { get; set; }
        byte[] RightThumbImage { get; set; }
        byte[] RightThumbMinutia { get; set; }
        byte[] Signature { get; set; }
        string ResidentialState { get; set; }
        string StateOfOrigin { get; set; }
        string Surname { get; set; }
        string Title { get; set; }
    }
}