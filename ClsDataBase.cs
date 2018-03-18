using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Collections.ObjectModel;
using System.Data;

namespace TradeApp
{
    class ClsDataBase
    {
        static SqlConnection Conn = new SqlConnection("Server=.;Database=DBTradeApp;Trusted_Connection=true");
        static SqlCommand CMD;

        public static void InsertScriptCode()
        {

            try
            {

                int i = 0;
                SqlCommand Cmd = new SqlCommand();
                var reader = new StreamReader(File.OpenRead(@"F:\EQUITY_L.csv"));
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listc = new List<string>();
                List<string> listd = new List<string>();
                List<string> liste = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                    listc.Add(values[2]);
                    listd.Add(values[3]);
                    liste.Add(values[4]);
                }

                Cmd.Connection = Conn;
                Conn.Open();
                foreach (var item in listA)
                {
                    Cmd.CommandText = "Insert into TblScriptDetails(ScriptCode,ScriptName,Series,DateOfListing,FaceValue,Favourite) values ('" + listA[i] + "','" + listB[i] + "','"+ listc[i] + "','" + listd[i] + "','" + liste[i] + "',0)";
                    Cmd.ExecuteNonQuery();
                    i = i + 1;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conn.Close();
            }
        }
        public static bool UpdateEodData(Collection<ClsPriceDataSet> EodData, string TableName)
        {
            CMD = new SqlCommand();
            CMD.Connection = Conn;
            try
            {
                Conn.Open();
                foreach (var item in EodData)
                {
                    CMD.CommandText = "Insert into " + TableName +
                        " (ScriptId,TradeDate,OpenPrice,HighPrice,LowPrice," +
                        "LastPrice,ClosePrice,TotalValume,TurnOver)" +
                        "Values(" + item.ScriptId + ",'" + item.Date.ToShortDateString() + "','" +
                        item.OpenPrice + "','" + item.HighPrice + "','" + item.LowPrice + "','" +
                        item.LastPrice + "','" + item.ClosePrice + "','" + item.TotalVal + "','" + item.TurnOver + "' )";
                    CMD.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static Collection<ClsScriptsMaster> GetScriptsCode(bool IsLiveScripts)
        {
            try
            {
                Collection<ClsScriptsMaster> ScriptCodes = new Collection<ClsScriptsMaster>();
                SqlCommand Cmd = new SqlCommand();
                SqlDataReader Dr;
                Cmd.Connection = Conn;
                if (IsLiveScripts)
                    Cmd.CommandText = "Select * from TblScriptDetails where Active=1 and ZerodhaIntraDay=1 order by ID";
                else
                    Cmd.CommandText = "Select * from TblScriptDetails where Active=1 order by ID";
                Conn.Open();
                Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    ScriptCodes.Add(new ClsScriptsMaster()
                    {
                        ScriptId = Convert.ToInt16(Dr["ID"].ToString()),
                        ScriptsName = Dr["ScriptName"].ToString().Trim(),
                        Series= Dr["Series"].ToString().Trim(),
                        ScriptsCode = Dr["ScriptCode"].ToString().Trim(),
                        DateOfListing = Convert.ToDateTime(Dr["DateOfListing"].ToString()),
                        FaceValue = Convert.ToInt16(Dr["FaceValue"].ToString()),
                        Favourite = Convert.ToBoolean(Dr["Favourite"].ToString()),
                        TableName = Dr["TableName"].ToString().Trim()
                    });

                }
                return ScriptCodes;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }

        }
        public static void MarkScriptInvalid(string ScriptCode)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Update TblScriptDetails set Active=0 where ScriptCode='" + ScriptCode + "'";
                Conn.Open();
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        public static bool UpdateConfigTbl(string ConfigName, string ConfigValue)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Update tblConfig set COnfigValue='"+ConfigValue+"' where ConfigName='" + ConfigName + "'";
                Conn.Open();
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ex.Message);
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public static List<DateTime> GetDatesForDataDownload(string DownloadedDate,string QunadlDate)
        {
            try
            {
                List<DateTime> DownloadDate = new List<DateTime>();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                DateTime BSEBhavFileTime = Convert.ToDateTime("6:00 PM");
                if(DateTime.Now.TimeOfDay> BSEBhavFileTime.TimeOfDay)
                Cmd.CommandText = "select * from businessdays where BusinessDate>'" + DownloadedDate + "' and businessDate<='" + DateTime.Today + "' order by BusinessDate";
                else
                Cmd.CommandText = "select * from businessdays where BusinessDate>'" + DownloadedDate + "' and businessDate<='" + DateTime.Today.AddDays(-1) + "' order by BusinessDate";
                Conn.Open();
                SqlDataReader Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    DownloadDate.Add(Convert.ToDateTime(Dr[0]));
                }
                return DownloadDate;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                Conn.Close();
            }
                
        }
        public static string GetConfigValue(string ConfigName)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select ConfigValue from tblConfig where ConfigName='" + ConfigName + "'";
                Conn.Open();
                return Cmd.ExecuteScalar().ToString();
                
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ex.Message);
                return "False";
            }
            finally
            {
                Conn.Close();
            }
        }
        public static bool UpdateEmaDma()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateEMA_DMA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = Conn;
                Conn.Open();
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                ClsLog.WriteLog("ERROR: Module UpdateEmaDma : "+ex.Message);
                return false;
            }
            finally
            {
                Conn.Close();
            }

        }
        public static DataTable GetBreakOutData(int Mode)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataReader dr;
                Cmd.Connection = Conn;
                Cmd.CommandText = "PR_Get_DMA_P_Breakout_Scripts";
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", Mode);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Int32;
                Cmd.Parameters.Add(param);
                Conn.Open();
                Da.SelectCommand = Cmd;
                Da.Fill(Ds);
                if (Ds.Tables.Count > 0)
                {
                    Dt = Ds.Tables[0];
                    return Dt;
                }
                return null;
            }
            catch(Exception ex)
            {
                ClsLog.WriteLog("ERROR: "+ ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static string GetSriptLastClosePrice(string ScriptCode)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "select concat(Rtrim(TableName),'|',ID) from TblScriptDetails where ScriptCode='" + ScriptCode+ "'";
                Conn.Open();
                var TableName=Cmd.ExecuteScalar().ToString().Split('|');
                Conn.Close();
                Cmd.CommandText = "select top 1 ClosePrice from " + TableName[0]+" where ScriptId=" + TableName[1] + " order by TradeDate desc";
                Conn.Open();
                return Cmd.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static bool RemoveSwingScript(int ScriptId)
        {
            try
            {
                    CMD = new SqlCommand();
                    CMD.Connection = Conn;
                    Conn.Open();
                    CMD.CommandText = "Delete from TblSwingScripts where ScriptId="+ScriptId;
                    CMD.ExecuteNonQuery();
                    return true;
                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        public  static bool InsertSwingScripts(string[] Data,bool DataUpdate)
        {
            try
            {
                if (!DataUpdate)
                {
                    CMD = new SqlCommand();
                    CMD.Connection = Conn;
                    Conn.Open();
                    CMD.CommandText = "Insert into TblSwingScripts" +
                        " Values(" + Data[0] + "," + Data[1] + "," +
                       Data[2] + ",'" + Data[3] + "',0,"+ Data[4] + ")";
                    CMD.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    CMD = new SqlCommand();
                    CMD.Connection = Conn;
                    Conn.Open();
                    CMD.CommandText = "Update TblSwingScripts Set" +
                        " UpperLimit="+ Data[1] + ",LowerLimit=" +
                       Data[2] + ",Comments='" + Data[3]+"' where ScriptId="+ Data[0];
                    CMD.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static string[] GetSwingScriptById(string ScriptId)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "select concat(UpperLimit,'|',LowerLimit,'|',Comments) from TblSwingScripts where ScriptID='" + ScriptId + "'";
                Conn.Open();
                var Data= Cmd.ExecuteScalar();
                if (Data != null)
                    return Data.ToString().Split('|');
                else
                    return null;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }

        public static DataTable GetSwingScriptData()
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataReader dr;
                Cmd.Connection = Conn;
                Cmd.CommandText = "select RTRIM( B.ScriptName) ScriptName,C.LastClosePrice,A.* from TblSwingScripts"+
                    " A join TblScriptDetails B on A.ScriptID = B.ID Join TblScriptDMA_EMA C on A.ScriptID = C.ScriptID";
                Conn.Open();
                Da.SelectCommand = Cmd;
                Da.Fill(Ds);
                if (Ds.Tables.Count > 0)
                {
                    Dt = Ds.Tables[0];
                    return Dt;
                }
                return null;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static DataTable GetSwingThit(bool BuyCall)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataReader dr;
                Cmd.Connection = Conn;
                if(BuyCall)
                Cmd.CommandText = "select C.ScriptName,D.LastClosePrice  from (select B.ScriptName,A.ScriptID from TblSwingScripts A join TblScriptDetails B on A.ScriptID=B.ID where A.TargetHit=1)C" +
                                  " Join TblScriptDMA_EMA D on C.ScriptID = D.ScriptID";
                else
                Cmd.CommandText = "select C.ScriptName,D.LastClosePrice  from (select B.ScriptName,A.ScriptID from TblSwingScripts A join TblScriptDetails B on A.ScriptID=B.ID where A.TargetHit=2)C" +
                                  " Join TblScriptDMA_EMA D on C.ScriptID = D.ScriptID";
                Conn.Open();

                Da.SelectCommand = Cmd;
                Da.Fill(Ds);
                if (Ds.Tables.Count > 0)
                {
                    Dt = Ds.Tables[0];
                    return Dt;
                }
                return null;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static bool DeleteTrackScript(int ScriptId)
        {
            try
            {
                CMD = new SqlCommand();
                CMD.Connection = Conn;
                Conn.Open();
                CMD.CommandText = "Delete from TblScriptTracking where ScriptId=" + ScriptId;
                CMD.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static bool InsertTrackScripts(string[] Data)
        {
            try
            {
                    CMD = new SqlCommand();
                    CMD.Connection = Conn;
                    Conn.Open();
                    CMD.CommandText = "Insert into TblScriptTracking" +
                        " Values(" + Data[0] + ",'" + Data[1] + "'," +
                       Data[2] +")";
                    CMD.ExecuteNonQuery();
                    return true;
                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static bool CheckTrackScript(string ScriptID)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataReader dr;
                Cmd.Connection = Conn;
                Cmd.CommandText = "select Count(*) from TblScriptTracking where ScriptID="+ScriptID;
                Conn.Open();
                if (Cmd.ExecuteScalar().ToString() == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static DataTable GetTrackScriptData()
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataReader dr;
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select B.ScriptName,A.* from TblScriptTracking A Join TblScriptDetails B "+
                                  "on A.ScriptID = B.ID";
                Conn.Open();

                Da.SelectCommand = Cmd;
                Da.Fill(Ds);
                if (Ds.Tables.Count > 0)
                {
                    Dt = Ds.Tables[0];
                    return Dt;
                }
                return null;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public static DataTable GetTrackScriptData(String ScriptId, string StartDate)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataReader dr;
                Cmd.Connection = Conn;
                //Cmd.CommandText = "Select B.ScriptName,A.* from TblScriptTracking A Join TblScriptDetails B " +
                                 // "on A.ScriptID = B.ID";
                Conn.Open();

                Da.SelectCommand = Cmd;
                Da.Fill(Ds);
                if (Ds.Tables.Count > 0)
                {
                    Dt = Ds.Tables[0];
                    return Dt;
                }
                return null;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog("ERROR: " + ex.Message);
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }

    }

}
