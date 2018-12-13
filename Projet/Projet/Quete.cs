using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Quete : Personnage
    {
        private string[] objAsk;
        private string objDrop;

        public Quete(string name, string ph, int energy, string[] objets, string objDrop) : base(name, ph, energy)
        {
            this.objAsk = objets;
            this.objDrop = objDrop;
        }

        public List<string> All_ObjAsk(List<string> objJoueur)
        {
            int len = objAsk.Length;
            int i = 0;

            while ((i < len) && objJoueur.Contains(objAsk[i]))
            {
                ++i;
            }

            if (i == len)
            {
                for (int j = 0; j < objAsk.Length; j++)
                {
                    objJoueur.Remove(objAsk[j]);
                }
                objJoueur.Add(objDrop);
            }
            return objJoueur;
        }
    }
}
