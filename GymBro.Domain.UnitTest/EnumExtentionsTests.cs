using GymBro.Abstractions.Helpers;
using Shouldly;
using System.Runtime.Serialization;

namespace GymBro.Domain.UnitTest
{
    public sealed class EnumExtentionsTests
    {
        public enum TestEnum
        {
            [EnumMember(Value = "A")]
            Alpha,

            [System.ComponentModel.Description("O")]
            Omega
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldSerialize_FromEnumAttribute()
        {
            var result = TestEnum.Alpha.ToStringByAttributes();
            Assert.That(result,Is.EqualTo("A"));
        }

        [Test]
        public void ShouldSerialize_FromDescriptionAttribute()
        {
            var result = TestEnum.Omega.ToStringByAttributes();
            result.ShouldBe("O");
        }
        [Test]
        public void ShouldDeserialize_FromDescriptionAttribute()
        {
            var result = "O".ToEnumByAttributes<TestEnum>();
            result.ShouldBe(TestEnum.Omega);
        }

        [Test]
        public void ShouldDeserialize_FromPropertyName()
        {
            var result = "Alpha".ToEnumByAttributes<TestEnum>();
            result.ShouldBe(TestEnum.Alpha);
        }
    }
}