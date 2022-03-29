using System;
using System.Collections.Generic;
using System.Text;

namespace Combobox
{
    /// <summary>
    /// 功能二欄位
    /// </summary>
    public class StockSearchItem
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
        public decimal AvgPrice { get; set; }
        /// <summary>
        /// 買賣超
        /// </summary>
        public decimal BuySellOver { get; set; }
        /// <summary>
        /// 券商數量
        /// </summary>
        public decimal SecBrokerCnt { get; set; }
    }
}
