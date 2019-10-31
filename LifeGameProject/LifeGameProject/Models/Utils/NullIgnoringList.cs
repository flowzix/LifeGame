using System.Collections.Generic;

namespace LifeGameProject.Models
{
    internal class NullIgnoringList<T> : List<T>
    {
        public new void Add(T item)
        {
            if (item == null)
            {
                return;
            }
            base.Add(item);
        }
    }
}
