using DungeonLibrary;
using MonsterLibrary;
using System.Media;

namespace SpaceDungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@" 
                 <<<<<-=-=-= SpaceDungeon =-=-=->>>>>


    .    * .    . *.    * .    . *    .    * .    . *.    * .    . *
       * .  * .  .          |-----------| .  .  * .  .   * .  * .  .    * .
                .  *   .  . |===========|  .  * .   . .  *  .   .      . *
           |            ____|,---------.|___--~\__--. * .  .   * .   .  .    * .
    #---,'''''`-_   `  /    |`---------'|    `       \    ,--~~  __-/~~--'_______
       | ~~~~~~~~~|---~---/=| __________|=\---~-----~-----| .--~~  |  .__ |  ____|
     -[|.-- ===|#####|-| |@@@@|+-+@@@| |]=###|/-++++-[| ||||___+_.  | `===='-.
     -[| '==~' |#####|-| |@@@@|+-+@@@| |]=###|\-++++-[| ||||~~~+~'  | ,====.-'
       | _________ | ---u-- -\=| ~~~~~~~~~~~|=/ ---u---- - u---- -| '--__ |'~~||
        \       /= -   `    |,---------.|  .    ` . *`    `--__  ~~-\__--.~~~~~'
--- =:===\     /    .  . *  |`---------'|      .    .       .  ~~--_/~~--'
     -- <:\___/ --   .      |===========|     *  .   .   *   *  .   .   * 
                  .  .. *   |-----------| *  .   .   *   *  .   .   * 
  *  .   .   *   *  .   .   |___________| * .  * .  .   * .  * .  .    * .  * .  
         __  .   .   .    *    *    .    *     *    .    *    *    .    *
 .  .    \ \_____      * .    . *    .    * .    . *.    * .    . *
      ###[==_____>    .    *    *    .    *     *    .    *    *    .    *
         /_/ _   * .    . *    .    * .    . *.    * .    . *   .   *
    .       \ \_____  .    * .    . *.    * .    . *    .    * .    . *.    
         ###[==_____>    * .  * .  .    * .  * .  .  * .  * .  .    * .  * .
 .          /_/    *   *  .   .   *   *  .   .   *     *  .   .   *   *  . ");

            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "spacedungeon.wav";
            musicPlayer.PlayLooping();//will repeat when finished. .Play() plays once and stops.


            //implement Monster Tiers
            //implement vending machine perks
            //fix player info
            //fix player death
            //add more attributes to races
            //make weapons selectable(?)
            

            int score = 0;
            int invGold = 30;


            Weapon laserGun = new Weapon(10, 6, "Laser Gun", 8, false, WeaponType.LaserGun);
            Weapon laserSword = new Weapon(8, 6, "Laser Sword", 16, false, WeaponType.LaserSword);

            Console.WriteLine("No one can hear you scream in space.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press 'Enter' to Continue.");
            Console.ResetColor();


            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n Hey! You're finally awake! We need your help! " +
                "What's your name?\n");
            string userName = Console.ReadLine();
            Console.WriteLine("\n\nWhat alien race are you?\n");
            var races = Enum.GetValues(typeof(Race));
            int index = 1;
            foreach (var race in races)
            {
                Console.WriteLine($"{index}) {race}");
                index++;
            }
            //9 items or less, you can use a Console.ReadKey90. any more, and you'll need to use a ReadLine().
            int userInput = int.Parse(Console.ReadLine()) - 1;//subtracting 1 to make it zero-based
            Race userRace = (Race)userInput;
            Console.WriteLine(userRace);

            Player player = new Player(userName, 90, 5, 40, 40, userRace, laserGun);

            Console.Clear();

            Console.WriteLine("Well, " + userName + ", to fill you in on the situation, you're a prisoner aboard a space dungeon.\n" +
                "You got knocked out when space monsters started boarding our ship.They took over the flight deck\n" +
                "So you must head there and regain control of the ship. I must warn you, the \n" +
                "enemies only get stronger the closer you get so be sure to visit the\n" +
                "vending machine between fights. Good luck.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press 'Enter' to Continue.");
            Console.ResetColor();

            Console.ReadLine();
            Console.Clear();

            bool exit = false;

            bool exitMenu = false;


            #region Encounter (Next Room)
            do
            {
                Console.WriteLine("\nPlease select an option: \n" +
                    "N) Next Room\n" +
                    "V) Vending Machine\n" +
                    "E) Exit\n\n");
                string userChoice1 = Console.ReadKey(true).Key.ToString();
                Console.Clear();

                switch (userChoice1)
                {
                    case "N":

                        string room = GetRoom();
                        Console.WriteLine(room);

                        Monster monster = Monster.GetMonster();
                        Console.WriteLine("You've encountered " + monster.Name + "!");


                        bool reload = false;

                        do
                        {
                            Console.WriteLine("\nPlease choose an action:\n" +
                                "A) Attack\n" +
                                "P) Player Info\n" +
                                "M) Monster Info\n" +
                                "R) Run Away\n" +
                                "E) Exit\n");
                            string userChoice2 = Console.ReadKey(true).Key.ToString();
                            Console.Clear();
                            switch (userChoice2)
                            {
                                case "A":
                                    Console.WriteLine("Attack!");
                                    Combat.DoBattle(player, monster);
                                    if (monster.Life > 0 && score < 4)
                                    {
                                        Combat.DoAttack(monster, player);
                                    }
                                    if (monster.Life <= 0)
                                    {
                                        score++;
                                        invGold += 10;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nYou killed {monster.Name}!\n\n");
                                        Console.ResetColor();

                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Press 'Enter' to Continue.");
                                        Console.ResetColor();
                                        reload = true;
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    if (player.Life <= 0)
                                    {
                                        Console.WriteLine("You died!\a");
                                        exit = true;
                                    }
                                    break;
                                case "P":
                                    Console.WriteLine("Player Info");
                                    Console.WriteLine(player);
                                    Console.WriteLine("Monsters Defeated: " + score);
                                    Console.WriteLine(invGold + " Gold");
                                    break;

                                case "M":
                                    Console.WriteLine("Monster Info");
                                    Console.WriteLine(monster);
                                    break;
                                case "R":
                                    Console.WriteLine("Run Away");
                                    Console.WriteLine($"{monster.Name} attacks you as you flee!");
                                    Combat.DoAttack(monster, player);
                                    //reload = false;
                                    Console.Clear();
                                    break;
                                case "E":
                                    Console.WriteLine("The space monsters win this time.");
                                    exit = true;
                                    break;
                                default:
                                    Console.WriteLine("Please try again...");
                                    break;
                            }
                        } while (!exit && !reload);

                        break;
                    case "V":
                        bool reloadVend = false;
                        do
                        {
                            int v1 = 20;
                            int v2 = 30;
                            int v3 = 40;
                            Console.WriteLine($"What would you like to do?\n" +
                                "1) 20 Gold: Heal +30hp\n" +
                                "2) 30 Gold: Increase Damage + 10\n" +
                                "3) 40 Gold: Increase Max Health + 20\n" +
                                "4) Go Back\n\n" +
                                "You have " + invGold + " Gold\n");



                            string vendChoice = Console.ReadLine();
                            Console.Clear();

                            if (vendChoice == "1" && invGold >= v1)
                            {

                                invGold -= 20;
                                Console.WriteLine("You healed yourself");

                                reloadVend = true;
                            }
                            if (vendChoice == "2" && invGold >= v2)
                            {
                                invGold -= 30;
                                Console.WriteLine($"{laserGun.IncDamage}");
                                Console.WriteLine("Damage has been increased!");
                            }
                            if (vendChoice == "3" && invGold >= v3)
                            {
                                Console.WriteLine("Your Max Health has been increased!");
                            }
                            else if (vendChoice == "4")
                            {
                                reloadVend = true;
                            }
                        } while (!reloadVend);

                        break;
                }
            } while (!exitMenu);
            #endregion
        }
        private static string GetRoom()
        {
            string[] rooms =
            {
                "There's space debris all over this room",
                "You're in the hallway",
                "You're in the hangar",
                "Why is there blood everywhere?",
                "You found a spacedungeon cell",
                "There's sticky stuff everywhere!"

            };
            return rooms[new Random().Next(rooms.Length)];

        }
    }
}