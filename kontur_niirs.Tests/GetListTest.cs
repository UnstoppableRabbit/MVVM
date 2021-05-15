using NUnit.Framework;
using kontur_niirs.ViewModel;
using kontur_niirs.Model;
using System.Collections.ObjectModel;

namespace kontur_niirs.Tests
{
    [TestFixture]
    class GetListTest
    {
        [Test]
        public void GetBigList()
        {
            decimal k = (decimal)uint.MaxValue + 1;

            ObservableCollection<ListItem> f = new ObservableCollection<ListItem>();

            f.Add(new ListItem { Digit = "Слишком" });
            f.Add(new ListItem { Digit = "большое" });
            f.Add(new ListItem { Digit = "число" });

            ObservableCollection<ListItem> n = DetailedViewModel.GetList(k.ToString());

            for(int i = 0; i < 3; i++ )
                Assert.AreEqual(n[i].Digit, f[i].Digit);
        }
    }
}
