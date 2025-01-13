using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace TodoNotizen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //To do und notizen liste: Create, Read, Update, Delete
            //Todos abgeschlossen markieren und die erfüllungs datum Dateonly
            //Notizen : titel und text
            // create todo and datum first option then 2nd is notizen gen separat

            List<Todoloo> list = new List<Todoloo>();
            Menutype menutype = Menutype.None;
            bool ok=false;
            do
            {
                try
                {
                    
                    ok = true;
                    Console.WriteLine("Welcome! Select if you'd like to work with 1.To do's  2.Notes:");
                    menutype = (Menutype)ushort.Parse(Console.ReadLine());
                    switch (menutype)
                    {
                        case Menutype.Todo:
                            {
                                ToDoContents();
                                ok = false;

                            }; break;
                        case Menutype.Notes:
                            {
                               NotesContents();
                                ok = false;
                                
                            } break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please put an actual input in");
                    ok = false;
                }
            } while (!ok);

        }
        public static void ToDoContents()
        {
            List<Todoloo> todoList = new List<Todoloo>();
            TodoMenu menuTodo = new TodoMenu();
            bool error = false;

            do
            {
                try
                {
                    error = true;
                    Console.WriteLine("What would you like to do: 1.Create 2.Read 3.Update 4.Remove 5.Go back to main 6.Set done");
                    menuTodo = (TodoMenu)ushort.Parse(Console.ReadLine());
                    switch (menuTodo)
                    {
                        case TodoMenu.Create:
                            {
                                Todoloo todo = new Todoloo();
                                Console.WriteLine("Write the title of your To do: ");
                                todo.Name = Console.ReadLine();

                                Console.WriteLine("Write your Description:");
                                todo.Description = Console.ReadLine();

                                Console.WriteLine("What is the deadline");
                                todo.Date = DateOnly.Parse(Console.ReadLine());

                                todoList.Add(todo);

                            }
                            break;
                        case TodoMenu.Read:
                            {
                                for (int count = 0; count < todoList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + todoList[count]);
                                }
                            }
                            break;
                        case TodoMenu.Update:
                            {
                                Updatemenu input = Updatemenu.Text;
                                for (int count = 0; count < todoList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + todoList[count]);
                                }

                                Console.WriteLine("what do you want to update: 1.Title 2.The contents");
                                input = (Updatemenu)int.Parse(Console.ReadLine());
                                switch (input)
                                {
                                    case Updatemenu.Titel:
                                        {
                                            Console.WriteLine("Which note do you want to update. Type the title in.");
                                            string tryUpdate = Console.ReadLine();
                                            Todoloo changing = todoList.Find(x => x.Name == tryUpdate);

                                            Console.WriteLine("What would you like to rename to your note: ");
                                            string newTitle = Console.ReadLine();
                                            changing.Name = newTitle;

                                            Console.WriteLine("What date would you like to switch it to");
                                            DateOnly date = DateOnly.Parse(Console.ReadLine());
                                            changing.Date = date;
                                        }
                                        break;
                                    case Updatemenu.Text:
                                        {
                                            Console.WriteLine("Which note do you want to update. Type the title in.");
                                            string tryUpdate = Console.ReadLine();
                                            Todoloo descrDel = todoList.Find(x => x.Name == tryUpdate);

                                            Console.WriteLine("What would you like to re-write in your note: ");
                                            string newText = Console.ReadLine();
                                            descrDel.Description = newText;
                                        }
                                        break;
                                }


                            }
                            break;
                        case TodoMenu.Delete:
                            {
                                Console.WriteLine("Which To do, do you want to delete. Type the title in.");
                                string tryDelete = Console.ReadLine();
                                Todoloo insideDel = todoList.Find(x => x.Name == tryDelete);

                                if (insideDel != null)
                                {
                                    todoList.Remove(insideDel);
                                }
                                for (int count = 0; count < todoList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + todoList[count]);
                                }

                            }
                            break;
                        case TodoMenu.GoBack: return;
                            case TodoMenu.SetDone:
                            {
                                //shows all tasks
                                for (int count = 0; count < todoList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + todoList[count]);
                                }
                                Console.WriteLine("Type in the title to set it as completed");
                                string setRead = Console.ReadLine();

                                Todoloo reset = todoList.Find(x=> x.Name == setRead);
                                reset.Done = true;

                            } break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("please put an input in");
                    error = false;
                }

            } while (error);

        }
        public static void NotesContents()
        {
            List<Notes> noteList = new List<Notes>();
            NotesMenu notesMenu = NotesMenu.Create;
            bool error = false;
         
            do
            {
                try
                {
                    error = true;
                    Console.WriteLine("What would you like to do: 1.Create 2.Read 3.Update 4.Remove 5.Go back to main");
                    notesMenu = (NotesMenu)ushort.Parse(Console.ReadLine());
                    switch (notesMenu)
                    {
                        case NotesMenu.Create:
                            {
                                Notes addNote = new Notes();
                                Console.WriteLine("Write the title of your note: ");
                                addNote.Title = Console.ReadLine();

                                Console.WriteLine("Write your note:");
                                addNote.Text = Console.ReadLine();

                                noteList.Add(addNote);

                            }
                            break;
                        case NotesMenu.Read:
                            {
                                for (int count = 0; count < noteList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + noteList[count]);
                                }
                            }
                            break;
                        case NotesMenu.Update:
                            {
                                Updatemenu input = Updatemenu.Text;
                                for (int count = 0; count < noteList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + noteList[count]);
                                }

                                Console.WriteLine("what do you want to update: 1.Title of the note 2.The note");
                                input = (Updatemenu)int.Parse(Console.ReadLine());
                                switch (input)
                                {
                                    case Updatemenu.Titel:
                                        {
                                            Console.WriteLine("Which note do you want to update. Type the title in.");
                                            string tryUpdate = Console.ReadLine();
                                            Notes noteDel = noteList.Find(x => x.Title == tryUpdate);

                                            Console.WriteLine("What would you like to rename to your note: ");
                                            string newTitle = Console.ReadLine();
                                            noteDel.Title = newTitle;
                                        }
                                        break;
                                    case Updatemenu.Text:
                                        {
                                            Console.WriteLine("Which note do you want to update. Type the title in.");
                                            string tryUpdate = Console.ReadLine();
                                            Notes noteDel = noteList.Find(x => x.Title == tryUpdate);

                                            Console.WriteLine("What would you like to re-write in your note: ");
                                            string newText = Console.ReadLine();
                                            noteDel.Text = newText;
                                        }
                                        break;
                                }


                            }
                            break;
                        case NotesMenu.Delete:
                            {
                                Console.WriteLine("Which note do you want to delete. Type the title in.");
                                string tryDelete = Console.ReadLine();
                                Notes noteDel = noteList.Find(x => x.Title == tryDelete);

                                if (noteDel != null)
                                {
                                    noteList.Remove(noteDel);
                                }
                                for (int count = 0; count < noteList.Count; count++)
                                {
                                    Console.WriteLine($"{count} " + noteList[count]);
                                }

                            }
                            break;
                        case NotesMenu.GoBack: return;
                            
                            
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("please put an input in");
                    error= false;
                }

            } while (error);

        }
    }
    public class Todoloo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public DateOnly Date { get; set; }

        public override string ToString()
        {
            return $"{Name} needs to be done. You need to: {Description} until {Date}.Completed status: {Done}";
        }
      


    }
    public class Notes
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return $"{Title}\n{Text}";
        }
    }
    enum TodoMenu : ushort
    {
        Create = 1,
        Read,
        Update,
        Delete,
        GoBack,
        SetDone

    }
    enum NotesMenu : ushort
    {
        Create = 1,
        Read,
        Update,
        Delete,
        GoBack

    }
    enum Menutype
    {
        None = 0,
        Todo = 1,
        Notes
    }
    enum Updatemenu
    {
        Titel = 1,
        Text = 2
    }
}
