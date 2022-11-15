using CoreServices.Dtos.Client;
using CoreServices.Dtos.Supplier;
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
    public class CreateSupplierDtoTests
    {
        [Test]
        public void ShouldHaveError_WhenNameIsMissing()
        {
            var createSupplierDto = new CreateSupplierDto
            {
                IsVATApplicable = true,
            };

            var validationResults = ValidateModel(createSupplierDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("Name") &&
                    v.ErrorMessage.Contains("Supplier name cannot be empty")));
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
