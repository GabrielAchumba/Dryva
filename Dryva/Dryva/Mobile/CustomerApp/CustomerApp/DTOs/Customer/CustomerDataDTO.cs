using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DTOs.Customer
{

    public class CustomerDataDTO : BaseDTO
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the other.
        /// </summary>
        /// <value>The name of the other.</value>
        public string OtherName { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the CSN.
        /// </summary>
        /// <value>The CSN.</value>
        public long? Csn { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the residential city.
        /// </summary>
        /// <value>The residential city.</value>
        public string ResidentialCity { get; set; }
        /// <summary>
        /// Gets or sets the state of the residential.
        /// </summary>
        /// <value>The state of the residential.</value>
        public string ResidentialState { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the blood group.
        /// </summary>
        /// <value>The blood group.</value>
        public string BloodGroup { get; set; }
        /// <summary>
        /// Gets or sets the genotype.
        /// </summary>
        /// <value>The genotype.</value>
        public string Genotype { get; set; }
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        public string MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the lga of origin.
        /// </summary>
        /// <value>The lga of origin.</value>
        public string LGAOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the state of origin.
        /// </summary>
        /// <value>The state of origin.</value>
        public string StateOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the left thumb image.
        /// </summary>
        /// <value>The left thumb image.</value>
        public byte[] LeftThumbImage { get; set; }
        /// <summary>
        /// Gets or sets the left index image.
        /// </summary>
        /// <value>The left index image.</value>
        public byte[] LeftIndexImage { get; set; }
        /// <summary>
        /// Gets or sets the left thumb minutia.
        /// </summary>
        /// <value>The left thumb minutia.</value>
        public byte[] LeftThumbMinutia { get; set; }
        /// <summary>
        /// Gets or sets the left index minutia.
        /// </summary>
        /// <value>The left index minutia.</value>
        public byte[] LeftIndexMinutia { get; set; }

        /// <summary>
        /// Gets or sets the right thumb image.
        /// </summary>
        /// <value>The right thumb image.</value>
        public byte[] RightThumbImage { get; set; }
        /// <summary>
        /// Gets or sets the right index image.
        /// </summary>
        /// <value>The right index image.</value>
        public byte[] RightIndexImage { get; set; }
        /// <summary>
        /// Gets or sets the right thumb minutia.
        /// </summary>
        /// <value>The right thumb minutia.</value>
        public byte[] RightThumbMinutia { get; set; }
        /// <summary>
        /// Gets or sets the right index minutia.
        /// </summary>
        /// <value>The right index minutia.</value>
        public byte[] RightIndexMinutia { get; set; }

        /// <summary>
        /// Gets or sets the photograph.
        /// </summary>
        /// <value>The photograph.</value>
        public byte[] Photograph { get; set; }
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>The signature.</value>
        public byte[] Signature { get; set; }
    }

}
