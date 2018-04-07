using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorTest
{
    public class ListIterator
    {
        private IList<string> list;
        private int currentIndex;

        public ListIterator(IEnumerable<string> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            this.List = new List<string>(list);
        }

        public IList<string> List
        {
            get { return this.list; }
            set { this.list = value; }
        }

        public bool Move() => ++ this.currentIndex < this.list.Count;

        public bool HasNext() => this.currentIndex < this.list.Count-1;

        public string Print()
        {

            if (this.list.Count==0)
            {
                throw new InvalidOperationException("The list is empty!");
            }
            var result = list[this.currentIndex];
            return result;
        }
    }
}
