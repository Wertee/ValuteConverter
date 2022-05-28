using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValuteConverter.Models;

namespace ValuteConverter.Services
{
    public class Converter
    {
        public List<Money> MoneyList { get; }

        public Converter()
        {
            MoneyList = new List<Money>();
            GetTodayValutes();
        }

        private async Task DownloadTodayValutes()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
            var responceBodyResult = response.Content.ReadAsStringAsync().Result;
            var headerWithValutesAsJson = JsonConvert.DeserializeObject<Header>(responceBodyResult);
            var moneis = JsonConvert.DeserializeObject<Dictionary<string, Money>>(headerWithValutesAsJson.Valute.ToString()).Values.ToList();
            MoneyList.AddRange(moneis);

        }

        private void GetTodayValutes()
        {
            Task downloadTask = DownloadTodayValutes();
            Task.WaitAll(downloadTask);
        }

        public decimal CountValute(string first, decimal countFirst, string second)
        {
            var firstValue = MoneyList.First(x => x.CharCode == first);
            var secondValue = MoneyList.FirstOrDefault(x => x.CharCode == second);
            return (firstValue.Value * countFirst) / (secondValue.Value);
        }
    }
}
