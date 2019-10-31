using System;

namespace LifeGameProject.Models
{
    public class GameCell : ICloneable
    {
        public bool Alive { get; set; }
        public int Position { get; set; }
        public int AliveFor { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
