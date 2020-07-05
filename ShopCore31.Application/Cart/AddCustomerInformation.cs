﻿using ShopCore31.Domain.Infrastructure;
using ShopCore31.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopCore31.Application.Cart
{
    public class AddCustomerInformation
    {
        private readonly ISessionManager _sessionManager;

        public AddCustomerInformation(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public class Request
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            [Required]
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string ZipCode { get; set; }
        }

        public void Do(Request request)
        {
            _sessionManager.AddCustomerInformation(new CustomerInformation 
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                ZipCode = request.ZipCode,
            });

        }
    }
}