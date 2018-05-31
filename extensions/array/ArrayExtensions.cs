using System;

namespace Extensions
{
    public static class ArrayExtensions
    {
        public static int[] GetRow(this int[,] array, int rowNumber) {
            var row = new int[array.GetLength(0)];

            for (int i = 0; i < row.Length; i++)
            {
                row[i] = array[rowNumber, i];
            }

            return row;
        }

        public static int[,] SetRow(this int[,] destinationArray, int[] sourceArray, int rowNumber) {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                destinationArray[rowNumber, i] = sourceArray[i];
            }

            return destinationArray;
        }

        public static int[] GetColumn(this int[,] array, int columnNumber) {
            var column = new int[array.GetLength(1)];

            for (int i = 0; i < column.Length; i++)
            {
                column[i] = array[i, columnNumber];
            }

            return column;
        }

        public static int[,] SetColumn(this int[,] destinationArray, int[] sourceArray, int columnNumber) {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                destinationArray[i, columnNumber] = sourceArray[i];
            }

            return destinationArray;
        }

        public static void GetNonZeroFirst(this int[] array) {
            Array.Sort(array, CompareToZero);
        }

        private static int CompareToZero(int x, int y) {
            if(x == 0) {
                return 1;
            } 

            if(y == 0) {
                return -1;
            }

            return 0;
        }
    }
}