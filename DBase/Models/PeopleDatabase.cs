using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBase.Models
{
    public class PeopleDatabase
    {
        private HashSet<IPerson> people;

        public PeopleDatabase()
        {
            this.people = new HashSet<IPerson>();
        }

        public PeopleDatabase(IEnumerable<IPerson> people)
            : this()
        {
            if (people != null)
            {
                foreach (var person in people)
                {
                    this.Add(person);
                }
            }
        }

        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove(IPerson person)
        {
            this.people.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
        }

        public IPerson Find(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var foundPerson = this.people.FirstOrDefault(p => p.Id == id);
            if (foundPerson == null)
            {
                throw new InvalidOperationException();
            }

            return foundPerson;
        }

        public IPerson Find(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            var foundPerson = this.people.FirstOrDefault(p => p.Username == username);
            if (foundPerson == null)
            {
                throw new InvalidOperationException();
            }

            return foundPerson;
        }
    }
}
