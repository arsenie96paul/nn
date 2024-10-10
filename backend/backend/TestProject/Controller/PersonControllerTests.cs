using System;
using Moq; 
using backend.Models; 
using backend.Controllers; 
using backend.Services;
using Microsoft.EntityFrameworkCore;
using backend.Database;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controller
{
    public class PersonControllerTests
    {
        private readonly Mock<IDbContextFactory<BackendDbContext>> _contextFactoryMock; 
        private readonly Mock<PersonService> _personServiceMock; 
        private readonly PersonController _controller;

        public PersonControllerTests()
        {
            // Create a mock of IDbContextFactory
            _contextFactoryMock = new Mock<IDbContextFactory<BackendDbContext>>();
            _personServiceMock = new Mock<PersonService>(_contextFactoryMock.Object); 
            _controller = new PersonController(_personServiceMock.Object);
        }

        [Fact]
        public void PersonController_GetAll_ReturnPersonList()
        {
            // Setup Expected Answer
            var expectedPersons = new List<Person>
            {
                new Person { PersonId = 1, Name = "John Doe" },
                new Person { PersonId = 2, Name = "Jane Smith" }
            };

            _personServiceMock.Setup(service => service.GetAllPeople()).Returns(expectedPersons);

            // Action
            var result = _controller.GetAll();

            // Asserts
            Assert.NotNull(result);

            var actionResult = Assert.IsType<ActionResult<List<Person>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualPersons = Assert.IsType<List<Person>>(okResult.Value);

            Assert.Equal(expectedPersons.Count, actualPersons.Count);
            Assert.Equal(expectedPersons[0].Name, actualPersons[0].Name);
            Assert.Equal(expectedPersons[1].Name, actualPersons[1].Name);
        }
    }
}
