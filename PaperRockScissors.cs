namespace PaperRockScissors;
class Program
{
    static void Main(string[] args){
        Console.WriteLine();
        Console.WriteLine("****Rock Paper Scissors, Start!!****");

        int startingPoints= 5;
        HumanPlayer human = new HumanPlayer(startingPoints);
        ComputerPlayer computer = new ComputerPlayer();

        int round= 1;
        int totalRound= 10;
        bool gameFinished= false;
        while (round <= totalRound && !gameFinished){
            Console.WriteLine("You have " + human.GetPoints()+ " points");
            string hDecision = human.HumanDecision();
            string cDecision = computer.ComputerDecision();

            if (hDecision == cDecision){
                Console.WriteLine("This round is a Tie!");
                Console.WriteLine();
            }
            else if (hDecision == "rock" && cDecision == "scissors" || hDecision == "paper" && cDecision == "rock" || hDecision == "scissors" && cDecision == "paper"){
                Console.WriteLine("You win this round!");
                Console.WriteLine();
                human.WinRound();
            } 
            else{
                Console.WriteLine("You lose this round!");
                Console.WriteLine();
                human.LoseRound();
            }
            if (human.GetPoints()<=0){
                Console.WriteLine("Sorry, you don't have enough points, thanks for playing.");
                Console.WriteLine("Press r to restart, or any other key to exit: ");//added r for restart when points are at 0 to quickly reset the game and start from 0
                string restart = Console.ReadLine().ToLower();
                if(restart=="r"){
                    human= new HumanPlayer(startingPoints);
                    round= 0;
                    gameFinished= false;
                    Console.WriteLine();
                    Console.WriteLine("****Rock Paper Scissors, Start!!****");
                }
                else{
                    break;
                }
            }
            else{
            Console.WriteLine("--> Play again? Input y to continue, or n to exit: ");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain=="n"){
                break;
            }
            round++;
            Console.WriteLine();
            Console.WriteLine("****Rock Paper Scissors, Start!!****");
            }
        }
        Console.WriteLine("Thank you for playing!");
    }
}
class HumanPlayer{
    private int points;
    public HumanPlayer(int initial){
        points = initial;
    }
    public int GetPoints(){
        return points;
    }
    public void WinRound(){
        points+=5;
    }
    public void LoseRound(){
        points-=5;
    }
    public string HumanDecision(){
        Console.WriteLine("Please input your choice: rock, paper, or scissors.");
        string input= Console.ReadLine().ToLower();
        while (input != "rock" && input != "paper" && input != "scissors"){
            Console.WriteLine("Invalid input, enter choice again.");
            input = Console.ReadLine().ToLower();
        }
        Console.WriteLine();
        Console.WriteLine("--> Your Decision: "+ input);
        return input;
    }
}
class ComputerPlayer{
    public string ComputerDecision(){
        Random rnd = new Random();
        int rnd_num = rnd.Next(0,3);
        string[] choices = {"rock","paper","scissors"};
        Console.WriteLine("--> Computer Decision: "+choices[rnd_num]);
        Console.WriteLine();
        return choices[rnd_num];
    }
}