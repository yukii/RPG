using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Map
    {
        private int etages;
        private int cote;
        
        public List<Case[,]> myMap;
        
        private Ennemy ennmyRand;
        private Personnage pnjRand;

        public Map()
        {
            this.etages = 4;
            this.cote = 10;
        }
        
        public void Init()
        {
            myMap = new List<Case[,]>();

            //etage 1
            //int[,] etage1 = { { 8, 8, 0, 6, 0, 0, 6, 10, 10, 10 }, { 0, 0, 0, 0, 0, 6, 0, 10, 3, 5 }, { 0, 6, 0, 2, 0, 0, 0, 0, 6, 0 }, { 0, 6, 0, 6, 0, 3, 0, 10, 10, 6 }, { 6, 0, 0, 2, 0, 1, 0, 10, 4, 10 }, { 1, 5, 0, 0, 6, 0, 0, 10, 10, 5 }, { 0, 5, 7, 0, 0, 2, 0, 10, 10, 10 }, { 1, 0, 0, 2, 0, 0, 0, 10, 5, 10 }, { 7, 7, 7, 0, 0, 5, 0, 10, 1, 10 }, { 8, 8, 7, 0, 6, 0, 0, 10, 10, 6 } };
            Case[,] etage1 = new Case[10, 10];
            
            //etage2
            //int[,] etage2 = { { 8, 8, 0, 2, 0, 0, 6, 0, 10, 10 }, { 0, 0, 2, 0, 1, 0, 3, 0, 10, 10 }, { 10, 10, 0, 0, 2, 0, 0, 0, 10, 3 }, { 4, 10, 0, 6, 0, 0, 3, 0, 10, 10 }, { 10, 10, 0, 0, 1, 2, 0, 0, 10, 2 }, { 4, 10, 0, 3, 0, 0, 0, 6, 10, 10 }, { 6, 0, 6, 0, 0, 6, 0, 0, 10, 5 }, { 2, 2, 2, 2, 2, 2, 2, 2, 10, 5 }, { 6, 6, 6, 6, 6, 6, 0, 0, 0, 0 }, { 7, 7, 7, 7, 7, 7, 0, 0, 8, 8 } };
            Case[,] etage2 = new Case[10, 10];
            
            //etage3
            //int[,] etage3 = { { 8, 8, 0, 0, 3, 0, 0, 0, 11, 11 }, { 0, 0, 0, 2, 0, 6, 3, 0, 11, 11 }, { 0, 6, 0, 0, 0, 0, 2, 0, 11, 11 }, { 0, 0, 4, 4, 4, 0, 0, 0, 11, 11 }, { 3, 0, 5, 5, 5, 0, 2, 0, 11, 11 }, { 0, 0, 2, 3, 2, 0, 0, 0, 11, 11 }, { 0, 3, 0, 2, 0, 0, 6, 0, 11, 11 }, { 7, 7, 0, 0, 3, 0, 2, 0, 11, 11 }, { 0, 0, 0, 2, 0, 0, 0, 6, 7, 7 }, { 6, 6, 1, 0, 0, 2, 0, 6, 8, 8 } };
            Case[,] etage3 = new Case[10, 10];
            
            //etage4
            //int[,] etage4 = { { 8, 8, 0, 0, 0, 0, 0, 1, 10, 5 }, { 0, 0, 0, 6, 1, 0, 2, 0, 6, 6 }, { 5, 6, 0, 1, 0, 1, 0, 0, 10, 10 }, { 6, 10, 4, 0, 2, 0, 2, 0, 5, 10 }, { 10, 10, 0, 2, 0, 2, 0, 1, 10, 10 }, { 5, 10, 1, 0, 2, 0, 2, 0, 10, 10 }, { 6, 10, 0, 0, 1, 0, 1, 1, 10, 5 }, { 5, 6, 1, 3, 0, 1, 0, 0, 10, 5 }, { 6, 6, 1, 3, 0, 1, 0, 0, 0, 0 }, { 6, 6, 0, 6, 1, 6, 6, 0, 8, 8 } };
            Case[,] etage4 = new Case[10, 10];

            myMap.Add(etage1);
            myMap.Add(etage2);
            myMap.Add(etage3);
            myMap.Add(etage4);

            for (int e = 0; e < etages; e++)
            { 
                for (int i = 0; i < cote; i++)
                {
                    for (int j = 0; j < cote; j++)
                    {
                        myMap[e][i, j] = new Case();
                    }
                }
            }

            All_Ennemy();
            All_Boss();
            All_PNJ();
            All_Meuble();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (etage4[i, j].ennemy != null)
                    {
                        Console.Write("E|");
                    }
                    else if (etage4[i,j].pnj != null)
                    {
                        Console.Write("P|");
                    }
                    else
                    {
                        Console.Write(" |");
                    }
                }
                Console.WriteLine();
            }
        }

        private void All_Ennemy()
        {
            #region Etage 1
            //etage 1
            ennmyRand = new Ennemy("ISEE random", "Bienvenu au Rez-de-Chaussée", 20, 34, 25, 18, "piece", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][2, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Tu ne passeras pas !!", 22, 39, 27, 20, "piece", 11, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][4, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "J'ai les meilleurs PV", 24, 42, 30, 22, "piece", 12, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][5, 6] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE random", "Je suis le plus fort !!", 25, 45, 32, 24, "piece", 13, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][7, 3] = new Case(ennmyRand);
            #endregion

            #region Etage 2
            //etage 2
            ennmyRand = new Ennemy("ISEE random", "Jamais je ne bosserais !!", 12, 24, 17, 10, "piece", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][0, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je cherche ma lentille", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][0, 9] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je ne te connais pas...", 10, 20, 14, 8, "piece", 5, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][1, 2] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "T'es ki ?", 12, 24, 17, 10, "piece", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][2, 4] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE random", "Je ne menace pas le PNJ à côté !", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][4, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je me suis enfermé ...", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][4, 9] = new Case(ennmyRand);

            //la borchette à l'étage 2
            ennmyRand = new Ennemy("ISEE random", "Je suis force Jaune devant et Marron derrière ! \\o/", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("CD du club Dorothée !", 10, 0);
            myMap[1][7, 0] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Force Verte prêt au combat \\o/", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 1] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je suis Force Rouge", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Go Go Go Power Rangers !! ♫♫♫♫", 10, 0);
            myMap[1][7, 2] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Je suis Force Rose ♥♥♥♥", 12, 24, 17, 10, "piece", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Force Bleu paré au combat ! \\o/", 12, 24, 17, 10, "piece", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 4] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je suis le 3ème cerbère.", 12, 24, 17, 10, "piece", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je suis le 2ème cerbère et le plus faible.", 10, 20, 14, 8, "piece", 5, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 6] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Je suis le 1er cerbère.", 12, 24, 17, 10, "piece", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 7] = new Case(ennmyRand);
            #endregion

            #region Etage 3
            //etage 3
            ennmyRand = new Ennemy("ISEE affamé", "J'ai FAIM !!!", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][1, 3] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE affamé", "Tu me passes 1€ ?", 18, 30, 22, 15, "piece", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][2, 6] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE fauché", "Je suis fauché...", 20, 34, 25, 18, "piece", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][4, 6] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE seul", "Tu veux bien être mon ami ?", 18, 30, 22, 15, "piece", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][5, 2] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "J'aime pas les hommes.", 18, 30, 22, 15, "piece", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][5, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE zombiz", "Il y a quelqu'un qui fait de bons gâteaux ici ^^", 20, 34, 25, 18, "piece", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][6, 4] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE zombie", "ça te ne dérange pas si je te racket ? J'ai faim.", 18, 30, 22, 15, "piece", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][7, 6] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE zombie", "Laisse moi tranquille, je mange !", 20, 34, 25, 18, "piece", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][8, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je veux pas manger tout seul...", 15, 28, 20, 15, "piece", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][9, 5] = new Case(ennmyRand);
            #endregion

            #region Etage 4
            //etage 4
            ennmyRand = new Ennemy("ISEE random", "J'ai pas ton Pc :p ", 5, 15, 5, 3, "piece", 3, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][1, 6] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Je passais juste par là.", 5, 15, 5, 3, "piece", 3, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][3, 4] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "J'aime les shorts !", 4, 10, 4, 2, "piece", 2, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][3, 6] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Il y avait un projet à faire ?", 4, 10, 4, 2, "piece", 2, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][4, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je me suis perdu ...", 2, 5, 2, 1, "piece", 1, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][4, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Laisse moi tranquille, je mange !", 4, 10, 4, 2, "piece", 2, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][5, 4] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE random", "Je suis niveau 2 !! Palapala ♫♫♫", 2, 5, 2, 1, "piece", 1, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][5, 6] = new Case(ennmyRand);
            #endregion
        }

        private void All_PNJ()
        {
            //etage 1
            pnjRand = new Personnage("Visiteur Random", "Il y a une JPO aujourd'hui ?", 0);
            myMap[0][4, 5] = new Case(pnjRand);

            pnjRand = new Personnage("Gardien", "La sortie est vers le bas.", 0);
            myMap[0][5, 0] = new Case(pnjRand);

            pnjRand = new Personnage("Emmanuel", "Je t'ai laissé un dossier sur ton bureau", 0);
            myMap[0][7, 0] = new Case(pnjRand);

            //etage 2
            pnjRand = new Personnage("Brahim", "J'ai vu les Power Rangers :o", 0);
            myMap[1][1, 4] = new Case(pnjRand);

            pnjRand = new Personnage("Emmanuel", "Tu as pensé à rechargé ta vie ?", 0);
            myMap[1][4, 4] = new Case(pnjRand);

            //etage 3
            pnjRand = new Personnage("Imène", "J'ai peur !! Il y a des ISEE Zombies partout !!", 0);
            myMap[2][9, 2] = new Case(pnjRand);

            //etage 4
            pnjRand = new Personnage("Clément", "Je veux avoir des Pokémons !!", 0);
            myMap[3][0, 7] = new Case(pnjRand);

            pnjRand = new Personnage("Charif", "Il y a des boissons, de la nourriture et du café en bas.", 0);
            myMap[3][1, 4] = new Case(pnjRand);

            pnjRand = new Personnage("Sumeet", "Je peux te spoiler ?", 0);
            myMap[3][2, 3] = new Case(pnjRand);

            pnjRand = new Personnage("Aviel", "Je suis un élève fantôme, tu ne me vois pas.", 0);
            myMap[3][2, 5] = new Case(pnjRand);

            pnjRand = new Personnage("Emmanuel", "Tu devrais croiser mon double à l'étage 1.", 0);
            myMap[3][4, 7] = new Case(pnjRand);

            pnjRand = new Personnage("Antoine", "Tu veux bien m'entrainer à LOL ?", 0);
            myMap[3][5, 2] = new Case(pnjRand);

            pnjRand = new Personnage("Thomas", "A quand le labo cuisine ?", 0);
            myMap[3][6, 4] = new Case(pnjRand);

            pnjRand = new Personnage("Jean", "Qu'est-ce que tu veux ?", 0);
            myMap[3][6, 6] = new Case(pnjRand);

            pnjRand = new Personnage("Ingesup anonyme", "Tu n'aurais pas vu mon clavier mécanique ?", 0);
            myMap[3][6, 7] = new Case(pnjRand);

            pnjRand = new Personnage("Adrien", "J'ai pas compris.", 0);
            myMap[3][7, 2] = new Case(pnjRand);

            pnjRand = new Personnage("Perceval", "C'est pas faux.", 0);
            myMap[3][7, 5] = new Case(pnjRand);

            pnjRand = new Personnage("Gauthier", "Fais attention il y a des ISEE sauvages !", 0);
            myMap[3][8, 2] = new Case(pnjRand);

            pnjRand = new Personnage("Abdel", "Je m'ennuie...", 0);
            myMap[3][8, 5] = new Case(pnjRand);

            pnjRand = new Personnage("Dieu", "Attention aux pièges et bon courage !! Je t'attendrai au paradis :)", 0);
            myMap[3][9, 4] = new Case(pnjRand);

        }

        private void All_Boss()
        {
            //etage 4
            ennmyRand = new Ennemy("Nathalie", "J'ai pas encore justifié tes absences mais tu peux prendre un bonbon.", 10, 24, 16, 10, "", 10, 5);
            ennmyRand.AddAtk("Absences", 15, 33);
            ennmyRand.AddAtk("Retards", 15, 33);
            ennmyRand.AddAtk("Notes en retard", 20, 33);
            ennmyRand.AddAtk("Année perdue", 25, 0);
            myMap[3][3, 2] = new Case(ennmyRand);

            //etage 3
            ennmyRand = new Ennemy("Clement", "Vous ? Ici ?", 25, 50, 34, 26, "", 25, 10);
            ennmyRand.AddAtk("Hurlement", 10, 45);
            ennmyRand.AddAtk("Mots compliqués", 20, 45);
            ennmyRand.AddAtk("Crises de stresse", 20, 10);
            ennmyRand.AddAtk("Malus au mémoire", -4, 0);
            myMap[2][3, 2] = new Case(ennmyRand);

            ennmyRand = new Ennemy("Matthias", "Je ne peux pas te payer mais tu as le droit à un mug !", 25, 50, 34, 26, "mug", 25, 10);
            ennmyRand.AddAtk("Armogaste", 2, 10);
            ennmyRand.AddAtk("Des particules !!", 20, 50);
            ennmyRand.AddAtk("Eclair Photoshop !!", 25, 30);
            ennmyRand.AddAtk("Seek The Stars", 30, 0);
            myMap[2][3, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("Loic", "Si on pouvait en finir rapidemment T.T ...", 25, 50, 34, 26, "", 25, 10);
            ennmyRand.AddAtk("Je veux jouer à Red Dead !!", 6, 50);
            ennmyRand.AddAtk("Role Master", 0, 30);
            ennmyRand.AddAtk("Lucha Libre", 20, 20);
            ennmyRand.AddAtk("Unity Master", 30, 0);
            myMap[2][3, 4] = new Case(ennmyRand);

            //etage 2
            ennmyRand = new Ennemy("Renaud", "", 20, 38, 27, 20, "", 20, 10);
            ennmyRand.AddAtk("No cours", 15, 25);
            ennmyRand.AddAtk("PHP Master", 10, 50);
            ennmyRand.AddAtk("Je suis un debogueur !!", 15, 25);
            ennmyRand.AddAtk("Tu as triché !!", 25, 0);
            myMap[1][3, 0] = new Case(ennmyRand);

            ennmyRand = new Ennemy("Damien", "", 20, 38, 27, 20, "", 20, 10);
            ennmyRand.AddAtk("Tu ne sais pas compter comme Emmanuel.", 1, 50);
            ennmyRand.AddAtk("Damien mène l'enquête", 10, 25);
            ennmyRand.AddAtk("Ma barbe est sublime ^^", 15, 25);
            ennmyRand.AddAtk("0 punitif", 30, 0);
            myMap[1][5, 0] = new Case(ennmyRand);

            //etage 1
            ennmyRand = new Ennemy("Marie-Pierre", "Ta carte étudiante est ici.", 30, 60, 40, 34, "carte étudiante", 30, 10);
            ennmyRand.AddAtk("Paperasse", 20, 50);
            ennmyRand.AddAtk("Autorité", -2, 10);
            ennmyRand.AddAtk("Clin d'oeil", 30, 30);
            ennmyRand.AddAtk("Amour d'Adrien", 40, 0);
            myMap[0][4, 8] = new Case(ennmyRand);
        }

        private void All_Quete()
        {
            //etage 1
            myMap[0][3, 5] = new Case(new Quete("Maxence", "Je te fais  une fausse signature en échange d'un coca.", 0, new string[1] { "coca" }, "fausse signature"));

            //etage 2
            myMap[1][5, 3] = new Case(new Quete("Ludo", "Je cherche les aiguilles de ma montre", 0, new string[2] { "grande aiguille", "petite aiguille" }, "montre"));

            //etage 3
            myMap[2][5, 3] = new Case(new Quete("Julie", "J'ai besoin d'ingrédient pour faire un gateau au chocolat.", 0, new string[3] { "farine", "chocolat", "oeuf" }, "gateau au chocolat"));

            //etage 4
            myMap[3][7, 3] = new Case(new Quete("Raphaelle", "J'ai perdu ma corne.", 0, new string[1] { "corne de licorne" }, "licorne"));
        }

        private void All_Object()
        {
            //etage 1

            //etage 2

            //etage 3

            //etage 4
        }

        private void All_Meuble()
        {
            //etage 1
            myMap[0][1, 9] = new Case("meuble");
            myMap[0][5, 1] = new Case("meuble");
            myMap[0][5, 9] = new Case("meuble");
            myMap[0][6, 1] = new Case("meuble");
            myMap[0][7, 8] = new Case("meuble");
            myMap[0][8, 5] = new Case("meuble");

            //etage 2
            myMap[1][7, 9] = new Case("meuble");
            myMap[1][6, 9] = new Case("meuble");

            //etage 3
            //distributeur
            myMap[2][0, 8] = new Case("distributeur");
            myMap[2][0, 9] = new Case("distributeur");
            myMap[2][1, 8] = new Case("distributeur");
            myMap[2][1, 9] = new Case("distributeur");
            myMap[2][2, 8] = new Case("distributeur");
            myMap[2][2, 9] = new Case("distributeur");
            myMap[2][3, 8] = new Case("distributeur");
            myMap[2][3, 9] = new Case("distributeur");
            myMap[2][4, 8] = new Case("distributeur");
            myMap[2][4, 9] = new Case("distributeur");
            myMap[2][5, 8] = new Case("distributeur");
            myMap[2][5, 9] = new Case("distributeur");
            myMap[2][6, 8] = new Case("distributeur");
            myMap[2][6, 9] = new Case("distributeur");
            myMap[2][7, 8] = new Case("distributeur");
            myMap[2][7, 9] = new Case("distributeur");

            myMap[2][4, 2] = new Case("meuble");
            myMap[2][4, 3] = new Case("meuble");
            myMap[2][4, 4] = new Case("meuble");

            //etage 4
            myMap[3][0, 9] = new Case("meuble");
            myMap[3][2, 0] = new Case("coffre");
            myMap[3][3, 8] = new Case("meuble");
            myMap[3][5, 0] = new Case("meuble");
            myMap[3][6, 9] = new Case("meuble");
            myMap[3][7, 0] = new Case("meuble");
            myMap[3][7, 9] = new Case("meuble");
        }
    }
}