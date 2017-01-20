using Sumator.Contracts;

namespace Sumator.Models
{
    public class SumatorBusinessLogic : ISumatorBusinessLogic
    {
        public double Sum(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}