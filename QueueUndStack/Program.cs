using System.Collections;

namespace QueueUndStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> strings = new Queue<string>();
            strings.Enqueue("A");
            strings.Enqueue("B");   
            strings.Enqueue("C");
            strings.Enqueue("D");

            Console.WriteLine(strings.Dequeue());
            Console.WriteLine(strings.Peek());
            Console.WriteLine(strings.Dequeue());

            Stack<string> stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");
             
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
        }
    }
}
