using System.Collections.Generic;
using System.Linq;
using LifeGameProject.Static;

namespace LifeGameProject.Models
{
    public class LifeGame : ILifeGame
    {
        public List<GameCell> Cells
        {
            get;
            set;
        }
        public Settings GameSettings
        {
            get;
            set;
        }
        public LifeGame()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            GameSettings = Settings.InitialSettings;
            Cells = new List<GameCell>();
            ReinitMap();
        }

        private void ReinitMap()
        {
            Cells.Clear();
            int totalCells = GetWorldWidth() * GetWorldHeight();
            for (int i = 0; i < totalCells; i++)
            {
                Cells.Add(new GameCell { Alive = false, Position = i, AliveFor = 0 });
            }
        }
        public void NextGeneration()
        {
            List<GameCell> newGeneration = new List<GameCell>();
            for (int i = 0; i < Cells.Count; i++)
            {
                GameCell currentCell = (GameCell)GetCell(i).Clone();
                newGeneration.Add(currentCell);
                List<GameCell> surroudings = GetSurroundingsOfCellAt(i % GetWorldWidth(), i / GetWorldWidth());
                int aliveSurrounding = GetAliveCount(surroudings);

                if (!currentCell.Alive && aliveSurrounding == GetSettingValue(SettingType.REANIMATION_COUNT))
                {
                    currentCell.Alive = true;
                    continue;
                }
                if (aliveSurrounding <= GetSettingValue(SettingType.DEPOPULATION_COUNT) || aliveSurrounding >= GetSettingValue(SettingType.OVERPOPULATION_COUNT))
                {
                    currentCell.Alive = false;
                }
            }
            Cells = newGeneration;
        }

        private NullIgnoringList<GameCell> GetSurroundingsOfCellAt(int x, int y)
        {
            NullIgnoringList<GameCell> surroundingCells = new NullIgnoringList<GameCell>();

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (!(i == 0 && j == 0))
                        surroundingCells.Add(GetCell(x + i, y + j));

            return surroundingCells;
        }

        public List<GameCell> GetCells()
        {
            return Cells;
        }
        public GameCell GetCell(int x, int y)
        {
            if (x < 0 || x >= GetWorldWidth() || y < 0 || y >= GetWorldHeight())
            {
                return null;
            }
            return Cells[x + y * GetWorldWidth()];
        }

        public GameCell GetCell(int position)
        {
            if (position < 0 || position >= Cells.Count)
            {
                return null;
            }
            return Cells[position];
        }
        private int GetAliveCount(List<GameCell> surroundings)
        {
            return surroundings.Count(o => o.Alive);
        }
        public int GetWorldHeight()
        {
            return GameSettings.GetSetting(Static.SettingType.CELLS_HORIZONTAL);
        }
        public void SetWorldHeight(int height)
        {
            GameSettings.SetSetting(Static.SettingType.CELLS_HORIZONTAL, height);
            ReinitMap();
        }

        public int GetWorldWidth()
        {
            return GameSettings.GetSetting(Static.SettingType.CELLS_VERTICAL);
        }
        public void SetWorldWidth(int width)
        {
            GameSettings.SetSetting(Static.SettingType.CELLS_VERTICAL, width);
            ReinitMap();
        }
        public void SetAlive(int position, bool alive)
        {
            GetCell(position).Alive = alive;
        }
        public Settings GetSettings()
        {
            return GameSettings;
        }
        private int GetSettingValue(SettingType settingType)
        {
            return GameSettings.GetSetting(settingType);
        }
    }
}
