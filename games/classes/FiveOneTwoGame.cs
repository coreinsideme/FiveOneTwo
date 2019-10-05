using System;
using Field;
using Extensions;
using System.Linq;
using System.Collections.Generic;

namespace Games
{
    public class FiveOneTwoGame: IGame
    {
        private int[,] gameData;
        
        private GameState gameState = GameState.NotStarted;

        private IFieldBuilder fieldBuilder;

        public FiveOneTwoGame(IFieldBuilder _fieldBuilder) {
            if(_fieldBuilder == null) {
                throw new ArgumentNullException(nameof(_fieldBuilder) + " should be specified");
            }

            fieldBuilder = _fieldBuilder;
        }

        public GameState GameState { 
            get {
                var gameState = new GameState();
                gameState.State = gameState;
                gameState.StateData = gameData;

                return gameState;
            }
            set {
                gameData = value;
            }
        }

        public void StartGame() {
            if(fieldBuilder == null || gameData == null) {
                throw new Exception("field builder and game data should be specified");
            }

            gameState = GameState.InProcess;
            Refresh();
        }

        public void GoUp() {
            OrderColumnUp();
            Shuffle();
            Refresh();
        }

        public void GoDown() {
            OrderColumnDown();
            Shuffle();
            Refresh();
        }

        public void GoLeft() {
            OrderRowLeft();
            Shuffle();
            Refresh();
        }

        public void GoRight() {
            OrderRowRight();
            Shuffle();
            Refresh();         
        }

        private void OrderColumnDown() {
            OrderArray(true, 
                (gameData, index) => { return gameData.GetColumn(index); },
                (gameData, array, index) => { gameData.SetColumn(array, index); });
        }

        private void OrderColumnUp() { 
            OrderArray(false, 
                (gameData, index) => { return gameData.GetColumn(index); },
                (gameData, array, index) => { gameData.SetColumn(array, index); });
        }

        private void OrderRowLeft() {
            OrderArray(false, 
                (gameData, index) => { return gameData.GetRow(index); },
                (gameData, array, index) => { gameData.SetRow(array, index); });
        }

        private void OrderRowRight() {
            OrderArray(true, 
                (gameData, index) => { return gameData.GetRow(index); },
                (gameData, array, index) => { gameData.SetRow(array, index); });
        }

        private void OrderArray(bool isReverseNeeded, Func<int[,], int, int[]> getDelegate, Action<int[,], int[], int> setAction) {
            for (int i = 0; i < gameData.GetLength(1); i++)
            {
                var array = getDelegate(gameData, i);

                if(isReverseNeeded) {
                    Array.Reverse(array);
                }

                array.GetNonZeroFirst();

                for (int j = 1; j < array.Length; j++)
                {
                    if(array[j] == 0) continue;

                    if(array[j] == array[j - 1]) {
                        array[j - 1] *= 2;
                        array[j] = 0;
                    }

                    array.GetNonZeroFirst();
                }

                if(isReverseNeeded) {
                    Array.Reverse(array);
                }

                setAction(gameData, array, i);
            }
        }

        private void Refresh() {
            string gameState = fieldBuilder.CreateField(gameData);

            Console.Clear();
            Console.WriteLine(gameState);
        }

        private void Shuffle() {
            int fieldSize = gameData.GetLength(1);
            var random = new Random();
            
            int emptyCells = 0;
            var emptyCellsCoordinates = new List<Coordinates>();
            for (int x = 0; x < fieldSize; x++)
            {
                for (int y = 0; y < fieldSize; y++) {
                    if(gameData[x, y] == 0) {
                        emptyCellsCoordinates.Add(new Coordinates(x, y));
                        emptyCells++;
                    }

                    if(gameData[x, y] >= 512) {
                        gameState = GameState.Won;
                        return;
                    }
                }
            }

            if(emptyCells == 0) {
                gameState = GameState.Lost;
                return;
            }

            var newValuesCapacity = emptyCells >= fieldSize - 2 ? fieldSize - 2: emptyCells;

            for (int i = newValuesCapacity; i > 0; i--)
            {
                int index = random.Next(0, emptyCellsCoordinates.Count - 1);
                Coordinates coord = emptyCellsCoordinates[index];
                emptyCellsCoordinates.RemoveAt(index);
                gameData[coord.x, coord.y] = 2;
            }
        }
    }
    
}