using LifeGameProject.Models.EnumHelpers;
using System.ComponentModel;

namespace LifeGameProject.Static
{
    public enum SettingType
    {
        [Description("Szerokość mapy")]
        [InitialValue(20)]
        CELLS_HORIZONTAL,

        [Description("Wysokość mapy")]
        [InitialValue(20)]
        CELLS_VERTICAL,

        [Description("Ilość powodująca przeludnienie (>=)")]
        [InitialValue(4)]
        OVERPOPULATION_COUNT,

        [Description("Ilość powodująca wyludnienie (<=)")]
        [InitialValue(1)]
        DEPOPULATION_COUNT,

        [Description("Ilość powodująca ożycie martwej komórki")]
        [InitialValue(3)]
        REANIMATION_COUNT


    }
}
