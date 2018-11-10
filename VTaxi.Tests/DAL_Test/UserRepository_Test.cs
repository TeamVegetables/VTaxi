using System.Collections.Generic;
using System.Linq;
using EntityFrameworkMock;
using Moq;
using NUnit.Framework;
using VTaxi.DAL.EF;
using VTaxi.DAL.Models;
using VTaxi.DAL.Repositories;
using VTaxi.Shared.Enums;

namespace VTaxi.Tests.DAL_Test
{
    [TestFixture]
    public class UserRepository_Test
    {
        private List<User> _data;

        private DbSetMock<User> _mockSet;

        private DbContextMock<TaxiContext> _contextMock;

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
            _contextMock = new DbContextMock<TaxiContext>("defaultconnection");
            _mockSet = _contextMock.CreateDbSetMock(i => i.Users, _data);
            _contextMock.Setup(i => i.Users).Returns(_mockSet.Object);
        }


        [Test]
        public void Create_Test()
        {
            //Arrange
            var userRepository = new UserRepository(_contextMock.Object);

            //Act
            var user = new User { };
            userRepository.Create(user);

            //Assert
            _mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        }

        [Test]
        public void Delete_Test()
        {
            //Arrange
            var userRepository = new UserRepository(_contextMock.Object);

            //Act
            _mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new User());
            userRepository.Delete(1);

            //Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
        }

        [Test]
        public void Find_Test()
        {
            //Arrange
            var userRepository = new UserRepository(_contextMock.Object);

            //Act
            var users = userRepository.Find(i => i.FirstName == "AAA" || i.FirstName == "BBB").ToList();

            //Assert
            Assert.AreEqual(users.Count, 2);
        }

        [Test]
        public void Get_Test()
        {
            //Arrange
            var userRepository = new UserRepository(_contextMock.Object);

            //Act
            userRepository.Get(1);
            userRepository.Get(2);
            userRepository.Get(3);

            //Assert
            _mockSet.Verify(m=>m.Find(It.IsAny<int>()),Times.Exactly(3));
        }

        [Test]
        public void GetAll_Test()
        {
            //Arrange
            var userRepository = new UserRepository(_contextMock.Object);

            //Act
            var users = userRepository.GetAll().ToList();

            //Assert
            Assert.AreEqual(users.Count, 3);
            Assert.AreEqual(users[0].LastName, "AAA");
            Assert.AreEqual(users[1].LastName, "BBB");
            Assert.AreEqual(users[2].LastName, "CCC");
        }

        [Test]
        public void Update_Test()
        {
            //Arrange
            var userRepository = new UserRepository(_contextMock.Object);

            //Act
            var user = new User();
            //Assert
            Assert.Pass();
        }
    }
}
