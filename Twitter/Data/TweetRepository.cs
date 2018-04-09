using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Twitter.Contracts;

namespace Twitter.Data
{
    public class TweetRepository : ITweetRepository
    {

        private const string ServerFileName = "Server.txt";
        private const string MessageSeparator = "<[<MessageSeparator>]>";
        private readonly string serverFullPath = Path.Combine(Environment.CurrentDirectory, ServerFileName);

       

        public void SaveTweet(string content)
        {
            File.AppendAllText(this.serverFullPath, $"{content}{MessageSeparator}");
        }
    }
}
