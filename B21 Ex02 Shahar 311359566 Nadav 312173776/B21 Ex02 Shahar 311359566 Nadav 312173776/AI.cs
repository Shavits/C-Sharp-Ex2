using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class AI
    {
        private static Random rand = new Random();
        public static void MakeAIMove(BoardLogic io_Board)
        {
            int row = rand.Next(0, io_Board.BoardSize);
            int col = rand.Next(0, io_Board.BoardSize);
            Move aiMove = new Move(row, col);
            Thread.Sleep(1500);
            while (!io_Board.UpdateBoard(aiMove))
            {
                row = rand.Next(0, io_Board.BoardSize);
                col = rand.Next(0, io_Board.BoardSize);
                aiMove = new Move(row, col);
            }
        }

    }
}
