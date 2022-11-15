using CoreServices.Dtos.Invoice;
using CoreServices.Services;
using DomainModels.Entities;
using DomainModels.Enums;
using NSubstitute;
using NUnit.Framework;
using OutsideInfrastructure.Interfaces;

namespace Tests.Services
{
    [TestFixture]
    public class InvoiceServiceTests
    {
        [Test]
        public async Task ProduceInvoice_ShouldNotApplyVAT_WhenSupplierIsNotVATApplicable()
        {
            //Arrange:

            var repository = Substitute.For<IRepository>();

            var testClient = new Client
            {
                IsVATApplicable = true,
                CountryId = 1,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Europe,
                },
            };

            var testSupplier = new Supplier
            {
                IsVATApplicable = false,
                CountryId = 1,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Europe,
                },
            };

            var createInvoiceDto = new CreateInvoiceDto
            {
                ClientId = 1,
                SupplierId = 2,
                TransactionPrice = 100,
            };

            repository.GetByIdAsync<Client>(createInvoiceDto.ClientId).Returns(testClient);
            repository.GetByIdAsync<Supplier>(createInvoiceDto.SupplierId).Returns(testSupplier);


            var mapper = new EntityMapper();
            var invoiceService = new InvoiceService(repository, mapper);

            var expectedInvoicePrice = createInvoiceDto.TransactionPrice;

            // Act:
            var actualInvoice = await invoiceService.CreateInvoice(createInvoiceDto);

            // Assert
            Assert.That(actualInvoice.FinalPrice, Is.EqualTo(expectedInvoicePrice));
        }

        [Test]
        public async Task ProduceInvoice_ShouldNotApplyVAT_WhenClientLivesOutsideEU()
        {
            //Arrange:

            var repository = Substitute.For<IRepository>();

            var testClient = new Client
            {
                IsVATApplicable = true,
                CountryId = 2,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Africa,
                },
            };

            var testSupplier = new Supplier
            {
                IsVATApplicable = true,
                CountryId = 1,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Europe,
                },
            };

            var createInvoiceDto = new CreateInvoiceDto
            {
                ClientId = 1,
                SupplierId = 2,
                TransactionPrice = 100,
            };

            repository.GetByIdAsync<Client>(createInvoiceDto.ClientId).Returns(testClient);
            repository.GetByIdAsync<Supplier>(createInvoiceDto.SupplierId).Returns(testSupplier);


            var mapper = new EntityMapper();
            var invoiceService = new InvoiceService(repository, mapper);

            var expectedInvoicePrice = createInvoiceDto.TransactionPrice;

            // Act:
            var actualInvoice = await invoiceService.CreateInvoice(createInvoiceDto);

            // Assert
            Assert.That(actualInvoice.FinalPrice, Is.EqualTo(expectedInvoicePrice));
        }

        [Test]
        public async Task ProduceInvoice_ShouldApplyVAT_WhenClientLivesInEU_IsNotVATAplicable_LivesInDifferentCountryThanSupplier()
        {
            //Arrange:

            var repository = Substitute.For<IRepository>();

            var testClient = new Client
            {
                IsVATApplicable = false,
                CountryId = 2,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Europe,
                },
            };

            var testSupplier = new Supplier
            {
                IsVATApplicable = true,
                CountryId = 1,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Africa,
                },
            };

            var createInvoiceDto = new CreateInvoiceDto
            {
                ClientId = 1,
                SupplierId = 2,
                TransactionPrice = 100,
            };

            repository.GetByIdAsync<Client>(createInvoiceDto.ClientId).Returns(testClient);
            repository.GetByIdAsync<Supplier>(createInvoiceDto.SupplierId).Returns(testSupplier);


            var mapper = new EntityMapper();
            var invoiceService = new InvoiceService(repository, mapper);

            var expectedInvoicePrice = createInvoiceDto.TransactionPrice * (1 + (testClient.Country.VatPercentage / 100));

            // Act:
            var actualInvoice = await invoiceService.CreateInvoice(createInvoiceDto);

            // Assert
            Assert.That(actualInvoice.FinalPrice, Is.EqualTo(expectedInvoicePrice));
        }

        [Test]
        public async Task ProduceInvoice_ShouldNotApplyVAT_WhenClientLivesInEU_IsVATAplicable_LivesInDifferentCountryThanSupplier()
        {
            //Arrange:

            var repository = Substitute.For<IRepository>();

            var testClient = new Client
            {
                IsVATApplicable = true,
                CountryId = 2,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Europe,
                },
            };

            var testSupplier = new Supplier
            {
                IsVATApplicable = true,
                CountryId = 1,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Africa,
                },
            };

            var createInvoiceDto = new CreateInvoiceDto
            {
                ClientId = 1,
                SupplierId = 2,
                TransactionPrice = 100,
            };

            repository.GetByIdAsync<Client>(createInvoiceDto.ClientId).Returns(testClient);
            repository.GetByIdAsync<Supplier>(createInvoiceDto.SupplierId).Returns(testSupplier);


            var mapper = new EntityMapper();
            var invoiceService = new InvoiceService(repository, mapper);

            var expectedInvoicePrice = createInvoiceDto.TransactionPrice;

            // Act:
            var actualInvoice = await invoiceService.CreateInvoice(createInvoiceDto);

            // Assert
            Assert.That(actualInvoice.FinalPrice, Is.EqualTo(expectedInvoicePrice));
        }

        [Test]
        public async Task ProduceInvoice_ShouldApplyVAT_WhenClientLivesInEU_IsVATAplicable_LivesInSameCountryAsSupplier()
        {
            //Arrange:

            var repository = Substitute.For<IRepository>();

            var testClient = new Client
            {
                IsVATApplicable = true,
                CountryId = 2,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Europe,
                },
            };

            var testSupplier = new Supplier
            {
                IsVATApplicable = true,
                CountryId = 2,
                Country = new Country
                {
                    VatPercentage = 10,
                    Continent = Continent.Africa,
                },
            };

            var createInvoiceDto = new CreateInvoiceDto
            {
                ClientId = 1,
                SupplierId = 2,
                TransactionPrice = 100,
            };

            repository.GetByIdAsync<Client>(createInvoiceDto.ClientId).Returns(testClient);
            repository.GetByIdAsync<Supplier>(createInvoiceDto.SupplierId).Returns(testSupplier);


            var mapper = new EntityMapper();
            var invoiceService = new InvoiceService(repository, mapper);

            var expectedInvoicePrice = createInvoiceDto.TransactionPrice * (1 + (testClient.Country.VatPercentage / 100));

            // Act:
            var actualInvoice = await invoiceService.CreateInvoice(createInvoiceDto);

            // Assert
            Assert.That(actualInvoice.FinalPrice, Is.EqualTo(expectedInvoicePrice));
        }
    }
}
