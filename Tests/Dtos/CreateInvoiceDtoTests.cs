using CoreServices.Dtos.Invoice;
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
    public class CreateInvoiceDtoTests
    {
        [Test]
        public void ShouldHaveError_WhenTransactionPriceIsNegative()
        {
            var createInvoiceDto = new CreateInvoiceDto
            {
                ClientId = 1,
                SupplierId = 2,
                TransactionPrice = -1,
            };

            var validationResults = ValidateModel(createInvoiceDto);

            Assert.IsTrue(validationResults.Any(
                v => v.MemberNames.Contains("TransactionPrice") &&
                    v.ErrorMessage.Contains("Please enter a value bigger than 0")));
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
