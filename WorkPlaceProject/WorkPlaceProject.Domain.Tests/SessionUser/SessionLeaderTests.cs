using NUnit.Framework;
using WorkPlaceProject.Domain.SessionUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Domain.SessionUser.Tests
{
    [TestFixture()]
    public class SessionLeaderTests
    {
        [Test]
        public void Create_SessionLeader_ReturnsInstanceWithCorrectValues()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();

            // Act
            SessionLeader sessionLeader = SessionLeader.Create(id, azureId, sessionId);

            // Assert
            Assert.That(sessionLeader.Id, Is.EqualTo(id));
            Assert.That(sessionLeader.AzureId, Is.EqualTo(azureId));
            Assert.That(sessionLeader.SessionId, Is.EqualTo(sessionId));
            Assert.IsFalse(sessionLeader.IsSessionLeader);
        }
    }
}