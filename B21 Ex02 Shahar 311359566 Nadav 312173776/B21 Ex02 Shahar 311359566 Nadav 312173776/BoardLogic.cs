using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class BoardLogic
    {
        private Move.enumXO[,] m_BoardMatrix;
        private int m_BoardSize;

        public BoardLogic(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_BoardMatrix = new Move.enumXO[i_BoardSize, i_BoardSize];


        }

        public bool UpdateBoard(Move i_Move)
        {
            bool movesuccessful = false;
            if (CheckLegalMove(i_Move))
            {
                if (m_BoardMatrix[i_Move.Row, i_Move.Column].Equals(Move.enumXO.EMPTY))
                {
                    m_BoardMatrix[i_Move.Row, i_Move.Column] = i_Move.Turn;
                    movesuccessful = true;
                }
            }

            return movesuccessful;
        }

        private bool CheckLegalMove(Move i_Move)
        {
            bool legalMove = true;
            if (i_Move.Row < 0 || i_Move.Row >= m_BoardSize || i_Move.Column < 0 || i_Move.Column >= m_BoardSize)
            {
                legalMove = false;
            }
            return legalMove;
        }

        public bool CheckLose()
        {
            bool gameLost = false;
            //CheckRows
            for (int i = 0; i < m_BoardSize; i++)
            {
                Move.enumXO[] row = new Move.enumXO[m_BoardSize];
                for (int j = 0; j < m_BoardSize; j++)
                {
                    row[j] = m_BoardMatrix[i, j];
                }
                if (CheckSeriesLose(row))
                {
                    gameLost = true;
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
                if (CheckSeriesLose(col))
                {
                    gameLost = true;
                }
            }

            //CheckDiag
            Move.enumXO[] diag1 = new Move.enumXO[m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                diag1[i] = m_BoardMatrix[i, i];
            }
            if (CheckSeriesLose(diag1))
            {
                gameLost = true;
            }

            Move.enumXO[] diag2 = new Move.enumXO[m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                diag2[i] = m_BoardMatrix[i,m_BoardSize - i - 1];
            }

            if (CheckSeriesLose(diag2))
            {
                gameLost = true;
            }

            return gameLost;
        }

        private bool CheckSeriesLose(Move.enumXO[] i_Series)
        {
            bool gameLost = true;
            Move.enumXO firstEntry = i_Series[0];
            if(firstEntry == Move.enumXO.EMPTY)
            {
                gameLost = false;
            }
            foreach (Move.enumXO entry in i_Series)
            {
                if (!entry.Equals(firstEntry))
                {
                    gameLost = false;
                }
            }

            return gameLost;
        }

        public bool CheckTie()
        {
            return Program.TurnNum == Math.Pow(m_BoardSize, 2)-1;
        }



        //Properties
        public Move.enumXO[,] BoardMatrix
        {
            get { return m_BoardMatrix; }
        }
        public int BoardSize
        {
            get { return m_BoardSize; }
        }

    }
}
