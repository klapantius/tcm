using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using TestControllerManager;
using TestControllerManager.BusinessLogic;
using TestControllerManager.ViewModel;


namespace UnitTests
{
    [TestFixture]
    public class MainViewModelTests
    {
        [Test]
        public void TestControllerIsSelectedPropertyWillBeTrueOnSelecting()
        {
            var mckCfg = new Mock<IConfiguration>();
            mckCfg.Setup(foo => foo.Favourites).Returns(string.Empty);
            var sut = new MainViewModel(mckCfg.Object, null, null, null);
            var mckBus = new Mock<ITestController>();
            mckBus.Setup(foo => foo.Agents).Returns(new List<ITestAgent>());
            var tc1 = new TestControllerViewModel("tc1", mckBus.Object, false);
            sut.TestController = tc1;
            Assert.IsTrue(tc1.IsSelected, "Unexpected value for TestControllerViewModel.IsSelected after the TestController got selected.");
        }

        [Test]
        public void PreviouslySelectedTestControllerWillBeUnselectedOnChange()
        {
            var mckCfg = new Mock<IConfiguration>();
            mckCfg.Setup(foo => foo.Favourites).Returns(string.Empty);
            var sut = new MainViewModel(mckCfg.Object, null, null, null);
            var mckBus = new Mock<ITestController>();
            mckBus.Setup(foo => foo.Agents).Returns(new List<ITestAgent>());
            var tc1 = new TestControllerViewModel("tc1", mckBus.Object, false);
            var tc2 = new TestControllerViewModel("tc2", mckBus.Object, false);
            sut.TestController = tc1;
            sut.TestController = tc2;
            Assert.IsFalse(tc1.IsSelected, "Unexpected value of IsSelected for previously selected test controller.");
            Assert.IsTrue(tc2.IsSelected, "Unexpected value of IsSelected for later selected test controller.");
        }
    }
}
