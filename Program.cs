using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace todolist
{
    class Program
    {
        class Activity
        {
            public string date;
            public string state;
            public string title;

            public Activity(string D, string S, string T)
            {
                date = D; state = S; title = T;
            }
        }
        static void Main(string[] args)
        {
            //Declarations:
            //Input:
            string command;
            string[] commandWord;

            //Todolist data:
            List<Activity> todoList;

            //Greetings
            Console.WriteLine("Hello and welcome to the todo list!");
            Console.WriteLine("To quit type 'quit', for help type 'help'!");
            //REPL (do-while-loop)(read execute program loop)
            do
            {
                Console.WriteLine("> ");
                command = Console.ReadLine();
                commandWord = command.Split(' ');
                // Om commandot är load: läs filen
                
                if(commandWord[0] == "load")
                {
                    Console.WriteLine("Reading file {0}", commandWord[1]);
                    todoList = ReadToDoListFile(commandWord[1]);
                }
                else if (commandSplit[0] == "save")
                {
                    if (commandSplit.Length == 1)
                    {
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            for (int i = 0; i < todoList.Count; i++)
                            {
                                writer.WriteLine($"{todoList[i].date}#{todoList[i].state}#{todoList[i].title}");
                            }
                        }
                    }
                    else if (commandSplit.Length == 2)
                    {
                        using (StreamWriter sw = File.CreateText(commandSplit[1]))
                        {
                            for (int i = 0; i < todoList.Count; i++)
                            {
                                sw.WriteLine($"{todoList[i].date}#{todoList[i].status}#{todoList[i].title}");
                else
                {
                    Console.WriteLine("Unkwown command: {0}", command);
                }
                
            } while (command != "quit");
            Console.WriteLine("bye");
            Console.ReadKey();

        }

        private static List<Activity> ReadToDoListFile(string fileName)
        {
            List<Activity> todoList = new List<Activity>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0) // Is next char an EndOfFile sign?
                {

                    //Console.WriteLine("{0}", line);
                    string[] lword = sr.ReadLine().Split('#');
                    
                    Activity A = new Activity(lword[0], lword[1], lword[2]);
                    Console.WriteLine("{0} - {1} - {2}", A.date, A.state, A.title);
                    todoList.Add(A);
                }
            }
            return todoList;
        }
    }
}
