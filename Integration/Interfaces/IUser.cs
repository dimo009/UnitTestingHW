using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interfaces
{
    public interface IUser
    {
        string Name { get; }

        IEnumerable<ICategory> Categories { get; }

        void AddCategory(ICategory category);

        void RemoveCategory(ICategory category);
    }
}
