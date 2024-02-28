using CustomerApp.DTOs.Customer;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Models
{
    public class CustomerInfo
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double CreditBalance { get; set; }
        public int TripsBalance { get; set; }
        public long? Csn { get; set; }
        public bool IsActive { get; set; }
        public byte[] Photo { get; set; }


        public void SetData(CustomerDataDTO customerData)
        {
            if (customerData == null)
                return;

            this.CustomerId = customerData.Id;
            this.FirstName = customerData.FirstName;
            this.LastName = customerData.Surname;
            this.Email = customerData.Email;
            this.PhoneNumber = customerData.PhoneNumber;
            this.Photo = customerData.Photograph;
            this.Csn = customerData.Csn;
        }

    }
}
