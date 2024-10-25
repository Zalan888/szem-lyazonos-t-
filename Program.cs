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
            string id1birth = "";
            string id2birth = "";

            for (int i = 2; i <= 7; i++)
            {
                id1birth += Convert.ToString(id1[i]);
            }

            for (int i = 2; i <= 7; i++)
            {
                id2birth += Convert.ToString(id2[i]);
            }

            if (id1birth == id2birth)
            {
                return birthOrder1 > birthOrder2 ? 1 : birthOrder2 > birthOrder1 ? 2 : 0;
            }
            else
            {
                return Convert.ToInt32(id1birth) > Convert.ToInt32(id2birth) ? 1
                    : 2;
            }
        }

        static int birthDiff(string id1, string id2)
        {
            int idyear1 = id1[1] + id1[2];
            int idyear2 = id2[1] + id2[2];
            if ( idyear1 > 25)
            {
                idyear1 += 2000;
            }
            else
            {
                idyear1 += 1900;
            }
            if (idyear2 > 25)
            {
                idyear2 += 2000;
            }
            else
            {
                idyear2 += 1900;
            }
            return (idyear1 - idyear2) >= 0 ? idyear1 - idyear2 : idyear2 - idyear1;
        }
        static void Main(string[] args)
        {
            string id = input();
            int birthOrder1 = id[7] + id[8] + id[9];
            Console.WriteLine(gender(id));
            birth(id);
            Console.WriteLine("A következő születésnapi életkora: " + birthday(id));
            string id2 = input();
            int birthOrder2 = id[7] + id[8] + id[9];
            Console.WriteLine("Az " + older(id, id2, birthOrder1, birthOrder2) + ". számú az idősebb");
            Console.WriteLine("A születési különbségük: " + birthDiff(id,id2));
        }
    }
}
