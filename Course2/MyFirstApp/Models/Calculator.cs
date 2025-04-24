using System.Numerics;

namespace MyFirstApp.Models;

public class Calculator
{
    public T Add<T>(T a, T b)
        where T : INumber<T>
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return a / b;
    }
}