using System;
using System.Collections.Generic;
using System.Text;

namespace Combobox
{
    /// <summary>
    /// 第三功能欄位
    /// </summary>
    public class BuySellOverItem
    {
        /// <summary>
        /// 股票名稱
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// 買賣超
        /// </summary>
        public string SecBrokerName { get; set; }

        /// <summary>
        /// 買賣超
        /// </summary>
        public decimal BuySellOver { get; set; }
    }
}
