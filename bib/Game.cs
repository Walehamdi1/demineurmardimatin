using System;


namespace bib
{
    public enum Level { Beginner = 10, Intermediate = 20, Advanced = 40 };
    public class Game
    {
        // attributs
        public int[,] Grid { get; set; }
        private int bombs;

        #region constructeur
        public Game(Level level)
        {
            bombs = (int)level;
            switch (level)
            {
                case Level.Beginner:
                    // bombs = 10;
                    Grid = new int[9, 9];
                    break;
                case Level.Intermediate:
                    //  bombs = 20;
                    Grid = new int[12, 12];
                    break;
                case Level.Advanced:
                    //  bombs = 40;
                    Grid = new int[12, 16];
                    break;
            }
            SetMines();
            setNumbers();
        }
        public Game(Level level, int bombs) : this(level)
        {
            this.bombs = bombs;

        }
        #endregion
        #region méthodes
        private void SetMines()
        {
            Random r = new Random();
            int nb = 0;

            while (nb < this.bombs)
            {

                int l = r.Next(0, Grid.GetLength(0));
                int c = r.Next(0, Grid.GetLength(1));
                if (Grid[l, c] != 9)
                {
                    nb++;
                    Grid[l, c] = 9;
                }

            }

        }

        private void setNumbers()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (Grid[i, j] == 9)
                    {
                        SetCounter(i, j);
                    }

                }
            }
        }

        private void SetCounter(int l, int c)
        {

            for (int i = l - 1; i <= l + 1; i++)
            {
                if (i >= 0 && i < Grid.GetLength(0))
                    for (int j = c - 1; j <= c + 1; j++)
                    {
                        if (j >= 0 && j < Grid.GetLength(1))
                          if (Grid[i, j] != 9)
                            {
                                Grid[i, j]++;
                            }
                    }
            }
        }
       
        #endregion


    }
}


