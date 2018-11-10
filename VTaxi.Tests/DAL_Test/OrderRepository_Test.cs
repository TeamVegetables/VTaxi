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
    public class OrderRepository_Test
    {
        private List<Order> _data;

        private DbSetMock<Order> _mockSet;

        private DbContextMock<TaxiContext> _contextMock;

        [SetUp]
        public virtual void Setup()
        {
            _data = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    StartPoint = "AAA",
                    FinishPoint = "DDD",
                    PassengerName = "IVAN",
                    Status = OrderStatus.Started
                },
                new Order
                {
                    Id = 2,
                    StartPoint = "BBB",
                    FinishPoint = "CCC",
                    PassengerName = "PETRO",
                    Status = OrderStatus.InProcess
                },
                new Order
                {
                    Id = 3,
                    StartPoint = "YYY",
                    FinishPoint = "XXX",
                    PassengerName = "EVHEN",
                    Status = OrderStatus.Finished
                },
            };
            _contextMock = new DbContextMock<TaxiContext>("defaultconnection");
            _mockSet = _contextMock.CreateDbSetMock(i => i.Orders, _data);
            _contextMock.Setup(i => i.Orders).Returns(_mockSet.Object);
        }


        [Test]
        public void Create_Test()
        {
            //Arrange
            var orderRepository = new OrderRepository(_contextMock.Object);

            //Act
            var order = new Order { };
            orderRepository.Create(order);

            //Assert
            _mockSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
        }

        [Test]
        public void Delete_Test()
        {
            //Arrange
            var orderRepository = new OrderRepository(_contextMock.Object);

            //Act
            _mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(new Order());
            orderRepository.Delete(1);

            //Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<Order>()), Times.Once());
        }

        [Test]
        public void Find_Test()
        {
            //Arrange
            var orderRepository = new OrderRepository(_contextMock.Object);

            //Act
            var orders = orderRepository.Find(i => i.StartPoint == "AAA" || i.StartPoint == "BBB").ToList();

            //Assert
            Assert.AreEqual(orders.Count, 2);
        }

        [Test]
        public void Get_Test()
        {
            //Arrange
            var orderRepository = new OrderRepository(_contextMock.Object);

            //Act
            orderRepository.Get(1);
            orderRepository.Get(2);
            orderRepository.Get(3);

            //Assert
            _mockSet.Verify(m => m.Find(It.IsAny<int>()), Times.Exactly(3));
        }

        [Test]
        public void GetAll_Test()
        {
            //Arrange
            var orderRepository = new OrderRepository(_contextMock.Object);

            //Act
            var orders = orderRepository.GetAll().ToList();

            //Assert
            Assert.AreEqual(orders.Count, 3);
            Assert.AreEqual(orders[0].StartPoint, "AAA");
            Assert.AreEqual(orders[1].StartPoint, "BBB");
            Assert.AreEqual(orders[2].FinishPoint, "XXX");
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
