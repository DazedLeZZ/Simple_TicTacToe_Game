using System;

namespace TicTacToe
{
    class Menu_Screen
    {
        static void Main(string[] args)
        {
            char playAgain;

            do
            {
                Tic_Tac_Toe instance = new();
                instance.StartGame();

                Console.WriteLine();
                Console.WriteLine("To play Agian enter 'y' otherwise enter 'n'");
                playAgain = char.Parse(Console.ReadLine());
            }
            while (playAgain == 'y');

        }
    };

    public class Tic_Tac_Toe
    {
        public char markSelectedByP1;
        public char markSelectedByP2;
        public string currentPlayerTurn;
        public bool winner = false;
        public char[] gridSpace = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        Interface instance = new();

        public void StartGame()
        {
            ChooseMark();
            while (winner != true || (winner == false && ((gridSpace[0] == 'X' || gridSpace[0] == 'O') && (gridSpace[1] == 'X' || gridSpace[1] == 'O') && (gridSpace[2] == 'X' || gridSpace[2] == 'O') && (gridSpace[3] == 'X' || gridSpace[3] == 'O') && (gridSpace[4] == 'X' || gridSpace[4] == 'O') && (gridSpace[5] == 'X' || gridSpace[5] == 'O') && (gridSpace[6] == 'X' || gridSpace[6] == 'O') && (gridSpace[7] == 'X' || gridSpace[7] == 'O') && (gridSpace[8] == 'X' || gridSpace[8] == 'O'))))
            {
                currentPlayerTurn = "Player1";
                instance.DisplayGrid(gridSpace);
                MarkGridSpace();


                winner = WinCheck();
                instance.DisplayGrid(gridSpace);
                if (winner == false && ((gridSpace[0] == 'X' || gridSpace[0] == 'O') && (gridSpace[1] == 'X' || gridSpace[1] == 'O') && (gridSpace[2] == 'X' || gridSpace[2] == 'O') && (gridSpace[3] == 'X' || gridSpace[3] == 'O') && (gridSpace[4] == 'X' || gridSpace[4] == 'O') && (gridSpace[5] == 'X' || gridSpace[5] == 'O') && (gridSpace[6] == 'X' || gridSpace[6] == 'O') && (gridSpace[7] == 'X' || gridSpace[7] == 'O') && (gridSpace[8] == 'X' || gridSpace[8] == 'O')))
                {
                    break;
                }
                else if (winner == false)
                {
                    currentPlayerTurn = "Player2";
                    instance.DisplayGrid(gridSpace);
                    MarkGridSpace();
                    winner = WinCheck();
                    instance.DisplayGrid(gridSpace);
                }
            }
            if (winner == true)
            {
                Console.WriteLine();
                Console.WriteLine("{0} is the WINNER!!!", currentPlayerTurn);
            }
            else if (winner == false && ((gridSpace[0] == 'X' || gridSpace[0] == 'O') && (gridSpace[1] == 'X' || gridSpace[1] == 'O') && (gridSpace[2] == 'X' || gridSpace[2] == 'O') && (gridSpace[3] == 'X' || gridSpace[3] == 'O') && (gridSpace[4] == 'X' || gridSpace[4] == 'O') && (gridSpace[5] == 'X' || gridSpace[5] == 'O') && (gridSpace[6] == 'X' || gridSpace[6] == 'O') && (gridSpace[7] == 'X' || gridSpace[7] == 'O') && (gridSpace[8] == 'X' || gridSpace[8] == 'O')))
            {
                Console.WriteLine();
                Console.WriteLine("It is a DRAW", currentPlayerTurn);
            }

        }


        public void ChooseMark()
        {
            bool runLoopAgain = true;

            while (runLoopAgain == true)
            {
                Console.Clear();
                Console.WriteLine("Player1 Select 'X' or 'O'");
                markSelectedByP1 = char.Parse(Console.ReadLine());

                if (markSelectedByP1 == 'X' || markSelectedByP1 == 'x')
                {
                    markSelectedByP1 = 'X';
                    markSelectedByP2 = 'O';
                    runLoopAgain = false;
                }
                else if (markSelectedByP1 == 'O' || markSelectedByP1 == 'o')
                {
                    markSelectedByP1 = 'O';
                    markSelectedByP2 = 'X';
                    runLoopAgain = false;
                }
                else
                {
                    Console.WriteLine("Invalid Mark Selected");
                    runLoopAgain = true;
                    Console.WriteLine();
                    Console.WriteLine("Press any key to Try Again");
                    Console.ReadKey();
                }
            }
            

            Console.Clear();

            Console.WriteLine("Player1 Selected {0}", markSelectedByP1);
            Console.WriteLine("Player2's Mark is: {0}", markSelectedByP2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to Continue");
            Console.ReadKey();

        }



        public void MarkGridSpace()
        {        
            bool runLoopAgain = true;


            Console.WriteLine();
            Console.WriteLine("{0} Select Space Number to Mark", currentPlayerTurn);
            int selectedSpace = int.Parse(Console.ReadLine());

            while(runLoopAgain == true)
            {
                if (selectedSpace >= 1 && selectedSpace <= 9)
                {
                    if(currentPlayerTurn == "Player1")
                    {
                        gridSpace[selectedSpace - 1] = markSelectedByP1;
                    }
                    else
                    {
                        gridSpace[selectedSpace - 1] = markSelectedByP2;
                    }
                    runLoopAgain = false;
                }
                else
                {
                    Console.WriteLine("Invalid Space Number Selected");
                    runLoopAgain = true;
                }
            }
        }

        public bool WinCheck()
        {
            if (gridSpace[0] == gridSpace[1] && gridSpace[1] == gridSpace[2])
            {
                winner = true;
            }
            else if (gridSpace[3] == gridSpace[4] && gridSpace[4] == gridSpace[5])
            {
                winner = true;
            }
            else if (gridSpace[6] == gridSpace[7] && gridSpace[7] == gridSpace[8])
            {
                winner = true;
            }
            else if (gridSpace[0] == gridSpace[3] && gridSpace[3] == gridSpace[6])
            {
                winner = true;
            }
            else if (gridSpace[1] == gridSpace[4] && gridSpace[4] == gridSpace[7])
            {
                winner = true;
            }
            else if (gridSpace[2] == gridSpace[5] && gridSpace[5] == gridSpace[8])
            {
                winner = true;
            }
            else if (gridSpace[0] == gridSpace[4] && gridSpace[4] == gridSpace[8])
            {
                winner = true;
            }
            else if (gridSpace[2] == gridSpace[4] && gridSpace[4] == gridSpace[6])
            {
                winner = true;
            }
            return winner;
        }


    };

    public class Interface
    {
            
        public void DisplayGrid(char[] gridSpace)
        {
            Console.Clear();
            Console.WriteLine("---------TIC TAC TOE---------");
            Console.WriteLine();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridSpace[0], gridSpace[1], gridSpace[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridSpace[3], gridSpace[4], gridSpace[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridSpace[6], gridSpace[7], gridSpace[8]);
            Console.WriteLine("     |     |      ");

        }
      



    };






}


