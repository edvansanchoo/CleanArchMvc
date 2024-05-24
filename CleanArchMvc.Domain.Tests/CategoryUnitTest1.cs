using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid Paramteres Result Object Valid State")]
        public void CreateCategory_WithValidParamteres_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid Id Value Result DomainExceptionValidation")]
        public void CreateCategory_WithInvalidIdValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Short Name Value Result DomainExceptionValidation")]
        public void CreateCategory_WithShortNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With Null Name Value Result DomainExceptionValidation")]
        public void CreateCategory_WithNullNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Empty Name Value Result DomainExceptionValidation")]
        public void CreateCategory_WithEmptyNameValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Category(1, string.Empty);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Update Category With Valid Paramteres Result Object Valid State")]
        public void UpdateCategory_WithValidParamteres_ResultObjectValidState()
        {
            var category = new Category(1, "Category Name");
            Action action = () => category.Update("Category Name Updated");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Category With Short Name Value Result DomainExceptionValidation")]
        public void UpdateCategory_WithShortNameValue_ResultDomainExceptionValidation()
        {
            var category = new Category(1, "Category Name");
            Action action = () => category.Update("Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Update Category With Null Name Value Result DomainExceptionValidation")]
        public void UpdateCategory_WithNullNameValue_ResultDomainExceptionValidation()
        {
            var category = new Category(1, "Category Name");
            Action action = () => category.Update(null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Update Category With Empty Name Value Result DomainExceptionValidation")]
        public void UpdateCategory_WithEmptyNameValue_ResultDomainExceptionValidation()
        {
            var category = new Category(1, "Category Name");
            Action action = () => category.Update(string.Empty);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }



    }
}