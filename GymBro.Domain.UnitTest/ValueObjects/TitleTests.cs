using GymBro.Domain.Errors;
using GymBro.Domain.ValueObjects;
using Shouldly;

namespace GymBro.Domain.UnitTest.ValueObjects
{
    public sealed class TitleTests
    {
        [Test]
        public void Create_WithTitle_ReturnsTitleObject()
        {
            var validTitle = "HijiBiji";

            var result=Title.Create(validTitle);

            result.IsSuccess.ShouldBe(true);
            result.Value.Value.ShouldBe(validTitle);
        }

        [Test]
        public void Create_WithEmptyTitle_ReturnsFailureResult()
        {
            var emptyTitle = "";

            var result=Title.Create(emptyTitle);

            result.IsFailure.ShouldBeTrue();
            result.Error.ShouldBe(DomainErrors.Title.Empty);

        }

        [Test]
        public void Create_WithNullTitle_ReturnsFailureResult()
        {
            string? emptyTitle = null;

            var result = Title.Create(emptyTitle);

            result.IsFailure.ShouldBeTrue();
            result.Error.ShouldBe(DomainErrors.Title.Empty);

        }

        [Test]
        public void Create_WithLongTitle_ReturnsFailureResult()
        {
            var veryLongTitle = new string('x', Title.MaxLength+1);

            var result=Title.Create(veryLongTitle);

            result.IsFailure.ShouldBeTrue();
            result.Error.ShouldBe(DomainErrors.Title.TooLong);
        }
    }
}
