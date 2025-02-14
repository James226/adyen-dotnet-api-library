﻿#region Licence
// 
//                        ######
//                        ######
//  ############    ####( ######  #####. ######  ############   ############
//  #############  #####( ######  #####. ######  #############  #############
//         ######  #####( ######  #####. ######  #####  ######  #####  ######
//  ###### ######  #####( ######  #####. ######  #####  #####   #####  ######
//  ###### ######  #####( ######  #####. ######  #####          #####  ######
//  #############  #############  #############  #############  #####  ######
//   ############   ############  #############   ############  #####  ######
//                                       ######
//                                #############
//                                ############
// 
//  Adyen Dotnet API Library
// 
//  Copyright (c) 2020 Adyen B.V.
//  This file is open source and available under the MIT license.
//  See the LICENSE file for more info.
#endregion

using Adyen.Model.Checkout;
using Adyen.Model.Checkout.Details;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adyen.Test
{
    [TestClass]
    public class PaymentMethodDetailsTest
    {
        [TestMethod]
        public void TestAchPaymentMethod()
        {
            var paymentRequest = new PaymentRequest
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("EUR", 1000),
                Reference = "ACH test",
                PaymentMethod = new AchDetails
                {
                    BankAccountNumber = "1234567",
                    BankLocationId = "1234567",
                    EncryptedBankAccountNumber = "1234asdfg",
                    OwnerName = "John Smith"
                },
                ShopperIP = "192.0.2.1",
                Channel = PaymentRequest.ChannelEnum.Web,
                Origin = "https://your-company.com",
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy..",

            };
            var paymentMethodDetails = (AchDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "ach");
            Assert.AreEqual(paymentMethodDetails.BankAccountNumber, "1234567");
            Assert.AreEqual(paymentMethodDetails.BankLocationId, "1234567");
            Assert.AreEqual(paymentMethodDetails.EncryptedBankAccountNumber, "1234asdfg");
            Assert.AreEqual(paymentMethodDetails.OwnerName, "John Smith");
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "ACH test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }


        [TestMethod]
        public void TestApplePayPaymentMethod()
        {
            var paymentRequest = new PaymentRequest
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("EUR", 1000),
                Reference = "apple pay test",
                PaymentMethod = new ApplePayDetails
                {
                    ApplePayToken = "VNRWtuNlNEWkRCSm1xWndjMDFFbktkQU..."
                },
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy.."
            };
            var paymentMethodDetails = (ApplePayDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "applepay");
            Assert.AreEqual(paymentMethodDetails.ApplePayToken, "VNRWtuNlNEWkRCSm1xWndjMDFFbktkQU...");
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "apple pay test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }

        [TestMethod]
        public void TestGiropayPaymentMethod()
        {
            var paymentRequest = new PaymentRequest
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("EUR", 1000),
                Reference = "giro pay test",
                PaymentMethod = new GiropayDetails(),
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy.."
            };
            var paymentMethodDetails = (GiropayDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "giropay");
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "giro pay test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }

        [TestMethod]
        public void TestGooglePayPaymentMethod()
        {
            var paymentRequest = new PaymentRequest
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("EUR", 1000),
                Reference = "google pay test",
                PaymentMethod = new GooglePayDetails
                {
                    GooglePayToken = "==Payload as retrieved from Google Pay response==",
                    FundingSource = GooglePayDetails.FundingSourceEnum.Credit
                },
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy.."
            };
            var paymentMethodDetails = (GooglePayDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "paywithgoogle");
            Assert.AreEqual(paymentMethodDetails.GooglePayToken, "==Payload as retrieved from Google Pay response==");
            Assert.AreEqual(paymentMethodDetails.FundingSource, GooglePayDetails.FundingSourceEnum.Credit);
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "google pay test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }

        [TestMethod]
        public void TestIdealPaymentMethod()
        {
            var paymentRequest = new PaymentRequest
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("EUR", 1000),
                Reference = "ideal test",
                PaymentMethod = new IdealDetails
                {
                    Issuer = "1121"
                },
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy.."
            };
            var paymentMethodDetails = (IdealDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "ideal");
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "ideal test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }

        [TestMethod]
        public void TestBacsDirectDebitDetails()
        {
            var paymentRequest = new PaymentRequest
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("GBP", 1000),
                Reference = "bacs direct debit test",
                PaymentMethod = new BacsDirectDebitDetails
                {
                    BankAccountNumber = "NL0123456789",
                    BankLocationId = "121000358",
                    HolderName = "John Smith"
                },
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy.."
            };
            var paymentMethodDetails = (BacsDirectDebitDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "directdebit_GB");
            Assert.AreEqual(paymentMethodDetails.BankAccountNumber, "NL0123456789");
            Assert.AreEqual(paymentMethodDetails.BankLocationId, "121000358");
            Assert.AreEqual(paymentMethodDetails.HolderName, "John Smith");
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "bacs direct debit test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }


        [TestMethod]
        public void TestPaypalSuccess()
        {
            var paymentRequest = new PaymentRequest()
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("USD", 1000),
                Reference = "paypal test",
                PaymentMethod = new PayPalDetails() { Subtype= PayPalDetails.SubtypeEnum.SDK},          
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy.."
            };
            var paymentMethodDetails = (PayPalDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "paypal");
            Assert.AreEqual(paymentMethodDetails.Subtype, PayPalDetails.SubtypeEnum.SDK);
        }
        
        [TestMethod]
        public void TestZipSuccess()
        {
            var paymentRequest = new PaymentRequest()
            {
                MerchantAccount = "YOUR_MERCHANT_ACCOUNT",
                Amount = new Amount("USD", 1000),
                Reference = "zip test",
                PaymentMethod = new ZipDetails()
                {
                    Type = ZipDetails.Zip
                },          
                ReturnUrl = "https://your-company.com/checkout?shopperOrder=12xy..",
            };
            var paymentMethodDetails = (ZipDetails)paymentRequest.PaymentMethod;
            Assert.AreEqual(paymentMethodDetails.Type, "zip");
            Assert.AreEqual(paymentRequest.MerchantAccount, "YOUR_MERCHANT_ACCOUNT");
            Assert.AreEqual(paymentRequest.Reference, "zip test");
            Assert.AreEqual(paymentRequest.ReturnUrl, "https://your-company.com/checkout?shopperOrder=12xy..");
        }
    }
}
