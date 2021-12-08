﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace CryptoCheck.coingeckoResponse
{
    sealed class CoinGeckoResponse
    {
        private const string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=50&page=1&sparkline=false";
        private readonly List<Coin> _coins;
        public CoinGeckoResponse()
        {
            _coins = new List<Coin>();
            _coins = GetAPI();
        }

        public List<Coin> GetAPI()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            var result = JsonConvert.DeserializeObject<List<Coin>>(response);

            

            return result;
        }

        public List<Coin> GetCoins()
        {
            return _coins;
        }
    }
}
