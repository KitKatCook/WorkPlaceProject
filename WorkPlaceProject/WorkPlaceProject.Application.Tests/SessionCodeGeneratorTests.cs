namespace WorkPlaceProject.Application.Tests
{
    public class SessionCodeGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Generate_ReturnsString()
        {
            string result = SessionCodeGenerator.Generate();
            Assert.That(result, Has.Length.EqualTo(8));
        }

        [Test]
        public void Validate_NullValue_ReturnsFalse()
        {
            bool result = SessionCodeGenerator.Validate(null);
            Assert.False(result);
        }

        [TestCase("0")]
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("123")]
        [TestCase("1234")]
        [TestCase("12345")]
        [TestCase("123456")]
        [TestCase("1234567")]
        [TestCase("123456789")]
        [TestCase("1234567890")]
        [TestCase("12345678901")]
        [TestCase("123456789012")]
        [TestCase("1234567890123")]
        [TestCase("12345678901234")]
        [TestCase("123456789012345")]
        [TestCase("1234567890123456")]
        [TestCase("12345678901234567")]
        [TestCase("123456789012345678")]
        [TestCase("1234567890123456789")]
        [TestCase("12345678901234567890")]
        public void Validate_LengthTooLong_ReturnsFalse(string value)
        {
            bool result = SessionCodeGenerator.Validate(value);
            Assert.False(result);
        }

        [TestCase("12345678")]
        [TestCase("ABCDEFGH")]
        public void Validate_ValidValue_ReturnsTrue(string value)
        {
            bool result = SessionCodeGenerator.Validate(value);
            Assert.True(result);
        }
    }
}