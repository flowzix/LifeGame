using System.Collections.Generic;

namespace LifeGameProject.Models
{
    public interface ILifeGame
    {
        void InitializeGame();
        List<GameCell> GetCells();
        GameCell GetCell(int x, int y);
        GameCell GetCell(int position);
        int GetWorldWidth();
        int GetWorldHeight();
        void SetAlive(int position, bool alive);
        Settings GetSettings();
        void SetWorldWidth(int width);
        void SetWorldHeight(int height);
        void NextGeneration();
    }

}
