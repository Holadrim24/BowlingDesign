using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BowlingDesign
{
    //Detta är en Singleton-klass som hanterar att spelet ska skapas/att spelare ska läggas till
    //Skapar bara en global instans av klassen som kan användas i hela applikationen
    public class GameManager
    {
        private static GameManager _instance;
        private static readonly object _lock = new();
        public static GameManager Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new GameManager();
                }
            }
        }

        //Detta är konstruktorn
        private GameManager() { } 

        //Denna metoden skapar upp spelet och registrerar spelarna (de sparas inte)
        public void CreateGame()
        {
            Console.WriteLine("------------------------------------\n " +
                              "🎳 Välkommen till Bowlinghallen! 🎳\n" +
                              "------------------------------------");
            Console.WriteLine("Tryck på Enter för att starta spelet");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                //Loopar igenom tills användaren trycker på Enter
            }
            Console.Write("Ange Spelare 1: ");
            string player1 = Console.ReadLine()!;
            Console.Write("Ange Spelare 2: ");
            string player2 = Console.ReadLine()!;

            //Om användaren inte har angett två spelare så skrivs ett felmeddelande ut
            if (player1 == "" || player2 == "")
            {
                Console.WriteLine("Du måste ange två spelare!");
                return;
            }
            User firstPlayer  = new(player1);
            User secondPlayer = new(player2);

            //Här skapas en instans av BowlingGame-klassen och skickar med spelarna till Program.cs
            BowlingGame game = new(firstPlayer, secondPlayer);
            game.DecideWinner();
        }
    }
}
