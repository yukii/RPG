using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Personnage
    {
        public string name;
        public string phrase;
        public int energy;

        public Personnage(string name, string ph, int energy)
        {
            this.name = name;
            this.phrase = ph;
            this.energy = energy;
        }

        public void AffichPh()
        {
            Console.WriteLine(name + " : " + phrase);
        }

        //pvAdv, defAdv = pv et def de l'adversaire
        //myATK = atk de l'attaque
        //atkMoi = mon atk
        public static int Attack(int pvAdv, int defAdv, int myATK, int atkMoi)
        {
            if (myATK != 0)
            {
                int damage = atkMoi + myATK - defAdv;
                if (damage > 0)
                    pvAdv -= damage;
            }
            return pvAdv;
        }

        public static bool AttackSpe(int energy, int energyMax)
        {
            return energy >= energyMax;
        }

    }
}
