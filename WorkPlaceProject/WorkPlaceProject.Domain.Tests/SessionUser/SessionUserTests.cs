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
    public class SessionUserTests
    {
        [Test]
        public void Create_SessionUser_ReturnsInstanceWithCorrectValues()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();

            // Act
            SessionUser sessionUser = SessionUser.Create(id, azureId, sessionId);

            // Assert
            Assert.That(sessionUser.Id, Is.EqualTo(id));
            Assert.That(sessionUser.AzureId, Is.EqualTo(azureId));
            Assert.That(sessionUser.SessionId, Is.EqualTo(sessionId));
            Assert.IsFalse(sessionUser.IsSessionLeader);
        }
    }
}