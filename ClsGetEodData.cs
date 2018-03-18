using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using QuandlCS.Connection;
using QuandlCS.Requests;
using QuandlCS.Types;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO.Compression;
using System.IO;
using TicTacTec.TA.Library;


namespace TradeApp
{
    class ClsGetEodData
    {
        public static string[] uri;
        private static DataTable DtLivedata;
        
        static ClsGetEodData()
        {
            CreateLiveDataTbl();


        }
        public static void DownloadEodDataNSEBhav(ref BackgroundWorker BGW, List<DateTime> Dates)
        {

            try
            {
                Collection<ClsScriptsMaster> ScriptCodes = ClsDataBase.GetScriptsCode(false);
                Collection<ClsPriceDataSet> ColEodData = new Collection<ClsPriceDataSet>();
                ArrayList TempData = new ArrayList();
                string BhavFileName = null;
                string BhavFilePath = null;
                string NseZipFile = null;
                string BhavCsvFileName = null;
                DateTime Tradedate = DateTime.Today; 
                DataSet ds;
                DataRow[] Dr;
                int i=0;
                ClsDashBoard.OverallPbarMax = ScriptCodes.Count;
                WebClient WC;
                foreach (DateTime item in Dates)
                {
                    ClsLog.WriteLog("Dowloading NSE Bhav file..");
                    ClsDashBoard.ScriptOStatus = "Dowloading NSE Bhav file for the date";
                    BGW.ReportProgress(0);
                    ClsDashBoard.DataDate = item.ToString("dd-MM-yyyy");
                    BGW.ReportProgress(2);
                    i = 0;
                    BhavFileName = "cm"+item.ToString("dd")+ item.ToString("MMM").ToUpper()+ item.Year.ToString()+"bhav.csv.zip";
                    BhavCsvFileName= "cm" + item.ToString("dd") + item.ToString("MMM").ToUpper() + item.Year.ToString() + "bhav.csv";
                    BhavFilePath = "https://www.nseindia.com/content/historical/EQUITIES/" + item.Year.ToString() + "/" + item.ToString("MMM").ToUpper() + "/";
                    BhavFilePath = BhavFilePath + BhavFileName;
                    NseZipFile = "AllNSEData_" + item.ToString("ddMMMyyyy") + ".zip";
                    WC = new WebClient();
                    if (File.Exists(BhavFilePath))
                        File.Delete(BhavFilePath);
                    WC.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                    WC.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1");
                    WC.DownloadFile(BhavFilePath, NseZipFile);
                    ZipFile.ExtractToDirectory(Application.StartupPath+"\\"+ NseZipFile, Application.UserAppDataPath);
                    var connString = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""",
                          Application.UserAppDataPath);
                    using (var conn = new OleDbConnection(connString))
                    {
                        conn.Open();
                        var query = "SELECT * FROM [" + BhavCsvFileName + "]";
                        using (var adapter = new OleDbDataAdapter(query, conn))
                        {
                            ds = new DataSet("CSV File");
                            adapter.Fill(ds);
                        }
                    }
                    foreach (var Scode in ScriptCodes)
                    {
                        ClsLog.WriteLog("Starting Data Download for script: " + Scode.ScriptsName + "(" + Scode.ScriptsCode + ")");
                        ClsDashBoard.ScriptOStatus = "Total Scripts: " + ScriptCodes.Count.ToString() + " Downloading " + 
                                                      i.ToString() + " Of " + ScriptCodes.Count.ToString()+
                                                      " Script Name: "+Scode.ScriptsCode;
                        ClsDashBoard.OverallProgress = i;
                        i = i + 1;
                        BGW.ReportProgress(0);
                        Dr =ds.Tables[0].Select("SYMBOL='"+ Scode.ScriptsCode + "' and SERIES='"+ Scode.Series+"'");
                        if (Dr.Length != 0)
                        {
                            Tradedate = Convert.ToDateTime(Dr[0]["TIMESTAMP"]);
                            ColEodData.Add(new ClsPriceDataSet()
                            {

                                ScriptId = Scode.ScriptId,
                                Date = Convert.ToDateTime(Dr[0]["TIMESTAMP"]),
                                OpenPrice = Dr[0]["OPEN"] != null ? Convert.ToDouble(Dr[0]["OPEN"].ToString()) : 0.0,
                                HighPrice = Dr[0]["HIGH"] != null ? Convert.ToDouble(Dr[0]["HIGH"].ToString()) : 0.0,
                                LowPrice = Dr[0]["LOW"] != null ? Convert.ToDouble(Dr[0]["LOW"].ToString()) : 0.0,
                                LastPrice = Dr[0]["LAST"] != null ? Convert.ToDouble(Dr[0]["LAST"].ToString()) : 0.0,
                                ClosePrice = Dr[0]["CLOSE"] != null ? Convert.ToDouble(Dr[0]["CLOSE"].ToString()) : 0.0,
                                TotalVal = Dr[0]["TOTTRDQTY"] != null ? Convert.ToDouble(Dr[0]["TOTTRDQTY"].ToString()) : 0.0,
                                TurnOver = Dr[0]["TOTTRDVAL"] != null ? Convert.ToDouble(Dr[0]["TOTTRDVAL"].ToString()) : 0.0
                            });
                        }
                        else
                        {
                            ColEodData.Add(new ClsPriceDataSet()
                            {

                                ScriptId = Scode.ScriptId,
                                Date = Tradedate,
                                OpenPrice = 0.0,
                                HighPrice = 0.0,
                                LowPrice =  0.0,
                                LastPrice = 0.0,
                                ClosePrice =0.0,
                                TotalVal =  0.0,
                                TurnOver = 0.0
                            });
                        }
                        ClsDataBase.UpdateEodData(ColEodData, Scode.TableName);
                        ClsLog.WriteLog("Data Download for script: " + Scode.ScriptsName + "(" + Scode.ScriptsCode + ") Completed.");
                        ColEodData.Clear();
                        
                    }
                    File.Move(Application.UserAppDataPath+@"\" + BhavCsvFileName, @"E:\TradeAppBackup\" + BhavCsvFileName);

                }
                ClsLog.WriteLog("Running EMA DMA SP...");
                ClsDashBoard.ScriptOStatus = "Data Download Complete. Running EMA DMA Update SP.";
                ClsDashBoard.ScriptSStatus = "Data Download Complete. Running EMA DMA Update SP.";
                BGW.ReportProgress(0);
                ClsDataBase.UpdateEmaDma();
                ClsLog.WriteLog("Running EMA DMA SP...Completed");

            }
            catch(Exception ex)
            {
                ClsLog.WriteLog(ex.Message);
            }
        }
        public static void DownlaodBulkEodData(ref BackgroundWorker BGW,List<DateTime> Dates)
        {
            try
            {
                Collection<ClsScriptsMaster> ScriptCodes = ClsDataBase.GetScriptsCode(false);
                Collection<ClsPriceDataSet> ColEodData = new Collection<ClsPriceDataSet>();
                ArrayList TempData = new ArrayList();
                string json="";
                ClsDashBoard ObjDashBoard = new ClsDashBoard();
                ClsDashBoard.OverallPbarMax= ScriptCodes.Count;
                //ClsDashBoard.ChangeOPbarValue = false;
                //ClsDashBoard.OverallPbarMax = ScriptCodes.Count;
                int i=1;int j = 1;
                foreach (var Scode in ScriptCodes)
                {
                    
                    ClsLog.WriteLog("Starting Data Download for script: " + Scode.ScriptsName + "(" + Scode.ScriptsCode + ")");

                    QuandlDownloadRequest request = new QuandlDownloadRequest();
                    request.APIKey = "Fp8XizZQKq3P1pqcHNxc";
                    request.Datacode = new Datacode("NSE", Scode.ScriptsCode); // PRAGUESE is the source, PX is the datacode
                    request.Format = FileFormats.JSON;
                    request.Frequency = Frequencies.Daily;
                    request.StartDate = Dates[0];
                    if(Dates.Count>1)
                    request.EndDate = Dates[Dates.Count-1];
                    //request.Truncation = 150;
                    request.Sort = SortOrders.Descending;
                    //request.Transformation = Transformations.Difference;
                    QuandlConnection conn = new QuandlConnection();
                    try
                    {
                        json = conn.Request(request); // request is your QuandlDownloadRequst
                    }
                    catch(Exception ex)
                    {
                        ClsLog.WriteLog("ERROR: Not able to Downlaoding data for " + Scode.ScriptsCode + ". Exception: " + ex.Message);
                        ClsDataBase.MarkScriptInvalid(Scode.ScriptsCode);
                        continue;
                    }

                    RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
                    ClsDashBoard.ScriptOStatus = "Total Scripts: "+ScriptCodes.Count.ToString()+" Downloading "+i.ToString()+" Of "+ ScriptCodes.Count.ToString();
                    ClsDashBoard.OverallProgress = i;
                    ClsDashBoard.ScriptPbarMax = 0;
                    ClsDashBoard.ChangeSPbarValue = true;
                    BGW.ReportProgress(0);
                    ClsDashBoard.ScriptSStatus = Scode.ScriptsCode+" Total Records:"+ obj.data.Count.ToString();
                    ClsLog.WriteLog(Scode.ScriptsCode + " Total Records:" + obj.data.Count.ToString());
                    ClsDashBoard.ScriptPbarMax = obj.data.Count;
                    ClsDashBoard.ChangeSPbarValue = true;
                    BGW.ReportProgress(0);
                    i = i + 1;
                    j = 0;

                    //ClsDashBoard.ScriptPbarMax = obj.data.Count;
                    if (obj.data.Count != 0)
                    {
                        foreach (var item in obj.data)
                        {

                            ColEodData.Add(new ClsPriceDataSet()
                            {
                                ScriptId = Scode.ScriptId,
                                Date = Convert.ToDateTime(item[0].ToString()),
                                OpenPrice = item[1] != null ? Convert.ToDouble(item[1].ToString()) : 0.0,
                                HighPrice = item[2] != null ? Convert.ToDouble(item[2].ToString()) : 0.0,
                                LowPrice = item[3] != null ? Convert.ToDouble(item[3].ToString()) : 0.0,
                                LastPrice = item[4] != null ? Convert.ToDouble(item[4].ToString()) : 0.0,
                                ClosePrice = item[5] != null ? Convert.ToDouble(item[5].ToString()) : 0.0,
                                TotalVal = item[6] != null ? Convert.ToDouble(item[6].ToString()) : 0.0,
                                TurnOver = item[7] != null ? Convert.ToDouble(item[7].ToString()) : 0.0
                            });
                            ClsDashBoard.ScriptProgress = j;
                            BGW.ReportProgress(0);
                            j = j + 1;
                        }
                    }
                    else
                    {
                        ColEodData.Add(new ClsPriceDataSet()
                        {
                            ScriptId = Scode.ScriptId,
                            Date = request.StartDate,
                            OpenPrice = 0.0,
                            HighPrice = 0.0,
                            LowPrice = 0.0,
                            LastPrice = 0.0,
                            ClosePrice = 0.0,
                            TotalVal = 0.0,
                            TurnOver = 0.0
                        });
                        ClsDashBoard.ScriptProgress = j;
                        BGW.ReportProgress(0);
                        j = j + 1;
                    }
                    ClsDataBase.UpdateEodData(ColEodData,Scode.TableName);
                    ColEodData.Clear();
                    ClsLog.WriteLog("Data Download for script: " + Scode.ScriptsName + "(" + Scode.ScriptsCode + ") Completed.");
                }
                ClsLog.WriteLog("Running EMA DMA SP...");
                ClsDashBoard.ScriptOStatus = "Data Download Complete. Running EMA DMA Update SP.";
                ClsDashBoard.ScriptSStatus = "Data Download Complete. Running EMA DMA Update SP.";
                BGW.ReportProgress(0);
                ClsDataBase.UpdateEmaDma();
                ClsLog.WriteLog("Running EMA DMA SP...Completed");
            }
            catch (Exception ex)
            {

                ClsLog.WriteLog(ex.Message);
            }
            
            
        }
        public static string  GetLatestDateFromQuandl()
        {
            QuandlDownloadRequest request = new QuandlDownloadRequest();
            request.APIKey = "Fp8XizZQKq3P1pqcHNxc";
            request.Datacode = new Datacode("NSE", "ICICIBANK"); // PRAGUESE is the source, PX is the datacode
            request.Format = FileFormats.JSON;
            request.Frequency = Frequencies.Daily;
            request.StartDate = DateTime.Today.AddDays(-5);
            request.Sort = SortOrders.Descending;
            //request.Transformation = Transformations.Difference;
            QuandlConnection conn = new QuandlConnection();
            string json = "";
            try
            {
                json = conn.Request(request); // request is your QuandlDownloadRequst
                RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
                return obj.to_date;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: Not able to Downlaoding data for " + "ICICIBANK" + ". Exception: " + ex.Message);
                //ClsDataBase.MarkScriptInvalid("ICICIBANK");
                return null;
            }

            
        }
        public static void Indicator()
        {
            
        }
        public static DataTable GetLivedata()
        {
            //Collection<ClsScriptsMaster> ScriptCodes = ClsDataBase.GetScriptsCode(true);
            
            WebClient wc = new WebClient();
            uri = ClsPriceDataSetLive.uri;
            int i = 0;
            foreach (String StrUri in uri)
            {
                var json = wc.DownloadString(StrUri);
                    json = json.Remove(0, 3);
                dynamic Result = JsonConvert.DeserializeObject<dynamic>(json);

                foreach (dynamic item in Result)
                {

                    DtLivedata.Rows[i]["LivePrice"] = item.l;
                    if(item.c!="")
                    DtLivedata.Rows[i]["ChangeInPrice"] = item.c;
                    DtLivedata.Rows[i]["Trend"] = "Positive";
                   // DtLivedata.Rows[i]["ScriptName"] = item.l;
                    i++;
                    //  var CurPrice = item.l;
                    //  var Change = item.c;
                    //  var Name = item.t;
                    //ClsLog.WriteLog("Update TblScriptDetails set GoogleScriptID='"+item.id+"' where ScriptCode='"+item.t+"'");
                    // MessageBox.Show(Convert.ToString(CurPrice) + "," + Convert.ToString(Change)+","+Convert.ToString(Name));
                }
            }
            return DtLivedata;
            ////     var json = wc.DownloadString(uri);
            //     json = json.Remove(0, 3);
            //     dynamic Result = JsonConvert.DeserializeObject<dynamic>(json);
            //     dynamic blogPost = Result[0];
            //     var CurPrice = blogPost.l;


        }
        public static string[] GetScriptForLiveData()
        {
            int i = 0;
            int j = 0;
            string[] UriList = new string[4];
            try
            {
                Collection<ClsScriptsMaster> ScriptCodes = ClsDataBase.GetScriptsCode(true);
                System.Text.StringBuilder StrScpt = new System.Text.StringBuilder();
                StrScpt.Append("https://www.google.com/finance/info?q=");
                foreach (var Script in ScriptCodes)
                {
                    StrScpt.Append("NSE:" + Script.ScriptsCode + ",");
                    i++;
                    if (i == 100)
                    {
                        StrScpt.Remove(StrScpt.Length - 1, 1);
                        StrScpt.Replace("&", "%26");
                        UriList[j] = StrScpt.ToString();
                        StrScpt.Clear();
                        StrScpt.Append("https://www.google.com/finance/info?q=");
                        j++;
                        i = 0;
                    }
                }
                if (i != 0)
                {
                    StrScpt.Remove(StrScpt.Length - 1, 1);
                    StrScpt.Replace("&", "%26");
                    UriList[j] = StrScpt.ToString();
                }
                
                return UriList;
            }
            catch(Exception ex)
            {
                ClsLog.WriteLog("ERROR:GetScriptForLiveData " + ex.Message);
                return null;
            }
        }
        private static void CreateLiveDataTbl()
        {
            Collection<ClsScriptsMaster> ScriptCodes = ClsDataBase.GetScriptsCode(true);
            DtLivedata = new DataTable("NSELiveData");
            DtLivedata.Columns.Add("ScriptCode", typeof(string));
            DtLivedata.Columns.Add("ScriptID", typeof(string));
            DtLivedata.Columns.Add("LivePrice", typeof(float));
            DtLivedata.Columns.Add("ChangeInPrice", typeof(float));
            DtLivedata.Columns.Add("LastClosePrice", typeof(float));
            DtLivedata.Columns.Add("Trend", typeof(string));
            DtLivedata.Columns.Add("ScriptName", typeof(string));
            foreach (var item in ScriptCodes)
            {

                DtLivedata.Rows.Add(item.ScriptsCode, item.ScriptId, null, null,ClsDataBase.GetSriptLastClosePrice(item.ScriptsCode), null, item.ScriptsName);
                

            }
        }

        
        
    }
    
    class ClsPriceDataSet
    {
        public int ScriptId {get; set;}
        public DateTime Date { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double LastPrice { get; set; }
        public double ClosePrice { get; set; }
        public double TotalVal { get; set; }
        public double TurnOver { get; set; }

    }
    class ClsPriceDataSetLive
    {
        public string ScriptId { get; set; }
        public string ScriptCode { get; set; }
        public string ScriptName { get; set;}
        public DateTime Date { get; set; }
        public double CurrentPrice { get; set; }
        public double ChangeInPrice { get; set; }
        public string Trend { get; set;}
        private static string[] _StrUri;
        public static string[] uri
        {
            get { return _StrUri ?? (_StrUri=ClsGetEodData.GetScriptForLiveData()); }

        }
        private static DataTable _DtLiveData;
        public static DataTable TblLiveData
        {
            get { return ClsGetEodData.GetLivedata(); }
        }
    }
    class ClsScriptsMaster
    {
        public int ScriptId { get; set; }
        public string ScriptsName { get; set; }
        public string ScriptsCode { get; set; }
        public string Series { get; set; }
        public DateTime DateOfListing { get; set; }
        public int FaceValue { get; set; }
        public bool Favourite { get; set; }
        public string TableName { get; set; }
    }
    public class Errors
    {
    }
    public class RootObject
    {
        public Errors errors { get; set; }
        public int id { get; set; }
        public string source_name { get; set; }
        public string source_code { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string urlize_name { get; set; }
        public string display_url { get; set; }
        public string description { get; set; }
        public string updated_at { get; set; }
        public string frequency { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public List<string> column_names { get; set; }
        public bool @private { get; set; }
        public object type { get; set; }
        public bool premium { get; set; }
        public List<List<object>> data { get; set; }
    }
    public static class StringExtensions
    {
        public static bool Contains(this string Sourcestr,string Tocheck,StringComparison Comp)
        {
            return Sourcestr.IndexOf(Tocheck,Comp)>=0;
        }
    }
}
