using System;
using System.Text;
using Extensions;

namespace Field
{
    public class FiveOneTwoFieldBuilder: IFieldBuilder {

        private readonly int fieldSize;

        public FiveOneTwoFieldBuilder(int _fieldSize)
        {
            if(_fieldSize <= 0) { throw new ArgumentException(nameof(_fieldSize) + " should be more then null"); }

            fieldSize = _fieldSize;
        }

        public string CreateField(int[,] gameData) {

            int horizontal = gameData.GetLength(0);
            int vertical = gameData.GetLength(1);
            
            if(gameData == null || horizontal != fieldSize || vertical != fieldSize) {
                throw new ArgumentNullException(nameof(gameData) + " should be appropriate");
            }
            
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < vertical; i++)
            {
                stringBuilder.Append(DrawLine(horizontal));
                stringBuilder.Append(DrawValues(gameData.GetRow(i)));

                if(i == vertical - 1) {
                    stringBuilder.Append(DrawLine(horizontal));
                }
            }

            return stringBuilder.ToString();
        }

        private string DrawValues(int[] values) {
            string line = "";

            for (int i = 0; i < values.Length; i++)
            {
                line += "|";

                if(values[i] < 99) {
                    line += " ";
                }

                if(values[i] == 0) {
                    line += " ";
                } else {
                    line += values[i];
                }

                if(values[i] < 9) {
                    line += " ";
                }
                
                if(i == values.Length - 1) {
                    line += "|";
                }
            }

            line += "\n";
            return line;
        }

        private string DrawLine(int rowSize) {
            string line = "";

            for (int i = 0; i < rowSize; i++)
            {
                line += "+---";
                
                if(i == rowSize - 1) {
                    line += "+";
                }
            }

            line += "\n";
            return line;
        }
    }    
}
