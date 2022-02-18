using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaDSLab1
{
    class Labyrinth
    {
        public int Ways { get; set; }
        public int AmountOfLines { get; set; }
        public int AmountOfColumns { get; set; }
        public Cell[,] Field { get; set; }

        public Labyrinth(int n, int m)
        {
            this.Ways = 0;
            this.AmountOfLines = n;
            this.AmountOfColumns = m;
            this.Field = new Cell[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.Field[i, j] = new Cell();
                }
            }
        }

        public Labyrinth GenerateRandom(int k)
        {
            for (int i = 0; i < this.AmountOfLines; i++)
            {
                for (int j = 0; j < this.AmountOfColumns; j++)
                {
                    this.Field[i, j] = new Cell();
                }
                if ((i == 0 || i == this.AmountOfLines - 1) && AmountOfZeros(this.Field, i) != k)
                {
                    i--;
                }
            }
            return this;
        }

        public Labyrinth ReadFromFile()
        {
            using (StreamReader sr = new StreamReader("Field.txt"))
            {
                for (int i = 0; i < this.AmountOfLines; i++)
                {
                    for (int j = 0; j < this.AmountOfColumns; j++)
                    {
                        this.Field[i, j].Value = sr.Read() - '0';
                    }
                    sr.Read();
                    sr.Read();
                }
            }
            this.SearchPossibleWaysForEachCell();
            return this;
        }

        private void SearchPossibleWaysForEachCell()
        {
            for (int i = 0; i < this.AmountOfLines; i++)
            {
                for (int j = 0; j < this.AmountOfColumns; j++)
                {
                    if (this.Field[i, j].Value == 0)
                        this.Field[i, j].PossibleWaysToGo = this.HaveFurtherMoves(i, j);
                }
            }
        }

        public void Write()
        {
            for (int i = 0; i < this.AmountOfLines; i++)
            {
                for (int j = 0; j < this.AmountOfColumns; j++)
                {
                    Console.Write(this.Field[i, j].ToString(), " ");
                }
                Console.WriteLine();
            }
        }

        public char Direction(int i, int j)
        {
            if (i == this.AmountOfLines - 1)
                return 'e';     // escape of the labyrinth

            if (i != 0 && this.HaveFurtherMoves(i, j) == 0)
            {
                return 't';     // tupik (a cho)
            }

            if (j != 0 && this.Field[i, j - 1].Value == 0 && !this.Field[i, j - 1].IsVisited)
                return 'l';
            else if (i != this.AmountOfLines - 1 && this.Field[i + 1, j].Value == 0 && !this.Field[i + 1, j].IsVisited)
                return 'd';
            else if (j != this.AmountOfColumns - 1 && this.Field[i, j + 1].Value == 0 && !this.Field[i, j + 1].IsVisited)
                return 'r';
            else if (i != 0 && this.Field[i - 1, j].Value == 0 && !this.Field[i - 1, j].IsVisited)
                return 'u';
            return 'd';
        }

        private int HaveFurtherMoves(int i, int j)
        {
            int count = 0;
            if (j != 0 && this.Field[i, j - 1].Value == 0 && !this.Field[i, j - 1].IsVisited)
                count++;
            if (i != 0 && this.Field[i - 1, j].Value == 0 && !this.Field[i - 1, j].IsVisited)
                count++;
            if (j != this.AmountOfColumns - 1 && this.Field[i, j + 1].Value == 0 && !this.Field[i, j + 1].IsVisited)
                count++;
            if (i != this.AmountOfLines - 1 && this.Field[i + 1, j].Value == 0 && !this.Field[i + 1, j].IsVisited)
                count++;

            return count;
        }

        private int AmountOfZeros(Cell[,] field, int i)
        {
            int ret = 0;
            for (int j = 0; j < this.AmountOfColumns; j++)
            {
                if (field[i, j].Value == 0)
                {
                    ret++;
                }
            }
            return ret;
        }
    }
}
