using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public enum Direction
    {
        Right,
        Left,
        Top,
        Bottom,
    }

    public enum GameStatus
    {
        Win,
        Lost,
        Idle
    }
}
