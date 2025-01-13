namespace BuchlisteImproved
{
    internal class Program
    {
        enum Menutype : ushort
        {
            MainMenu = 0,
            Adding = 1,
            Showing = 2,
            Delete = 3,
            End = 4,
            SetRead=5
        }
        enum Showbooks:ushort
        {
            All =1,
            Read =2,
            NotRead=3,
            
        }
        static void Main(string[] args)
        {
            //Bücher hinzufügen,anzeigen(alle, gelesen, ungelesene),entfernen
            //immer nach Titel sortiert werden
            //Alle optionen über Menu verfügbar

            //Bücher haben folgende Infos:
            //Titel, autor, beschreibung, ISBN als string, bool gelesen oder nicht
            List<Books> books = new List<Books>();
          

            Menutype type = Menutype.MainMenu;
            Showbooks showing = Showbooks.All;
            bool end = false;

            do
            {
                try
                {
                    Console.WriteLine("1.Add books  2.Show books  3.Delete books 4.End Program 5.Set Read");

                    type = (Menutype)ushort.Parse(Console.ReadLine());
                    switch (type)
                    {

                        case Menutype.MainMenu: Console.WriteLine("1.Add books | 2.Show books | 3.Delete book | 4.End Program | 5.Set read"); break;
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

                                Console.WriteLine("Did you already read this? (1.yes  2.no)");
                                int input = int.Parse(Console.ReadLine());
                                
                                if(input ==1)
                                {
                                    addBook.IsRead = true;
                                }
                                else if(input ==2)
                                {
                                    addBook.IsRead= false;

                                }

                                books.Add(addBook);
                                books.Sort();
                                type = Menutype.MainMenu;
                                end = true;

                            }
                            break;
                        case Menutype.Showing:
                            {
                                Console.WriteLine("Which books should show: 1.All books 2.Read books 3.Not read books");
                                showing = (Showbooks) ushort.Parse(Console.ReadLine());
                                

                                switch (showing)
                                {
                                    case Showbooks.All:
                                        {
                                            for (int count = 0; count < books.Count; count++)
                                            {
                                                Console.WriteLine($"{count}: " + books[count] );
                                            }
                                            type = Menutype.MainMenu;
                                            end = true;
                                        }break;
                                    case Showbooks.Read:  
                                        {
                                            for (int count = 0; count < books.Count; count++)
                                            {
                                                if (books[count].IsRead == true)
                                                {
                                                    Console.WriteLine($"{count}: " + books[count]);
                                                }
                                              
                                            }
                                            type = Menutype.MainMenu;
                                            end = true;
                                        } break;
                                    case Showbooks.NotRead: 
                                        {
                                            for (int count = 0; count < books.Count; count++)
                                            {
                                                // =false sets the value of the object
                                                if (books[count].IsRead == false)
                                                {
                                                    Console.WriteLine($"{count}: " + books[count]);
                                                }

                                            }
                                            type = Menutype.MainMenu;
                                            end = true;


                                        } break;

                                }
                               
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
                        case Menutype.SetRead:
                            {
                                end =true;
                                Console.WriteLine("Set a book as read");
                                //shows all books
                                for (int count = 0; count < books.Count; count++)
                                {
                                    Console.WriteLine($"{count}: " + books[count]);
                                }
                                //choose book
                                Console.WriteLine("type in the title");
                                string setRead = Console.ReadLine();
                                //finds the book
                                Books bookDel = books.Find(x => x.Title == setRead);
                                // set it to read
                               bookDel.IsRead = true;
                                   
                                

                            }
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please put an actual input in");
                    type = Menutype.MainMenu;
                    end = true;
                }
            } while (end);

        }
        public static string Input()
        {
            return Console.ReadLine();
        }

    }
    public class Books : IComparable<Books>
    {
        public int CompareTo(Books? other)
        {
            return this.Title.CompareTo(other.Title);
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get;  set; }
        public string ISBN { get; set; }
        public bool IsRead { get; set; }

        public Books() { }
        public override string ToString()
        {
            return $"{Title} is written by {Author} and talks about {Description}.It has the number {ISBN}. Has been read: {IsRead}.";
        }

    }
}
