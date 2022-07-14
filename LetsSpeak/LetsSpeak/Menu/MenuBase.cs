using LetsSpeak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSpeak
{
    public class MenuBase
    {
        public static void Start()
        {
            MenuItem mainMenu = new MenuItem("Menu");

            mainMenu.Add(new MenuItem("---Add new word---", Dictio.registerWords));
            mainMenu.Add(new MenuItem("---Remove a word---", Dictio.removeWords));
            mainMenu.Add(new MenuItem("---Search words---", SearchWords.Search));
            mainMenu.Add(new MenuItem("---Close program---", () => Environment.Exit(0)));


            mainMenu.Execute();
        }
    }
}
