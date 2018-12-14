using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Game
    {
        public Joueur player;
        private Map map;
        private Menu menu;
        
        public Game()
        {
            map = new Map();
            player = new Joueur("Machin", "", 5);
            menu = new Menu();
        }

        public void Deplacement()
        {

        }
    }
}
