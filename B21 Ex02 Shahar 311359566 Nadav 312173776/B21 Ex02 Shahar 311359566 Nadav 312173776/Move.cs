using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Move
    {
        public int turns = 0;
        private int m_Row ;
        private int m_Column;
        public enumXO m_Turn;

        public Move(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Turn =GetTurn();
        }

        public void SetMove(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Turn = GetTurn();
        }

        private enumXO GetTurn()
        {
            enumXO symbol = enumXO.X;
            if(turns % 2 ==1)
            {
                symbol = enumXO.O;
            }
            turns++;
            return symbol;
        }
        public enum enumXO{
            X,
            O
        }
    }
}
