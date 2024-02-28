// ***********************************************************************
// Assembly         : Dryva.Enrollment
// Author           : INTEGRITY
// Created          : 12-23-2019
//
// Last Modified By : INTEGRITY
// Last Modified On : 12-23-2019
// ***********************************************************************
// <copyright file="DriverDTO.cs" company="Dryva.Enrollment">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dryva.Enrollment.Enums;
using System;

namespace Dryva.Enrollment.DTOs.Driver
{

    /// <summary>
    /// Class DriverDataDTO.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.BaseDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.BaseDTO" />
    public class DriverDataDTO : BaseDTO
    {
        /// <summary>
        /// Gets or sets the make and model.
        /// </summary>
        /// <value>The make and model.</value>
        public string MakeAndModel { get; set; }
        /// <summary>
        /// Gets or sets the chassis number.
        /// </summary>
        /// <value>The chassis number.</value>
        public string ChassisNumber { get; set; }
        /// <summary>
        /// Gets or sets the engine number.
        /// </summary>
        /// <value>The engine number.</value>
        public string EngineNumber { get; set; }
        /// <summary>
        /// Gets or sets the plate number.
        /// </summary>
        /// <value>The plate number.</value>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is owner.
        /// </summary>
        /// <value><c>true</c> if this instance is owner; otherwise, <c>false</c>.</value>
        public bool IsOwner { get; set; }
        /// <summary>
        /// Gets or sets the owner surname.
        /// </summary>
        /// <value>The owner surname.</value>
        public string OwnerSurname { get; set; }
        /// <summary>
        /// Gets or sets the first name of the owner.
        /// </summary>
        /// <value>The first name of the owner.</value>
        public string OwnerFirstName { get; set; }
        /// <summary>
        /// Gets or sets the owner address.
        /// </summary>
        /// <value>The owner address.</value>
        public string OwnerAddress { get; set; }
        /// <summary>
        /// Gets or sets the owner email.
        /// </summary>
        /// <value>The owner email.</value>
        public string OwnerEmail { get; set; }
        /// <summary>
        /// Gets or sets the owner phone number.
        /// </summary>
        /// <value>The owner phone number.</value>
        public string OwnerPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the nok names.
        /// </summary>
        /// <value>The nok names.</value>
        public string NOKNames { get; set; }
        /// <summary>
        /// Gets or sets the nok address.
        /// </summary>
        /// <value>The nok address.</value>
        public string NOKAddress { get; set; }
        /// <summary>
        /// Gets or sets the nok phone number.
        /// </summary>
        /// <value>The nok phone number.</value>
        public string NOKPhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the nok relationship.
        /// </summary>
        /// <value>The nok relationship.</value>
        public string NOKRelationship { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>The type of the account.</value>
        public BankAccountTypes? AccountType { get; set; }

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
