using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Contracts;

namespace Twitter.Models
{
    public class Client : IClient
    {
       
        private IWriter writer;
        ITweetRepository tweetRepository;

        public Client(IWriter writer, ITweetRepository tweetRepository)
        {
            this.writer = writer;
            this.tweetRepository = tweetRepository;
        }

        public void SendTweetToServer(string message)
        {
            this.tweetRepository.SaveTweet(message);
        }

        public void WriteTweet(string message)
        {
            this.writer.WriteLine(message);
        }
    }
}
