using System;
using System.Collections.Generic;
using System.Text;

namespace Combobox
{
    /// <summary>
    /// 下拉選單選項與實際值
    /// </summary>
    public class ItemInComboBox
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="displayName">下拉選單</param>
        /// <param name="realValue">實際值</param>
        public ItemInComboBox(string displayName, string realValue)
        {
            DisplayName = displayName;
            RealValue = realValue;
        }
        /// <summary>
        /// 下拉選單名字
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 實際股票代號
        /// </summary>
        public string RealValue { get; set; }
        /// <summary>
        /// 覆寫toString回傳下拉選單名字
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
