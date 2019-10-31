using LifeGameProject.Events;
using LifeGameProject.Models;
using LifeGameProject.Static;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace LifeGameProject.ViewModels
{
    public class SettingsWindowViewModel : BindableBase
    {
        private SettingType _settingHelper;
        public SettingType SettingHelper 
        { 
            get { return _settingHelper; } 
            set { SetProperty(ref _settingHelper, value); } 
        }

        private ValueDescription _valueDescriptionSelected;
        public ValueDescription ValueDescriptionSelected
        {
            get { return _valueDescriptionSelected; }
            set { SetProperty(ref _valueDescriptionSelected, value); }
        }

        private string _settingUserInput = "";
        public string SettingUserInput 
        { 
            get { return _settingUserInput; } 
            set { SetProperty(ref _settingUserInput, value); } 
        }

        public DelegateCommand SettingChangedCommand { get; set; }
        public DelegateCommand LoadGameCommand { get; set; }
        public DelegateCommand SaveGameCommand { get; set; }

        public IEventAggregator _eventAggregator;
        public SettingsWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SettingChangedCommand = new DelegateCommand(() => ChangeSetting());
            LoadGameCommand = new DelegateCommand(() => LoadGameState());
            SaveGameCommand = new DelegateCommand(() => SaveGameState());
        }
        private void ChangeSetting()
        {
            int parsedUserSetting;
            bool success = Int32.TryParse(SettingUserInput, out parsedUserSetting);
            if (success)
            {
                _eventAggregator.GetEvent<SettingChangedEvent>().Publish(new KeyValuePair<SettingType, int>(ValueDescriptionSelected.Value, int.Parse(SettingUserInput)));
            }
        }

        private void SaveGameState()
        {
            _eventAggregator.GetEvent<SaveGameEvent>().Publish();
        }

        private void LoadGameState()
        {
            string gameState = FileUtils.OpenFileDialogForStringOutput();
            if (gameState != null)
            {
                _eventAggregator.GetEvent<LoadGameEvent>().Publish(gameState);
            }
        }

    }
}
