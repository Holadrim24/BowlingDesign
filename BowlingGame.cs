using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingDesign
{
    public class BowlingGame
    {
        public User Player1 { get; }
        public User Player2 { get; }

        private Random random = new(); 

        public BowlingGame(User player1, User player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        //Denna metoden används för att bestämma en vinnare och rada upp varje omgång av spelet
        public void DecideWinner()
        {
            int firstScore = 0;
            int secondScore = 0;

            int totalRounds = 10;
            int currentRound = 0;

            //En while-loop som loopar igenom antalet rundor och slumpar fram poängen för varje runda
            while (currentRound < totalRounds)
            {
                //Om det är första rundan så rensas konsolen för att underlätta läsbarhet
                if (currentRound == 0)
                {
                    Console.Clear();
                }

                currentRound++;

                Console.WriteLine($"-------" +
                                  $"Runda {currentRound}" +
                                  $"-------");
                int firstBowl = random.Next(0, 11);
                int secondBowl = random.Next(0, 11);

                firstScore += firstBowl;
                secondScore += secondBowl;

                Console.WriteLine($"{Player1.Name} fick {firstBowl} poäng denna omgången.");
                Console.WriteLine($"{Player2.Name} fick {secondBowl} poäng denna omgången. ");

                Thread.Sleep(2000);
            }

            //Om den sista rundan har spelats ut så skrivs poängen ut
            if (currentRound == totalRounds)
            {
                Console.Clear();

                Console.WriteLine($"{Player1.Name} slutade på {firstScore} poäng");
                Console.WriteLine($"{Player2.Name} slutade på {secondScore} poäng");

                //If-satser för att bestämma vinnaren/om det blev oavgjort
                if (firstScore > secondScore)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"{Player1.Name} vann matchen! 🏆");
                    Thread.Sleep(2000);
                    Console.WriteLine("Tack för att ni spelade!");
                }
                else if (secondScore > firstScore)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"{Player2.Name} vann matchen! 🏆");
                    Thread.Sleep(2000);
                    Console.WriteLine("Tack för att ni spelade!");
                }
                else
                {
                    Console.WriteLine("Det blev oavgjort!");
                    Thread.Sleep(2000);
                    Console.WriteLine("Tack för att ni spelade!");
                }

            }
        }
    }
}
