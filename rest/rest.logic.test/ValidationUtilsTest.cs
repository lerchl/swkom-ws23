using Rest.Logic.Validation;

namespace TourPlanner.Test {

    internal class ValidationUtilsTest {

        [Test]
        public void TestValidateRequiredPositive() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateRequired(null, "test", result);

            // Assert
            Assert.That(result.Messages, Has.Count.EqualTo(1));

            Assert.Multiple(() => {
                Assert.That(result.Messages[0].Status, Is.EqualTo(ValidationMessageStatus.Error));
                Assert.That(result.Messages[0].Message, Is.EqualTo("test is required"));
            });
        }

        [Test]
        public void TestValidateRequiredNegative() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateRequired("test", "test", result);

            // Assert
            Assert.That(result.Messages, Is.Empty);
        }

        [Test]
        public void TestValidateMinLengthPositive() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateMinLength("test", 5, "test", result);

            // Assert
            Assert.That(result.Messages, Has.Count.EqualTo(1));

            Assert.Multiple(() => {
                Assert.That(result.Messages[0].Status, Is.EqualTo(ValidationMessageStatus.Error));
                Assert.That(result.Messages[0].Message, Is.EqualTo("test is too short (min. 5 characters)"));
            });
        }

        [Test]
        public void TestValidateMinLengthNegative() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateMinLength("test", 3, "test", result);

            // Assert
            Assert.That(result.Messages, Is.Empty);
        }

        [Test]
        public void TestValidateMaxLengthPositive() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateMaxLength("test", 3, "test", result);

            // Assert
            Assert.That(result.Messages, Has.Count.EqualTo(1));

            Assert.Multiple(() => {
                Assert.That(result.Messages[0].Status, Is.EqualTo(ValidationMessageStatus.Error));
                Assert.That(result.Messages[0].Message, Is.EqualTo("test is too long (max. 3 characters)"));
            });
        }

        [Test]
        public void TestValidateMaxLenghtNegative() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateMaxLength("test", 5, "test", result);

            // Assert
            Assert.That(result.Messages, Is.Empty);
        }

        [Test]
        public void TestValidateMinValuePositive() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateMinValue(1, 2, "test", result);

            // Assert
            Assert.That(result.Messages, Has.Count.EqualTo(1));

            Assert.Multiple(() => {
                Assert.That(result.Messages[0].Status, Is.EqualTo(ValidationMessageStatus.Error));
                Assert.That(result.Messages[0].Message, Is.EqualTo("test is too small (min. 2)"));
            });
        }

        [Test]
        public void TestValidateMinValueNegative() {
            // Arrange
            var result = new ValidationResult();

            // Act
            ValidationUtils.ValidateMinValue(2, 1, "test", result);

            // Assert
            Assert.That(result.Messages, Is.Empty);
        }
    }
}
