using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    private const int Limit = 1048576 - 1;

    public int solution(string S)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        try 
        {
            return Evaluate(S);
        }
        catch
        {
            return -1;
        }
    }
    private static int Evaluate(string S)
    {
        var ops = S.Split(' ');
        var stack = new Stack<int>();
        foreach (var op in ops)
        {
            switch(op)
            {
                case "DUP":
                if (stack.Count < 1)
                    throw new Exception("Unable to duplicate value from an empty stack.");
                stack.Push(stack.Peek());
                break;

                case "POP":
                if (stack.Count < 1)
                    throw new Exception("Unable to pop from an empty stack.");
                stack.Pop();
                break;

                case "+":
                if (stack.Count < 2)
                    throw new Exception("Not enough operand in addition.");
                var sum = stack.Pop() + stack.Pop();
                if (sum > Limit)
                    throw new Exception("Overflow occurrs in addition.");
                stack.Push(sum);
                break;

                case "-":
                if (stack.Count < 2)
                    throw new Exception("Not enough operand in subtraction.");
                
                var operand1 = stack.Pop();
                var operand2 = stack.Pop();
                if (operand1 < operand2)
                    throw new Exception("Underflow occurrs in subtraction.");
                stack.Push(operand1 - operand2);
                break;

                default:
                stack.Push(int.Parse(op));
                break;
            }
        }
        if (stack.Count == 0)
            throw new Exception("Unable to return result from an empty stack.");
        return stack.Peek();
    }
}
