using CoreServices.Dtos.Client;
using CoreServices.Dtos.Country;
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
    public class CreateClientDtoTests
    {
        [Test]
        public void ShouldHaveError_WhenNameIsMissing()
        {
            var createClientDto = new CreateClientDto
            {
                IsVATApplicable = false,
            };

            var validationResults = ValidateModel(createClientDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("Name") &&
                    v.ErrorMessage.Contains("Client name cannot be empty")));
        }

        [Test]
        public void ShouldHaveError_WhenClientTypeIsIncorrectEnum()
        {
            var createClientDto = new CreateClientDto
            {
                IsVATApplicable = false,
                Name = "Antanas",
                Type = (PersonType)100,
            };

            var validationResults = ValidateModel(createClientDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("Type") &&
                    v.ErrorMessage.Contains("Client type value must be a legit client type")));
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
