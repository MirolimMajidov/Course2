using System.Numerics;

namespace MyFirstApp.Models;

public class Calculator<T>
    where T : INumber<T>//,class, new()
{
    public T MultiplyCount { get; set; }
    
    public TInternal Add<TInternal>(TInternal a, TInternal b)
        where TInternal : INumber<TInternal>
    {
        return a + b;
    }

    public T Subtract(T a, T b)
    {
        return a - b;
    }

    public T Multiply(T a, T b)
    {
        var result = a * b;
        return result * MultiplyCount;
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