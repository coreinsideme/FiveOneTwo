using System;
using System.Text;
using Extensions;

namespace Field
{
    public class FieldBuilder: IFieldBuilder {

        public string CreateField(int[,] gameField) {
            
            if(gameField == null || gameField.GetLength(0) != gameField.GetLength(1)) {
                throw new ArgumentNullException("gameField should be appropriate");
            }

            int horizontal = gameField.GetLength(0);
            int vertical = gameField.GetLength(1);
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < vertical; i++)
            {
                stringBuilder.Append(DrawLine(horizontal));
                stringBuilder.Append(DrawValues(gameField.GetRow(i)));

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
