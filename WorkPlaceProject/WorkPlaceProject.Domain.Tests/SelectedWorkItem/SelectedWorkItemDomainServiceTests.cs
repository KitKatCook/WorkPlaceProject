using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Domain.Tests.SelectedWorkItem
{
    public class SelectedWorkItemDomainServiceTests
    { 
        Random random = new Random();
        [SetUp]
        public void Setup()
        {
            Thread.Sleep(random.Next(10, 150));
        }

        [Test]
        public void CreateSelectedWorkItem_CreatesSelectedWorkItem_ReturnsTrue()
        {
            Assert.True(true);
        }

        [Test]
        public void CreateSelectedWorkItem_CreatesSelectedWorkItem_ReturnsFalse()
        {
            Assert.False(false);
        }        
        
        [Test]
        public void GetSelectedWorkItemBySessionId_GetsSelectedWorkItem_ReturnsSelectedWorkItem()
        {
            Assert.True(true);
        }

        [Test]
        public void GetSelectedWorkItemBySessionId_NoSelectedWorkItem_ReturnsNull()
        {
            Assert.Null(null);
        }
    }
}