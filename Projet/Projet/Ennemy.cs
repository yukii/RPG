using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Ennemy : Personnage
    {
       //public string name;
        //public int energy;
        //public string ph;

        protected int level;
        public int pv;
        public int atk;
        public int def;

        public string objet;
        public int xpDrop;

        public Dictionary<string, int> all_atk;
        public List<string> nameATK;
        protected List<int> proba;

        public Ennemy(string name, string ph, int level, int pv, int atk, int def, string objet, int xpDrop, int energy) : base(name, ph, energy)
        {
            //this.name = name;
            //this.energy = energy;
            //this.ph = ph;

            this.level = level;
            this.pv = pv;
            this.atk = atk;
            this.def = def;
            this.objet = objet;
            this.xpDrop = xpDrop;
            this.all_atk = new Dictionary<string, int>();
            this.nameATK = new List<string>();
            this.proba = new List<int>();
        }

        public void AddAtk(string nameAtk, int atk_, int probabilite)
        {
            this.all_atk.Add(nameAtk, atk_);
            this.nameATK.Add(nameAtk);
            this.proba.Add(probabilite);
        }

        public int AtkEnnemy(Joueur j)
        {
            Random rand = new Random();
            int prob = rand.Next(1, 101);
            if (prob <= proba[0])
            {
                Console.WriteLine(name + " utilise : " + nameATK[0]);
                return all_atk[nameATK[0]];
            }
            else if (prob <= proba[0] + proba[1])
            {
                Console.WriteLine(name + " utilise : " + nameATK[1]);
                if (all_atk[nameATK[1]] == 2)
                {
                    this.atk *= 2;
                    Console.WriteLine("L'attaque de " + name + " a doublé");
                    return 0;
                }
                else if (all_atk[nameATK[1]] == -2)
                {
                    j.atk /= 2;
                    Console.WriteLine("Votre attaque est divisé par 2");
                    return 0;
                }
                else if (all_atk[nameATK[1]] == -4)
                {
                    j.atk /= 4;
                    Console.WriteLine("Votre attaque est divisé par 4");
                    return 0;
                }
                else
                    return all_atk[nameATK[1]];
            }
            else
            {
                Console.WriteLine(name + " utilise : " + nameATK[2]);
                if (all_atk[nameATK[2]] == 1)
                {
                    Random rand_atk = new Random();
                    return rand_atk.Next(1, 12);
                }
                else if (all_atk[nameATK[2]] == -2)
                {
                    Random rand_atk = new Random();
                    return rand_atk.Next(4, 15);
                }
                else
                    return all_atk[nameATK[2]];
            }
        }
    }
}
