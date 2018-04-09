using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Contracts
{
   public interface ITweetRepository
    {
        void SaveTweet(string content);
    }
}
