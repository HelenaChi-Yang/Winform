using System;
using System.Collections.Generic;
using System.Text;

namespace Combobox
{
    /// <summary>
    /// 計算券商數量欄位
    /// </summary>
    public class CalculateItemInGrid
    {
        /// <summary>
        /// 股票代號
        /// </summary>
        public string StocksID { get; set; }

        /// <summary>
        /// 股票名稱
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// 買入總數
        /// </summary>
        public decimal BuyTotal { get; set; }

        /// <summary>
        /// 賣出總數
        /// </summary>
        public decimal SellTotal { get; set; }

        /// <summary>
        /// 平均價格
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 券商Id
        /// </summary>
        public HashSet<string> SecBrokerIdKey { get; set; }
    }
}
