using System;
using System.Text;
namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Program
    {
        private static int m_BoardSize;
        private static BoardLogic m_Board;
        private static int m_TurnNum = 0;
        private static bool m_Multiplayer = false;


        static void Main(string[] args)
        {
            InitializeGame();
        }
        public static void InitializeGame()
        {
            bool playing = true;
            while (playing)
            {
                m_BoardSize = UI.GetBoardSizeFromPlayer();
                m_Board = new BoardLogic(m_BoardSize);
                m_TurnNum = 0;
                m_Multiplayer = UI.CheckIfMultuplayer();
                UI.BoardPrinter(m_Board);

                if (m_Multiplayer)
                {
                    playing = UI.PlayMultiplayer(m_Board);
                }
                else
                {
                    playing = UI.PlayVsMachine(m_Board);
                }
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

