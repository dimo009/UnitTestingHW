using DBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBase
{
    public interface IPerson:IIdentifieble
    {
        string Username { get; set; }
    }
}
