using Moq;
using PromoitTesting.TestClasses;
using PromotItLibrary.Classes;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using System;
using Xunit;

namespace PromoitTesting
{
    public class TrueExampleTest
    {

        [Fact]
        public void TrueTest()
        {
            Assert.False(false);
            Assert.Equal(1, 1);

            Mock<IUsers> x = new Mock<IUsers>();
            x.Setup(y => y.Name).Returns("Value1");
            IUsers _user = x.Object;
            Assert.True(_user.Name == "Value1");

            DataTest dataTest = new DataTest();
            Assert.True(dataTest.UserName == "John");

            Assert.True(true, "True Results Examples for regular Testing X Unit");
        }

    }
}
