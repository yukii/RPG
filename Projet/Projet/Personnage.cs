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


        public static void AsciiFight(string name)
        {
            switch (name)
            {
                case "Loic":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@"   /
                        _,.------....___,.' ',.-.
                     ,-'          _,.--''       |
                   ,'         _.-'.
                  /   ,     ,'                   `
                 .   /     /                     ``.
                 |  |     .                       \.\
       ____ | ___._.  | __               \ `.
     .'    `---""       ``''-.--'''`  \               .  \
    .  ,            __               `              |   .
    `,'         ,-''.               \             | L
   ,'          '    _.'                -._          /    |
  ,`-.    ,'.   `--'                      >.      ,'     |
 . .'\'   `-'       __    ,  ,-.         /  `.__.-      ,'
 ||:, .           ,'  ;  /  / \ `        `.    .      .' /
 j |:D  \          `--'  ' ,'_  . .         `.__, \   , /
 / L:_ |                 .  '' :_;                `.'.'
.    ""'                  """"''                    V
 `.                                 .    `.   _,..  `
   `,_.    ._,-'/    .. `,'   __  `
    ) \`._ ___....----''  ,'   .'  \ |   '  \  .
/   `. '`-.--''         _,' ,'     `---' |    `./  |

._  `""'--.._____..--'   ,             ' |

| .' `. `-.                /-.           /          ,
| `._.'    `,_            ;  /         ,'.

.'          /| `-.        . ,'         ,           ,
 '-.__ __ _,','    '`-..___; -...__   ,.'\ ____.___.'
 `" + "'^--'..'   '-`-^-''--    `-^ -'`.'''''''`.,^.`.--''");
                    
                    break;
                case "Matthias":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@"   
                      ,..__
                      |  _  `--._                                  _.--\'\'\'`.
                      |   |._    `-.        __________         _.-'    ,|' |
                      |   |  `.     `-..--\'\'_.        `\'\'-..,-'  ,' |  |
                      L   |    `.        ,-'                      _,'   |  |
                       .  |     ,'     ,'            .           '.     |  |
                      |   |   ,'      /               \\            `.  |  |
                       |  . ,'      ,'                |              \\ /  j
                       `   \'       ,                 '               `   /
                        `,          |                ,'                  '+
                         /          |             _,'                     `
                        /     .-\'\'\''L          ,-' \\  ,-'\'\'\'\'`-.    `
                       j    ,' ,.+--.\\        '    ',' ,.,-\'--._`.          \\
                      |   / .'  L    `.        _.'/ .'  |      \\ \\          .
                     j   | | `--'     |`+-----'  . j`._,'       L |         |
                     |   L .          | |        | |            | |         |
                     |   `\\ \\        / j         | |            | |         |
                     |     \\ `-.._,.- /           . `         .'  '         |
                     l      `-..__,.-'             `.`-.....-' _.'          '
                     '                               `-.....--'            j
                      .                  -.....                            |
                       L                  `---'                            '
                        \\                                                 /
                         ` \\                                        ,   ,'
                          `.`.    |                        /      ,'   .
                            . `._,                        |     ,'   .'
                             `.                           `._.-'  ,-'
                        _,-\'\'\'\'`-,                             _,'\'-.._
                      ,'          `-.._                     ,-'        `.
                     /             _,' `\'-..___     _,..--\'`.            `.
                    |         _,.-'            `\'\'\''       `-._          \\
                    `-....---'                                   `-.._      |
                                                                      `--...'");
                    break;
                case "Damien":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(@"
                                                                            ,-.___.._
                     _     `. `.                                    _,-\'\'\'      ',._
                    `.`.      `.\\                                _,'         _..-'  `.
                      `._\\       `.                            ,'         _,'_,.-'-.  \\
                          `.       `.                        ,'        ,-',-\'       \\  .
                            `.       \\                      /  _,----\'',-'           L  L
                              `.      \\                   ,' _.--\'-.  [              |  |
                                `.     .                 / ,'       | |     _..---../   |
                                  .     L               / /         | j ,.-'        `   |
                                   \\    .              ' /          j ,'             |  |
                                    \\    .            ' /          ' /               |  |
                                     \\   l           / /          /,'                j  '
                                      L__L._        / /          +'      __,........'  j
                                    ,'   '  \'`.    / /         .' _,.--'\'           \\  |
                                   /,\'\'-.      `. ' '        _/.-'                  | F
                                  /|   / l       . /       ,'                       | |
                                 | |  /  |       ]'      ,'                         | |
                                ,._\\\''   |       |     ,'-'\'\'\'\'\'\'\'\'\'\'\'\'\''----.._    / |
                                |  \\`.._,'       F  _,'                         `--'  |
                                `..'           _/ ,:_____                         L   |
                                  `..          .-'       `'--.._                   | j
                                _,. /,---.       \\              `--..              | |
                               F  <j-.'   `       ._                 `\'-._        j  '
                               |  <|`,.    |       `L._                   `..   _, ,'
                               `..<|`.___,'        |.  `-.                   Y\'' _.
                                  `L               | `.   `-.._____________,',.-'
                                    `.            .Y   \\      `\'\'.\'\'\'\'\'.  .\''
                                      `.        ,' |\\   `.        `+-._ \\  |
                                        `,--. -'   | .    `.       `   `.| |
                                        /    //    |  \\    ``-..___/     | |
                                       j    .l     |   .    F   \\   `   F  |
                                       |    ||     |    `   `    .   ` ,  /
                                       |    ||    F      `-.|     . _,' _'
                                       |   / |    |       `._`-----'  ,'
                                       |  /  |   /           `-------'
                                       l /   \\_,'
                                        \");

                    break;
                case "Renaud":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"  
                    _
                   /_'. _
                 _   \ / '-.
                < ``-.;),--'`
                 '--.</()`--.
                   / |/-/`'._\
                   |/ |=|
                      |_|
                 ~`   |-| ~~      ~
             ~~  ~~ __|=|__   ~~
           ~~   .-'`  |_|  ``""-._   ~~
            ~~.'      |=|    O    '-.  ~
              |      `'''`  <|\      \   ~
          ~   \              |\      | ~~
               '-.__.--._    |/   .-'
                    ~~   `--...- '`    ~~
            ~~~~
                   ~~~~~");
                    break;
                case "Clement":
                    Console.WriteLine(@"
  .     '     ,
    _________
 _ /_|_____|_\ _
   '. \   / .'
     '.\ /.'
       '.'");
                    break;
                case "Nathalie":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"
           ,     ,
           |\.'./|
          /      \
         / _   _  \   ______
         \== Y ==/ ''`      `.
         /`-._ ^ _.- '\     ,-  . \
        /     `     \   /     \ \
        \  \.___./  / _ _\     / /
         `, \   / , '  (,-----' /
           ""' '""     '------'");
                    break;
                case "Marie-Pierre":
                    Console.WriteLine("Image not found");
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }

    }
}
