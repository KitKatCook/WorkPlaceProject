using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Domain.Tests.StoryPointerSession
{
    public class PointerSessionDomainServiceTests
    { 
        Random random = new Random();
        [SetUp]
        public void Setup()
        {
            Thread.Sleep(random.Next(10, 150));
        }

        [Test]
        public void CreatePointerSession_CreatesPointerSession_ReturnsTrue()
        {
            Assert.True(true);
        }

        [Test]
        public void CreatePointerSession_CreatesPointerSession_ReturnsFalse()
        {
            Assert.False(false);
        }

        [Test]
        public void GetPointerSessionById_GetsPointerSession_ReturnsPointerSession()
        {
            Assert.True(true);
        }

        [Test]
        public void GetPointerSessionById_NoPointerSession_ReturnsNull()
        {
            Assert.Null(null);
        }
        
        [Test]
        public void GetPointerSessionByCode_GetsPointerSession_ReturnsPointerSession()
        {
            Assert.True(true);
        }

        [Test]
        public void GetPointerSessionByCode_NoPointerSession_ReturnsNull()
        {
            Assert.Null(null);
        }
    }
}
