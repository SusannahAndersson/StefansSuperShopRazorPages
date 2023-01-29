using System;
using StefansSuperShop.Services;

namespace StefansSuperShopTests
{

	[TestClass]
	public class KrisInfoTests
	{
		private KrisInfoService sut;

		public KrisInfoTests()
		{
            sut = new KrisInfoService();

        }

        [TestMethod]
		public void stale_data_less_than_hour()
		{
			sut.LastUpdated = DateTime.Now.Subtract(TimeSpan.FromHours(1));
			Assert.IsFalse(sut.isDataStale());
		}

		[TestMethod]
		public void stale_data_exactly_an_hour()
		{
            sut.LastUpdated = DateTime.Now.AddHours(1);
            Assert.IsTrue(sut.isDataStale());
        }

		[TestMethod]
		public void stale_data_more_than_hour()
		{
            sut.LastUpdated = DateTime.Now.AddHours(2);
            Assert.IsTrue(sut.isDataStale());
        }

		[TestMethod]
		public async Task fetch_saves_10_items()
		{
			await sut.GetKrisInfosAsync();
			Assert.AreEqual(sut.KrisInfoList.Count, 10);
		}
    }
}