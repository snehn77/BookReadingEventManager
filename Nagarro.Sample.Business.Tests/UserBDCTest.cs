using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.Sample.Shared;
using System;

namespace Nagarro.Sample.Business.Tests
{
    [TestClass]
    public class UserBDCTest
    {
        private readonly IUserBDC sampleBDC;
        private readonly Mock<IDACFactory> mockDacFactory;
        private readonly Mock<IUserDAC> mockSampleDac;

        public UserBDCTest()
        {
            mockDacFactory = new Mock<IDACFactory>();
            mockSampleDac = new Mock<IUserDAC>();
            mockDacFactory.Setup(x => x.Create(It.IsAny<DACType>())).Returns(mockSampleDac.Object);
            sampleBDC = new UserBDC(mockDacFactory.Object);
        }

        [TestMethod]
        public void SampleTests1()
        {
            mockSampleDac.Setup(x => x.SignUp(It.IsAny<UserDTO>())).Returns(UserDTO);
            var response = sampleBDC.SignUp(UserDTO);
            Assert.AreEqual(OperationResultType.Success, response.ResultType);
        }

        [TestMethod]
        public void SampleTests2()
        {
            mockSampleDac.Setup(x => x.Login(It.IsAny<LoginDTO>())).Returns(LoginDTO);
            var response = sampleBDC.Login(new LoginDTO());
            Assert.AreEqual(OperationResultType.Failure, response.ResultType);
        }

        private UserDTO UserDTO = new UserDTO
        {
            Email = "snehn777@gmail.com",
            Password = "Abcd@1234",
            FirstName = "Sneh",
            LastName = "Nandu"
        };


        private LoginDTO LoginDTO = new LoginDTO
        {
            Email = "snehn777@gmail.com",
            Password = "Abcd@1234",

        };
    }
}
