using LetsSpeak;
using Sharprompt;
using System;
using System.Collections.Generic;

namespace LetsSpeak
{
    class Program
    {
        static void Main(string[] args)
        {

            Prompt.ColorSchema.Answer = ConsoleColor.Cyan;
            Prompt.ColorSchema.Select = ConsoleColor.DarkYellow;
            Prompt.ColorSchema.Error = ConsoleColor.DarkRed;

            Prompt.Symbols.Prompt = new Symbol("🤔", "><");
            Prompt.Symbols.Done = new Symbol("😎", ">");
            Prompt.Symbols.Error = new Symbol("😱", "X!");

            var menu = new MenuItem("Menu Principal");

            Console.Title = "Let's Speak";

            MenuBase.Start();
            menu.Execute();


        }

    }

}