using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    public class Move
    {
        private int m_Row;
        private int m_Column;
        private eTurn m_Turn;

        public Move(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Turn = GetTurn();
        }

        public static eTurn GetTurn()
        {
            eTurn symbol = eTurn.X;
            if (Program.TurnNum % 2 == 1)
            {
                symbol = eTurn.O;
            }

            return symbol;
        }

        public enum eTurn
        {
            EMPTY,
            X,
            O
        }

        public int Row
        {
            get { return m_Row; }
        }

        public int Column
        {
            get { return m_Column; }
        }

        public eTurn Turn
        {
            get { return m_Turn; }
        }
    }
}
