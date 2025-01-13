namespace Liste
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person? other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"{Name} ist {Age} Jahre alt";
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // mit primitive data types
            Random rmd = new Random();
            List<int> meineListe = new List<int> ();

            for (int i = 0; i < 5; i++)
            {
                meineListe.Add (rmd.Next(0,1001));
            }

            foreach (int value in meineListe)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("sortieren!");
            meineListe.Sort ();
            for (int count = 0; count < meineListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + meineListe[count]);
            }

            Console.WriteLine("Index: ");
            if (int.TryParse(Console.ReadLine(),out int input))
            {
                meineListe.Insert(input, rmd.Next(0, 1001));
            }
            for (int count = 0; count < meineListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + meineListe[count]);
            }

            Console.WriteLine("Remove Index: ");
            if (int.TryParse(Console.ReadLine(), out int input2))
            {
                meineListe.RemoveAt(input2);
            }
            meineListe.Add(100);
            meineListe.Add(100);
            meineListe.Add(100);
            meineListe.Add(100);
            for (int count = 0; count < meineListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + meineListe[count]);
            }

        


            Console.WriteLine("Remove Item: ");
            if (int.TryParse(Console.ReadLine(), out int input3))
            {
                meineListe.Remove(input3);
            }
            for (int count = 0; count < meineListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + meineListe[count]);
            }

            Console.WriteLine("Remove Itemall: ");
            if (int.TryParse(Console.ReadLine(), out int input4))
            {
                meineListe.RemoveAll(x=>x == input4);
            }
            for (int count = 0; count < meineListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + meineListe[count]);
            }

         
            
            //lists with objects

            List<Person> personenListe = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person tempPerson = new Person();
                tempPerson.Age = i;
                tempPerson.Name = "test" + i;
                personenListe.Add(tempPerson);

            }
            for (int count = 0; count < personenListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + personenListe[count]);
            }

            // hinzufuegen eines neun objekt
            Person pers1 = new Person();
            pers1.Name = "BEnn";
            pers1.Age = 400;
            personenListe.Add(pers1);
            Console.WriteLine("------------------------------");
            for (int count = 0; count < personenListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + personenListe[count]);
            }


            personenListe.Remove(pers1);
            Console.WriteLine("------------------------------");
            for (int count = 0; count < personenListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + personenListe[count]);
            }

            //search an object from the list based on an attribute
            Person search = personenListe.Find(p => p.Name.Equals("test1"));
            if (search != null)
            {
                personenListe.Remove(search);
            }
            Console.WriteLine("------------------------------");
            for (int count = 0; count < personenListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + personenListe[count]);
            }





            Person perA = new Person() {Name= "asdsa", Age=12 };
            Person perB = new Person() { Name = "hiuh", Age = 20 };
            Person perC = new Person() { Name = "kjba", Age = 4 };

            personenListe.Add(perA);
            personenListe.Add(perB);
            personenListe.Add(perC);

            for (int count = 0; count < personenListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + personenListe[count]);
            }
            Console.WriteLine("Sortieren");
            personenListe.Sort();

            Console.WriteLine("------------------------------");
            for (int count = 0; count < personenListe.Count; count++)
            {
                Console.WriteLine($"{count}: " + personenListe[count]);
            }



            Console.WriteLine("ende");





        }
    }
}
