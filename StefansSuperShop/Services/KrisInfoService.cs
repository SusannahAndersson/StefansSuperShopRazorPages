using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using StefansSuperShop.ViewModels;

namespace StefansSuperShop.Services
{
	public interface IKrisInfoService
	{
		public Task<List<KrisInfo>> GetKrisInfos();

    }
    public class KrisInfoService : IKrisInfoService
	{
		private List<KrisInfo> KrisInfoList = new List<KrisInfo>();
		private DateTime LastUpdated;

		public KrisInfoService()
		{
			//fetchFromAPI();
		}

		public async Task<List<KrisInfo>> GetKrisInfos()
		{
			await fetchFromAPI();
			return KrisInfoList;
		}


		private async Task<bool> fetchFromAPI()
		{

			const string apiUrl = "https://api.krisinformation.se/v1/themes?format=json";

			if(	KrisInfoList.Count == 0 || 
				isDataStale())
			{
				using (var response = await new HttpClient().GetAsync(apiUrl))
				{
					var result = JsonConvert.DeserializeObject<KrisInfoWrapper>(await response.Content.ReadAsStringAsync());
					KrisInfoList = result.ThemeList.GetRange(0, 10);
				}

                LastUpdated = DateTime.Now;
                return true;
			}
			return false;
        }

        public bool isDataStale()
        {
            if (LastUpdated.AddHours(1) <= DateTime.Now)
                return true;
            return false;
        }

    }


}

