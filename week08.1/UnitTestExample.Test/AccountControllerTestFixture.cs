using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
   public class AccountControllerTestFixture
    {
       [
                Test,
               TestCase("abcd1234", false),
               TestCase("irf@uni-corvinus", false),
               TestCase("irf.uni-corvinus.hu", false),
               TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

            
        }
        public bool ValidatePassword(string password)
        {
            var hasLowercase = new Regex(@"[a-z]+");
            var hasUppercase = new Regex(@"[A-Z]+");
            var hasNumber = new Regex(@"[0-9]+");
            var isEightLong = new Regex(@".{8,}");
            return hasLowercase.IsMatch(password) && hasUppercase.IsMatch(password) && hasNumber.IsMatch(password) && isEightLong.IsMatch(password);
        }
    }
}
