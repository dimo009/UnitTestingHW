using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Contracts
{
    public interface ITweet
    {
        void ReceiveMessage(string message);
    }
}
