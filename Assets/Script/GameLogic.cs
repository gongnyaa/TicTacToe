using UnityEngine;

namespace Script
{
    public class GameLogic
    {
        private PlayerMark[,] _boardStates;
        private int _turnCount;

        public GameLogic()
        {
            Init();
        }

        public void Init()
        {
            _boardStates = new PlayerMark[3, 3];
        }

        public PlayerMark GetCellMark(int x, int y)
        {
            return _boardStates[x, y];
        }


        public bool CanSelect(int x, int y)
        {
            if (GetWinnerPlayer() != PlayerMark.Blank)
            {
                return false;
            }

            var boardState = _boardStates[x, y];
            if (boardState != PlayerMark.Blank)
            {
                return false;
            }

            return true;
        }

        public void Select(int x, int y)
        {
            if (x < 0 || 3 < x)
            {
                Debug.Log("Error:x should be 0-2 but x=" + x);
                return;
            }

            if (y < 0 || 3 < y)
            {
                Debug.Log("Error:y should be 0-2 but y=" + x);
                return;
            }

            var boardState = _boardStates[x, y];
            if (boardState != PlayerMark.Blank)
            {
                Debug.Log("this cell is not blank" + x);
                return;
            }

            var turnPlayer = GetTurnPlayer();
            _boardStates[x, y] = turnPlayer;
            NextTurn();
        }

        private void NextTurn()
        {
            _turnCount++;
        }

        public PlayerMark GetTurnPlayer()
        {
            if (_turnCount % 2 == 0)
            {
                return PlayerMark.Circle;
            }

            return PlayerMark.Cross;
        }

        public PlayerMark GetWinnerPlayer()
        {
            if (IsWin(PlayerMark.Circle))
            {
                return PlayerMark.Circle;
            }

            if (IsWin(PlayerMark.Cross))
            {
                return PlayerMark.Cross;
            }

            return PlayerMark.Blank;
        }

        private bool IsWin(PlayerMark playerMark)
        {
            //横
            for (int y = 0; y < 3; y++)
            {
                if (_boardStates[0, y] == playerMark
                    && _boardStates[1, y] == playerMark
                    && _boardStates[2, y] == playerMark)
                {
                    return true;
                }
            }

            //縦
            for (int x = 0; x < 3; x++)
            {
                if (_boardStates[x, 0] == playerMark
                    && _boardStates[x, 1] == playerMark
                    && _boardStates[x, 2] == playerMark)
                {
                    return true;
                }
            }

            //斜め
            if (_boardStates[0, 0] == playerMark
                && _boardStates[1, 1] == playerMark
                && _boardStates[2, 2] == playerMark)
            {
                return true;
            }

            if (_boardStates[2, 0] == playerMark
                && _boardStates[1, 1] == playerMark
                && _boardStates[0, 2] == playerMark)
            {
                return true;
            }

            return false;
        }
    }
}