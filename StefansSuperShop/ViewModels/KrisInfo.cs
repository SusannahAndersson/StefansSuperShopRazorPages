using System;
using System.Collections.Generic;

namespace StefansSuperShop.ViewModels
{
	public class KrisInfo
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }
		public string LinkUrl { get; set; }
	}

	public class KrisInfoWrapper
	{
		public List<KrisInfo> ThemeList { get; set; }
	}
}

