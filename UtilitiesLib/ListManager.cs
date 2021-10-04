using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLib
{
    public abstract class ListManager<T> : IListManager<T>
    {
        public abstract int Count { get; }

        public abstract bool Add(T aType);
        public abstract bool ChangeAt(T aType, string anIndex);
        public abstract bool CheckIndex(string index);
        public abstract void DeleteAll();
        public abstract bool DeleteAt(string anIndex);
        public abstract T GetAt(string anIndex);
        public abstract string[] ToStringArray();
        public abstract List<string> ToStringList();
    }
}
