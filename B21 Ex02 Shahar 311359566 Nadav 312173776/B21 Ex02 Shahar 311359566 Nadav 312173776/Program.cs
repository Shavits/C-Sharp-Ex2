using System;
using System.Text;
namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Program
    {
        private static int m_BoardSize;
        private static Board m_Board;
        private static int m_TurnNum = 0;
        private static bool m_Multiplayer = false;


        static void Main(string[] args)
        {
            InitializeGame();
            /*Move cur_move = UI.GetPlayerMove();
            while (!board.UpdateBoard(cur_move))
            {
                cur_move = UI.GetPlayerMove();
            }*/
        }
        private static void InitializeGame()
        {
            Console.WriteLine("Welcome to our Tic Tac Toe game");
            GetBoardSizeFromPlayer();
            m_Board = new Board(m_BoardSize);
            m_TurnNum = 0;
            CheckIfMultuplayer();
            UI.BoardPrinter(m_Board);
            if (m_Multiplayer)
            {
                PlayMultiplayer();
            }
            else
            {
                PlayVsMachine();
            }
        }

        private static void PlayMultiplayer()
        {
            bool gameTied = false;
            while (!gameTied)
            {
                Console.WriteLine($"It is now {Move.GetTurn(m_TurnNum)} turn");
                Move cur_move = UI.GetPlayerMove();
                while (!m_Board.UpdateBoard(cur_move))
                {
                    Console.WriteLine("Ilegal Move, please enter a new move");
                    cur_move = UI.GetPlayerMove();
                }
                UI.BoardPrinter(m_Board);
                if (m_Board.CheckLose())
                {
                    Console.WriteLine($"You lost! {Move.GetTurn(m_TurnNum + 1)} Wins!");
                    break;
                }

                gameTied = m_Board.CheckTie();
                m_TurnNum++;
            }
            if (gameTied)
            {
                Console.WriteLine("The game is tied, nobody wins");
            }
            CheckForNewGame();
        }
        private static void PlayVsMachine()
        {
            bool gameTied = false;
            while (!gameTied)
            {
                if(m_TurnNum%2 == 0)
                {
                    Console.WriteLine($"It is now your turn");
                    Move cur_move = UI.GetPlayerMove();
                    while (!m_Board.UpdateBoard(cur_move))
                    {
                        Console.WriteLine("Ilegal Move, please enter a new move");
                        cur_move = UI.GetPlayerMove();
                    }
                }
                else
                {
                    AI.MakeAIMove(m_Board);
                }
                UI.BoardPrinter(m_Board);
                if (m_Board.CheckLose())
                {
                    if (m_TurnNum % 2 == 0)
                    {
                        Console.WriteLine($"You lost! AI Wins!");
                    }
                    else
                    {
                        Console.WriteLine($"You Won!");
                    }
                    break;
                }

                gameTied = m_Board.CheckTie();
                m_TurnNum++;
            }
            if (gameTied)
            {
                Console.WriteLine("The game is tied, nobody wins");
            }
            CheckForNewGame();
        }

        private static void CheckForNewGame()
        {
            Console.WriteLine("Would you like you play another game? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                InitializeGame();
            }
            else if(answer == "N")
            {
                Environment.Exit(0);
            }
        }


        private static void GetBoardSizeFromPlayer()
        {
            Console.WriteLine("Please enter the size of board (3 to 9)");
            string boardSizeString = Console.ReadLine();
            bool validInput = int.TryParse(boardSizeString, out m_BoardSize);
            while (!validInput || (m_BoardSize<3 || m_BoardSize>9))
            {
                Console.WriteLine("Invalid size, please enter the size of board (3 to 9)");
                boardSizeString = Console.ReadLine();
                validInput = int.TryParse(boardSizeString, out m_BoardSize);
            }
        }


        private static void CheckIfMultuplayer()
        {
            Console.WriteLine("Please choose number of human players (1/2)");
            string numOfPlayersString = Console.ReadLine();
            int numOfPlayers;
            bool validInput = int.TryParse(numOfPlayersString, out numOfPlayers);
            while (!validInput || (numOfPlayers<0 || numOfPlayers >2))
            {
                Console.WriteLine("Invalid number of players, please choose number of human players (1/2)");
                numOfPlayersString = Console.ReadLine();
                validInput = int.TryParse(numOfPlayersString, out numOfPlayers);
            }
            if(numOfPlayers == 2)
            {
                m_Multiplayer = true;
            }

        }

        public static int TurnNum
        {
            get
            {
                return m_TurnNum;
            }
            set
            {
                m_TurnNum = value;
            }





        }



        
    }
}

