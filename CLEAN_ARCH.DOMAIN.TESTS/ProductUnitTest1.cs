using CLEAN_ARCH.DOMAIN.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using FluentAssertions;

namespace CLEAN_ARCH.DOMAIN.TESTS
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Description", 99.99m, 99, "Image");
            action.Should()
                .NotThrow<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Product With Valid Parameters Id Result Invalid State")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Description", 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid id value!");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Description", 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, too short, minimun 3 charecters!");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Description", 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, name is requered!");
        }

        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Description", 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description, description is requered!");
        }

        [Fact]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description, too short, minimun 5 charecters!");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(1, "Product Name", "Description", -99.99m, 99, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value!");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Description", 99.99m, value, "Image");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid stock value!");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImage()
        {
            Action action = () => new Product(1, "Product Name", "Description", 99.99m, 99, "Imageeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid image, too long, maximun 250 charecters!");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_DomainExceptionNullImage()
        {
            Action action = () => new Product(1, "Product Name", "Description", 99.99m, 99, null);
            action.Should()
                .NotThrow<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Description", 99.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}