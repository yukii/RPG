using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Ennemy : Personnage
    {
        private int level;
        public int pv;
        public int atk;
        public int def;

        private string objet;
        private int xpDrop;

        private Dictionary<string, int> all_atk;
        private List<string> nameATK;
        private List<int> proba;

        public Ennemy(string name, string ph, int level, int pv, int atk, int def, string objet, int xpDrop, int energy) : base(name, ph, energy)
        {
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

        public int AtkEnnemy()
        {
            Random rand = new Random();
            int prob = rand.Next(1, 101);
            if (prob <= proba[0])
                return all_atk[nameATK[0]];
            else if (prob <= proba[0] + proba[1])
                return all_atk[nameATK[1]];
            else
                return all_atk[nameATK[2]];
        }
    }
}
