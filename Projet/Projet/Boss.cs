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
            objFaible = obj_faible;
        }

        public void Faiblesse()
        {

        }
    }
}
