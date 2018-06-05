using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Games
{
    public class GameDataProvider: IGameDataProvider
    {
        private readonly int fieldSize;

        public GameDataProvider(int _fieldSize)
        {
            if(_fieldSize <= 3) throw new ArgumentException(nameof(_fieldSize) + " should be more or equal then 3 ");

            fieldSize = _fieldSize;
        }

        public int[,] GetStartData() {
            var result = new int[fieldSize, fieldSize];
            var random = new Random();
            
            for (int i = 0; i < fieldSize; i++)
            {
                result[random.Next(0, fieldSize - 1), random.Next(0, fieldSize - 1)] = 2;
            }

            return result;
        }

        public bool SaveData(GameState gameState) {
            bool saved;

            try
            {
                SerializeGameStateToBinary(gameState);
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
            }

            return saved;
        }

        public GameState LoadData() {
            return DeserializeGameStateFromBinary();
        }

        private void SerializeGameStateToBinary(GameState gameState) {
            FileStream fileStream = new FileStream("save.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            try {
                formatter.Serialize(fileStream, gameState);
            }
            catch (SerializationException) {
                throw;
            }
            finally {
                fileStream.Close();
            }
        }

        private GameState DeserializeGameStateFromBinary() {
            FileStream fileStream = new FileStream("save.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            GameState state = null;

            try {
                state = (GameState)formatter.Deserialize(fileStream);
            }
            catch(Exception ex) {
                Console.WriteLine("Failed to deserialize. Reason: " + ex.Message);
            }
            finally {
                fileStream.Close();
            }

            return state;
        }
    } 
}