using kontur_niirs.ViewModel;
using NUnit.Framework;

namespace kontur_niirs.Tests
{
    [TestFixture]
    public class GetStringTest
    {
        [Test]
        public void GetSomeStr()
        {
            uint k = 158;

            var n = BriefViewModel.GetString(k);

            Assert.AreEqual("one five eight ", n);
        }
        [Test]
        public void GetBigStr()
        {
            uint x = uint.MaxValue;
            uint y = 3;

            var n = BriefViewModel.GetString((decimal)x + y);

            Assert.AreEqual("Слишком большое число", n);
        }
    }
}
