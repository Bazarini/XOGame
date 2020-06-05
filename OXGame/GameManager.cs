using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXGame
{
    class GameManager
    {

        private string[,] field;
        public Player currentPlayer;
        public Player FP;
        public Player SP;

        public GameManager()
        {
            FP = new Player("", "X");
            SP = new Player("", "O");
        }

        public void NewGame(string P1Name, string P2Name)
        {
            if (FP.Name == "")
                FP.Name = P1Name;
            if (SP.Name == "")
                SP.Name = P2Name;
            NewGame();
        }
        public void NewGame()
        {
            field = new string[3, 3];
            currentPlayer = FP;
        }

        public bool ChangeCell(int x, int y)
        {
            field[x, y] = currentPlayer.Character;
            if (CheckWin(x, y))
            {
                currentPlayer.Win();
                return true;
            }
            ChangePlayer();
            return false;
        }
        private void ChangePlayer()
        {
            currentPlayer = currentPlayer == FP ? SP : FP;
        }   
        private bool CheckWin(int x, int y)
        {
            if ((x + y) % 2 == 0 && field[1, 1] != null && CheckDia() || CheckHor(x) || CheckVer(y))
                return true;
            return false;
        }

        private bool CheckHor(int x)
        {
            if (field[x, 0] == field[x, 1] && field[x, 1] == field[x, 2])
                return true;
            return false;
        }
        private bool CheckVer(int y)
        {
            if (field[0, y] == field[1, y] && field[1, y] == field[2, y])
                return true;
            return false;
        }
        private bool CheckDia()
        {
            return
                (field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2]) ||
                (field[2, 0] == field[1, 1] && field[2, 0] == field[0, 2]);
        }
    }
}
