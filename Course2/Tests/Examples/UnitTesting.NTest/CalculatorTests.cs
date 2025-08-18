using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTesting.NTest;

namespace CalculatorApp.UnitTesting.NUnitTest
{
    public class CalculatorTests: BaseTestInit
    {
        private readonly DateTime _time = DateTime.Now;

        [SetUp]
        public override void TestInitialize()
        {
            base.TestInitialize();
            
            Console.WriteLine(_time);
        }

        [Test]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqualTo15()
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            var result = calculator.Add(4, 11);

            // Assert/Then
            Assert.That(result, Is.EqualTo(15));
            result.Should().Be(15);
        }

        [Test]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldNotBeEqualTo15()
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(5, 6);

            // Assert
            Assert.That(result, Is.EqualTo(11));
            result.Should().NotBe(15);
        }

        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(-1, -1, -2)]
        [TestCase(0, 0, 0)]
        [TestCase(100, 200, 300)]
        public void Add_AddsTwoNumbers_ReturnsSum(int a, int b, int expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            int result = calculator.Add(a, b);

            // Assert/Then
            Assert.That(result, Is.EqualTo(expected));
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(5, 3, 2)]
        [TestCase(-1, -1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(100, 50, 50)]
        public void Subtract_SubtractsTwoNumbers_ReturnsDifference(int a, int b, int expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act
            int result = calculator.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(5, 3, 15)]
        [TestCase(-1, -1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(10, 20, 200)]
        public void Multiply_MultipliesTwoNumbers_ReturnsProduct(int a, int b, int expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act
            int result = calculator.Multiply(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(10, 2, 5.0)]
        [TestCase(9, 3, 3.0)]
        [TestCase(7, 1, 7.0)]
        [TestCase(100, 25, 4.0)]
        public void Divide_DividesTwoNumbers_ReturnsQuotient(int a, int b, double expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act
            double result = calculator.Divide(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            result.Should().BeApproximately(expected, 0.001);
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(-5, 0)]
        [TestCase(0, 0)]
        public void Divide_DivideByZero_ThrowsArgumentException(int a, int b)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act
            Action act = () => calculator.Divide(a, b);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Cannot divide by zero.");
        }
    }
}