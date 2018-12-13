using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Menu
    {
        public Menu()
        {
            PrintMenu();
            int mychoice = Console.Read();
            //Choice(mychoice);
        }

        public void PrintMenu()
        {

        }

        public int Choice(int min, int max)
        {
            //choix pour le menu
            //choix pour le combat...
            int res = int.Parse(Console.ReadLine()); //prend le premier charactère
            while (res < max || res > min)
            {
                res = int.Parse(Console.ReadLine());
            }
            return res;
        }

        public void Start()
        {

        }

        public void Quit()
        {

        }
    }
}
