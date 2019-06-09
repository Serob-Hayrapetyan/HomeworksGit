namespace MathServer
{
    public class MathService : IMathService
    {
        public double num1;
        public double num2;

        public double Add(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }

        public double Div(double firstValue, double secondValue)
        {
            return firstValue / secondValue;
        }

        public double Mult(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }

        public double Sub(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }

        /// <summary>
        ///  A method which will do appropriate operations based on the incoming request
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public double PerformOperation(char operation)
        {
            switch (operation)
            {
                case '+':
                    return Add(num1, num2);
                case '-':
                    return Sub(num1, num2);
                case '*':
                    return Mult(num1, num2);
                case '/':
                    return Div(num1, num2);
                default:
                    return 0;
            }
        }
    }
}