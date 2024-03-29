﻿using System;
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
            Init();
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

            //placements
            All_Ennemy();
            All_Boss();
            All_PNJ();
            All_Quete();
            All_Object();
            All_Meuble();
            All_Pieces();
            
        }

        //placements des ennemy
        private void All_Ennemy()
        {
            #region Etage 1
            //etage 1
            ennmyRand = new Ennemy("ISEE random", "Bienvenu au Rez-de-Chaussée", 20, 34, 25, 18, "1 pièce", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][2, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Tu ne passeras pas !!", 22, 39, 27, 20, "1 pièce", 11, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][4, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "J'ai les meilleurs PV", 24, 42, 30, 22, "1 pièce", 12, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][5, 6] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE random", "Je suis le plus fort !!", 25, 45, 32, 24, "1 pièce", 13, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[0][7, 3] = new Case(ennmyRand);
            #endregion

            #region Etage 2
            //etage 2
            ennmyRand = new Ennemy("ISEE random", "Jamais je ne bosserais !!", 12, 24, 17, 10, "1 pièce", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][0, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je cherche ma lentille", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][0, 9] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je ne te connais pas...", 10, 20, 14, 8, "1 pièce", 5, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][1, 2] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "T'es ki ?", 12, 24, 17, 10, "1 pièce", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][2, 4] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE random", "Je ne menace pas le PNJ à côté !", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][4, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je me suis enfermé ...", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][4, 9] = new Case(ennmyRand);

            //la borchette à l'étage 2
            ennmyRand = new Ennemy("ISEE random", "Je suis force Jaune devant et Marron derrière ! \\o/", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("CD du club Dorothée !", 10, 0);
            myMap[1][7, 0] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Force Verte prêt au combat \\o/", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 1] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je suis Force Rouge", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Go Go Go Power Rangers !! ♫♫♫♫", 10, 0);
            myMap[1][7, 2] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Je suis Force Rose ♥♥♥♥", 12, 24, 17, 10, "1 pièce", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Force Bleu paré au combat ! \\o/", 12, 24, 17, 10, "1 pièce", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 4] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je suis le 3ème cerbère.", 12, 24, 17, 10, "1 pièce", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je suis le 2ème cerbère et le plus faible.", 10, 20, 14, 8, "1 pièce", 5, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 6] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Je suis le 1er cerbère.", 12, 24, 17, 10, "1 pièce", 6, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[1][7, 7] = new Case(ennmyRand);
            #endregion

            #region Etage 3
            //etage 3
            ennmyRand = new Ennemy("ISEE affamé", "J'ai FAIM !!!", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][1, 3] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE affamé", "Tu me passes 1€ ?", 18, 30, 22, 15, "1 pièce", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][2, 6] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE fauché", "Je suis fauché...", 20, 34, 25, 18, "1 pièce", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][4, 6] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE seul", "Tu veux bien être mon ami ?", 18, 30, 22, 15, "1 pièce", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][5, 2] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "J'aime pas les hommes.", 18, 30, 22, 15, "1 pièce", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][5, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE zombiz", "Il y a quelqu'un qui fait de bons gâteaux ici ^^", 20, 34, 25, 18, "1 pièce", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][6, 4] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE zombie", "ça te ne dérange pas si je te racket ? J'ai faim.", 18, 30, 22, 15, "1 pièce", 9, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][7, 6] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE zombie", "Laisse moi tranquille, je mange !", 20, 34, 25, 18, "1 pièce", 10, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][8, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je veux pas manger tout seul...", 15, 28, 20, 15, "1 pièce", 7, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[2][9, 5] = new Case(ennmyRand);
            #endregion

            #region Etage 4
            //etage 4
            ennmyRand = new Ennemy("ISEE random", "J'ai pas ton Pc :p ", 5, 15, 5, 3, "1 pièce", 3, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][1, 6] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "Je passais juste par là.", 5, 15, 5, 3, "1 pièce", 3, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][3, 4] = new Case(ennmyRand);
            
            ennmyRand = new Ennemy("ISEE random", "J'aime les shorts !", 4, 10, 4, 2, "1 pièce", 2, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][3, 6] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Il y avait un projet à faire ?", 4, 10, 4, 2, "1 pièce", 2, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][4, 3] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Je me suis perdu ...", 2, 5, 2, 1, "1 pièce", 1, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][4, 5] = new Case(ennmyRand);

            ennmyRand = new Ennemy("ISEE random", "Laisse moi tranquille, je mange !", 4, 10, 4, 2, "1 pièce", 2, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][5, 4] = new Case(ennmyRand);


            ennmyRand = new Ennemy("ISEE random", "Je suis niveau 2 !! Palapala ♫♫♫", 2, 5, 2, 1, "1 pièce", 1, 5);
            ennmyRand.AddAtk("No Work", 2, 33);
            ennmyRand.AddAtk("F0tes d'otografe", 5, 33);
            ennmyRand.AddAtk("CRI", 6, 33);
            ennmyRand.AddAtk("Personne ne nous aime :'(", 10, 0);
            myMap[3][5, 6] = new Case(ennmyRand);
            #endregion
        }

        //placements des PNJ
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

            pnjRand = new Personnage("Salim", "Je peux te spoiler ?", 0);
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

        //placements des Boss 
        private void All_Boss()
        {
            //etage 4
            Boss bossRand = new Boss("Nathalie", "J'ai pas encore justifié tes absences mais tu peux prendre un bonbon.", 10, 24, 16, 10, "un morceau de feuille", "des bonbons", 10, 5);
            bossRand.AddAtk("Absences", 15, 33);
            bossRand.AddAtk("Retards", 15, 33);
            bossRand.AddAtk("Notes en retard", 20, 33);
            bossRand.AddAtk("Année perdue", 25, 0);
            myMap[3][3, 2] = new Case(bossRand);

            //etage 3
            bossRand = new Boss("Clement", "Vous ? Ici ?", 25, 50, 34, 26, "un morceau de feuille", "une montre", 25, 10);
            bossRand.AddAtk("Hurlement", 10, 45);
            bossRand.AddAtk("Mots compliqués", 20, 45);
            bossRand.AddAtk("Crises de stresse", 20, 10);
            bossRand.AddAtk("Malus au mémoire", -4, 0);
            myMap[2][3, 2] = new Case(bossRand);

            bossRand = new Boss("Matthias", "Je ne peux pas te payer mais tu as le droit à un mug !", 25, 50, 34, 26, "mug", "un gateau au chocolat", 25, 10);
            bossRand.AddAtk("Des particules !!", 20, 50);
            bossRand.AddAtk("Armogaste", 2, 10);
            bossRand.AddAtk("Eclair Photoshop !!", 25, 30);
            bossRand.AddAtk("Seek The Stars", 30, 0);
            myMap[2][3, 3] = new Case(bossRand);

            bossRand = new Boss("Loic", "Si on pouvait en finir rapidemment T.T ...", 25, 50, 34, 26, "un morceau de feuille", "une licorne", 25, 10);
            bossRand.AddAtk("Je veux jouer à Red Dead !!", 6, 50);
            bossRand.AddAtk("Lucha Libre", 20, 20);
            bossRand.AddAtk("Role Master", 0, 30);
            bossRand.AddAtk("Unity Master", 30, 0);
            myMap[2][3, 4] = new Case(bossRand);

            //etage 2
            bossRand = new Boss("Renaud", "", 20, 38, 27, 20, "un morceau de feuille", "une feuille de cours", 20, 10);
            bossRand.AddAtk("No cours", 15, 25);
            bossRand.AddAtk("PHP Master", 10, 50);
            bossRand.AddAtk("Je suis un debogueur !!", 15, 25);
            bossRand.AddAtk("Tu as triché !!", 25, 0);
            myMap[1][3, 0] = new Case(bossRand);

            bossRand = new Boss("Damien", "", 20, 38, 27, 20, "un morceau de feuille", "une fausse signature", 20, 10);
            bossRand.AddAtk("Damien mène l'enquête", 10, 25);
            bossRand.AddAtk("Ma barbe est sublime ^^", 15, 25);
            bossRand.AddAtk("Tu ne sais pas compter comme Emmanuel.", 1, 50);
            bossRand.AddAtk("0 punitif", 30, 0);
            myMap[1][5, 0] = new Case(bossRand);

            //etage 1
            bossRand = new Boss("Marie-Pierre", "Ta carte étudiante est ici.", 30, 60, 40, 34, "carte étudiante", "", 30, 10);
            bossRand.AddAtk("Paperasse", 20, 50);
            bossRand.AddAtk("Autorité", -2, 10);
            bossRand.AddAtk("Clin d'oeil", 30, 30);
            bossRand.AddAtk("Amour d'Adrien", 40, 0);
            myMap[0][4, 8] = new Case(bossRand);
        }

        //placement des perso avec des quetes
        private void All_Quete()
        {
            //etage 1
            myMap[0][3, 5] = new Case(new Quete("Elève fantôme", "Je te fais  une fausse signature en échange d'un coca.", 0, new string[1] { "un coca" }, "une fausse signature"));
            myMap[0][1, 8] = new Case(new Quete("Amoureux", "J'ai perdu mon amour .... :'( ", 0, new string[1] { "une lettre d'amour" }, "love"));
            myMap[0][8, 8] = new Case(new Quete("Recruteur", "Vous avez pas le profil.", 0, new string[5] { "un cv", "une lettre de motivation", "php skill", "linux skill", "windows skill" }, "un contrat"));

            //etage 2
            myMap[1][5, 3] = new Case(new Quete("Ludo", "Je cherche les aiguilles de ma montre", 0, new string[2] { "une grande aiguille", "une petite aiguille" }, " une montre"));
            myMap[1][1, 6] = new Case(new Quete("Sumeet", "J'ai soif ! Va me chercher à boire.", 0, new string[1] { "des bières"}, "chaussures"));
            myMap[1][2, 9] = new Case(new Quete("Ryan", "Je veux des nuggest :3", 0, new string[1] { "des nuggest" }, "des ciseaux"));

            //etage 3
            myMap[2][5, 3] = new Case(new Quete("Julie", "J'ai besoin d'ingrédient pour faire un gateau au chocolat.", 0, new string[3] { "de la farine", "du chocolat", "des oeuf" }, "un gateau au chocolat"));
            myMap[2][0, 4] = new Case(new Quete("Elise", "J'ai perdu mon passeport.", 0, new string[1] { "le passeport d'Elise" }, "une feuille de cours"));
            myMap[2][1, 6] = new Case(new Quete("Yasmiina", "Il faudrait un dépliant Ynov, tu l'as ?", 0, new string[1] { "un depliant Ynov" }, "des bonbons"));
            myMap[2][4, 0] = new Case(new Quete("Matthieu", "Trouve moi une feuille et je te fais un cours.", 0, new string[1] { "une feuille" }, "une feuille de cours"));
            myMap[2][6, 1] = new Case(new Quete("Antoine", "Achete moi un mars.", 0, new string[1] { "un mars" }, "un skin LOL"));
            myMap[2][7, 5] = new Case(new Quete("Julien", "Je veux un jeu parfait !!", 0, new string[] { "ET sur Atari" }, "la reconnaissance"));


            //etage 4
            myMap[3][7, 3] = new Case(new Quete("Raphaelle", "J'ai perdu ma corne.", 0, new string[1] { "corne de licorne" }, "licorne"));
            myMap[3][8, 3] = new Case(new Quete("John", "Tu n'aurais pas vu mon bouquin d'histoire ?", 0, new string[] { "un bouquin d'histoire" }, "un cd de Beyonce"));
        }

        //placement des objets
        private void All_Object()
        {
            //etage 1
            myMap[0][0, 3] = new Case("un cv");
            myMap[0][3, 1] = new Case("une balle de ping pong");
            myMap[0][3, 3] = new Case("une raquette de ping pong");
            myMap[0][5, 4] = new Case("une table de ping pong");
            myMap[0][2, 8] = new Case("une feuille");
            myMap[0][3, 9] = new Case("une replique d'Excalibur");
            myMap[0][9, 9] = new Case("un canapé");
            myMap[0][9, 4] = new Case("un coca périmé");
            myMap[0][1, 5] = new Case("un bouquin d'histoire");

            //etage 2
            myMap[1][8, 0] = new Case("une lettre d'amour");
            myMap[1][0, 6] = new Case("le passeport d'Elise");
            myMap[1][4, 3] = new Case("une petite aiguille");
            myMap[1][6, 7] = new Case("php skill");
            myMap[1][7, 0] = new Case("dossier d'inscription");
            myMap[1][7, 2] = new Case("un corne de licorne");
            myMap[1][7, 5] = new Case("un truc blanc visqueux");
            myMap[1][8, 1] = new Case("une carte Magic");
            myMap[1][8, 2] = new Case("une carte Yu-Gi-Oh");
            myMap[1][8, 3] = new Case("une carte Pokemon");
            myMap[1][8, 4] = new Case("une carte Carapuce");
            myMap[1][8, 5] = new Case("du chocolat");

            //etage 3
            myMap[2][9, 0] = new Case("un coca");
            myMap[2][9, 1] = new Case("de la farine");
            myMap[2][9, 7] = new Case("une grande aiguille");
            myMap[2][8, 7] = new Case("des bières");
            myMap[2][6, 6] = new Case("un mars");
            myMap[2][2, 1] = new Case("un depliant Ynov");
            myMap[2][1, 5] = new Case("une souris");


            //etage 4
            myMap[3][1, 8] = new Case("une lettre de motivation");
            myMap[3][1, 3] = new Case("The Scroll of Stupidity");
            myMap[3][2, 1] = new Case("des nuggest");
            myMap[3][3, 0] = new Case("ET sur Atari");
            myMap[3][6, 0] = new Case("une carte de Kanto");
            myMap[3][7, 1] = new Case("des oeufs");
            myMap[3][8, 1] = new Case("un passe-partout");
            myMap[3][9, 0] = new Case("un cours liquide");
            myMap[3][9, 1] = new Case("linus skill");
            myMap[3][9, 3] = new Case("windows skill");
            myMap[3][9, 5] = new Case("un sac de pc");
            myMap[3][9, 6] = new Case("une fiche de perso");
        }

        //placement des meubles
        private void All_Meuble()
        {
            //etage 1
            myMap[0][1, 9] = new Case("meuble");
            myMap[0][5, 1] = new Case("meuble");
            myMap[0][5, 9] = new Case("meuble");
            myMap[0][6, 1] = new Case("meuble");
            myMap[0][7, 8] = new Case("meuble");
            myMap[0][8, 5] = new Case("meuble");

            myMap[0][0, 0] = new Case("escalier");
            myMap[0][0, 1] = new Case("escalier");

            //etage 2
            myMap[1][7, 9] = new Case("meuble");
            myMap[1][6, 9] = new Case("meuble");

            myMap[1][0, 0] = new Case("escalier");
            myMap[1][0, 1] = new Case("escalier");
            myMap[1][9, 8] = new Case("escalier");
            myMap[1][9, 9] = new Case("escalier");

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

            myMap[2][0, 0] = new Case("escalier");
            myMap[2][0, 1] = new Case("escalier");
            myMap[2][9, 8] = new Case("escalier");
            myMap[2][9, 9] = new Case("escalier");

            //etage 4
            myMap[3][0, 9] = new Case("meuble");
            myMap[3][2, 0] = new Case("coffre");
            myMap[3][3, 8] = new Case("meuble");
            myMap[3][5, 0] = new Case("meuble");
            myMap[3][6, 9] = new Case("meuble");
            myMap[3][7, 0] = new Case("meuble");
            myMap[3][7, 9] = new Case("meuble");

            myMap[3][0, 0] = new Case("escalier");
            myMap[3][0, 1] = new Case("escalier");
            myMap[3][9, 8] = new Case("escalier");
            myMap[3][9, 9] = new Case("escalier");
        }

        //placement des pièces
        private void All_Pieces()
        {
            Case pieces = new Case("2 pieces");
            //etage 1
            myMap[0][0, 6] = pieces;
            myMap[0][2, 1] = pieces;
            myMap[0][4, 0] = pieces;
            myMap[0][6, 2] = pieces;
            myMap[0][2, 1] = pieces;
            myMap[0][8, 0] = pieces;
            myMap[0][8, 1] = pieces;
            myMap[0][8, 2] = pieces;
            myMap[0][9, 2] = pieces;

            //etage 2
            myMap[1][9, 0] = pieces;
            myMap[1][9, 1] = pieces;
            myMap[1][9, 2] = pieces;
            myMap[1][9, 3] = pieces;
            myMap[1][9, 4] = pieces;
            myMap[1][9, 5] = pieces;

            //etage 3
            myMap[2][1, 0] = pieces;
            myMap[2][3, 6] = pieces;
            myMap[2][7, 0] = pieces;
            myMap[2][7, 1] = pieces;
            myMap[2][8, 5] = pieces;
            myMap[2][8, 8] = pieces;
            myMap[2][8, 9] = pieces;

            //etage 4
            myMap[3][0, 2] = pieces;
            myMap[3][1, 2] = pieces;
            myMap[3][1, 0] = pieces;
            myMap[3][1, 1] = pieces;
            myMap[3][9, 7] = pieces;
            myMap[3][8, 7] = pieces;
            myMap[3][8, 8] = pieces;
            myMap[3][8, 9] = pieces;

        }


        public void PrintMap(int x, int y)
        {
            string north = "  | | \n";
            string south = "  | | \n";
            string couloir = "__   __ \n   O \n__   __ \n";

            if (x == 0)
                north = "  __ \n";
            else if (x == 9)
                south = "  __ \n";
            if (y == 9)
                couloir = "__   | \n   O \n__   | \n";
            else if (y == 0)
                couloir = "|   __ \n   O \n|   __ \n";
            //Console.Clear();
            Console.Write(north + couloir + south);
        }
    }
}