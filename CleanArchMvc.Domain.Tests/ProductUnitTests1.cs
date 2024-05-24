using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTests1
    {
        [Fact(DisplayName = "Create Product With Valid Paramteres Result Object Valid State")]
        public void CreateProduct_WithValidParamteres_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Short Name Value Result DomainExceptionValidation")]
        public void CreateProduct_WithShortNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Pr", "Product Descrition", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Null Name Value Result DomainExceptionValidation")]
        public void CreateProduct_WithNullNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(null, "Product Descrition", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Empty Name Value Result DomainExceptionValidation")]
        public void CreateProduct_WithEmptyNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(string.Empty, "Product Descrition", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Short Description Value Result DomainExceptionValidation")]
        public void CreateProduct_WithShortDescriptionValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Product Name", "Pr", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Null Description Value Result DomainExceptionValidation")]
        public void CreateProduct_WithNullDescriptionValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Product Name", null, 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Empty Description Value Result DomainExceptionValidation")]
        public void CreateProduct_WithEmptyDescriptionValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Product Name", string.Empty, 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Negative Price Value Result DomainExceptionValidation")]
        public void CreateProduct_WithNegativePriceValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Product Name", "Product Descrition", -9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Negative Stock Value Result DomainExceptionValidation")]
        public void CreateProduct_WithNegativeStockValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Product Name", "Product Descrition", 9.99m, -99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Long Image Value Result DomainExceptionValidation")]
        public void CreateProduct_WithLongImageValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image".PadLeft(251, 'A'));
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. Too long,  maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image Value No Result NullReferenceExeption")]
        public void CreateProduct_WithNullImageValue_NoResultNullReferenceExeption()
        {
            Action action = () => new Product("Product Name", "Product Descrition", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }


        public void UpdateProduct_WithValidParamteres_ResultObjectValidState()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", "Product Descrition", 9.99m, 99, "Product Image", 1);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Product With Short Name Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithShortNameValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Pr", "Product Descrition", 9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Update Product With Null Name Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithNullNameValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update(null, "Product Descrition", 9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Update Product With Empty Name Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithEmptyNameValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update(string.Empty, "Product Descrition", 9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Update Product With Short Description Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithShortDescriptionValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", "Pr", 9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Update Product With Null Description Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithNullDescriptionValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", null, 9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Update Product With Empty Description Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithEmptyDescriptionValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", string.Empty, 9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Update Product With Negative Price Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithNegativePriceValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", "Product Descrition", -9.99m, 99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Update Product With Negative Stock Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithNegativeStockValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", "Product Descrition", 9.99m, -99, "Product Image", 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Update Product With Long Image Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithLongImageValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", "Product Descrition", 9.99m, 99, "Product Image".PadLeft(251, 'A'), 1);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. Too long,  maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Id Value Result DomainExceptionValidation")]
        public void CreateProduct_WithInvalidIdValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(-1, "Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Update Product With Invalid Id Value Result DomainExceptionValidation")]
        public void UpdateProduct_WithInvalidIdValue_ResultDomainExceptionValidation()
        {
            var product = new Product("Product Name", "Product Descrition", 9.99m, 99, "Product Image");
            Action action = () => product.Update("Product Name", "Product Descrition", 9.99m, 99, "Product Image", 1);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
