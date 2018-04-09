using System;

namespace TwitterTest.Test
{
    using Moq;
    using NUnit.Framework;
    using Twitter.Contracts;
    using Twitter.Models;
    

    [TestFixture]
    public class TweeterTests
    {
        [Test]
        public void ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
        {
            // Arrange
            var client = new Mock<IClient>();
            client.Setup(c => c.WriteTweet(It.IsAny<string>()));
            var tweet = new Tweet(client.Object);

           

            // Act
            tweet.ReceiveMessage("Test");

            // Assert
            // (Mock.Verify) Verifies that the method is Invoked during the Test exactly 1 time
            client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once,
                "Tweet doesn't invoke its client to write the message");
        }

        [Test]
        public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
        {
            // Arrange
            var client = new Mock<IClient>();
            client.Setup(c => c.SendTweetToServer(It.IsAny<string>()));
            var tweet = new Tweet(client.Object);

            // Act
            tweet.ReceiveMessage("Test");

            // Assert
            client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once,
                "Tweet doesn't invoke its client to send the message to the server");
        }
    }
}
