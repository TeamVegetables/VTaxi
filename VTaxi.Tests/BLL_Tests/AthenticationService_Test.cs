using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Services;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;
using VTaxi.Shared.Enums;

namespace VTaxi.Tests.BLL_Tests
{
    [TestFixture]
    public class UserRepository_Test
    {
        private List<User> _data;

        private Mock<IUnitOfWork> _mockUoW;

        private Mock<IRepository<User>> _mockRepo;
        
        [SetUp]
        public virtual void Setup()
        {
            _data = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "AAA",
                    LastName = "AAA",
                    SuccessfulTrips = 1,
                    Type = UserType.Driver,
                    Password = "test",
                    Email = "aaa@test.com"
                },
                new User
                {
                    Id = 2,
                    FirstName = "BBB",
                    LastName = "BBB",
                    SuccessfulTrips = 1,
                    Type = UserType.Driver,
                    Password = "test",
                    Email = "bbb@test.com"
                },
                new User
                {
                    Id = 3,
                    FirstName = "CCC",
                    LastName = "CCC",
                    SuccessfulTrips = 1,
                    Type = UserType.Driver,
                    Password = "test",
                    Email = "ccc@test.com"
                }
            };
            _mockUoW = new Mock<IUnitOfWork>();
            _mockRepo = new Mock<IRepository<User>>();
        }


        [Test]
        public void LogIn_SuccessfullyTest()
        {
            //Arrange
            var authenticationService = new AuthenticationService(_mockUoW.Object);
            _mockRepo.Setup(i => i.Find(It.IsAny<Func<User, bool>>())).Returns(_data);
            _mockUoW.Setup(i => i.Users).Returns(_mockRepo.Object);

            //Act
            var user = _data.FirstOrDefault();
            authenticationService.LogIn(new UserDto());

            //Assert
            Assert.AreEqual(AuthenticationService.CurrentUser.FirstName, user.FirstName);
            Assert.AreEqual(AuthenticationService.CurrentUser.LastName, user.LastName);
            Assert.AreEqual(AuthenticationService.CurrentUser.Email, user.Email);
            Assert.AreEqual(AuthenticationService.CurrentUser.Password, user.Password);
            Assert.AreEqual(AuthenticationService.CurrentUser.Type, user.Type);
            Assert.AreEqual(AuthenticationService.CurrentUser.SuccessfulTrips, user.SuccessfulTrips);
            _mockRepo.Verify(i=>i.Find(It.IsAny<Func<User, bool>>()), Times.Once);
        }

        [Test]
        public void LogIn_NotFoundUserTest()
        {
            //Arrange
            var authenticationService = new AuthenticationService(_mockUoW.Object);
            _mockUoW.Setup(i => i.Users).Returns(_mockRepo.Object);
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => authenticationService.LogIn(new UserDto()));
        }

        [Test]
        public void Register_SuccessfullyTest()
        {
            //Arrange
            var authenticationService = new AuthenticationService(_mockUoW.Object);
            _mockUoW.Setup(i => i.Users).Returns(_mockRepo.Object);
            var tmp = _data.First();
            var user = new UserDto
            {
                Id = tmp.Id,
                FirstName = tmp.FirstName,
                LastName = tmp.LastName,
                Email = tmp.Email,
                Password = tmp.Password,
                Type = tmp.Type,
                SuccessfulTrips = tmp.SuccessfulTrips
            };

            //Act
            authenticationService.Register(user);

            //Assert
            Assert.AreEqual(AuthenticationService.CurrentUser.FirstName, user.FirstName);
            Assert.AreEqual(AuthenticationService.CurrentUser.LastName, user.LastName);
            Assert.AreEqual(AuthenticationService.CurrentUser.Email, user.Email);
            Assert.AreEqual(AuthenticationService.CurrentUser.Password, user.Password);
            Assert.AreEqual(AuthenticationService.CurrentUser.Type, user.Type);
            _mockRepo.Verify(i => i.Find(It.IsAny<Func<User, bool>>()), Times.Once);
            _mockRepo.Verify(i => i.Create(It.IsAny<User>()), Times.Once);
            _mockUoW.Verify(i=>i.Save(), Times.Once);
        }

        [Test]
        public void Register_FailedTest()
        {
            //Arrange
            var authenticationService = new AuthenticationService(_mockUoW.Object);
            _mockRepo.Setup(i => i.Find(It.IsAny<Func<User, bool>>())).Returns(_data);
            _mockUoW.Setup(i => i.Users).Returns(_mockRepo.Object);
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => authenticationService.Register(new UserDto()));
        }

        [Test]
        public void Dispose_Test()
        {
            //Arrange
            var authenticationService = new AuthenticationService(_mockUoW.Object);
            //Act
            authenticationService.Dispose();
            //Assert
            _mockUoW.Verify(i=> i.Dispose(), Times.Once);
        }
    }
}
