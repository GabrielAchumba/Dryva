﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DryvaClient.Models.Transaction;
using DryvaClient.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DryvaClient.ViewModels.Transaction
{
    /// <summary>
    /// ViewModel for Checkout page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CheckoutPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Customer> deliveryAddress;

        private ObservableCollection<Payment> paymentModes;

        private ObservableCollection<Product> cartDetails;

        private double totalPrice;

        private double discountPrice;

        private double discountPercent;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CheckoutPageViewModel" /> class.
        /// </summary>
        public CheckoutPageViewModel()
        {
            this.DeliveryAddress = new ObservableCollection<Customer>
            {
                new Customer
                {
                    CustomerId = 1, CustomerName = "John Doe", AddressType = "Home", Address = "410 Terry Ave N, USA",
                    MobileNumber = "+1-202-555-0101"
                },
                new Customer
                {
                    CustomerId = 1, CustomerName = "John Doe", AddressType = "Office",
                    Address = "388 Fort Worth, Texas, United States", MobileNumber = "+1-356-636-8572"
                },
            };

            this.PaymentModes = new ObservableCollection<Payment>
            {
                new Payment
                {
                    PaymentMode = "Goldman Sachs Bank Credit Card", CardNumber = "48** **** **** 9876",
                    CardTypeIcon = "Card.png"
                },
                new Payment {PaymentMode = "Wells Fargo Bank Credit Card"},
                new Payment {PaymentMode = "Debit / Credit Card"},
                new Payment {PaymentMode = "NetBanking"},
                new Payment {PaymentMode = "Cash on Delivery"},
                new Payment {PaymentMode = "Wallet"},
            };

            this.CartDetails = new ObservableCollection<Product>
            {
                new Product
                {
                    PreviewImage = App.BaseImageUrl + "Image1.png", Name = "Full-Length Skirt",
                    Summary =
                        "This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days.",
                    SellerName = "New Fashion Company", ActualPrice = 245, DiscountPercent = 30, TotalQuantity = 1
                },
                new Product
                {
                    PreviewImage = App.BaseImageUrl + "Image2.png", Name = "Peasant Blouse",
                    Summary =
                        "Look your best this fall in this V-neck, pleated peasant blouse with full sleeves. Comes in white, chocolate, forest green, and more.",
                    SellerName = "New Fashion Company", ActualPrice = 245, DiscountPercent = 30, TotalQuantity = 1
                }
            };

            double percent = 0;
            foreach (var item in this.CartDetails)
            {
                this.TotalPrice += (item.ActualPrice * item.TotalQuantity);
                this.DiscountPrice += (item.DiscountPrice * item.TotalQuantity);
                percent += item.DiscountPercent;
            }

            this.DiscountPercent = percent > 0 ? percent / this.CartDetails.Count : 0;

            this.EditCommand = new Command(this.EditClicked);
            this.AddAddressCommand = new Command(this.AddAddressClicked);
            this.PlaceOrderCommand = new Command(this.PlaceOrderClicked);
            this.PaymentOptionCommand = new Command(PaymentOptionClicked);
            this.ApplyCouponCommand = new Command(this.ApplyCouponClicked);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with SfListView, which displays the delivery address.
        /// </summary>
        public ObservableCollection<Customer> DeliveryAddress
        {
            get { return this.deliveryAddress; }

            set
            {
                if (this.deliveryAddress == value)
                {
                    return;
                }

                SetProperty(ref this.deliveryAddress, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with SfListView, which displays the payment modes.
        /// </summary>
        public ObservableCollection<Payment> PaymentModes
        {
            get { return this.paymentModes; }

            set
            {
                if (this.paymentModes == value)
                {
                    return;
                }

                SetProperty(ref this.paymentModes, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the cart details.
        /// </summary>
        public ObservableCollection<Product> CartDetails
        {
            get { return this.cartDetails; }

            set
            {
                if (this.cartDetails == value)
                {
                    return;
                }

                SetProperty(ref this.cartDetails, value);
            }
           
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays total price.
        /// </summary>
        public double TotalPrice
        {
            get { return this.totalPrice; }

            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }

                SetProperty(ref this.totalPrice, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays total discount price.
        /// </summary>
        public double DiscountPrice
        {
            get { return this.discountPrice; }

            set
            {
                if (this.discountPrice == value)
                {
                    return;
                }

                this.discountPrice = value;
                SetProperty(ref this.discountPrice, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays discount.
        /// </summary>
        public double DiscountPercent
        {
            get { return this.discountPercent; }

            set
            {
                if (this.discountPercent == value)
                {
                    return;
                }

                this.discountPercent = value;
                SetProperty(ref this.discountPercent, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Add new address button is clicked.
        /// </summary>
        public Command AddAddressCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command PlaceOrderCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the payment option button is clicked.
        /// </summary>
        public Command PaymentOptionCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the apply coupon button is clicked.
        /// </summary>
        public Command ApplyCouponCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Edit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void EditClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Add address button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddAddressClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Place order button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void PlaceOrderClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Payment option is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void PaymentOptionClicked(object obj)
        {
            if (obj is RowDefinition rowDefinition && rowDefinition.Height.Value == 0)
            {
                rowDefinition.Height = GridLength.Auto;
            }
        }

        /// <summary>
        /// Invoked when the Apply coupon button is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ApplyCouponClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}