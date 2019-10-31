using Prism.Mvvm;

namespace LifeGameProject.Models
{
    public class UIGameCell : BindableBase
    {

        public UIGameCell()
        {

        }
        public bool Alive { get; set; }

        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                SetProperty(ref _color, value);
            }
        }


        public int Position { get; set; }

    }
}
