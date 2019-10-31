using LifeGameProject.Models;
using LifeGameProject.Views;
using Prism.Ioc;
using System.Windows;

namespace LifeGameProject
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Settings initial = Settings.InitialSettings;
            containerRegistry.Register<ILifeGame, LifeGame>();
        }
    }
}
