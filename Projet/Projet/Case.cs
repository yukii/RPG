using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Case
    {
        public Personnage pnj;
        public Ennemy ennemy;
        public Quete quete;
        public string obj;
        public Boss boss;

        public Case(Personnage pnj)
        {
            this.pnj = pnj;
            ennemy = null;
            obj = "";
        }

        public Case(Ennemy enn)
        {
            this.ennemy = enn;
            this.obj = "";
            this.pnj = null;
        }

        public Case(Boss boss)
        {
            ennemy = null;
            obj = "";
            this.pnj = null;
            this.boss = boss;
        }

        public Case(Quete quest)
        {
            quete = quest;
            ennemy = null;
            obj = "";
            this.pnj = null;
        }

        public Case(string obj)
        {
            ennemy = null;
            this.obj = obj;
            this.pnj = null;
        }

        public Case()
        {
            ennemy = null;
            obj = "";
            this.pnj = null;
        }

        public bool CanPass()
        {
            //verifier s'il y a un meuble
            switch (obj)
            {
                case "meuble":
                    return true;
                case "distributeur":
                    return false;
                case "coffre":
                    return false;
                default:
                    return true;
            }
        }
    }
}
