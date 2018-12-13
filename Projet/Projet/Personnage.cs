using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Personnage
    {
        protected string name;
        protected string phrase;
        protected int energy;

        public Personnage(string name, string ph, int energy)
        {
            this.name = name;
            this.phrase = ph;
            this.energy = energy;
        }

        public void AffichPh()
        {
            Console.WriteLine(phrase);
        }

        //pvAdv, defAdv = pv et def de l'adversaire
        //myATK = atk de l'attaque
        //atkMoi = mon atk
        public static int Attack(int pvAdv, int defAdv, int myATK, int atkMoi)
        {
            int damage = atkMoi + myATK - defAdv;
            if (damage > 0)
                pvAdv -= damage;

            return pvAdv;
        }

    }
}
