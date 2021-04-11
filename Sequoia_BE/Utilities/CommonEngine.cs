using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Net;
using System.Net.Cache;
using System.Configuration;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Sequoia_BE.Utilities
{
    public class CommonEngine
    {
        private string strUserCode = "";
        private string strSiteCode = "";
        private SqlConnection myConnection = null;
        private SqlDataAdapter oSqlAdap = null;
        private DataSet Ds = null;
        private SqlCommand oCommand = null;

        public DataSet ExecuteDataSet(string Query)
        {
            DataSet functionReturnValue = null;
            string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["Logger"];
            myConnection = new SqlConnection(ConnectionString);
            Ds = new DataSet();
            try
            {
                myConnection.Open();
                oSqlAdap = new SqlDataAdapter(Query, myConnection);
                oSqlAdap.Fill(Ds, "T_Temp");
                functionReturnValue = Ds;
            }
            catch (Exception ex)
            {
                myConnection.Close();
                throw new ApplicationException("Exception in Run Query  " + ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection = null;
                oSqlAdap = null;
            }
            return functionReturnValue;
        }

        public DataTable ExecuteDataTable(string strQuery)
        {
            string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["Logger"];
            myConnection = new SqlConnection(ConnectionString);
            DataTable _retVal = null;
            DataSet oDataSet = new DataSet();
            try
            {
                myConnection.Open();
                oCommand = new SqlCommand();
                if (myConnection.State == ConnectionState.Open)
                {
                    oCommand.Connection = myConnection;
                    oCommand.CommandText = strQuery;
                    oCommand.CommandType = CommandType.Text;
                    oSqlAdap = new SqlDataAdapter(oCommand);
                    if (oSqlAdap != null)
                        oSqlAdap.Fill(oDataSet);
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                myConnection.Close();
                oCommand = null;
                oSqlAdap = null;
            }
            return _retVal = oDataSet.Tables[0];
        }


        public DataTable GetDataTableFromAPI(string strURL, string postData)
        {
            DataTable _retVal = null;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strURL);
                var data = Encoding.ASCII.GetBytes(postData);
                req.Method = "POST";
                req.ContentType = "application/json";
                req.ContentLength = data.Length;
                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                WebResponse response = req.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);
                JavaScriptSerializer js = new JavaScriptSerializer();
                js.MaxJsonLength = Int32.MaxValue;
                js.RecursionLimit = 100;
                dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());
                dynamic MyDynamic_Result = MyDynamic["result"];
                JavaScriptSerializer js_result = new JavaScriptSerializer();
                js_result.MaxJsonLength = Int32.MaxValue;
                js_result.RecursionLimit = 100;
                var json = js_result.Serialize(MyDynamic_Result);
                _retVal = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            }
            catch (Exception)
            {
                return _retVal;
            }
            return _retVal;
        }

        public bool ExecuteQueryHasRows(string strQuery)
        {
            bool _RetVal = false;
            string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["Logger"];
            myConnection = new SqlConnection(ConnectionString);
            DataSet oDataSet = new DataSet();
            try
            {
                myConnection.Open();
                oCommand = new SqlCommand();
                if (myConnection.State == ConnectionState.Open)
                {
                    oCommand.Connection = myConnection;
                    oCommand.CommandText = strQuery;
                    oCommand.CommandType = CommandType.Text;
                    oSqlAdap = new SqlDataAdapter(oCommand);
                    if (oSqlAdap != null)
                        oSqlAdap.Fill(oDataSet);
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                myConnection.Close();
                oCommand = null;
                oSqlAdap = null;
            }
            if (oDataSet.Tables[0].Rows.Count == 0)
            {
                _RetVal = false;
            }
            else
            {
                _RetVal = true;
            }
            return _RetVal;
        }

        public DataTable GetDataTableFromExcel(string Path)
        {
            DataTable rs = null;
            OleDbConnection odConnection = null;
            OleDbDataAdapter oda = null;
            odConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1;';");
            odConnection.Open();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = odConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);         
            string sheetName = string.Empty;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {                   
                    cmd.Connection = odConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [" + dt.Rows[0][0].ToString() + "]";
                    oda = new OleDbDataAdapter(cmd);
                    oda.Fill(ds, "excelData");
                    rs = ds.Tables["excelData"];
                }
            }
            return rs;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool UploadFile(string _Document, string PrimaryKey, string FileName)
        {
            bool _RetVal = false;
            try
            {

                FileName = "C:\\Users\\User\\Desktop\\OHS Product List.xlsx";
                string _URI = "ftp://localhost:21/" + _Document + "/" + Path.GetFileName(FileName) + "";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URI);
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("User", "123123");

                StreamReader sourceStream = new StreamReader(@FileName);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return _RetVal;
        }

        public void ExecuteNonQuery(string strQuery, SqlParameter[] sqlParameters=null)
        {
            string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["Logger"];
            myConnection = new SqlConnection(ConnectionString);
            try
            {
                myConnection.Open();
                oCommand = new SqlCommand();
                if (myConnection.State == ConnectionState.Open)
                {
                    oCommand.Connection = myConnection;
                    oCommand.CommandText = strQuery;
                    oCommand.CommandType = CommandType.Text;
                    if (sqlParameters!=null)
                    {
                        foreach (SqlParameter parameter in sqlParameters)
                        {
                            oCommand.Parameters.Add(parameter);
                        }
                    }
                    oCommand.ExecuteNonQuery();

                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                myConnection.Close();
                oCommand = null;
                oSqlAdap = null;
            }

        }

        public string GetAutoGenerateCode(string UserCode,string SiteCode, string Type)
        {
            string _RetVal = string.Empty;
            DataTable oDT_Series = new DataTable();          
            oDT_Series = ExecuteDataTable("Select dbo.Get_NextCode('"+ UserCode.Trim() + "','"+ SiteCode.Trim() + "','"+ Type.Trim() + "')");
            if (oDT_Series.Rows.Count == 1)
            {
                _RetVal = oDT_Series.Rows[0][0].ToString().Trim();
            }
            else
            {
                _RetVal = "";
            }
            return _RetVal;
        }

        public bool Check_UserAuthorization(string UserCode, string MenuCode)
        {

            try
            {
                DataTable oDT_General = new DataTable();
                oDT_General = ExecuteDataTable("Select * from MenuAuth Where [User]='" + UserCode + "' And MenuCode='" + MenuCode + "' And Active='Y'");
                if (oDT_General.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public void AccessLog(string ID, string Type, string AccessOperation)
        {
            string strIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string strPlatform = "";
            if (strIP == "" || strIP == null)
                strIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            var ua = HttpContext.Current.Request.UserAgent;

            if (ua.Contains("Android"))
                strPlatform= "Android";

            if (ua.Contains("iPad"))
                strPlatform = "iOS iPad";

            if (ua.Contains("iPhone"))
                strPlatform = "iOS iPhone";

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                strPlatform = "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                strPlatform = "Black Berry";

            if (ua.Contains("Windows Phone"))
                strPlatform = "Windows Phone";

            if (ua.Contains("Mac OS"))
                strPlatform = "iOS MacBook";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                strPlatform = "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                strPlatform = "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                strPlatform = "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                strPlatform = "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                strPlatform = "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                strPlatform = "Windows 10";

            if (strPlatform == "")
                strPlatform = HttpContext.Current.Request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
            ExecuteNonQuery("INSERT INTO AccessLog VALUES ('" + ID.Trim() + "','"+ Type.Trim() + "','" + strPlatform.Trim() + "','" + HttpContext.Current.Request.Browser.Browser.ToString().Trim() + "','" + strIP + "',GETDATE(),'"+ AccessOperation.Trim() + "') ");
        }

        public string GetXMLfromDataTable(DataTable _DT)
        {
            string _XML = string.Empty;
            StringWriter _SW = new StringWriter();
            _DT.WriteXml(_SW, false);
            _XML = _SW.ToString().Replace("'", "''");
            return _XML;

        }

        public enum MessageType
        {
            Error = 0,
            Success = 1,
            Warning = 2
        }
        public enum MessageDuration
        {
            Short = 0,
            Medium = 1,
            Long = 2
        }

        public void SetAlert(System.Web.UI.Page oPage, string Message, MessageType _MessageType, MessageDuration _MessageDuration)
        {
            ScriptManager.RegisterStartupScript(oPage, oPage.GetType(), "Hello", "showAlert('" + Message + "','" + _MessageType.ToString() + "','" + _MessageDuration.ToString() + "');", true);
        }

    }

    public class SignatureToImage
    {
        public Color BackgroundColor { get; set; }
        public Color PenColor { get; set; }
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }
        public float PenWidth { get; set; }
        public float FontSize { get; set; }
        public string FontName { get; set; }

        /// <summary>
        /// Gets a new signature generator with the default options.
        /// </summary>
        public SignatureToImage()
        {
            // Default values
            BackgroundColor = Color.White;
            PenColor = Color.FromArgb(20, 83, 148);
            //CanvasWidth = 218;
            //CanvasHeight = 90;
            CanvasWidth = 248;
            CanvasHeight = 130;
            PenWidth = 2;
            FontSize = 24;
            FontName = "Journal";
        }

        /// <summary>
        /// Draws a signature based on the JSON provided by Signature Pad.
        /// </summary>
        /// <param name="json">JSON string of line drawing commands.</param>
        /// <returns>Bitmap image containing the signature.</returns>
        public Bitmap SigJsonToImage(string json)
        {
            var signatureImage = GetBlankCanvas();
            if (!string.IsNullOrWhiteSpace(json))
            {
                using (var signatureGraphic = Graphics.FromImage(signatureImage))
                {
                    signatureGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                    var pen = new Pen(PenColor, PenWidth);
                    var serializer = new JavaScriptSerializer();
                    // Next line may throw System.ArgumentException if the string
                    // is an invalid json primitive for the SignatureLine structure
                    var lines = serializer.Deserialize<List<SignatureLine>>(json);
                    foreach (var line in lines)
                    {
                        signatureGraphic.DrawLine(pen, line.lx, line.ly, line.mx, line.my);
                    }
                }
            }
            return signatureImage;
        }

        /// <summary>
        /// Draws an approximation of a signature using a font.
        /// </summary>
        /// <param name="name">The string that will be drawn.</param>
        /// <param name="fontPath">Full path of font file to be used if default font is not installed on the system.</param>
        /// <returns>Bitmap image containing the user's signature.</returns>
        public Bitmap SigNameToImage(string name, string fontPath = null)
        {
            var signatureImage = GetBlankCanvas();
            if (!string.IsNullOrWhiteSpace(name))
            {
                Font font;
                // Need a reference to the font, be it the .ttf in the project or the system-installed font
                if (string.IsNullOrWhiteSpace(fontPath))
                {
                    // Path parameter not provided, try to use system-installed font
                    var installedFontCollection = new InstalledFontCollection();
                    if (installedFontCollection.Families.Any(f => f.Name == FontName))
                    {
                        font = new Font(FontName, FontSize);
                    }
                    else
                    {
                        throw new ArgumentException("The full path of the font file must be provided when the specified font is not installed on the system.", "fontPath");
                    }
                }
                else if (File.Exists(fontPath))
                {
                    try
                    {
                        // Temporarily install font while not affecting the system-installed collection
                        var collection = new PrivateFontCollection();
                        collection.AddFontFile(fontPath);
                        font = new Font(collection.Families.First(), FontSize);
                    }
                    catch (FileNotFoundException)
                    {
                        // Since the existence of the file has already been tested, this exception
                        // means the file is invalid or not supported when trying to load
                        throw new Exception("The specified font file \"" + fontPath + "\" is either invalid or not supported.");
                    }
                }
                else
                {
                    throw new FileNotFoundException("The specified font file \"" + fontPath + "\" does not exist or permission was denied.", fontPath);
                }
                using (var signatureGraphic = Graphics.FromImage(signatureImage))
                {
                    signatureGraphic.TextRenderingHint = TextRenderingHint.AntiAlias;
                    signatureGraphic.DrawString(name, font, new SolidBrush(PenColor), 0, 0);
                }
            }
            return signatureImage;
        }

        /// <summary>
        /// Get a blank bitmap using instance properties for dimensions and background color.
        /// </summary>
        /// <returns>Blank bitmap image.</returns>
        private Bitmap GetBlankCanvas()
        {
            var blankImage = new Bitmap(CanvasWidth, CanvasHeight);
            blankImage.MakeTransparent();
            using (var signatureGraphic = Graphics.FromImage(blankImage))
            {
                signatureGraphic.Clear(BackgroundColor);
            }
            return blankImage;
        }

        /// <summary>
        /// Line drawing commands as generated by the Signature Pad JSON export option.
        /// </summary>
        private class SignatureLine
        {
            public int lx { get; set; }
            public int ly { get; set; }
            public int mx { get; set; }
            public int my { get; set; }
        }
    }
}