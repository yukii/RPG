using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Joueur : Personnage
    {
        public int pv;
        public int atk;
        public int def;
        public int level;

        private int xpMax;
        private int xp;

        public List<string> objects;
        public Dictionary<string, int> all_atk;


        public Joueur(string name, string ph, int energy) : base(name, ph, energy)
        {
            level = 1;
            pv = 10;
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
        }
        
        public void RamasserObj(string objet)
        {
            this.objects.Add(objet);
        }

        public void LevelUP(int xpDrop)
        {
            xp += xpDrop;
            if (xp >= xpMax)
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

        public void Death()
        {
            if (pv <= 0)
            {
                Console.WriteLine("you lose");
            }
        }
    }
}
