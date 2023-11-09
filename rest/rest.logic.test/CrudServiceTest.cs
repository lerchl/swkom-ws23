using Moq;
using Rest.Dal;
using Rest.Logic.Service;
using Rest.Logic.Validation;
using Rest.Model;

namespace TourPlanner.Test {

    internal class CrudServiceTest {

        [Test]
        public void TestGetAll() {
            // Arrange
            var document1 = new Document();
            var document2 = new Document();
            var list = new List<Entity>() { document1, document2 };

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.GetAll()).Returns(list);

            var mockValidator = new Mock<IValidator<Entity>>();
            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result, Has.Member(document1));
            Assert.That(result, Has.Member(document2));
        }

        [Test]
        public void TestGetByIdExists() {
            // Arrange
            var document = new Document() { Id = 100L };

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.GetById(document.Id)).Returns(document);

            var mockValidator = new Mock<IValidator<Entity>>();
            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            var result = service.GetById(document.GetId());

            // Assert
            Assert.That(result, Is.EqualTo(document));
        }

        [Test]
        public void TestGetByIdDoesNotExist() {
            // Arrange
            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns((Entity?) null);

            var mockValidator = new Mock<IValidator<Entity>>();
            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            var result = service.GetById(100L);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestAddValid() {
            // Arrange
            var document = new Document();

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.Add(document)).Returns(document);

            var mockValidator = new Mock<IValidator<Entity>>();
            mockValidator.Setup(x => x.ValidateSave(document)).Returns(new ValidationResult());

            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            var result = service.Add(document);

            // Assert
            Assert.That(result, Is.EqualTo(document));
        }

        [Test]
        public void TestAddInvalid() {
            // Arrange
            var document = new Document();
            var validationResult = new ValidationResult();
            validationResult.AddMessage(new ValidationMessage(ValidationMessageStatus.Error, ""));

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.Add(document)).Returns(document);

            var mockValidator = new Mock<IValidator<Entity>>();
            mockValidator.Setup(x => x.ValidateSave(document)).Returns(validationResult);

            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            // Assert
            Assert.Throws<ValidationException>(() => service.Add(document));
        }

        [Test]
        public void TestUpdateValid() {
            // Arrange
            var document = new Document();

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.Update(document)).Returns(document);

            var mockValidator = new Mock<IValidator<Entity>>();
            mockValidator.Setup(x => x.ValidateSave(document)).Returns(new ValidationResult());

            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            var result = service.Update(document);

            // Assert
            Assert.That(result, Is.EqualTo(document));
        }

        [Test]
        public void TestUpdateInvalid() {
            // Arrange
            var document = new Document();
            var validationResult = new ValidationResult();
            validationResult.AddMessage(new ValidationMessage(ValidationMessageStatus.Error, ""));

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.Update(document)).Returns(document);

            var mockValidator = new Mock<IValidator<Entity>>();
            mockValidator.Setup(x => x.ValidateSave(document)).Returns(validationResult);

            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            // Assert
            Assert.Throws<ValidationException>(() => service.Update(document));
        }

        [Test]
        public void TestRemove() {
            // Arrange
            var document = new Document();

            var mockRepository = new Mock<ICrudRepository<Entity>>();
            mockRepository.Setup(x => x.Remove(document));

            var mockValidator = new Mock<IValidator<Entity>>();
            var service = new CrudService<Entity, ICrudRepository<Entity>, IValidator<Entity>>(mockRepository.Object, mockValidator.Object);

            // Act
            service.Remove(document);

            // Assert
            mockRepository.Verify(x => x.Remove(document), Times.Once);
        }
    }
}
