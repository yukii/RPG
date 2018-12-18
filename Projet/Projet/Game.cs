using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            player = new Joueur("C3PO", "", 5);
            menu = new Menu();

            Deplacement(3, 8, 0);
        }

        public int Deplacement(int e, int x, int y)
        {
            //Console.ReadKey().Key
            map.PrintMap(x, y);
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    //x-1
                    if ((x != 0) && map.myMap[e][x - 1, y].CanPass())
                    {
                        x--;
                        InsideCase(e, x, y);
                    }
                    else if (x == 0)
                        Console.WriteLine("C'est un mur ...");
                    else
                        Bloque(e, x - 1, y);
                    break;
                case ConsoleKey.LeftArrow:
                    //y-1
                    if ((y != 0) && map.myMap[e][x, y - 1].CanPass())
                    {
                        y--;
                        InsideCase(e, x, y);
                    }
                    else if (y == 0)
                        Console.WriteLine("C'est un mur ...");
                    else
                        Bloque(e, x, y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    //x+1
                    if ((x != 9) && map.myMap[e][x + 1, y].CanPass())
                    {
                        x++;
                        InsideCase(e, x, y);
                    }
                    else if (x == 9)
                        Console.WriteLine("C'est un mur ...");
                    else
                        Bloque(e, x + 1, y);
                    break;
                case ConsoleKey.RightArrow:
                    //y+1
                    if ((y != 9) && map.myMap[e][x, y + 1].CanPass())
                    {
                        y++;
                        InsideCase(e, x, y);
                    }
                    else if (y == 9)
                        Console.WriteLine("C'est un mur ...");
                    else
                        Bloque(e, x, y + 1);
                    break;
                default:
                    break;
            }
            Console.WriteLine("etage : " + (e + 1));
            Thread.Sleep(5000);
            Console.Clear();
            return Deplacement(e, x, y);
        }

        public void InsideCase(int e, int x, int y)
        {
            //afficher ph
            if (map.myMap[e][x, y].ennemy != null)
            {
                //combat
                map.myMap[e][x, y].ennemy.AffichPh();
                //un truc d'ascii ? ou dire : vous etes atk
                Combat(map.myMap[e][x, y].ennemy);
            }
            else if (map.myMap[e][x, y].boss != null)
            {
                //combat
                map.myMap[e][x, y].boss.AffichPh();
                //un truc d'ascii ? ou dire : vous etes atk

                player.objects = map.myMap[e][x, y].boss.Faiblesse(player.objects);
                Combat(map.myMap[e][x, y].boss);
            }
            else if ((map.myMap[e][x, y].obj != "") && (map.myMap[e][x, y].obj != "escalier"))
            {
                //ramasser l'objet
                player.RamasserObj(map.myMap[e][x, y].obj);
                Console.WriteLine("nb obj : " + player.objects.Count);
            }
            else if (map.myMap[e][x, y].quete != null)
            {
                //tous les objets ?
                map.myMap[e][x, y].quete.AffichPh();
                player.objects = map.myMap[e][x, y].quete.All_ObjAsk(player.objects);
            }
            else if (map.myMap[e][x, y].obj == "escalier")
            {
                //demander pour monter ou descendre 
                if ((e != 0) && (e != 3))
                {
                    menu.PrintMenu(new string[] { "Monter ?", "Descendre ?" });
                    int choice = menu.Choice(1, 2);
                    switch (choice)
                    {
                        case 1:
                            Deplacement(e++, x, y);
                            break;
                        case 2:
                            Deplacement(e--, x, y);
                            break;
                        default:
                            break;
                    }
                }
                else if (e == 0)
                {
                    Console.WriteLine("Vous voulez monter ?");
                    menu.PrintMenu(new string[] { "oui", "non" });
                    int choice = menu.Choice(1, 2);
                    if (choice == 1)
                    {
                        e++;
                        Deplacement(e, x, y);
                    }
                }
                else
                {
                    Console.WriteLine("Vous voulez descendre ?");
                    menu.PrintMenu(new string[] { "oui", "non" });
                    int choice = menu.Choice(1, 2);
                    if (choice == 1)
                    {
                        e--;
                        Deplacement(e, x, y);
                    }

                }
            }
            else if (map.myMap[e][x, y].pnj != null)
            {
                //afficher les ph pnj
                map.myMap[e][x, y].pnj.AffichPh();
            }
        }

        public void Bloque(int e, int x, int y)
        {
            switch (map.myMap[e][x,y].obj)
            {
                case "meuble":
                    Console.WriteLine("Vous fouillez le meuble.");
                    Random rand = new Random();
                    if (rand.Next(1, 101) >= 50)
                        player.RamasserObj("2 pieces");
                    else
                        Console.WriteLine("Vous n'avez rien trouvé...");
                    break;
                case "distrubuteur":
                    if (player.money >= 2)
                    {
                        Console.WriteLine("En quoi puis je vous aidez ?");
                        menu.PrintMenu(new string[] { "Redonne moi de la vie !!", "En rien...", "Où sont mes affaires ?" });
                        int choi = menu.Choice(1, 3);
                        switch (choi)
                        {
                            case 1:
                                Random life = new Random();
                                player.pv += life.Next(5, 20);
                                break;
                            case 3:
                                Console.WriteLine("Erreur systeme, erreur systeme .... 404");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "coffre":
                    //demander le code
                    Console.WriteLine("Le code ?");
                    string code = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public void Combat(Ennemy e)
        {
            Console.WriteLine("Vous avez " + player.pv + " pv.");
            int energyE = 0;
            int energyJ = 0;
            int atkEnnemy = 0;
            int choice = 0;

            while ((e.pv > 0) && (!Death()))
            {
                if (!Personnage.AttackSpe(energyE, e.energy))
                    atkEnnemy = e.AtkEnnemy(player);
                else if (e.all_atk[e.nameATK[3]] == -4)
                {
                    Console.WriteLine("Clement utilise Malus au mémoire");
                    Console.WriteLine("Votre attaque est divisé par 2");
                    player.atk /= 4;
                    energyE = 0;
                }
                else
                {
                    atkEnnemy = e.all_atk[e.nameATK[3]];
                    energyE = 0;
                }

                player.pv = Personnage.Attack(player.pv, player.def, atkEnnemy, e.atk);
                Thread.Sleep(2000);
                if ((atkEnnemy + e.atk - player.def) > 0)
                    Console.WriteLine(e.name + " vous inflige " + (atkEnnemy + e.atk - player.def) + "dégats.");
                else
                    Console.WriteLine(e.name + "vous inflige 0 dégats");
                Thread.Sleep(2000);

                if (!Personnage.AttackSpe(energyJ, player.energy))
                {
                    menu.PrintMenu(player.nameAtk);
                    choice = menu.Choice(1, 3);
                }
                else
                {
                    choice = 3;
                    energyJ = 0;
                }

                e.pv = Personnage.Attack(e.pv, e.def, player.all_atk[player.nameAtk[choice - 1]], player.atk);
                if ((atkEnnemy + e.atk - player.def) > 0)
                    Console.WriteLine("Vous avez infligé " + (player.all_atk[player.nameAtk[choice - 1]] + player.atk - e.def) + " dégats.");
                else
                    Console.WriteLine("Vous avez infligé 0 dégats");

                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Vous avez " + player.pv + " pv.");
            }
            if (e.pv <= 0)
            {
                player.LevelUP(e.xpDrop);
                player.RamasserObj(e.objet);
            }
        }


        public bool Death()
        {
            if (player.pv <= 0)
            {
                Console.Clear();
                Console.WriteLine("Tu es tombé inconscient à cause du manque d'exercices...");
                return true;
            }
            return false;
        }
        
    }
}
