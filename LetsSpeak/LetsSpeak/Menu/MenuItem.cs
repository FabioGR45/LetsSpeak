using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharprompt;

namespace LetsSpeak
{
    public class MenuItem
    {
        internal MenuType Type { get; }
        internal static MenuItem _root;
        public MenuItem Parent { get; set; } = null;
        public string Title { get; }
        public List<MenuItem> Items { get; }
        public Action Action { get; }

        public MenuItem(string title)
        {
            this.Title = title;
            Items = new List<MenuItem>();
            if (_root == null) _root = this;
            Type = MenuType.Submenu;
        }

        public MenuItem(string title, Action action) : this(title)
        {
            this.Action = action;
            Type = MenuType.Command;
        }

        public void Add(MenuItem menuItem)
        {
            menuItem.Parent = this;
            Items.Add(menuItem);
        }

        public void Execute()
        {

            Console.Clear();
            Console.ResetColor();

            var menuItems = Prompt.Select(Title, Items);

            switch (menuItems.Type)
            {
                case MenuType.Submenu:
                    menuItems.Execute();
                    break;

                case MenuType.Command:
                    menuItems.Action();
                    Console.ReadKey(true);
                    break;

                default:
                    break;
            }

            menuItems.Parent.Execute();
        }



        public override string ToString()
        {
            return Title;
        }

        public enum MenuType
        {
            Submenu,
            Command
        }

    }
}
