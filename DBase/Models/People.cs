using DBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBase
{
    public class People:IPerson, IIdentifieble
    {

        private string username;
        private long id;

        public People(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

    }
}
