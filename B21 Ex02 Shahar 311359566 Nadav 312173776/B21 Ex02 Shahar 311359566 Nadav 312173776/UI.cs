using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    public class UI
    {
        public static void BoardPrinter(Board i_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder rowBuilder = new StringBuilder();

            for (int i = 1; i <= i_Board.BoardSize; i++)
            {
                rowBuilder.Append("   " + i);
            }

            Console.WriteLine(rowBuilder);

            for (int i = 0; i < i_Board.BoardSize; i++)
            {
                rowBuilder.Clear();
                rowBuilder.Append((i + 1) + "|");
                for (int j = 0; j < i_Board.BoardSize; j++)
                {
                    if (i_Board.BoardMatrix[i, j] == Move.eTurn.EMPTY)
                    {
                        rowBuilder.Append("   |");
                    }
                    else
                    {
                        rowBuilder.Append($" {i_Board.BoardMatrix[i, j]} |");
                    }
                }

                Console.WriteLine(rowBuilder);
                rowBuilder.Clear();
                rowBuilder.Append(" =").Append('=', 4 * i_Board.BoardSize);
                Console.WriteLine(rowBuilder);
            }
        }

        public static Move GetPlayerMove(out bool o_ContinueGame)
        {
            Move playerMove = null;
            o_ContinueGame = true;
            bool checking = true;
            while (checking)
            {
                Console.WriteLine("Please enter your row number and column number seprated by a space");
                Console.WriteLine("If you like to Quit enter just Q");
                string moveString = Console.ReadLine();
                string[] inputs = moveString.Split(' ');
                int[] parsedInts = new int[2];
                if (moveString.Equals("Q"))
                {
                    o_ContinueGame = !CheckForGameQuit();
                    if (o_ContinueGame)
                    {
                        continue;
                    }
                    else
                    {
                        checking = false;
                    }
                }

                if (o_ContinueGame)
                {
                    if(!IsValidInputs(inputs, out parsedInts))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    checking = false;
                    playerMove = new Move(parsedInts[0] - 1, parsedInts[1] - 1);
                }
            }

            return playerMove;
        }

        private static bool IsValidInputs(string[] i_Inputs, out int[] o_parsedInts)
        {
            bool valid = true;

            if(i_Inputs.Length != 2)
            {
                valid = false;
            }

            int[] parsedInts = new int[2];

            if (valid)
            {
                for(int i = 0; i < i_Inputs.Length; i++)
                {
                    if (!int.TryParse(i_Inputs[i].ToString(), out parsedInts[i]))
                    {
                        valid = false;
                    }
                }
            }

            o_parsedInts = parsedInts;

            return valid;
        }

        public static int GetBoardSizeFromPlayer()
        {
            Console.WriteLine("Please enter the size of board (3 to 9)");
            string boardSizeString = Console.ReadLine();
            bool validInput = int.TryParse(boardSizeString, out int boardSize);

            while (!validInput || (boardSize < 3 || boardSize > 9))
            {
                Console.WriteLine("Invalid size, please enter the size of board (3 to 9)");
                boardSizeString = Console.ReadLine();
                validInput = int.TryParse(boardSizeString, out boardSize);
            }

            return boardSize;
        }

        public static bool CheckIfMultiplayer()
        {
            Console.WriteLine("Please choose number of human players (1/2)");
            string numOfPlayersString = Console.ReadLine();
            bool multiplayer = false;
            bool validInput = int.TryParse(numOfPlayersString, out int numOfPlayers);
            while (!validInput || (numOfPlayers < 0 || numOfPlayers > 2))
            {
                Console.WriteLine("Invalid number of players, please choose number of human players (1/2)");
                numOfPlayersString = Console.ReadLine();
                validInput = int.TryParse(numOfPlayersString, out numOfPlayers);
            }

            if (numOfPlayers == 2)
            {
                multiplayer = true;
            }

            return multiplayer;
        }

        public static bool PlayMultiplayer(Board io_Board)
        {
            BoardPrinter(io_Board);
            bool gameTied = false;
            bool continueGame = true;
            while (!gameTied)
            {
                Console.WriteLine($"It is now {Move.GetTurn()} turn");
                Move cur_move = GetPlayerMove(out continueGame);
                if (!continueGame)
                {
                    break;
                }

                while (!io_Board.UpdateBoard(cur_move))
                {
                    Console.WriteLine("Ilegal Move, please enter a new move");
                    cur_move = GetPlayerMove(out continueGame);
                    if (!continueGame)
                    {
                        break;
                    }
                }

                BoardPrinter(io_Board);
                if (io_Board.CheckLose())
                {
                    Move.eTurn winner = Move.eTurn.X;
                    if (Move.GetTurn() == Move.eTurn.X)
                    {
                        winner = Move.eTurn.O;
                    }

                    Console.WriteLine($"You lost! {winner} Wins!");
                    break;
                }

                gameTied = io_Board.CheckTie();
                Program.TurnNum++;
            }

            if (gameTied)
            {
                Console.WriteLine("The game is tied, nobody wins");
            }

            if (continueGame)
            {
                continueGame = CheckForNewGame();
            }

            return continueGame; 
        }

        public static bool PlayVsMachine(Board io_Board)
        {
            BoardPrinter(io_Board);
            bool gameTied = false;
            bool continueGame = true;
            while (!gameTied)
            {
                if (Move.GetTurn() == Move.eTurn.X)
                {
                    Console.WriteLine("It is now your turn");
                    Move cur_move = GetPlayerMove(out continueGame);
                    if (!continueGame)
                    {
                        break;
                    }

                    while (!io_Board.UpdateBoard(cur_move))
                    {
                        Console.WriteLine("Ilegal Move, please enter a new move");
                        cur_move = GetPlayerMove(out continueGame);
                        if (!continueGame)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    io_Board.MakeMachineMove();
                }

                BoardPrinter(io_Board);
                if (io_Board.CheckLose())
                {
                    if (Move.GetTurn() == Move.eTurn.X)
                    {
                        Console.WriteLine($"You lost! the Machine Wins!");
                    }
                    else
                    {
                        Console.WriteLine($"You Won!");
                    }

                    break;
                }

                gameTied = io_Board.CheckTie();
                Program.TurnNum++;
            }

            if (gameTied)
            {
                Console.WriteLine("The game is tied, nobody wins");
            }

            if (continueGame)
            {
                continueGame = CheckForNewGame();
            }

            return continueGame;
        }

        private static bool CheckForNewGame()
        {
            bool newGame = false;
            bool checking = true;
            while (checking)
            {
                Console.WriteLine("Would you like you play another game? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    newGame = true;
                    checking = false;
                    Ex02.ConsoleUtils.Screen.Clear();
                }
                else if (answer == "N")
                {
                    Console.WriteLine("Thank you for playing");
                    checking = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }

            return newGame;
        }

        private static bool CheckForGameQuit()
        {
            bool gameQuit = false;
            bool checking = true;
            while (checking)
            {
                Console.WriteLine("Are you sure you want to quit? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Console.WriteLine("Thank you for playing");
                    gameQuit = true;
                    checking = false;
                }
                else if (answer == "N")
                {
                    checking = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }

            return gameQuit;
        }
    }
}