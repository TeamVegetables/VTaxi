using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Moq;
using NUnit.Framework;
using VTaxi.BLL.Services;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;
using VTaxi.Shared.Enums;

namespace VTaxi.Tests.BLL_Tests
{
    [TestFixture]
    public class OrderService_Test
    {
        private List<Order> _data;

        private Mock<IUnitOfWork> _mockUoW;
        
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
            _mockUoW= new Mock<IUnitOfWork>();
        }


        [Test]
        public void StartTrip_NotFountOrderTest()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            //Act
            var mockRepo = new Mock<IRepository<Order>>();
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Assert
            Assert.Throws<InvalidOperationException>(() => orderService.StartTrip(0));
        }

        [Test]
        public void StartTrip_SuccessfullyTest()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            var mockRepo = new Mock<IRepository<Order>>();
            mockRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(new Order());
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Act
            orderService.StartTrip(0);
            //Assert
            mockRepo.Verify(i=>i.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void FinishTrip_NotFountOrderTest()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            //Act
            var mockRepo = new Mock<IRepository<Order>>();
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Assert
            Assert.Throws<InvalidOperationException>(() => orderService.FinishTrip(0, 0, 0));
        }

        [Test]
        public void FinishTrip_SuccessfullyTest()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            var mockRepo = new Mock<IRepository<Order>>();
            mockRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(new Order());
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Act
            orderService.StartTrip(0);
            //Assert
            mockRepo.Verify(i => i.Get(It.IsAny<int>()), Times.Once);
            mockRepo.Verify(i => i.Update(It.IsAny<Order>()), Times.Once);
        }

        [Test]
        public void GetAll_Test()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            var mockRepo = new Mock<IRepository<Order>>();
            mockRepo.Setup(i => i.GetAll()).Returns(_data);
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Act

            var orders = orderService.GetAll();

            //Assert
            mockRepo.Verify(i => i.GetAll(), Times.Once);
            Assert.AreEqual(orders.Count(), 3);
        }

        [Test]
        public void Get_NotFoundOrderTest()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            var mockRepo = new Mock<IRepository<Order>>();
            mockRepo.Setup(i => i.Get(It.IsAny<int>()));
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Act

            //Assert
            Assert.Throws<ValidationException>(() => orderService.Get(0));
        }

        [Test]
        public void Get_SuccessfullyTest()
        {
            //Arrange
            var orderService = new OrderService(_mockUoW.Object);
            var mockRepo = new Mock<IRepository<Order>>();
            var order = new Order
            {
                StartPoint = "AAA",
                FinishPoint = "BBB"
            };
            mockRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(order);
            _mockUoW.Setup(i => i.Orders).Returns(mockRepo.Object);
            //Act
            var result = orderService.Get(1);
            //Assert
            Assert.AreEqual(order.StartPoint, result.StartPoint);
            Assert.AreEqual(order.FinishPoint, result.FinishPoint);
        }
    }
}
