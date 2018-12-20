using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;


namespace Projet
{
    class Menu
    {
        public string key;
        public List<int> jStats = new List<int>();

        public Menu()
        {
            YHateFile();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(@"
======================================
___  _______  ________  _____________
\  \/  /|  |__|  | __ \ |__   __|_  |
 \    / |        | __\ \   | |  __|
  |  |  |  ___   | ___  \  | |  |___
  |__|  |__|  |__|_|  \__\ |_|______|
======================================
");
            Console.WriteLine("Bienvenue en Enfer ^^ :D");

            Music();
            int myChoice = PrintMenu(new string[] { "Start", "Load", "Quit" });

            switch (myChoice)
            {
                case 1:
                    Start();
                    break;
                case 2:
                    Load();
                    break;
                case 3:
                    Quit();
                    break;
                default:
                    break;
            }
            //int mychoice = Console.Read();
            //Choice(mychoice);

            Console.ResetColor();
        }

        public int PrintMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine((i + 1) + "- " + menu[i]);
            }
            int choix = Choice(1, menu.Length);
            return choix;
        }

        public int Choice(int min, int max)
        {
            //choix pour le menu
            //choix pour le combat...
            int res = int.Parse(Console.ReadLine()); //prend le premier charactère
            while (res > max || res < min)
            {
                Console.WriteLine("Try Again");
                res = int.Parse(Console.ReadLine());
            }
            return res;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("?? : Hé ! Hé ! Tu es réveillé ?");
            Thread.Sleep(2000);
            Console.WriteLine("Vous ouvrez les yeux tranquillement.");
            Thread.Sleep(5000);
            Console.WriteLine("?? : Enfin... ça doit faire 5 minutes que j'essaie de te réveiller... On a cours ici après... Tu t'appelle comment ?");

            string name = Console.ReadLine();

            Console.WriteLine("?? : " + name + "... Tu ne dois pas être dans notre classe... Je vais t'appeler C3PO du coup ! :D");
            Thread.Sleep(1000);
            Console.WriteLine("Vous avez été renommé C3PO \\o/");
            Thread.Sleep(3000);
            Console.WriteLine("?? : Si tu pouvais partir s'il te plait pour qu'on puisse avoir cours.");
            Thread.Sleep(3000);
            Console.WriteLine("Vous acceptez. Au moment de partir vous remarquez que vos affaires ne sont plus là. Une personne rentre dans la salle");
            Thread.Sleep(2000);
            Console.Write("?? 2 : Tu es encore là ?");
            Thread.Sleep(3000);
            Console.WriteLine(" Tu n'as plus tes affaires ... Faut dire qu'on ne t'aime pas trop ici... Va voir les profs au cas où ils les auraient retrouvés.");

            Thread.Sleep(2000);
            Console.Clear();
        }

        private void Load()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists(mydocpath + @"\YHate\Sauv.txt"))
            {
                using (StreamReader sr = new StreamReader(mydocpath + @"\YHate\Sauv.txt", true))
                {
                    string l;
                    while ((l = sr.ReadLine()) != null)
                    {
                        jStats.Add(int.Parse(l));
                    }
                }
            }
            else
            {
                Console.WriteLine("Il n'y a pas de sauvegarde ici ...");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Initialisation du Joueur...");
                Thread.Sleep(500);
                Console.WriteLine("Initialisation des Ennemis...");
                Thread.Sleep(600);
                Console.WriteLine("Initialisation des Boss...");
                Thread.Sleep(800);
                Console.WriteLine("Initialisation des objets...");
                Thread.Sleep(200);
                Console.WriteLine("Prêt... Bye bye ^^");
                Thread.Sleep(100);
                Start();
            }

        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        private void YHateFile()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!File.Exists(mydocpath + @"\YHate"))
            {
                Directory.CreateDirectory(mydocpath + @"\YHate");
            }
            if (!File.Exists(mydocpath + @"\YHate\Story.txt"))
            {
                using (StreamWriter sw = new StreamWriter(mydocpath + @"\YHate\Story.txt", true))
                {
                    sw.WriteLine("Vous êtes un étudiant d'Ynov Campus Paris. Vous êtes très souvent absent et votre comportement est ... Comment dire ?");
                    sw.WriteLine("Votre comportement est... ... votre comportement est ... spécial... Vous ne respectez personne et personne ne vous respecte d'ailleurs.");
                    sw.WriteLine("Les profs ont décider de cacher vos affaires. Vous les trouverez dans un coffre fort, la combinaison a été caché.");
                    sw.WriteLine("ATTENTION ! Les ISEE sont à la botte des profs !");
                    sw.WriteLine("Voici votre lueur d'espoir : chaque prof (boss) possèdent une faiblesse sous forme d'objet. Pour les obtenir, vous devez complèter les différentes quêtes que vous donneront les Ingesup et les Lim'Art.");
                    sw.WriteLine("Que La Force Soit Avec Vous !!");
                }
            }
            if (File.Exists(mydocpath + @"\YHate\Key.txt"))
            {
                File.Delete(mydocpath + @"\YHate\Key.txt");
            }
            using (StreamWriter sw = new StreamWriter(mydocpath + @"\YHate\Key.txt", true))
            {
                Random keyRand = new Random();
                int len = keyRand.Next(1, 15);

                for (int i = 0; i < len; i++)
                {
                    key += keyRand.Next(1, 10);
                    sw.Write(key);
                }

                File.SetAttributes(mydocpath + @"\YHate\Key.txt", FileAttributes.Hidden);
            }
        }

        public void Sauv(Joueur j)
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (File.Exists(mydocpath + @"\YHate\Sauv.txt"))
            {
                File.Delete(mydocpath + @"\YHate\Sauv.txt");
            }
            using (StreamWriter sw = new StreamWriter(mydocpath + @"\YHate\Sauv.txt", true))
            {
                sw.WriteLine(j.level);
                sw.WriteLine(j.atk);
                sw.WriteLine(j.def);
                sw.WriteLine(j.money);
                sw.WriteLine(j.morceau);
            }
        }

        private async void Music()
        {
            //idiot, now music Mario, tu vas mourir, regarde dans tes dossiers, je rigole on recommence

            string[] morse = new string[] { ".._.. ..___ _", "_.___.__ __ .._... .._._.__._._. ..___", "_.._..._._...__ ___.._._. .. ._.", "._. .__. ._._._.. ._.. ._ _. ..._. ..._..___... ... .. . ._. ...", ".___ . ._. .. __. ___ ._.. . ___ _. ._. . _._. ___ __ __ . _. _._. ." };

            await Task.Run(
                () =>
                {
                    foreach (string beep in morse)
                    {
                        for (int i = 0; i < beep.Length; i++)
                        {
                            switch (beep[i])
                            {
                                case '.':
                                    Console.Beep(900, 150);
                                    break;
                                case '_':
                                    Console.Beep(900, 450);
                                    break;
                                case ' ':
                                    Thread.Sleep(450);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            );
            Music();
        }

    }
}
