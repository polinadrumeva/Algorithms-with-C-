namespace _03._Connected_Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Area
        {
            public int Row { get; set; }     

            public int Col { get; set; }

            public int Size { get; set; }
        }

        private static char[,] matrix;
        private static int size = 0;
        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());    

            matrix = new char[row, col];
            for (int  r = 0; r < row; r++)
            {
                var colElements = Console.ReadLine();
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            var areas = new List<Area>();

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    size = 0;
                    FindArea(r,c);

                    if (size != 0)
                    {
                        areas.Add(new Area { Row = r, Col = c, Size = size });

                    }
                }
            }

            var sorted = areas.OrderByDescending(x => x.Size)
                              .ThenBy(x => x.Row)
                              .ThenBy(x => x.Col)
                              .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");
            for (int i = 0; i < sorted.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine($"Area #{i+1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void FindArea(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            size++;
            matrix[row, col] = 'v';

            FindArea(row -1,col);
            FindArea(row + 1,col);
            FindArea(row,col - 1);
            FindArea(row,col + 1);
        }
    }
}