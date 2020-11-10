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
                    //Fas1
                    //string date = lword[0];
                    //string state = lword[1];
                    //string title = lword[2];
                    //Fas2
                    Activity A = new Activity(lword[0], lword[1], lword[2]);
                    Console.WriteLine("{0} - {1} - {2}", A.date, A.state, A.title);
                    todoList.Add(A);
                }
            }
            return todoList;
        }
    }
}
