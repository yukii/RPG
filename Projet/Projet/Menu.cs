using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet
{
    class Menu
    {
        public Menu()
        {
            int myChoice = PrintMenu(new string[] { "Start", "Quit"});
            
            switch (myChoice)
            {
                case 1:
                    Start();
                    break;
                case 2:
                    Quit();
                    break;
                default:
                    break;
            }
            //int mychoice = Console.Read();
            //Choice(mychoice);
        }

        public int PrintMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine((i+1) + "- " + menu[i]);
            }
            int choix = Choice(1, menu.Length);
            return choix;
        }

        public int Choice(int min, int max)
        {
            //choix pour le menu
            //choix pour le combat...
            int res = int.Parse(Console.ReadLine()); //prend le premier charactère
            while (res > max || res < min)
            {
                Console.WriteLine("Try Again");
                res = int.Parse(Console.ReadLine());
            }
            return res;
        }

        public void Start()
        {
            Console.WriteLine("?? : Hé ! Hé ! Tu es réveillé ?");
            Thread.Sleep(500);
            Console.WriteLine("Vous ouvrez les yeux tranquillement.");
            Thread.Sleep(500);
            Console.WriteLine("?? : Enfin... ça doit faire 5 minutes que j'essaie de te réveiller... On a cours ici après... Tu t'appelle comment ?");
            string name = Console.ReadLine();
            Console.WriteLine("?? : " + name + "... Tu ne dois pas être dans notre classe... Je vais t'appeler Machin du coup ! :D");
            Thread.Sleep(500);
            Console.WriteLine("Vous avez été renommé Machin \\o/");
            Thread.Sleep(500);
            Console.WriteLine("?? : Si tu pouvais partir s'il te plait pour qu'on puisse avoir cours.");
            Thread.Sleep(500);
            Console.WriteLine("Vous acceptez. Au moment de partir vous remarquez que vos affaires ne sont plus là. Une personne rentre dans la salle");
            Thread.Sleep(500);
            Console.Write("?? 2 : Tu es encore là ?");
            Thread.Sleep(500);
            Console.WriteLine(" Tu n'as plus tes affaires ... Faut dire qu'on ne t'aime pas trop ici... Va voir les profs au cas où ils les auraient retrouvés.");

            Thread.Sleep(1000);
            Console.Clear();
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
    }
}
