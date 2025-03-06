namespace SortedCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
           SortedList<string,string> list = new SortedList<string, string> ();
            list.Add ("Mia", "Pikachu");
            list.Add("Cami", "CT");
            list.Add("Princess", "Bao");
            list.Add("Hannah", "Clothes");
            list.Add("Cate", "sleep");
            list.Add("Benn", "Ben");
            foreach (KeyValuePair<string, string> pair in list)
            {
                //sorted alfabetic from keys
                Console.WriteLine($"{pair.Key} -- {pair.Value}" );
            }

        }
    }
}
