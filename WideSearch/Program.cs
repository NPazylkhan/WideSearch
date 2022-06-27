using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WideSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(search("you"));
            Console.ReadKey();
        }

        static bool search(string name)
        {
            Dictionary<string, List<string>> ht = new Dictionary<string, List<string>>();

            List<string> you = new List<string> { "alice", "bob", "claire" };
            List<string> bob = new List<string> { "anuj", "peggy" };
            List<string> alice = new List<string> { "peggy" };
            List<string> claire = new List<string> { "tom", "jonny" };
            List<string> emptyList = new List<string>();

            ht.Add("you", you);
            ht.Add("bob", bob);
            ht.Add("alice", alice);
            ht.Add("claire", claire);
            ht.Add("anuj", emptyList);
            ht.Add("peggy", emptyList);
            ht.Add("tom", emptyList);
            ht.Add("jonny", emptyList);

            Queue<string> search_queue = new Queue<string>(ht[name]);

            List<string> searched = new List<string>();

            while (search_queue.Count() > 0)
            {
                var person = search_queue.Dequeue();
                if (searched.Contains(person) == false)
                {
                    if (PersonIsSeller(person))
                    {
                        Console.WriteLine($"{person} is a mango seller!");
                        return true;
                    }
                    else
                    {
                        foreach (string item in ht[person])
                        {
                            search_queue.Enqueue(item);
                        }
                        searched.Add(person);
                    }
                }
            }
            return false;
        }

        static bool PersonIsSeller(string name)
        {
            if (name == "anuj")
            {
                return true;
            }
            return false;
        }
    }
}
