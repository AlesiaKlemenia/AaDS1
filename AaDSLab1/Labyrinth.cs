namespace AaDSLab1
{
    class Labyrinth
    {
        public int AmountOfLines { get; set; }
        public int AmountOfColumns { get; set; }
        public Cell[,] Field { get; set; }

        public Labyrinth(int n, int m)
        {
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

        public static void ReadFromFile(Labyrinth field)
        {
            using (StreamReader sr = new StreamReader("Field.txt"))
            {
                for (int i = 0; i < field.AmountOfLines; i++)
                {
                    for (int j = 0; j < field.AmountOfColumns; j++)
                    {
                        field.Field[i, j].Value = sr.Read() - '0';
                    }
                    sr.Read();
                    sr.Read();
                }
            }
            field.SearchPossibleWaysForEachCell();
        }

        private void SearchPossibleWaysForEachCell()
        {
            for (int i = 0; i < this.AmountOfLines; i++)
            {
                for (int j = 0; j < this.AmountOfColumns; j++)
                {
                    if (this.Field[i, j].Value == 0)
                    {
                        this.Field[i, j].PossibleWaysToGo = this.HaveFurtherMoves(i, j);
                    }
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

        public Direction GetDirection(int i, int j)
        {
            if (i == this.AmountOfLines - 1)
                return Direction.Escape;     // escape of the labyrinth

            if (i != 0 && this.HaveFurtherMoves(i, j) == 0)
                return Direction.DeadEnd;     // tupik (a cho)

            if (j != 0 && this.Field[i, j - 1].Value == 0 && !this.Field[i, j - 1].IsVisited)
                return Direction.Left;
            else if (i != this.AmountOfLines - 1 && this.Field[i + 1, j].Value == 0 && !this.Field[i + 1, j].IsVisited)
                return Direction.Down;
            else if (j != this.AmountOfColumns - 1 && this.Field[i, j + 1].Value == 0 && !this.Field[i, j + 1].IsVisited)
                return Direction.Right;
            else if (i != 0 && this.Field[i - 1, j].Value == 0 && !this.Field[i - 1, j].IsVisited)
                return Direction.Up;
            return Direction.DeadEnd;
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
    }
}
