using System;
using System.Collections.Generic;
using IteratorDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IteratorDemoTests
{
    [TestClass]
    public class UnitTest1
    {
        private List<IPainter> painters;
        Mock<IPainter> cheapest;

        [TestInitialize]
        public void TestSetup()
        {

            var painter1 = new Mock<IPainter>();
            painter1.SetupAllProperties();
            painter1.Object.IsAvailable = true;
            painter1.Setup(p => p.EstimateCompensation(10)).Returns(1199);

            var painter2 = new Mock<IPainter>();
            painter2.SetupAllProperties();
            painter2.Object.IsAvailable = true;
            painter2.Setup(p => p.EstimateCompensation(10)).Returns(101);


            var painter3 = new Mock<IPainter>();
            painter3.SetupAllProperties();
            painter3.Object.IsAvailable = true;
            painter3.Setup(p => p.EstimateCompensation(10)).Returns(50);


            var painter4 = new Mock<IPainter>();
            painter4.SetupAllProperties();
            painter4.Object.IsAvailable = true;
            painter4.Setup(p => p.EstimateCompensation(10)).Returns(25);


            var painter5 = new Mock<IPainter>();
            painter5.SetupAllProperties();
            painter5.Object.IsAvailable = true;
            painter5.Setup(p => p.EstimateCompensation(10)).Returns(33);

            cheapest = new Mock<IPainter>();
            cheapest.SetupAllProperties();
            cheapest.Object.IsAvailable = true;
            cheapest.Setup(p => p.EstimateCompensation(10)).Returns(23);



            painters = new List<IPainter>
            {
                painter1.Object,
                painter2.Object,
                painter3.Object,
                cheapest.Object,
                painter4.Object,
                painter5.Object
            };

        }

        [TestMethod]
        public void TestMethod1()
        {

            double estimate;

            foreach (var painter in painters)
            {
                estimate = painter.EstimateCompensation(10);
                estimate = painter.EstimateCompensation(10);
                estimate = painter.EstimateCompensation(10);
            }


            var result = Program.FindCheapestPainter(10, painters);

            Assert.AreEqual(cheapest.Object, result);
        }
    }
}
