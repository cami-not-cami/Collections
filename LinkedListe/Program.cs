namespace LinkedListe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> feb = new LinkedList<int>();
            int z1=1, z2 = 1 , temp;
            feb.AddLast(z1);
            feb.AddLast(z2);
            for (int i = 0; i < 10; i++)
            {
                
                temp= z1+z2 ;
                feb.AddLast(temp);
                z1 = z2;
                z2=temp;

            }
            LinkedListNode<int> node = feb.Find(21);

            Console.WriteLine(node.Previous.Value);
            Console.WriteLine(node.Next.Value);

            foreach (int i in feb)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
