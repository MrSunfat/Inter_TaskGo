using Microsoft.Extensions.Configuration;
using MISA.Web06.APIS.Core.Interfaces.Services;
using MISA.Web06.APIS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.APIS.Test.Core.Service
{
    internal class UserServiceTests
    {
        private UserService userService;
        private IConfiguration configuration;

        [SetUp]
        public void Setup()
        {
            userService = new UserService(configuration);
        }

        [Test]
        public void Test1()
        {
            // Arrange

            // Act

            // Assert

            Assert.Pass();
        }
    }
}
