using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Twitter.Contracts;
using Twitter.Models;

namespace TwitterTest.Test
{
    public class ClientTest
    {
        private const string Message = "TestMessage";

        [Test]
        public void SendTweetToServerShouldSendTheMessageToItsServer()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var tweetRepo = new Mock<ITweetRepository>();
            tweetRepo.Setup(tr => tr.SaveTweet(It.IsAny<string>()));
            var client = new Client(writer.Object, tweetRepo.Object);

            // Act
            client.SendTweetToServer(Message);

            // Assert
            tweetRepo.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == Message)),
                Times.Once,
                "Message was not sent to the server");
        }

        [Test]
        public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            writer.Setup(w => w.WriteLine(It.IsAny<string>()));
            var tweetRepo = new Mock<ITweetRepository>();
            var client = new Client(writer.Object, tweetRepo.Object);

            // Act 
            client.WriteTweet(Message);

            // Assert
            writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)),
                $"Tweet is not sent to the {typeof(Client)}'s writer");
        }
    }
}
