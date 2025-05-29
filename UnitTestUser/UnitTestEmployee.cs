using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using AutoMeagler_s2_v2.MockData;

namespace UnitTestUsers
{
    [TestClass]
    public class UnitTestEmployee
    {
        /// <summary>
        /// A test class for the Employee model.
        /// </summary>
        private Models.Employee _employee;

        /// <summary>
        /// Initializes the test class with a mock employee before each test method runs.
        /// </summary>
        [TestInitialize]
        public void BeforeTest()
        {
            _employee = MockData.GetMockEmployees()[0];
        }

        /// <summary>
        /// Tests the FullName property of the Employee model to ensure it returns the correct full name.
        /// </summary>
        [TestMethod]
        public void TestEmployeeFullName()
        {
            // Arrange 
            string expectedFullName = $"{_employee.FirstName} {_employee.LastName}";

            // Act
            string actualFullName = _employee.FullName;

            // Assert
            Assert.AreEqual(expectedFullName, actualFullName, "The FullName property did not return the expected value.");
        }

        /// <summary>
        /// Tests the Employee Type property to ensure it returns the correct type.
        /// </summary>
        [TestMethod]
        public void TestEmployeeType() 
        {
            // Arrange
            string expectedType = "Sælger";
            
            // Act
            string actualType = _employee.Type;
            
            // Assert
            Assert.AreEqual(expectedType, actualType, "The Type property did not return the expected value.");
        }

        /// <summary>
        /// Tests the Email property of the Employee model to ensure it returns the correct email address.
        /// </summary>
        [TestMethod]
        public void TestEmployeeEmail() 
        {
            // Arrange
            string expectedEmail = _employee.Email;

            // Act
            string actualEmail = "Okronborg@gmail.com";

            // Assert
            Assert.AreEqual(expectedEmail, actualEmail, "The Email property did not return the expected value.");
        }
    }
}
