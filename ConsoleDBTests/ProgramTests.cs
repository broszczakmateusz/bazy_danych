using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        //[TestMethod()]
        //public void ConnectAsTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void CorrectIsNIPValidTest()
        {
            Assert.IsTrue(Program.IsNIPValid("0123456789"));
        }
        [TestMethod()]
        public void WrongIsNIPValidTest()
        {
            Assert.IsFalse(Program.IsNIPValid("01Z345678a"));
        }

        [TestMethod()]
        public void CorrectIsPhoneNumberValidTest()
        {
            Assert.IsTrue(Program.IsPhoneNumberValid("111222333"));
        }

        [TestMethod()]
        public void WrongIsPhoneNumberValidTest()
        {
            Assert.IsFalse(Program.IsPhoneNumberValid("111222333444"));
        }

        [TestMethod()]
        public void CorrectIsOnlyTextAndNumbersValidTest()
        {
            Assert.IsTrue(Program.IsOnlyTextAndNumbersValid("abcd123kdla"));
        }

        [TestMethod()]
        public void WrongIsOnlyTextAndNumbersValidTest()
        {
            Assert.IsFalse(Program.IsOnlyTextAndNumbersValid("abc d-123kd.la?"));
        }

        [TestMethod()]
        public void CorrectIsOnlyTextValidTest()
        {
            Assert.IsTrue(Program.IsOnlyTextValid("ABZacgffd"));
        }

        [TestMethod()]
        public void WrongIsOnlyTextValidTest()
        {
            Assert.IsFalse(Program.IsOnlyTextValid("abcd123kdla"));
        }

        [TestMethod()]
        public void CorrectIsOnlyNumbersValidTest()
        {
            Assert.IsTrue(Program.IsOnlyNumbersValid("1234567"));
        }

        [TestMethod()]
        public void WrongIsOnlyNumbersValidTest()
        {
            Assert.IsFalse(Program.IsOnlyNumbersValid("12a34.567"));
        }

        [TestMethod()]
        public void CorrectIsPostalCodeValidTest()
        {
            Assert.IsTrue(Program.IsPostalCodeValid("50-669"));
        }

        [TestMethod()]
        public void WrongtIsPostalCodeValidTest()
        {
            Assert.IsFalse(Program.IsPostalCodeValid("a50-669"));
        }

        [TestMethod()]
        public void CorrectIsDateValidTest()
        {
            Assert.IsTrue(Program.IsDateValid("2022-06-16"));
        }

        [TestMethod()]
        public void WrongtIsDateValidTest()
        {
            Assert.IsFalse(Program.IsDateValid("2022.12.16"));
        }

        [TestMethod()]
        public void CorrectIsPriceValidTest()
        {
            Assert.IsTrue(Program.IsPriceValid("100.36"));
        }

        [TestMethod()]
        public void WrongtIsPriceValidTest()
        {
            Assert.IsFalse(Program.IsPriceValid("5.555"));
        }
    }
}