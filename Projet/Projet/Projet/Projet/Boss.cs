using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Boss : Ennemy
    {
        private string objFaible;

        public Boss(string name, string ph, int level, int pv, int atk, int def, string objet, string obj_faible, int xpDrop, int energy) : base (name, ph, level, pv, atk, def, objet, xpDrop, energy)
        {
            this.name = name;
            this.energy = energy;
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

            objFaible = obj_faible;
        }

        public List<string> Faiblesse(List<string> obj)
        {
            if (obj.Contains(objFaible))
            {
                atk /= 3;
                obj.Remove(objFaible);
            }
            return obj;
        }
    }
}
