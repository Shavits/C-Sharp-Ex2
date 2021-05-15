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
            Thread.Sleep(500);
            List<Move> availableMoves = GetAvailableMoves(io_Board);
            Move chosenMove = availableMoves[rand.Next(availableMoves.Count)];
            io_Board.UpdateBoard(chosenMove);
        }

        private static List<Move> GetAvailableMoves(BoardLogic i_board)
        {
            List<Move> availableMoves = new List<Move>();
            for (int i = 0; i < i_board.BoardSize; i++)
            {
                for(int j = 0; j <i_board.BoardSize; j++)
                {
                    if(i_board.BoardMatrix[i,j] == Move.enumXO.EMPTY)
                    {
                        Move possibleMove = new Move(i, j);
                        availableMoves.Add(possibleMove);
                    }
                }
            }
            return availableMoves;
        }

    }
}
