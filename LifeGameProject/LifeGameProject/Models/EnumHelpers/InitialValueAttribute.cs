using System;

namespace LifeGameProject.Models.EnumHelpers
{
    public class InitialValueAttribute : Attribute
    {
        public int value { get; set; }
        public InitialValueAttribute(int value)
        {
            this.value = value;
        }
    }
}
