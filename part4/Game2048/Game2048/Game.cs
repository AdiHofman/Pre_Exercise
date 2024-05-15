using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Game
    {
        public Board GameBoard { get; set; }
        public GameStatus Status { get; set; }
        public int Points { get; protected set; }

        public Game()
        {
            GameBoard = new Board();
            Points = 0;
            Status = GameStatus.Idle;
        }

        public void Move(Direction direction)
        {
            if(Status.Equals(GameStatus.Idle))
            {
                Points += GameBoard.Move(direction);
                Status = GameBoard.GetBoardStatus();
            }
        }
    }
}
