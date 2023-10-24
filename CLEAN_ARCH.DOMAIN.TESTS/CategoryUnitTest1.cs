using CLEAN_ARCH.DOMAIN.Entities;
using FluentAssertions;

namespace CLEAN_ARCH.DOMAIN.TESTS
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Category With Valid Parameters Id Result Invalid State")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid id value!");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, too short, minimun 3 charecters!");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, name is required!");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CLEAN_ARCH.DOMAIN.Validation.DomainExceptionValidation>();
        }
    }
}