using System;
using System.Runtime.Serialization;

namespace Games
{
    [Serializable]
    public class GameState
    {
        
        public State State { get; set; }
        
        public int[,] Data { get; set; }

    }
}