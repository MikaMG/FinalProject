using System;

namespace Finals
{
    // Group : Mikael Garillon- Issa Dayekh- Najwa Chemaissani- Zahra Ayoub
    //We chose to code the XO game, we thought it would be a fun way to put our skills to the test while staying within the required conditions.
    //First we had to consider the needed conditions and functions and requirements in order to make this possible, then we had to print the board
    //And then we had to save the players' choices and display them.

    internal class Program
    {


        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int playerTurn = 1; // Player 1 starts

        static void Main()
        {
            do
            {
                Console.Clear(); // Clear the console on each turn
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");

                // Display the current board
                Console.WriteLine("     |     |      ");
                Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
                Console.WriteLine("__|_|__ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
                Console.WriteLine("__|_|__ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
                Console.WriteLine("     |     |      ");

                int choice;
                bool validInput;

                // Get the player's move
                do
                {
                    Console.WriteLine($"\nPlayer {playerTurn}, enter a number (1-9) to place your mark:");
                    validInput = int.TryParse(Console.ReadLine(), out choice);

                    if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        validInput = false;
                    }

                } while (!validInput);

                // Place the player's mark on the board
                char playerMark = (playerTurn % 2 == 0) ? 'O' : 'X';
                board[choice - 1] = playerMark;

                // Check for a winner or a tie
                if (IsWinner())
                {
                    Console.Clear();
                    Console.WriteLine($"Player {playerTurn} wins!");
                    break;
                }
                else if (IsBoardFull())
                {
                    Console.Clear();
                    Console.WriteLine("It's a tie!");
                    break;
                }

                // Switch to the other player's turn
                playerTurn = (playerTurn == 1) ? 2 : 1;

            } while (true);

            Console.ReadLine(); // Keep console open until a key is pressed
        }

        // Check if there is a winner
        static bool IsWinner()
        {
            // Check rows, columns, and diagonals
            return (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
                    CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
                    CheckLine(0, 4, 8) || CheckLine(2, 4, 6));
        }

        // Check if a line (row, column, or diagonal) has the same mark
        static bool CheckLine(int pos1, int pos2, int pos3)
        {
            return (board[pos1] == board[pos2] && board[pos2] == board[pos3]);
        }

        // Check if the board is full (tie)
        static bool IsBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false; // At least one cell is empty
            }
            return true; // All cells are filled
        }
    }

}