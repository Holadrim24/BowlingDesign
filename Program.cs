using System.Runtime.InteropServices;

namespace BowlingDesign
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Om det finns en instans av GameManager så skapas ett nytt spel
            //Om användaren svarar 'j' nedan så loopar spelet tillbaka hit
            while (true)
            {
                Console.Clear();
                //Här anropas CreateGame-metoden från GameManager-klassen    
                GameManager.Instance.CreateGame();
                Thread.Sleep(2000);
                Console.WriteLine("Vill du spela igen? (J/N)");
                string playAgain = Console.ReadLine()!.ToLower();

                //Om användaren vill fortsätta spela så bryts loopen
                if (playAgain != "j") break;
            }
        
            //Applikationen väntar 2 sekunder innan den stängs
            Console.WriteLine("Spelet stängs nu, tack för att du spelade!");
            Thread.Sleep(2000);
            //Stänger konsolfönstret
            Environment.Exit(0);
        }
    }
}
