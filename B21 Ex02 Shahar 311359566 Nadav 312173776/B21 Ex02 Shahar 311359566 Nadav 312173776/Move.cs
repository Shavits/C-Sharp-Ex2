using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Move
    {
        private int m_Row;
        private int m_Column;
        private enumXO m_Turn;


      
        public Move(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Turn = GetTurn(Program.TurnNum);
        }
/*
        public void SetMove(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Turn = GetTurn();
        }
*/
        private enumXO GetTurn(int i_turns)
        {
            enumXO symbol = enumXO.X;
            if(i_turns % 2 ==1)
            {
                symbol = enumXO.O;
            }
            Program.TurnNum++;
            return symbol;
        }
        public enum enumXO{
            X,
            O,
           // Empty:" " 
        }

        public int Row
        {
            get { return m_Row; }
        }

        public int Column
        {
            get { return m_Column; }
        }

        public enumXO Turn
        {
            get { return m_Turn; }
        }
    }
}
