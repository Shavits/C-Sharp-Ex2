using System;
using System.Collections.Generic;
using System.Text;


namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class UI
    {

        public static void BoardPrinter(BoardLogic i_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder row = new StringBuilder();

            for (int i = 1; i <= i_Board.BoardSize; i++)
            {
                row.Append("   " + i);
            }
            Console.WriteLine(row);

            for (int i = 0; i < i_Board.BoardSize; i++)
            {
                row.Clear();
                row.Append((i + 1) + "|");
                for (int j = 0; j < i_Board.BoardSize; j++)
                {
                    if (i_Board.BoardMatrix[i, j] == Move.enumXO.EMPTY)
                    {
                        row.Append("   |");
                    }
                    else
                    {
                        row.Append($" {i_Board.BoardMatrix[i, j]} |");
                    }

                }
                Console.WriteLine(row);
                row.Clear();
                row.Append(" =").Append('=', 4 * i_Board.BoardSize);
                Console.WriteLine(row);
            }
        }




        public static Move GetPlayerMove(out bool gameQuit)
        {
            Move playerMove = null;
            gameQuit = false;
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
                    gameQuit = CheckForGameQuit();
                    if (!gameQuit)
                    {
                        continue;
                    }
                    else
                    {
                        checking = false;
                    }
                }
                if (!gameQuit)
                {
                    if(!IsValidInputs(inputs, out parsedInts))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }
                    checking = false;
                    playerMove = new Move(parsedInts[0]-1, parsedInts[1]-1);
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
            for(int i =0; i<i_Inputs.Length; i++)
            {
                if (!int.TryParse(i_Inputs[i].ToString(), out parsedInts[i]))
                {
                    valid = false;
                }
            }
            o_parsedInts = parsedInts;
            return valid;
        }
        public static int GetBoardSizeFromPlayer()
        {
            Console.WriteLine("Please enter the size of board (3 to 9)");
            string boardSizeString = Console.ReadLine();
            int boardSize;
            bool validInput = int.TryParse(boardSizeString, out boardSize);
            while (!validInput || (boardSize < 3 || boardSize > 9))
            {
                Console.WriteLine("Invalid size, please enter the size of board (3 to 9)");
                boardSizeString = Console.ReadLine();
                validInput = int.TryParse(boardSizeString, out boardSize);
            }
            return boardSize;
        }
        public static bool CheckIfMultuplayer()
        {
            Console.WriteLine("Please choose number of human players (1/2)");
            string numOfPlayersString = Console.ReadLine();
            int numOfPlayers;
            bool multiplayer = false;
            bool validInput = int.TryParse(numOfPlayersString, out numOfPlayers);
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

        public static bool PlayMultiplayer(BoardLogic io_Board)
        {
            bool gameTied = false;
            bool gameQuit = false;
            while (!gameTied)
            {
                Console.WriteLine($"It is now {Move.GetTurn()} turn");
                Move cur_move = GetPlayerMove(out gameQuit);
                if (gameQuit)
                {
                    break;
                }
                while (!io_Board.UpdateBoard(cur_move))
                {
                    Console.WriteLine("Ilegal Move, please enter a new move");
                    cur_move = GetPlayerMove(out gameQuit);
                }
                BoardPrinter(io_Board);
                if (io_Board.CheckLose())
                {
                    Move.enumXO winner = Move.enumXO.X;
                    if (Move.GetTurn() == Move.enumXO.X)
                    {
                        winner = Move.enumXO.O;
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
            if (!gameQuit)
            {
                gameQuit = CheckForNewGame();
            }
            return gameQuit; 
        }
        public static bool PlayVsMachine(BoardLogic io_Board)
        {
            bool gameTied = false;
            bool gameQuit = false;
            while (!gameTied)
            {
                if (Move.GetTurn() == Move.enumXO.X)
                {
                    Console.WriteLine("It is now your turn");
                    Move cur_move = GetPlayerMove(out gameQuit);
                    if (gameQuit)
                    {
                        break;
                    }
                    while (!io_Board.UpdateBoard(cur_move))
                    {
                        Console.WriteLine("Ilegal Move, please enter a new move");
                        cur_move = GetPlayerMove(out gameQuit);
                    }
                    if (gameQuit)
                    {
                        break;
                    }
                }
                else
                {
                    AI.MakeAIMove(io_Board);
                }
                BoardPrinter(io_Board);
                if (io_Board.CheckLose())
                {
                    if (Move.GetTurn() == Move.enumXO.X)
                    {
                        Console.WriteLine($"You lost! AI Wins!");
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
            if (!gameQuit)
            {
                gameQuit = !CheckForNewGame();
            }
            return !gameQuit;
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

