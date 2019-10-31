using LifeGameProject.Static;
using Prism.Events;
using System.Collections.Generic;

namespace LifeGameProject.Events
{
    internal class SettingChangedEvent : PubSubEvent<KeyValuePair<SettingType, int>>
    {

    }
}
