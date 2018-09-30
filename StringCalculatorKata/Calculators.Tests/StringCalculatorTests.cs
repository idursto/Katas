namespace Calculators.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void StringCalculator_Add_EmptyString_Returns_0()
        {
            TestCalculatorAdd(string.Empty, 0);
        }

        [TestMethod]
        public void StringCalculator_Add_SingleNumber_ReturnsResult()
        {
            TestCalculatorAdd("1", 1);
        }

        [TestMethod]
        public void StringCalculator_Add_Numbers_ReturnsResult()
        {
            TestCalculatorAdd("1,4,5,6", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_DelimiterAtFront_ReturnsResult()
        {
            TestCalculatorAdd(",1,4,5,6", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_DelimiterAtEnd_ReturnsResult()
        {
            TestCalculatorAdd("1,4,5,6,", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_DelimiterAtFrontAndEnd_ReturnsResult()
        {
            TestCalculatorAdd(",1,4,5,6,", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_NumbersWithTwoDelimiters_ReturnsResult()
        {
            TestCalculatorAdd("1,4\n5,6", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_TwoDelimitersAtFrontAndEnd_ReturnsResult()
        {
            TestCalculatorAdd("\n1,4,5,6,", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_OnlyDelimiters_ReturnsResult()
        {
            TestCalculatorAdd("\n,", 0);
        }

        [TestMethod]
        public void StringCalculator_Add_SingleCharacterCustomDelimiter_WithNumbers_ReturnsResult()
        {
            TestCalculatorAdd("//;\n1;4;5;6;", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_SingleCharacterCustomDelimiter_WithOneNumber_ReturnsResult()
        {
            TestCalculatorAdd("//;\n1", 1);
        }

        [TestMethod]
        public void StringCalculator_Add_SingleCharacterCustomDelimiter_OnlyDelimiter_ReturnsResult()
        {
            TestCalculatorAdd("//;\n,", 0);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiter_WithOneNumber_ReturnsResult()
        {
            TestCalculatorAdd("//;\n1", 1);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiter_OnlyDelimiter_ReturnsResult()
        {
            TestCalculatorAdd("//;\n,", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))] // Assert
        public void StringCalculator_Add_OneNegativeNumber_ThrowsInvalidOperationException()
        {
            TestCalculatorAdd("-1", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))] // Assert
        public void StringCalculator_Add_OnlyNegativeNumbers_ThrowsInvalidOperationException()
        {
            TestCalculatorAdd("-1,-555,-999", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))] // Assert
        public void StringCalculator_Add_SomeNegativeNumbers_ThrowsInvalidOperationException()
        {
            TestCalculatorAdd("-1,555,-999,1", 1);
        }

        [TestMethod]
        public void StringCalculator_Add_OneNumber_BiggerThan1000_IsIgnored()
        {
            TestCalculatorAdd("1001", 0);
        }

        [TestMethod]
        public void StringCalculator_Add_Numbers_BiggerThan1000_AreIgnored()
        {
            TestCalculatorAdd("1001, 1004", 0);
        }

        [TestMethod]
        public void StringCalculator_Add_SomeNumbers_BiggerThan1000_AreIgnored()
        {
            TestCalculatorAdd("1001, 1004, 2, 5", 7);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiter_OneNumber_ReturnsResult()
        {
            TestCalculatorAdd("//[***]\n1", 1);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiter_WithNumbers_ReturnsResult()
        {
            TestCalculatorAdd("//[***]\n1***4***5***6***", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiter_WithNumbersBiggerThan1000_ReturnsResult()
        {
            TestCalculatorAdd("//[***]\n1***4***5***1006***", 10);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiters_OneNumber_ReturnsResult()
        {
            TestCalculatorAdd("//[**1][**2];\n1", 1);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiters_WithNumbers_ReturnsResult()
        {
            TestCalculatorAdd("//[**1][**2]\n1**14**25**26**1", 16);
        }

        [TestMethod]
        public void StringCalculator_Add_MultiCharacterCustomDelimiters_WithNumbersBiggerThan1000_ReturnsResult()
        {
            TestCalculatorAdd("//[**1][**2]\n1**14**25**21006**2", 10);
        }

        public void TestCalculatorAdd(string numbers, int expected)
        {
            // Arrange
            var stringCalculator = new StringCalculator(new DelimiterManager(new RegexAdapter()));

            // Act
            var calculatedSum = stringCalculator.Add(numbers);

            // Assert
            Assert.AreEqual(expected, calculatedSum);
        }
    }
}
