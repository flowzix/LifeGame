using LifeGameProject.Events;
using LifeGameProject.Models;
using LifeGameProject.Static;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace LifeGameProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "LIFE Game";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _nGenerationsInput;
        public string NGenerationsInput
        {
            get { return _nGenerationsInput; }
            set { SetProperty(ref _nGenerationsInput, value); }
        }

        private int _fieldWidth;
        public int FieldWidth
        {
            get { return _fieldWidth; }
            set { SetProperty(ref _fieldWidth, value); }
        }

        private int _fieldHeight;
        public int FieldHeight
        {
            get { return _fieldHeight; }
            set { SetProperty(ref _fieldHeight, value); }
        }
        public IEventAggregator eventAggregator { get; private set; }

        public DelegateCommand NGenerationsButtonCommand { get; set; }
        public DelegateCommand NextGenerationButtonCommand { get; set; }
        public DelegateCommand<object> CellClickCommand { get; set; }

        private ILifeGame Game { get; set; }
        private ObservableCollection<UIGameCell> _gameCells = new ObservableCollection<UIGameCell>();
        public ObservableCollection<UIGameCell> GameCells
        {
            get { return _gameCells; }
            set { SetProperty(ref _gameCells, value); }
        }

        public MainWindowViewModel(IEventAggregator _eventAggregator, ILifeGame game)
        {
            eventAggregator = _eventAggregator;

            NGenerationsButtonCommand = new DelegateCommand(CauseNGenerations, CanUseNGenerationsButton).ObservesProperty(() => NGenerationsInput);
            NextGenerationButtonCommand = new DelegateCommand(CauseNextGeneration);

            eventAggregator.GetEvent<SettingChangedEvent>().Subscribe(settingChanged);
            eventAggregator.GetEvent<LoadGameEvent>().Subscribe(LoadGameRequested);
            eventAggregator.GetEvent<SaveGameEvent>().Subscribe(SaveGameRequested);

            CellClickCommand = new DelegateCommand<object>(GameCellClicked);
            this.Game = game;
            synchronizeWithModel();
        }
        private void LoadGameRequested(string gameContents)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            Game = JsonConvert.DeserializeObject<LifeGame>(gameContents, settings);

            synchronizeWithModel();
        }
        private void SaveGameRequested()
        {
            string gameJson = JsonConvert.SerializeObject((LifeGame)Game);
            File.WriteAllText("game.txt", gameJson);
        }

        private void CauseNextGeneration()
        {
            Game.NextGeneration();
            synchronizeWithModelMatchingDimensions();
        }

        private void synchronizeWithModel()
        {
            GameCells.Clear();
            List<GameCell> cells = Game.GetCells();
            FieldWidth = Game.GetWorldWidth();
            FieldHeight = Game.GetWorldHeight();
            for (int i = 0; i < cells.Count; i++)
            {
                GameCells.Add(mapCellToUICell(cells[i]));
            }
        }

        private UIGameCell mapCellToUICell(GameCell gameCell)
        {
            string color;
            if (gameCell.Alive)
            {
                color = "Black";
            }
            else
            {
                color = "White";
            }
            return new UIGameCell { Color = color, Alive = gameCell.Alive, Position = gameCell.Position };
        }

        public void GameCellClicked(object eventArgs)
        {
            int position = (int)eventArgs;
            GameCell clickedCell = Game.GetCell(position);
            bool currentlyAlive = clickedCell.Alive;
            Game.SetAlive(position, !currentlyAlive);
            GameCells[position] = mapCellToUICell(clickedCell);
        }

        private void synchronizeWithModelMatchingDimensions()
        {
            List<GameCell> cells = Game.GetCells();

            for (int i = 0; i < cells.Count; i++)
            {
                GameCells[i] = mapCellToUICell(cells[i]);
            }
        }

        public void settingChanged(KeyValuePair<SettingType, int> setting)
        {
            switch (setting.Key)
            {
                case SettingType.CELLS_HORIZONTAL:
                    FieldWidth = setting.Value;
                    Game.SetWorldWidth(FieldWidth);
                    synchronizeWithModel();
                    return;
                case SettingType.CELLS_VERTICAL:
                    FieldHeight = setting.Value;
                    Game.SetWorldHeight(FieldHeight);
                    synchronizeWithModel();
                    return;
            }
            Game.GetSettings().SetSetting(setting.Key, setting.Value);
        }

        private bool CanUseNGenerationsButton()
        {
            return !String.IsNullOrWhiteSpace(NGenerationsInput);
        }
        private void CauseNGenerations()
        {
            int generationsCount = Int32.Parse(NGenerationsInput);
            for (int i = 0; i < generationsCount; i++)
            {
                CauseNextGeneration();
            }
        }
    }
}
