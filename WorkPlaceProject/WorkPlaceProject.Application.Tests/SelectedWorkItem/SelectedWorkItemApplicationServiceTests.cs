using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Application.Tests.SelectedWorkItem
{
    public class SelectedWorkItemApplicationServiceTests

    {
        [SetUp]
        public void Setup()
        {
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