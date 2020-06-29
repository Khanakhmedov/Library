using Library.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Library.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.JsonDataBase.Interfaces;
using System.Windows.Forms;

namespace Library
{
    public class Manager
    {
        private UI.Menu activeMenu;
        private Stack<UI.Menu> history;
        private Stack<int> indexHistory;
        private int index;
        private readonly IDataBase data;

        public Manager(IDataBase data)
        {
            this.data = data;
            history = new Stack<UI.Menu>();
            indexHistory = new Stack<int>();
            index = 0;

            //Книги
            List<UI.MenuItem> booksMenuItems = new List<UI.MenuItem>()
            {
                new MenuSeparator(){Text = "Назад", Width = 10, Action = ()=> back()},
                new MenuSeparator(){Text = "Показать все книги", Action = ()=> showAllBooks()},
                new MenuSeparator(){Text ="Добавить книгу", Action = ()=> addBook()}
            };
            var booksMenu = new UI.Menu() { Title = "Меню книг", MenuItems = booksMenuItems };

            //Описание
            List<UI.MenuItem> descMenuitems = new List<UI.MenuItem>()
            {
                new MenuSeparator(){Text = "Назад", Width = 10, Action = ()=> back()}
            };
            var descMenu = new DescriptionMenu()
            {
                Title = "Описание: ",
                MenuItems = descMenuitems
            };

            //Main
            List<UI.MenuItem> mainMenuItems = new List<UI.MenuItem>()
            {
                new MenuSeparator(){Text = "Книги", LinkMenu = booksMenu},
                new MenuSeparator(){Text = "Информация о библиотеке" , Action = ()=> showLibDesc()},
                new MenuSeparator(){Text = "Выход", Width = 10, Action = ()=> close()}
            };

            var mainMenu = new UI.Menu() { Title = "Главное меню", MenuItems = mainMenuItems };
            activeMenu = mainMenu;
        }


        public void Start()
        {
            while (true)
            {
                ItemPosition.Reset();
                activeMenu.Run();
                for (int i = 0; i < activeMenu.MenuItems.Count; i++)
                {
                    if (i == index)
                    {
                        activeMenu.MenuItems[i].Index = i;
                        activeMenu.MenuItems[i].IsHover = true;
                        activeMenu.MenuItems[i].Draw();
                    }
                    else
                    {
                        activeMenu.MenuItems[i].Index = i;
                        activeMenu.MenuItems[i].IsHover = false;
                        activeMenu.MenuItems[i].Draw();
                    }
                }

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            if (index == 0)
                            {
                                index = activeMenu.MenuItems.Count - 1;
                            }
                            else { index--; }
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (index == activeMenu.MenuItems.Count - 1)
                            {
                                index = 0;
                            }
                            else { index++; }
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            var item = activeMenu.MenuItems[index];
                            if (item.LinkMenu != null)
                            {
                                Console.Clear();
                                index = 0;
                                indexHistory.Push(item.Index);
                                history.Push(activeMenu);
                                activeMenu = item.LinkMenu;
                                activeMenu.Run();
                            }
                            else
                            {
                                Console.Clear();
                                //index = 0;
                                if (item.Index > 0)
                                {
                                    indexHistory.Push(item.Index);
                                }
                                item.Action?.Invoke();
                            }
                        }
                        break;
                }
            }
        }


        //Books
        private void showAllBooks()
        {
            Console.Clear();
            index = 0;
            List<UI.MenuItem> menuItems = new List<UI.MenuItem>();
            UI.MenuItem backButton = new MenuSeparator()
            {
                Y = ItemPosition.Y += 3,
                Text = "Back",
                Width = 10,
                Action = () => back()
            };
            menuItems.Add(backButton);

            int tmpIndex = 0;
            foreach (var b in data.library.Books)
            {

                UI.MenuItem book = new MenuSeparator
                {
                    Y = ItemPosition.Y += 3,
                    Text = b.Title,
                    Width = 70,
                    Index = tmpIndex,
                    LinkMenu = new BookMenu
                    {
                        book = b,
                        Title = $"Книга {b.Title}",
                        MenuItems = new List<UI.MenuItem>()
                        {
                            new MenuSeparator { Text = "Низад", Action = () => back() },
                            new MenuSeparator { Text = "Удалить книгу", Action = () => removeBook(b)}
                        }
                    }
                };
                ++tmpIndex;
                menuItems.Add(book);
            }


            UI.Menu books = new UI.Menu { Title = "Все книги", MenuItems = menuItems };
            history.Push(activeMenu);
            activeMenu = books;
        }

        private void removeBook(Book book)
        {
            var res = MessageBox.Show("Добавить эту книгу?", "Добавление книги", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                data.RemoveBook(book);
            }
            back();
            back();
            showAllBooks();
        }

        private void addBook()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  Добавить книгу");
            Console.Write("  Название книги:\t");
            string title = Console.ReadLine();
            Console.Write("  Дата релиза:\t");
            string releaseDate = Console.ReadLine();
            Console.Write("  Имя автора:\t");
            string authorname = Console.ReadLine();
            Console.Write("  Фамилия автора:\t");
            string surename = Console.ReadLine();

            var res = MessageBox.Show("Добавить эту книгу?", "Добавление книги", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                var book = new Book()
                {
                    Title = title,
                    ReleaseDate = releaseDate,
                    Author = new Author
                    {
                        FirstName = authorname,
                        SurName = surename
                    }
                };
                data.AddBook(book);
            }
            indexHistory.Pop();
            Console.Clear();
        }


        //Library Desc
        private void showLibDesc()
        {
            index = 0;
            List<UI.MenuItem> menuItems = new List<UI.MenuItem>();
            UI.MenuItem backButton = new MenuSeparator()
            {
                Y = ItemPosition.Y += 3,
                Text = "Back",
                Width = 10,
                Action = () => back()
            };
            menuItems.Add(backButton);
            var library = data.GetLibrary();
            UI.Menu desc = new DescriptionMenu { Library = library, Title = "Описание", MenuItems = menuItems };
            history.Push(activeMenu);
            activeMenu = desc;
        }

        private void back()
        {
            index = indexHistory.Pop();
            activeMenu = history.Pop();
        }

        private void close()
        {

            var res = MessageBox.Show("Сохранить изменения??", "Выход", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                data.Save();
            }
            Process.GetCurrentProcess().Kill();
        }
    }
}


