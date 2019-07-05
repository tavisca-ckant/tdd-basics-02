using Xunit;

namespace ConsoleCalculator
{
    public class CalculatorFixture
    {
        Calculator calculator = new Calculator();

        private string SendMultipleKeys(char[] key)
        {
            var i = 0;
            for (i = 0; i < key.Length - 1; i++)
                calculator.SendKeyPress(key[i]);
            return calculator.SendKeyPress(key[i]);
        }


        [Fact]
        public void TestKeyPress()
        {
            char key = '1';

            string actual = calculator.SendKeyPress(key);

            var expected = "1";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMultipleKeyPress()
        {
            char[] key = new char[] { 'h', '1', '2' };

            string actual = SendMultipleKeys(key);

            var expected = "12";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMultipleZeroesUpFront()
        {
            char[] key = new char[] { 'h', '0', '0', '0' };

            string actual = SendMultipleKeys(key);

            var expected = "0";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMultipleContinuousDecimalPoints()
        {
            char[] key = new char[] { 'h', '0', '.', '.' };

            string actual = SendMultipleKeys(key);

            var expected = "0.";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDecimalPointsUpfront()
        {
            char[] key = new char[] { 'h', '.', '.' };

            string actual = SendMultipleKeys(key);

            var expected = "0.";

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestOnOperatorKeyPressed()
        {
            char[] key = new char[] { 'h', '1', '2', '+' };

            string actual = SendMultipleKeys(key);

            var expected = "12";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberKeyPressedAfterPressingOperator()
        {
            char[] key = new char[] { 'h', '1', '2', '+', '1' };

            string actual = SendMultipleKeys(key);

            var expected = "1";

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestToggleSign()
        {
            char[] key = new char[] { 'h', '1', 's', 's' };

            string actual = SendMultipleKeys(key);

            var expected = "1";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestArithmeticAddition()
        {
            char[] key = new char[] { 'h', '1', '2', '+', '1', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "13";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestArithmeticSubtraction()
        {
            char[] key = new char[] { 'h', '1', '2', '-', '4', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "8";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestArithmeticMultiplication()
        {
            char[] key = new char[] { 'h', '1', '2', 'x', '3', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "36";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestArithmeticDivision()
        {
            char[] key = new char[] { 'h', '1', '2', '/', '2', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "6";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDivisionByZero()
        {
            char[] key = new char[] { 'h', '1', '/', '0', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "-E-";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSignAirthmetic()
        {
            char[] key = new char[] { 'h', '1', '+', '3', 's', 'S', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "4";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestArithmeticCalculationWithC()
        {
            char[] key = new char[] { '1', '+', '2', '+', 'C' };

            string actual = SendMultipleKeys(key);

            var expected = "0";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestArithmeticCalculation()
        {
            char[] key = new char[] { '1', '+', '2', '+', '3', '+', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "12";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCombinationOfArithmetic()
        {
            char[] key = new char[] { '1', '2', '+', '2', 'S', 's', 'S', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "10";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestZeroAndDecimal()
        {
            char[] key = new char[] { '0', '0', '.', '.', '0', '0', '1' };

            string actual = SendMultipleKeys(key);

            var expected = "0.001";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMultipleDecimalPointInNumber()
        {
            char[] key = new char[] { '1', '.', '0', '0', '.', '1', '+', '2', '=' };

            string actual = SendMultipleKeys(key);

            var expected = "-E-";

            Assert.Equal(expected, actual);
        }
    }
}
