namespace BuchListeBeisp
{
    internal class Program
    {
        enum Menutype : ushort
        {
            MainMenu= 0,
            Adding=1,
            Showing =2,
            Delete =3,
            End =4
        }
        static void Main(string[] args)
        {
            //Bücher hinzufügen,anzeigen,entfernen
            //immer nach Titel sortiert werden
            //Alle optionen über Menu verfügbar

            //Bücher haben folgende Infos:
            //Titel, autor, beschreibung, ISBN als string
            List<Books> books = new List<Books>();
            Menutype type = Menutype.MainMenu;
            bool end = false;

            do
            {
                try
                {
                    Console.WriteLine("1.Add books  2.Show books  3.Delete books 4.End Program");

                    type = (Menutype)ushort.Parse(Console.ReadLine());
                    switch (type)
                    {

                        case Menutype.MainMenu: Console.WriteLine("1.Add books | 2.Show books | 3.Delete books | 4.End Program"); break;
                        case Menutype.Adding:
                            {
                                Books addBook = new Books();
                                Console.WriteLine("Type the title in");
                                addBook.Title = Input();

                                Console.WriteLine("Type the author in");
                                addBook.Author = Input();

                                Console.WriteLine("Type the description in");
                                addBook.Description = Input();

                                Console.WriteLine("Type the ISBN in");
                                addBook.ISBN = Input();

                                books.Add(addBook);
                                books.Sort();
                                type = Menutype.MainMenu;
                                end = true;

                            }
                            break;
                        case Menutype.Showing:
                            {
                                for (int count = 0; count < books.Count; count++)
                                {
                                    Console.WriteLine($"{count}: " + books[count]);
                                }
                                type = Menutype.MainMenu;
                                end = true;
                            }

                            break;
                        case Menutype.Delete:
                            {
                                Console.WriteLine("Type in the Title of the book you want to delete");
                                string tryDelete = Console.ReadLine();
                                Books bookDel = books.Find(x => x.Title == tryDelete);
                                if (bookDel != null)
                                {
                                    books.Remove(bookDel);
                                }

                                for (int count = 0; count < books.Count; count++)
                                {
                                    Console.WriteLine($"{count}: " + books[count]);
                                }
                                type = Menutype.MainMenu;
                                end = true;

                            }
                            break;
                        case Menutype.End: end = false; break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please put an actual input in");
                    type = Menutype.MainMenu;
                    end = true;
                }
            }while (end);

        }
        public static string Input ()
        {
            return Console.ReadLine();
        }

    }
    public class Books  :IComparable<Books>
    {
        public int CompareTo(Books? other)
        {
            return this.Title.CompareTo(other.Title);
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public Books() { }
        public override string ToString()
        {
            return $"{Title} is written by {Author} and talks about {Description}.It has the number {ISBN}";
        }

    }
}
