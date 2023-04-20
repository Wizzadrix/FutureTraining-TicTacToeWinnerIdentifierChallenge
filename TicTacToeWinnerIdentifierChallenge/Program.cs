using System.ComponentModel.Design;
using System.Numerics;

namespace TicTacToeWinnerIdentifierChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numberMatrix =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            //PrintMatrixValues(matrix);

            string[,] stringMatrix =
     {
                { "1", "2", "O" },
                { "O", "O", "X" },
                { "O", "8", "X" }
            };

            Console.WriteLine(CheckWinner(stringMatrix));


            Console.ReadKey();
        }

        //My solution is a bit of an "overkill", since it also checks what kind of victory and who wins, not just "is there any winner"
        public static bool CheckWinner(string[,] board)
        {
            //X and O counter for diagonals left to right:
            int xCounterLr = 0;
            int oCounterLr = 0;

            //X and O counter for diagonals right to left:
            int xCounterRl = 0;
            int oCounterRl = 0;

            //all cases with a winner
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //case horizontal
                    if ((board[i, 0] == "X" && board[i, 1] == "X" && board[i, 2] == "X") || (board[i, 0] == "O" && board[i, 1] == "O" && board[i, 2] == "O"))
                    {
                        Console.WriteLine("horizontal victory for " + board[i,0]);
                        return true;
                    }
                    //case vertical
                    if ((board[0, j] == "X" && board[1, j] == "X" && board[2, j] == "X") || (board[0, j] == "O" && board[1, j] == "O" && board[2, j] == "O"))
                    {
                        Console.WriteLine("vertical victory for " + board[0,j]);
                        return true;
                    }
                    //case diagonal left to right
                    //else if ((board[1,1] == "X" && board[2,2] == "X" && board[3,3] == "X") || (board[1, 1] == "O" && board[2, 2] == "O" && board[3, 3] == "O"))

                    //case X diagonal left to righ
                    if ((board[i, j] == "X" && i == j))
                    {
                        xCounterLr++;
                        if (xCounterLr >= 3)
                        {
                            Console.WriteLine("left to right diagonal X victory");
                            return true;
                        }
                    }
                    //case O diagonal left to right
                    if (board[i, j] == "O" && i == j)
                    {
                        oCounterLr++;
                        if (oCounterLr >= 3)
                        {
                            Console.WriteLine("left to right diagonal O victory");
                            return true;
                        }
                    }

                    //case X diagonal right to left
                    if (board[j, i] == "X" && i + j == 2)
                    {
                        xCounterRl++;
                        if (xCounterRl >= 3)
                        {
                            Console.WriteLine("right to left diagonal X victory");
                            return true;
                        }
                    }
                    //case O diagonal right to left
                    if (board[j, i] == "O" && i + j == 2)
                    {
                        oCounterRl++;
                        if (oCounterRl >= 3)
                        {
                            Console.WriteLine("right to left diagonal O victory");
                            return true;
                        }
                    }
                    //note: diagonal cases could be combined

                }
            }

            //all cases without any winner
            return false;
        }

        #region bonus challenge



        //prints certain values of a given matrix (Bonus Challenge Video 91)
        private static void PrintMatrixValues(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)

            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.WriteLine(matrix[i, j]); //writes the diagonal top left bottom right

                    }

                    if (i + j == 2)
                    {
                        //Console.WriteLine(matrix[j,i]); //write the diagonal top right to bottom right
                        //Console.WriteLine(matrix[j, i]); //write the diagonal bottom left to top right
                    }

                }

                //solution //writes the diagonal top left bottom right => Have to go through matrix "backwards"/reverse
                //for (int i = 2; i >= 0; i--)
                //{
                //    for (int j = 2; j >= 0; j--)
                //    {
                //      Console.WriteLine(matrix[j, i]); //writes the diagonal top left bottom right
                //    }
                //}

            }

            #endregion bonus challenge
        }
    }
}

//Case Horizontal:

//         i  j
// 
// x x x   0  0,1,2
// 4 5 6   1  0,1,2  
// 7 8 9   2  0,1,2
//true, when all j are either all X or all O

/*
    This time, you have to write only a checker for the game. It will be a method that takes a 2D array and returns a boolean. If there is a winner, it returns true otherwise false.
    
    We use "X" and "O" as signs of our players. The empty places will be filled with numbers from 1 to 9.
    
    You have to check 3 types of cases:
    horizontal;
    vertical;
    diagonal;
    
    Hint: you can use more than one condition inside of one if, and don't hesitate to use loop; 

*/