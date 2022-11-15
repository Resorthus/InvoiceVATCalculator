using CoreServices.Dtos.Country;
using CoreServices.Dtos.Invoice;
using DomainModels.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Dtos
{
    [TestFixture]
    public class CreateCountryDtoTests
    {
        [Test]
        public void ShouldHaveError_WhenNameIsMissing()
        {
            var createCountryDto = new CreateCountryDto
            {
                VatPercentage = 50,
                Continent = 0,

            };

            var validationResults = ValidateModel(createCountryDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("Name") &&
                    v.ErrorMessage.Contains("Country name cannot be empty")));
        }

        [Test]
        public void ShouldHaveError_WhenIncorrectContinentEnum()
        {
            var createCountryDto = new CreateCountryDto
            {
                VatPercentage = 50,
                Continent = (Continent)10,
                Name = "Lithuania",

            };

            var validationResults = ValidateModel(createCountryDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("Continent") &&
                    v.ErrorMessage.Contains("Continent value must be a legit continent")));
        }

        [Test]
        public void ShouldHaveError_WhenVATPercentageIsNegative()
        {
            var createCountryDto = new CreateCountryDto
            {
                VatPercentage = -50,
                Continent = 0,
                Name = "Lithuania",

            };

            var validationResults = ValidateModel(createCountryDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("VatPercentage") &&
                    v.ErrorMessage.Contains("Please enter a value between 0 and 100")));
        }


        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
