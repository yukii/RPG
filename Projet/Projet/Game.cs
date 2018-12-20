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

            if (menu.jStats.Count != 0)
            {
                menu.jStats[0] = player.level;
                menu.jStats[0] = player.atk;
                menu.jStats[0] = player.def;
                menu.jStats[0] = player.money;
                menu.jStats[0] = player.morceau;
                //menu.jStats[0] = player.objects;
            }
            map.PrintMap(8, 0);
            Deplacement(3, 8, 0);
        }

        public int Deplacement(int e, int x, int y)
        {
            //Console.ReadKey().Key
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();
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
                case ConsoleKey.Escape:
                    Console.WriteLine("Tu veux sauvegarder ?");
                    int choice = menu.PrintMenu(new string[] { "oui", "non", "Quitter le jeu" });
                    switch (choice)
                    {
                        case 1:
                            menu.Sauv(player);
                            break;
                        case 3:
                            menu.Quit();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            map.PrintMap(x, y);
            Console.WriteLine("etage : " + (e + 1));
            //Console.WriteLine("case : " + (x + 1) + "," + (y + 1));
            Thread.Sleep(1000);
            return Deplacement(e, x, y);
        }

        public void InsideCase(int e, int x, int y)
        {
            //afficher ph
            if (map.myMap[e][x, y].ennemy != null)
            {
                //combat
                map.myMap[e][x, y].ennemy.AffichPh();
                Combat(map.myMap[e][x, y].ennemy);
            }
            else if (map.myMap[e][x, y].boss != null)
            {
                //combat
                map.myMap[e][x, y].boss.AffichPh();

                player.objects = map.myMap[e][x, y].boss.Faiblesse(player.objects);
                Combat(map.myMap[e][x, y].boss);
            }
            else if ((map.myMap[e][x, y].obj != "") && (map.myMap[e][x, y].obj != "escalier"))
            {
                //ramasser l'objet
                player.RamasserObj(map.myMap[e][x, y].obj);
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
                Console.WriteLine("Vous êtes à l'étage n°" + (e + 1));
                if ((e != 0) && (e != 3))
                {
                    int choice = menu.PrintMenu(new string[] { "Monter ?", "Descendre ?", "Rester ici" });
                    switch (choice)
                    {
                        case 1:
                            e++;
                            Console.WriteLine("Vous êtes à l'étage n°" + (e + 1));
                            map.PrintMap(x, y);
                            Deplacement(e, x, y);
                            break;
                        case 2:
                            e--;
                            Console.WriteLine("Vous êtes à l'étage n°" + (e + 1));
                            map.PrintMap(x, y);
                            Deplacement(e--, x, y);
                            break;
                        case 3:
                            Console.WriteLine("Vous êtes à l'étage n°" + (e + 1));
                            map.PrintMap(x, y);
                            Deplacement(e, x, y);
                            break;
                        default:
                            break;
                    }
                }
                else if (e == 0)
                {
                    Console.WriteLine("Vous voulez monter ?");
                    int choice = menu.PrintMenu(new string[] { "oui", "non" });
                    if (choice == 1)
                    {
                        e++;
                        Console.WriteLine("Vous êtes à l'étage n°" + (e + 1));
                        map.PrintMap(x, y);
                        Deplacement(e, x, y);
                    }
                }
                else
                {
                    Console.WriteLine("Vous voulez descendre ?");
                    int choice = menu.PrintMenu(new string[] { "oui", "non" });
                    if (choice == 1)
                    {
                        e--;
                        Console.WriteLine("Vous êtes à l'étage n°" + (e + 1));
                        map.PrintMap(x, y);
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
                    {
                        Console.WriteLine("Vous n'avez rien trouvé...");
                        Thread.Sleep(1000);
                    }
                    break;
                case "distrubuteur":
                    if (player.money >= 2)
                    {
                        Console.WriteLine("En quoi puis je vous aidez ?");
                        int choi = menu.PrintMenu(new string[] { "Redonne moi de la vie !!", "En rien...", "Où sont mes affaires ?" });
                        switch (choi)
                        {
                            case 1:
                                Random life = new Random();
                                player.pv += life.Next(5, 20);
                                break;
                            case 3:
                                Console.WriteLine("Erreur systeme, erreur systeme .... 404");
                                Thread.Sleep(1000);
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
                    if (menu.key == code)
                    {
                        Console.WriteLine("Vous avez retrouvé vos affaires !! \\o/");
                        Thread.Sleep(1000);
                        Credit();
                        Thread.Sleep(1000);
                        Console.WriteLine("Vous avez récupérer vos affaires.");
                        Thread.Sleep(200);
                        Console.WriteLine("Vous partez de l'école en serrant vos affaires contre vous....");
                        Thread.Sleep(500);
                        Console.WriteLine("Vous devenez parano...");
                        Thread.Sleep(600);
                        Console.WriteLine("Bon ! Moi je retourne sous ma couette avec un petit thé ^^");
                        Thread.Sleep(700);
                        Console.WriteLine("Bye Bye");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Tu n'as pas trouvé XD");
                        Thread.Sleep(1000);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Combat(Ennemy e)
        {
            int energyE = 0;
            int energyJ = 0;
            int atkEnnemy = 0;
            int choice = 0;

            while ((e.pv > 0) && (!Death()))
            {
                Personnage.AsciiFight(e.name);
                Console.WriteLine("Vous avez " + player.pv + " pv.");
                Console.WriteLine(e.name + " a " + e.pv + " pv.");

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
                    Console.WriteLine();
                    Console.WriteLine("Quelle attaque utilisez vous ?");
                    choice = menu.PrintMenu(player.nameAtk);
                }
                else
                {
                    choice = 3;
                    energyJ = 0;
                }

                e.pv = Personnage.Attack(e.pv, e.def, player.all_atk[player.nameAtk[choice - 1]], player.atk);
                if ((player.all_atk[player.nameAtk[choice - 1]] + player.atk - e.def) > 0)
                    Console.WriteLine("Vous avez infligé " + (player.all_atk[player.nameAtk[choice - 1]] + player.atk - e.def) + " dégats.");
                else
                    Console.WriteLine("Vous avez infligé 0 dégats");

                Thread.Sleep(2000);
                Console.Clear();

            }
            if (e.pv <= 0)
            {
                Console.WriteLine("Vous avez battu " + e.name);
                player.LevelUP(e.xpDrop);
                player.RamasserObj(e.objet);
                Thread.Sleep(1000);
            }
        }


        public bool Death()
        {
            if (player.pv <= 0)
            {
                Console.Clear();
                Console.WriteLine("Tu es tombé inconscient à cause du manque d'exercices...");
                Thread.Sleep(1000);

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dieu : Tu es arrivé plus tôt que prévu ... Partiente un peu je reviens");
                Thread.Sleep(1000);
                Credit();

                Console.Clear();
                Console.WriteLine("Dieu : Je suis de retour !!");
                Thread.Sleep(500);
                Console.WriteLine("Dieu : Tu te réincarneras plus tard .... c'est pas grave ....");
                Thread.Sleep(500);
                Console.WriteLine("En attendant allons fêter ta mort :)");
                Thread.Sleep(500);
                Console.WriteLine("Vous accompagnez Dieu au Paradis et allez festoyer pour fêter votre mort");
                Thread.Sleep(1000);
                Environment.Exit(0);
                return true;
            }
            return false;
        }

        public void Credit()
        {
            Console.Clear();
            Console.Write("Tu devrais trouver un fichier pour les crédits sur ton bureau.");
            Thread.Sleep(200);
            Console.WriteLine("Tu ne l'as pas trouvé .... Tu ne sais pas chercher en somme...");
            Thread.Sleep(200);
            Console.WriteLine("Tant pis pour toi !! (Enfin ils sont courts....");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Hello ! Merci d'avoir joué. Ceci a été développé dans le cadre d'un projet de cours.");
            Thread.Sleep(500);
            Console.WriteLine("Ce petit jeu a été développé, créer et pensé par MAri-Annaig Dupaya (Moi :D \\o/)");
            Thread.Sleep(500);
            Console.WriteLine("J'espère que ça vous a plus. Sur ce... ++");
            Thread.Sleep(2000);
            Console.WriteLine("End Game");
            Thread.Sleep(1000);
        }
        
    }
}
