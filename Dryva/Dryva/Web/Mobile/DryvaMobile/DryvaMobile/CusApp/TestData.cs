using CusApp.DTOs.Customer;
using CusApp.DTOs.Device;
using CusApp.DTOs.MapsDTO;
using CusApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp
{
    public class TestData
    {
        public TestData()
        {
            CreateRegistrationItem();
            CreateWalletItem();
            GetRegistrationDTO();
            GetMapAxisDTO();
        }
        public RegistrationItem registrationItem { get; set; }
        public WalletItem walletItem { get; set; }
        public RegistrationDTO registrationDTO { get; set; }
        public MapAxisDTO mapAxisDTO { get; set; }
        public DeviceTrailDTO deviceTrailDTO { get; set; }

        private void CreateRegistrationItem()
        {
            registrationItem = new RegistrationItem();
            registrationItem.FirstName = "Gabriel";
            registrationItem.Surname = "Achumba";
            registrationItem.OtherName = "Ifeanyi";
            registrationItem.PhoneNumber = "07032488605";
            registrationItem.Title = "Mr";
            registrationItem.Username = "GabrielAchumba";
        }
        private void CreateWalletItem()
        {
            walletItem = new WalletItem();
            walletItem.BankAccountNumber = "2088207548";
            walletItem.BankName = "Achumba Gabriel Ifeanyi";
            walletItem.CardExpiredDate = new DateTime(2022, 11, 1);
            walletItem.CardNumber = "5399411131028596";
            walletItem.Country = "Nigeria";
            walletItem.CVC = "999";
            walletItem.IsMonthlyChecked = true;
            walletItem.IsWeeklyChecked = false;
            walletItem.PaidDate = new DateTime(2019, 12, 21);
            walletItem.Units = 2500;
        }
        private void GetRegistrationDTO()
        {
            registrationDTO = new RegistrationDTO();
            registrationDTO.Title = "Mr";
            registrationDTO.FirstName = "Gabriel";
            registrationDTO.Surname = "Achumba";
            registrationDTO.OtherName = "Ifeanyi";
            registrationDTO.Gender = "M";
            registrationDTO.PhoneNumber = "07032488605";
        }
        private void GetMapAxisDTO()
        {
            mapAxisDTO = new MapAxisDTO();
            mapAxisDTO.Latitude = 201;
            mapAxisDTO.Longitude = 305;
            
        }
    }
}
