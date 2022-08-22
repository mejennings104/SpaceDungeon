using DungeonLibrary;
using MonsterLibrary;

namespace SpaceDungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-=-=-=SpaceDungeon=--=-=-");

            int score = 0;
            int invGold = 10;


            Weapon laserGun = new Weapon(10, 6, "Laser Gun", 8, false, WeaponType.LaserGun);
            Weapon laserSword = new Weapon(8, 6, "Laser Sword", 16, false, WeaponType.LaserSword);

            Console.WriteLine("No one can hear you scream in space.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press 'Enter' to Continue.");
            Console.ResetColor();


            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Hey! You're finally awake! We need your help!" +
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

            Console.WriteLine("Well, " + userName + ", to fill you in on the situation,\n" +
                "space monsters have boarded our spaceship and taken over the flight deck.\n" +
                "You must head there and regain control of the ship. I must warn you, the \n" +
                "enemies only get stronger the closer you get. Good luck.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press 'Enter' to Continue.");
            Console.ResetColor();

            Console.ReadLine();
            Console.Clear();

            bool exit = false;


            do
            {
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
                            if (monster.Life > 0)
                            {
                                Combat.DoAttack(monster, player);
                            }
                            if (monster.Life <= 0)
                            {
                                score++;
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
                            break;

                        case "M":
                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);
                            break;
                        case "R":
                            Console.WriteLine("Run Away");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            reload = true;
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
            } while (!exit);
           
        }
        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is a room",
                "The room is not a room"

            };
            return rooms[new Random().Next(rooms.Length)];

        }
    }
}