using System;
using System.Collections.Generic;
using System.Text;

namespace Combobox
{
    /// <summary>
    /// 主畫面(功能一)欄位
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string DealDate { get; set; }
        /// <summary>
        /// 股票代號
        /// </summary>
        public string StocksID { get; set; }
        /// <summary>
        /// 股票名稱
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 券商代號
        /// </summary>
        public string SecBrokerID { get; set; }
        /// <summary>
        /// 券商名稱
        /// </summary>
        public string SecBrokerName { get; set; }
        /// <summary>
        /// 成交價
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 買進張數
        /// </summary>
        public decimal BuyQty { get; set; }        
        /// <summary>
        /// 賣出張數
        /// </summary>
        public decimal SellQty { get; set; }
    }
}
