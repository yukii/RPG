using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Joueur : Personnage
    {
        //public string name;
        //public int energy;

        public int pv;
        public int atk;
        public int def;
        public int level;

        private int xpMax;
        private int xp;

        public List<string> objects;
        public Dictionary<string, int> all_atk;
        public string[] nameAtk;

        public int money;

        public Joueur(string name, string ph, int energy) : base(name, ph, energy)
        {
            level = 1;
            pv = 20;
            atk = 3;
            def = 1;
            xpMax = 3;
            xp = 0;
            objects = new List<string>();
            all_atk = new Dictionary<string, int>();
            all_atk.Add("Je vais hacker le monde !", 10);
            all_atk.Add("J'ai pas payé 6k pour ça.", 10);
            all_atk.Add("Je sais faire des sites \\o/", 15);
            all_atk.Add("Vim > Emacs", 20);

            nameAtk = new string[] { "Je vais hacker le monde !", "J'ai pas payé 6k pour ça.", "Je sais faire des sites \\o/" };

            money = 0;
        }
        
        public void RamasserObj(string objet)
        {
            if (objet == "2 pieces")
            {
                Console.WriteLine("Vous avez rammasser " + objet);
                money += 2;
            }
            else
                this.objects.Add(objet);
            List<string> obj = this.objects;
            if ((obj.Contains("un morceau de feuille")))
            {
                int m = 0;
                for (int i = 0; i < obj.Count; i++)
                {
                    if (obj[i] == "un morceau de feuille")
                    {
                        ++m;
                    }
                }
                if (m == 5)
                {
                    Console.WriteLine(@"/!\ System alert /!\");
                    Console.WriteLine(@"/!\ System alert /!\");
                    Console.WriteLine(@"Vos affaires sont au 4ème étage !");
                    Console.WriteLine(@"Pensez à aller voir Emmanuel au Rez De Chaussée");
                    Console.WriteLine(@"/!\ System alert /!\");
                    Console.WriteLine(@"/!\ System alert /!\");
                }
            }
        }

        public void LevelUP(int xpDrop)
        {
            xp += xpDrop;
            while (xp >= xpMax)
            {
                xp -= xpMax;
                level++;
                xpMax += level;
                atk += 3;
                def += 4;
                pv += 10;
                Console.WriteLine("Vous avez level UP");
            }
        }

    }
}
