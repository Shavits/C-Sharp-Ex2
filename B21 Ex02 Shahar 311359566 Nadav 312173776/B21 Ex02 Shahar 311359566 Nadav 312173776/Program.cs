using System;
using System.Text;
namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Program
    {
        private static int m_TurnNum;


        static void Main(string[] args)
        {
            Board board = new Board(3);
            Move cur_move = UI.GetPlayerMove();
            while (!board.UpdateBoard(cur_move))
            {
                cur_move = UI.GetPlayerMove();
            }
        }

        public static int TurnNum {
            get { 
                return m_TurnNum; 
                }
            set {
                m_TurnNum = value;
                 }
        }




    }
}
