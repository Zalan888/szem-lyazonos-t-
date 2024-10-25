using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace személyazonosító
{
    internal class Program
    {
        static string birthOrder1;
        static string birthOrder2;

        static string input()
        {
            string id;
            do
            {
                Console.WriteLine("Kérem az azonosító első 10 jegyét!");
                id = Console.ReadLine();
            }
            while (id.Length != 10);
            return id;
        }

        static string gender(string id) {
            if (id[0] == '1' || id[0] == '3')
            {
                return "férfi";
            }
            else if (id[0] == '2' || id[0] == '4')
            {
                return "nő";
            }
            else { return "helytelen adat"; }
        }

        static void birth(string id)
        {
            Console.WriteLine("A születési sorszám:");
            for (int i = 2; i <= 7; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        static int birthday(string id)
        {
            int year = DateTime.Now.Year;
            int idyear = Convert.ToInt32(id[1]) + Convert.ToInt32(id[2]);
            if (idyear > 25)
            {
                return year - (1900 + idyear);
            }
            else
            {
                return year - (2000 + idyear);
            }
        }

        static int older(string id1, string id2, int birthOrder1, int birthOrder2)
        {
            if (id1 == id2)
            {
                return birthOrder1 > birthOrder2 ? 1 : birthOrder2 > birthOrder1 ?  2 : 0;
            }

            return Convert.ToInt32(id1) > Convert.ToInt32(id2) ? 1 
                : Convert.ToInt32(id2) > Convert.ToInt32(id1) ? 2
                : 0;
        }

        static int birthDiff(string id1, string id2)
        {

        }
        static void Main(string[] args)
        {
            string id = input();
            int birthOrder1 = id[8] + id[9] + id[10];
            Console.WriteLine(gender(id));
            birth(id);
            Console.WriteLine("A következő születésnapi életkora: " + birthday(id));
            string id2 = input();
            int birthOrder2 = id[8] + id[9] + id[10];
            Console.WriteLine("Az " + older(id, id2, birthOrder1, birthOrder2) + ". számú az idősebb");
        }
    }
}
