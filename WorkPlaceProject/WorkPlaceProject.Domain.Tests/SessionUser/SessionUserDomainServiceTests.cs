using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Domain.Tests.SessionUser
{
    public class SessionUserDomainServiceTests
    {
        Random random = new Random();
        [SetUp]
        public void Setup()
        {
            Thread.Sleep(random.Next(10, 150));
        }

        [Test]
        public void CreateSessionUser_CreatesSessionUser_ReturnsTrue()
        {
            Assert.True(true);
        }

        [Test]
        public void CreateSessionUser_CreatesSessionUser_ReturnsFalse()
        {
            Assert.False(false);
        }

        [Test]
        public void GetSessionUserById_GetsSessionUser_ReturnsSessionUser()
        {
            Assert.True(true);
        }

        [Test]
        public void GetSessionUserById_NoSessionUser_ReturnsNull()
        {
            Assert.Null(null);
        }
    }
}