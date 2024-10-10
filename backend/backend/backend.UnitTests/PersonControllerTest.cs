using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using backend;
using backend.Services;


namespace backend.UnitTests
{
    [TestClass]
    public class PersonControllerTest
    {
        private readonly Mock<PersonController> _mockAddressService;
        private readonly PersonController _controllerPerson;
        [TestMethod]
        public void ReturnFromControllerGetAllPerson()
        {
            _mockAddressService = new Mock<AddressService>();
            var personController = new PersonController();
        }
    }
}
