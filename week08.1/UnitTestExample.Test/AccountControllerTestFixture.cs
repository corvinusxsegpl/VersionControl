using NUnit.Framework;
using System;
using System.Activities;
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
               TestCase("irf@uni-corvinus.hu", true),
                TestCase("irf@uni-corvinus.hu", "Abcd1234"),
                TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
                TestCase("irf@uni-corvinus", "Abcd1234"),
                TestCase("irf.uni-corvinus.hu", "Abcd1234"),
                TestCase("irf@uni-corvinus.hu", "abcd1234"),
                TestCase("irf@uni-corvinus.hu", "ABCD1234"),
                TestCase("irf@uni-corvinus.hu", "abcdABCD"),
                TestCase("irf@uni-corvinus.hu", "Ab1234"),
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(email);
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
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();
            var actualResult = accountController.Register(email, password);
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }
        public void TestRegisterValidateException(string email, string password)
        { 
            var accountController = new AccountController();
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }

            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }

    }
}
