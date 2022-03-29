using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combobox
{
    /// <summary>
    /// 畫面控制
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 計時器
        /// </summary>
        private Stopwatch calculateTime;
        /// <summary>
        /// 時鐘
        /// </summary>
        private TimeSpan time;
        /// <summary>
        /// 儲存股票字典
        /// </summary>
        private Dictionary<string, List<Stock>> stockDictionary;
        /// <summary>
        /// 使用者下拉選單選擇(預設查all全部)
        /// </summary>
        private string getCustomerChoose;
        /// <summary>
        /// stockDictionary的All選項
        /// </summary>
        private string allStock;
        /// <summary>
        /// CSV檔案名稱
        /// </summary>
        private string fileName;
        /// <summary>
        /// CSV檔案欄位
        /// </summary>
        public enum StockResult
        {
            DealDate = 0,
            StocksID = 1,
            StockName = 2,
            SecBrokerID = 3,
            SecBrokerName = 4,
            Price = 5,
            BuyQty = 6,
            SellQty = 7
        }
        /// <summary>
        /// 委派UI元件更改行為
        /// </summary>
        /// <param name="sMessage"></param>
        private delegate void ShowMessage(ItemInComboBox itemInComboBox);
        /// <summary>
        /// 所有StockId
        /// </summary>
        private List<string> allStockId = new List<string>();
        /// <summary>
        /// 建構子
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            calculateTime = new Stopwatch();
            stockDictionary = new Dictionary<string, List<Stock>>();
            getCustomerChoose = "All";
            allStock = "All";
        }
        /// <summary>
        /// 讀取檔案按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ReadingFile_Click(object sender, EventArgs e)
        {
            //清除dictionary原有資料
            stockDictionary.Clear();
            //開啟CSV檔案
            OpenFileDialog csvFile = new OpenFileDialog();
            csvFile.Filter = "csv files (*.*)|*.csv";
            if (csvFile.ShowDialog() == DialogResult.OK)
            {
                //更新讀取檔案路徑顯示
                textBox1.Text = csvFile.FileName;
                fileName = csvFile.FileName;
                Task<bool> task = new Task<bool>(() => ReadCsv(fileName));
                calculateTime.Restart();
                task.Start();
                //更新讀取狀態
                ReadingMode.Text = "讀檔中";
                bool isSuccess = await task;
                calculateTime.Stop();
                QueryTime.AppendText($"{System.Environment.NewLine}讀取時間:{ calculateTime.Elapsed.ToString("hh\\:mm\\:ss\\:fff")}");
                //更新讀取狀態
                ReadingMode.Text = "讀檔完成";
                calculateTime.Restart();
                //更新全部股票dataGridView
                AddAllStock();
                MainGridView.DataSource = stockDictionary[allStock];
                //更新下拉式選單
                StockCombo.Text = getCustomerChoose;
                calculateTime.Stop();
                QueryTime.AppendText($"{System.Environment.NewLine}ComboBox:{ calculateTime.Elapsed.ToString("hh\\:mm\\:ss\\:fff")}");
            }
        }
        /// <summary>
        /// 股票搜尋按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockSearch_Click(object sender, EventArgs e)
        {
            if (stockDictionary.Count != 0)
            {
                calculateTime.Restart();
                List<Stock> finalStockList = new List<Stock>();
                List<StockSearchItem> finalSearchList = new List<StockSearchItem>();
                if (StockCombo.Text == allStock)
                {
                    finalStockList = stockDictionary[allStock];
                    finalSearchList = DealWithStockSearch(finalStockList);
                }
                else
                {
                    string[] customerChooseStock = CheckCustomerInput();
                    if (customerChooseStock == null)
                    {
                        MessageBox.Show("請輸入正確ID");
                    }
                    else
                    {
                        List<string> customerChooseStockList = new List<string>(customerChooseStock);
                        finalStockList = ChooseFinalStockList(customerChooseStockList);
                        finalSearchList = DealWithStockSearch(finalStockList);
                    }
                }
                //更新所有dataGridView
                MainGridView.DataSource = finalStockList;
                StockQueryGridView.DataSource = finalSearchList;
                //時間停止
                calculateTime.Stop();
                time = calculateTime.Elapsed;
                QueryTime.AppendText($"{System.Environment.NewLine}股票查詢: {time.ToString("hh\\:mm\\:ss\\:fff")}");
            }
            else
            {
                MessageBox.Show("請先讀檔案");
            }
        }
        /// <summary>
        /// 股票搜尋從功能一的list篩出功能二list
        /// </summary>
        /// <param name="finalStockList">功能一的List</param>
        /// <returns></returns>
        private List<StockSearchItem> DealWithStockSearch(List<Stock> finalStockList)
        {
            List<StockSearchItem> finalSearchList = new List<StockSearchItem>();
            Dictionary<string, CalculateItemInGrid> searchDictionary = new Dictionary<string, CalculateItemInGrid>();
            foreach (Stock stock in finalStockList)
            {
                if (searchDictionary.TryGetValue(stock.StocksID, out CalculateItemInGrid oneStockList))
                {
                    oneStockList.BuyTotal += stock.BuyQty;
                    oneStockList.SellTotal += stock.SellQty;
                    oneStockList.TotalPrice += stock.Price * stock.SellQty + stock.Price * stock.BuyQty;
                    oneStockList.SecBrokerIdKey.Add(stock.SecBrokerID);
                }
                else
                {
                    searchDictionary.Add(stock.StocksID, new CalculateItemInGrid
                    {
                        StockName = stock.StockName,
                        BuyTotal = stock.BuyQty,
                        SellTotal = stock.SellQty,
                        TotalPrice = stock.Price * stock.SellQty + stock.Price * stock.BuyQty,
                        SecBrokerIdKey = new HashSet<string> { stock.SecBrokerID }
                    });
                }
            }
            foreach (KeyValuePair<string, CalculateItemInGrid> stock in searchDictionary)
            {
                decimal avgPrice;
                if ((stock.Value.BuyTotal + stock.Value.SellTotal) != 0)
                {
                    avgPrice = stock.Value.TotalPrice / (stock.Value.BuyTotal + stock.Value.SellTotal);
                }
                else
                {
                    avgPrice = 0;
                };
                finalSearchList.Add(new StockSearchItem
                {
                    StocksID = stock.Key,
                    StockName = stock.Value.StockName,
                    BuyTotal = stock.Value.BuyTotal,
                    SellTotal = stock.Value.SellTotal,
                    AvgPrice = avgPrice,
                    BuySellOver = stock.Value.BuyTotal - stock.Value.SellTotal,
                    SecBrokerCnt = stock.Value.SecBrokerIdKey.Count
                });
            }
            return finalSearchList;
        }
        /// <summary>
        /// 篩選功能一的List
        /// </summary>
        /// <param name="customerChooseStock"></param>
        /// <returns></returns>
        private List<Stock> ChooseFinalStockList(List<string> customerChooseStock)
        {
            List<Stock> finalStockList = new List<Stock>();
            foreach (string stock in customerChooseStock)
            {
                foreach (Stock stockRow in stockDictionary[stock])
                {
                    finalStockList.Add(stockRow);
                }
            }
            return finalStockList;
        }
        /// <summary>
        /// 買賣超50按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOverboughtOrOversold_Click(object sender, EventArgs e)
        {
            if (stockDictionary.Count != 0)
            {
                calculateTime.Restart();
                List<BuySellOverItem> finalFiftyList = new List<BuySellOverItem>();
                //功能三，處理3邏輯：All ， 多個，亂輸入 
                if (StockCombo.Text.Equals(allStock))
                {
                    finalFiftyList = DealWithBuySellOver(allStockId);
                }
                else
                {
                    string[] customerChooseStock = CheckCustomerInput();
                    if (customerChooseStock != null)
                    {
                        List<string> searchStockId = new List<string>(customerChooseStock);
                        finalFiftyList = DealWithBuySellOver(searchStockId);
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確值");
                    }
                }
                fiftyGridView.DataSource = finalFiftyList;
                calculateTime.Stop();
                time = calculateTime.Elapsed;
                QueryTime.AppendText($"{System.Environment.NewLine}買賣超查詢:{time.ToString("hh\\:mm\\:ss\\:fff")}");
            }
            else
            {
                MessageBox.Show("請先讀檔案");
            }
        }
        /// <summary>
        /// 對每一張要查詢的股票，篩選出所有券商並依照買賣超大到小排列
        /// </summary>
        /// <param name="searchStockId">所有要查詢的股票</param>
        /// <returns></returns>
        private List<BuySellOverItem> DealWithBuySellOver(List<string> searchStockId)
        {
            List<BuySellOverItem> finalFiftyList = new List<BuySellOverItem>();
            foreach (string stockId in searchStockId)
            {
                List<Stock> oneStockList = stockDictionary[stockId];
                //為這檔股票每個券商做唯一值
                Dictionary<string, BuySellOverItem> fiftyDictionary = new Dictionary<string, BuySellOverItem>();
                foreach (Stock stockRow in oneStockList)
                {
                    if (fiftyDictionary.TryGetValue(stockRow.SecBrokerID, out BuySellOverItem buySellOverItem))
                    {
                        buySellOverItem.BuySellOver += (stockRow.BuyQty - stockRow.SellQty);
                    }
                    else
                    {
                        fiftyDictionary.Add(stockRow.SecBrokerID, new BuySellOverItem()
                        {
                            StockName = stockRow.StockName,
                            SecBrokerName = stockRow.SecBrokerName,
                            BuySellOver = stockRow.BuyQty - stockRow.SellQty
                        });
                    }
                }
                //券商買賣超排序完成後加入最後的list
                List<BuySellOverItem> buySellOverItemsList = new List<BuySellOverItem>();
                foreach (KeyValuePair<string, BuySellOverItem> stock in fiftyDictionary)
                {
                    buySellOverItemsList.Add(stock.Value);
                }
                List<BuySellOverItem> buySellOverItemsPositionList = buySellOverItemsList.OrderByDescending(buySellOverItemsPosition => buySellOverItemsPosition.BuySellOver).ToList();
                List<BuySellOverItem> buySellOverItemsNegativeList = buySellOverItemsList.OrderBy(buySellOverItemsNegative => buySellOverItemsNegative.BuySellOver).ToList();
                List<BuySellOverItem> positionList = SortPositionBuySellOver(buySellOverItemsPositionList, finalFiftyList);
                List<BuySellOverItem> negativeList = SortNegativeBuySellOver(buySellOverItemsNegativeList, finalFiftyList);
            }
            return finalFiftyList;
        }
        /// <summary>
        /// 取前50
        /// </summary>
        /// <param name="buySellOverItemsList">一張股票全部券商大到小</param>
        /// <param name="finalFiftyList">一張股票券商大到小只取前50後50</param>
        private List<BuySellOverItem> SortPositionBuySellOver(List<BuySellOverItem> buySellOverItemsList, List<BuySellOverItem> finalFiftyList)
        {
            int firstOrLastFiftyStock = 50;
            if (buySellOverItemsList.Count < 50)
            {
                firstOrLastFiftyStock = buySellOverItemsList.Count;
            }
            for (int i = 0; i < firstOrLastFiftyStock; i++)
            {
                if (buySellOverItemsList[i].BuySellOver > 0)
                {
                    finalFiftyList.Add(buySellOverItemsList[i]);
                }
                else
                {
                    break;
                }
            }
            return finalFiftyList;
        }
        /// <summary>
        /// 取後50
        /// </summary>
        /// <param name="buySellOverItemsList"></param>
        /// <param name="finalFiftyList"></param>
        /// <returns></returns>
        private List<BuySellOverItem> SortNegativeBuySellOver(List<BuySellOverItem> buySellOverItemsList, List<BuySellOverItem> finalFiftyList)
        {
            int firstOrLastFiftyStock = 50;
            if (buySellOverItemsList.Count < 50)
            {
                firstOrLastFiftyStock = buySellOverItemsList.Count;
            }
            for (int i = 0; i < firstOrLastFiftyStock; i++)
            {
                if (buySellOverItemsList[i].BuySellOver < 0)
                {
                    finalFiftyList.Add(buySellOverItemsList[i]);
                }
                else
                {
                    break;
                }
            }
            return finalFiftyList;
        }
        /// <summary>
        /// 查看使用者當前輸入值
        /// </summary>
        /// <returns></returns>
        private string[] CheckCustomerInput()
        {
            string[] customerChooseStock;
            if (StockCombo.Text.Contains("-"))
            {
                try
                {
                    getCustomerChoose = ((ItemInComboBox)StockCombo.SelectedItem).RealValue;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show($"輸入正確值{ex}");
                }
                customerChooseStock = new string[] { getCustomerChoose };
            }
            else
            {
                customerChooseStock = StockCombo.Text.Split(",");
                foreach (string oneStock in customerChooseStock)
                {
                    if (!(stockDictionary.ContainsKey(oneStock)))
                    {
                        return null;
                    }
                }
            }
            return customerChooseStock;
        }
        /// <summary>
        /// StreamReader讀CSV檔案
        /// </summary>
        private bool ReadCsv(string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8))
                {
                    //第一欄位讀取
                    string headerLine = streamReader.ReadLine();
                    //存dictionary["All"]，StockCombo，all
                    stockDictionary.Add(allStock, new List<Stock>());
                    InvokeIfRequired(new ItemInComboBox(allStock, allStock));
                    //拆解Csv Rows
                    string allData;
                    while ((allData = streamReader.ReadLine()) != null)
                    {
                        string[] splitAllData = allData.Split(",");
                        //one Stock
                        Stock stock = new Stock()
                        {
                            DealDate = splitAllData[(int)StockResult.DealDate],
                            StocksID = splitAllData[(int)StockResult.StocksID],
                            StockName = splitAllData[(int)StockResult.StockName],
                            SecBrokerID = splitAllData[(int)StockResult.SecBrokerID],
                            SecBrokerName = splitAllData[(int)StockResult.SecBrokerName],
                            Price = Convert.ToDecimal(splitAllData[(int)StockResult.Price]),
                            BuyQty = Convert.ToDecimal(splitAllData[(int)StockResult.BuyQty]),
                            SellQty = Convert.ToDecimal(splitAllData[(int)StockResult.SellQty])
                        };
                        //put stock into Dic (處理重複StockID)
                        if (stockDictionary.TryGetValue(stock.StocksID, out List<Stock> stockList))
                        {
                            stockList.Add(stock);
                            //stockDictionary[allStock].Add(stock);
                        }
                        else
                        {
                            stockDictionary.Add(stock.StocksID, new List<Stock>() { stock });
                            //都只存所有同樣股票代號的List<Stock>的第一筆([0])的資料
                            //stockDictionary[allStock].Add(stock);
                            allStockId.Add(stock.StocksID);
                            //更新ComboBox
                            InvokeIfRequired(new ItemInComboBox($"{stock.StocksID}-{stock.StockName}", stock.StocksID));
                        }
                    }
                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\nDetails:\n\n{ex.StackTrace}");
            }
            return true;
        }
        /// <summary>
        /// 更新dictionary[allStock}資料
        /// </summary>
        private void AddAllStock()
        {
            foreach (KeyValuePair<string, List<Stock>> stocks in stockDictionary)
            {
                stockDictionary[allStock].AddRange(stocks.Value);
            }
        }
        /// <summary>
        /// 檢查非同步UI
        /// </summary>
        /// <param name="itemInComboBox"></param>
        private void InvokeIfRequired(ItemInComboBox itemInComboBox)
        {
            if (StockCombo.InvokeRequired)
            {
                ShowMessage del = new ShowMessage(InvokeIfRequired);
                this.Invoke(del, itemInComboBox);
            }
            else
            {
                StockCombo.Items.Add(itemInComboBox);
            }
        }
    }
}