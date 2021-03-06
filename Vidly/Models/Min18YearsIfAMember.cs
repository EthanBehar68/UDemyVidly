﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UDemyVidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // Doesn't work with client-side validation
        // Unless customer jquery is implemented
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            else
            {
                if (customer.BirthDate == null)
                    return new ValidationResult("Birthdate is required.");

                var age = DateTime.Now.Year - customer.BirthDate.Value.Year; // more complicated then this but not the focus

                return (age >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Customer needs to be 18 years old to create a subscription membership.");
            }
        }
    }
}