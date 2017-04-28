
using NUnit.Framework;

using TestControllerManager.ViewModel;

namespace UnitTests
{
    [TestFixture]
    public class TestControllerViewModelTests
    {
        [Test]
        public void IsSelectedIsInitiallyFalse()
        {
            var sut = new TestControllerViewModel("test", null, false);
            Assert.IsFalse(sut.IsSelected, "Unexpected initial value for TestControllerViewModel.IsSelected");
        }
    }
}
