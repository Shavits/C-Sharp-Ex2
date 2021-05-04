using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Board
    {
        private Move.enumXO[,] m_BoardMatrix;
        private int m_BoardSize;

        //REMOVE - Assumes size was checked before creation
        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_BoardMatrix = new Move.enumXO[i_BoardSize, i_BoardSize];
        }

        public bool UpdateBoard(Move i_Move, Move.enumXO i_Player)
        {
            bool movesuccessful = false;
            bool legalMove = true;
            if (i_Move.X < 0 || i_Move.X >= m_BoardSize || i_Move.Y < 0 || i_Move.Y >= m_BoardSize)
            {
                legalMove = false;
            }

            if (legalMove)
            {
                if(!m_BoardMatrix[i_Move.X, i_Move.Y].Equals(null))
                {
                    m_BoardMatrix[i_Move.X, i_Move.Y] = i_Player;
                    movesuccessful = true;
                }
            }

            return movesuccessful;
        }

        public bool CheckWin()
        {
            bool gameWon = false;
            //CheckRows
            for(int i = 0; i<m_BoardSize; i++)
            {
                Move.enumXO[] row = new Move.enumXO[m_BoardSize];
                for(int j = 0; j<m_BoardSize; j++)
                {
                    row[j] = m_BoardMatrix[i, j];
                }
                if (CheckSeriesWin(row))
                {
                    gameWon = true;
                }
            }

            //CheckCols
            for (int i = 0; i < m_BoardSize; i++)
            {
                Move.enumXO[] col = new Move.enumXO[m_BoardSize];
                for (int j = 0; j < m_BoardSize; j++)
                {
                    col[j] = m_BoardMatrix[j, i];
                }
                if (CheckSeriesWin(col))
                {
                    gameWon = true;
                }
            }

            //CheckDiag
            Move.enumXO[] diag1 = new Move.enumXO[m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                diag1[i] = m_BoardMatrix[i, i];
            }
            if (CheckSeriesWin(diag1))
            {
                gameWon = true;
            }
            
            Move.enumXO[] diag2 = new Move.enumXO[m_BoardSize];
            for (int i = m_BoardSize; i > 0; i--)
            {
                diag2[m_BoardSize- i] = m_BoardMatrix[m_BoardSize - i, m_BoardSize - i];
            }

            if (CheckSeriesWin(diag2))
            {
                gameWon = true;
            }

            return gameWon;
        }

        private bool CheckSeriesWin(Move.enumXO[] i_Series)
        {
            bool gameWon = true;
            Move.enumXO firstEntry = i_Series[0];
            foreach(Move.enumXO entry in i_Series)
            {
                if (!entry.Equals(firstEntry)){
                    gameWon = false;
                }
            }

            return gameWon;
        }



        //Properties
        public Move.enumXO[,] BoardMatrix
        {
            get { return m_BoardMatrix; }
        }


    }
}
