namespace TestingQueueStacketc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            Random random = new Random();
           string a = random.Next().ToString();
            queue.Enqueue("hello");
            queue.Enqueue("ola");
            queue.Enqueue(a);

            Console.WriteLine(queue.Peek());

            queue.Dequeue();
            Console.WriteLine(queue.Peek());



            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            Console.WriteLine(stack.Pop());

            SortedDictionary<int,string> keyValuePairs = new SortedDictionary<int,string>();
            keyValuePairs.Add(1, "hello");
            keyValuePairs.Add(2, "Cami");
            foreach(KeyValuePair<int,string> keyValuePair in keyValuePairs)
            {
                Console.WriteLine(keyValuePair.Value);
            }

        }
    }
}
