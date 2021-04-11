using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using Sequoia_BE.Utilities;
using System.Net.Http;
using System.Net;
using System.IO; 
using System.Web.Script.Serialization;
using System.Text;

namespace Sequoia_BE
{
    public partial class DashBoard : System.Web.UI.Page
    {

        #region Declaration
        private string strUserCode = "";
        private string strSiteCode = "";       
        private DataTable oDT_General = new DataTable();
        private CommonEngine oCommonEngine = new CommonEngine();
        private DataTable oDT_TimeLineHeader = new DataTable();
        private DataTable oDT_TimeLineDetails = new DataTable();

        private string _Prefix = string.Empty;
        private string _ControlNo = string.Empty;
        private string _PKey = string.Empty;

        #endregion

        #region Functions

        #region Load Page Informations

        private void LoadPageInformations()
        {
            try
            {
                oDT_General = oCommonEngine.ExecuteDataTable("Select Count(*) [_Count] from StudentMaster Where ((CreateSite+ISNULL(OtherSiteAccess,'') Like '%"+strSiteCode+"%' And '"+ strSiteCode + "'<>'HQ01') OR ('" + strSiteCode + "'='HQ01'))");
                lbl_Tile1.InnerText = oDT_General.Rows[0][0].ToString();
                oDT_General = oCommonEngine.ExecuteDataTable("Select Count(*) [_Count] from CourseScheduler Where '" + strSiteCode + "'='HQ01'");
                lbl_Tile2.InnerText = oDT_General.Rows[0][0].ToString();
                oDT_General = oCommonEngine.ExecuteDataTable("Select Count(*) [_Count] from CourseMaster Where '" + strSiteCode + "'='HQ01'");
                lbl_Tile3.InnerText = oDT_General.Rows[0][0].ToString();
                oDT_General = oCommonEngine.ExecuteDataTable("Select Count(*) [_Count] from EmployeeMaster Where '" + strSiteCode + "'='HQ01'");
                lbl_Tile4.InnerText = oDT_General.Rows[0][0].ToString();
                oDT_General = oCommonEngine.ExecuteDataTable("EXEC [Get_DashBoardTimeline] '"+ strUserCode.ToString().Trim() + "','"+ strSiteCode.ToString().Trim() + "'");
                DataView oDV = new DataView(oDT_General);
                oDT_TimeLineHeader = oDV.ToTable(true, "DateInfo", "DateColor");
                oDT_TimeLineDetails = oDT_General;
                rptrTimeLineHeader.DataSource = oDT_TimeLineHeader;
                rptrTimeLineHeader.DataBind();
                DataView oDV_1 = new DataView(oDT_General);
                oDV_1.RowFilter = "TodayTime<>''";
                rptrTodayClasses.DataSource = oDV_1.ToTable();
                rptrTodayClasses.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        [WebMethod]
        public static void CommonMasterNew(string Master, string Operation, string Code, string Name, Boolean InActive)
        {
            if (Master == "CITY")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCities p = new MasterCities { itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //var response = client.PostAsJsonAsync<City>("api/Cities", p).Result;
                        var post = client.PostAsJsonAsync<MasterCities>("api/Cities", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }
            else if (Master == "STATE")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCities p = new MasterCities { itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterCities>("api/States", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }
            }
            else if (Master == "COUNTRY")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCountries p = new MasterCountries { itmCode = Code, itmDesc = Name, itmIsactive = InActive, phonecode = "" };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterCountries>("api/Countries", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
         
            //_CommonEngine.ExecuteNonQuery("EXEC [Operation_CommonMasters] '"+ _UserCode.Trim()+"','"+ _SiteCode.ToString().Trim() + "','"+ Master + "','"+ Operation + "','"+ Code + "','"+ Name + "','"+ InActive + "'");
        }

        [WebMethod]
        //public static void CommonMaster(string Master, string Operation, string Code, string Name, Boolean InActive, string controlNo, string ShortDesc)
        public static void CommonMaster(string Master, string Operation, string Code, string Name, Boolean InActive, string controlNo)
        {
            string siteCode = "HQ";

            if (!string.IsNullOrEmpty((string)HttpContext.Current.Session["User_SiteCode"]))
                siteCode = (string)HttpContext.Current.Session["User_SiteCode"];

            if (Master == "CITY")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCities p = new MasterCities { itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterCities>("api/Cities", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "CITY CODE", sitecode= siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            else if (Master == "STATE")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCities p = new MasterCities { itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterCities>("api/States", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "State Code", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                            Console.Write("Error");

                    }
                }
            }

            else if (Master == "COUNTRY")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCountries p = new MasterCountries { itmCode = Code, itmDesc = Name, itmIsactive = InActive, phonecode = "" };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterCountries>("api/Countries", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Country Code", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "SITE GROUP")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterSiteGroups p = new MasterSiteGroups { code = Code, description = Name, isActive = InActive, isDelete = false };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterSiteGroups>("api/SiteGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Site Group", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "CUSTOMER TYPE")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerTypes p = new CustomerTypes { typeCode = Code, typeDesc = Name, typeIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<CustomerTypes>("api/CustomerTypes", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Customer Type Code", sitecode = siteCode, controlnumber = controlNo };                            
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            else if (Master == "OCCUPATION TYPE")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        OccupationTypes p = new OccupationTypes { occupationCode = Code, occupationDesc = Name, occupationIsactive = InActive , occupationSequence=0, operationStatus=0};
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



                        var post = client.PostAsJsonAsync<OccupationTypes>("api/Occupationtypes", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Occupation CODE", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "SOURCE")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        Sources p = new Sources { sourceCode = Code, sourceDesc = Name, sourceIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<Sources>("api/Sources", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Source", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "BlockReason")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        BlockReason p = new BlockReason { bNo = Code, bReason = Name, active = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<BlockReason>("api/BlockReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Block Reason", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "AdjustmentReason")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        AdjustmentReason p = new AdjustmentReason { revNo = Code, revDesc = Name, isActive = InActive, revRemark="" };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<AdjustmentReason>("api/ReverseTrmtReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Reverse Reason", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                        {
                            var errorMessage = response.Content.ReadAsStringAsync().Result;
                            Console.Write("Error");
                        }

                    }
                }


            }

            else if (Master == "Diagnosis")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        Diagnosis p = new Diagnosis { diagCode = Code, diagDesc = Name, diagIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<Diagnosis>("api/Diagnosissetups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Diagnosis", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                        {
                            var errorMessage = response.Content.ReadAsStringAsync().Result;
                            Console.Write("Error");
                        }

                    }
                }


            }

            //else if (Master == "ItemStatusGroup")
            //{
            //    if (Operation == "S")
            //    {
            //        using (var client = new HttpClient())
            //        {
            //            ItemStatusGroups p = new ItemStatusGroups { statusGroupCode = Code, statusGroupDesc = Name, statusGroupShortDesc = ShortDesc, isactive = InActive };
            //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
            //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //            var post = client.PostAsJsonAsync<ItemStatusGroups>("api/ItemStatusGroups", p);
            //            post.Wait();
            //            var response = post.Result;
            //            if (response.IsSuccessStatusCode)
            //            {
            //                Console.Write("Success");
            //                ControlNosUpdate c = new ControlNosUpdate { controldescription = "Item Status Group", controlnumber = controlNo };
            //                //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
            //                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //                string api = "api/ControlNos/updatecontrol";
            //                post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
            //                post.Wait();
            //                response = post.Result;
            //                if (response.IsSuccessStatusCode)
            //                {
            //                    Console.Write("Success");
            //                }

            //            }
            //            else
            //                Console.Write("Error");

            //        }
            //    }


            //}

            else if (Master == "DiscountReason")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        DiscountReason p = new DiscountReason { rCode = Code, rDesc = Name, isactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<DiscountReason>("api/PaymentRemarks", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Discount Voucher", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        {
                            var errorMessage = response.Content.ReadAsStringAsync().Result;
                            Console.Write("Error");
                        }
                    }
                }


            }

            else if (Master == "FocReason")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        FocReason p = new FocReason { focReasonCode = Code, focReasonLdesc = Name, focReasonIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<FocReason>("api/FocReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "FOC Reason Code", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "PaymentGroup")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        FocReason p = new FocReason { focReasonCode = Code, focReasonLdesc = Name, focReasonIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<FocReason>("api/PayGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "FOC Reason Code", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "PaymentType")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        FocReason p = new FocReason { focReasonCode = Code, focReasonLdesc = Name, focReasonIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<FocReason>("api/Paytable", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "FOC Reason Code", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "AppointmentGroup")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        AppointmentGroup p = new AppointmentGroup { apptGroupCode = Code, apptGroupDesc = Name, apptGroupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<AppointmentGroup>("api/AppointmentGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Appointment Group", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "TransactionReason")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        TransactionReason p = new TransactionReason { reasonCode = Code, reasonDesc = Name, isactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<TransactionReason>("api/TransactionReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Transaction Reason", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "VOIDTransactionReason")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        VoidReason p = new VoidReason { reasonCode = Code, reasonDesc = Name, isactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<VoidReason>("api/VoidReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "VOID REASON", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "ItemUOM")
            {
                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        ItemUOM p = new ItemUOM { uomCode = Code, uomDesc = Name, uomIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<ItemUOM>("api/ItemUoms", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            //ControlNosUpdate c = new ControlNosUpdate { controldescription = "VOID REASON", sitecode = siteCode, controlnumber = controlNo };
                            //string api = "api/ControlNos/updatecontrol";
                            //post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            //post.Wait();
                            //response = post.Result;
                            //if (response.IsSuccessStatusCode)
                            //{
                            //    Console.Write("Success");
                            //}

                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            else if (Master == "CUSTOMER GRP1")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerGroup1s p = new CustomerGroup1s { groupCode = Code, groupDesc = Name, groupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



                        var post = client.PostAsJsonAsync<CustomerGroup1s>("api/CustomerGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "CUSTOMER GROUP CODE", sitecode = siteCode, controlnumber = controlNo };
                            //client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "CUSTOMER GRP2")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerGroup1s p = new CustomerGroup1s { groupCode = Code, groupDesc = Name, groupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<CustomerGroup1s>("api/CustomerGroup2s", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Customer Group Code2", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "CUSTOMER GRP3")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerGroup1s p = new CustomerGroup1s { groupCode = Code, groupDesc = Name, groupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<CustomerGroup1s>("api/CustomerGroup3s", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Customer Group Code3", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "PRODUCT GRP")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        ProductGroups p = new ProductGroups { code = Code, description = Name, isActive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<ProductGroups>("api/ProductGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Product Group Code", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "RACE")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        Races p = new Races { itmCode = Code, itmName = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



                        var post = client.PostAsJsonAsync<Races>("api/Races", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Race", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "SKIN TYPE")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        SkinTypes p = new SkinTypes { code = Code, description = Name, isActive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



                        var post = client.PostAsJsonAsync<SkinTypes>("api/SkinTypes", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Skin Type Code", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "LANGUAGE")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCities p = new MasterCities { itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<MasterCities>("api/Languages", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Language Code", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            else if (Master == "LOCATION")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        Locations p = new Locations { locCode = Code, locName = Name, locIsactive = InActive, locAddress = "", locFax = "", locId = "", locTel = "" };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<Locations>("api/Locations", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "Location Code", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            else if (Master == "GENDER")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        Gender p = new Gender { itmCode = Code, itmName = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<Gender>("api/Genders", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            //ControlNosUpdate c = new ControlNosUpdate { controldescription = "Location Code", sitecode = siteCode, controlnumber = controlNo };
                            //string api = "api/ControlNos/updatecontrol";
                            //post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            //post.Wait();
                            //response = post.Result;
                            //if (response.IsSuccessStatusCode)
                            //{
                            //    Console.Write("Success");
                            //}
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            else if (Master == "AppointmentChannel")
            {

                if (Operation == "S")
                {
                    using (var client = new HttpClient())
                    {
                        ApptChannel p = new ApptChannel { channelCode = Code, channelDesc = Name, active = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PostAsJsonAsync<ApptChannel>("api/ApptChannels", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                            ControlNosUpdate c = new ControlNosUpdate { controldescription = "APPOINTMENT CHANNEL", sitecode = siteCode, controlnumber = controlNo };
                            string api = "api/ControlNos/updatecontrol";
                            post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                            post.Wait();
                            response = post.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }

            //string _Master = Master;
            //string _Operation = Operation;
            //string _Code = Code;
            //string _Name = Name;
            //string _InActive = InActive;
            //CommonEngine _CommonEngine = new CommonEngine();
            //string _UserCode = (string)HttpContext.Current.Session["User_UserCode"]; 
            //string _SiteCode = (string)HttpContext.Current.Session["User_SiteCode"];
            //_UserCode = "Manager";
            //_SiteCode = "HQ01";

            //_CommonEngine.ExecuteNonQuery("EXEC [Operation_CommonMasters] '"+ _UserCode.Trim()+"','"+ _SiteCode.ToString().Trim() + "','"+ Master + "','"+ Operation + "','"+ Code + "','"+ Name + "','"+ InActive + "'");
        }

        [WebMethod]
        //public static void CommonMasterUpdate(int id, string Master, string Operation, string Code, string Name, Boolean InActive,string ShortDesc)
        public static void CommonMasterUpdate(int id, string Master, string Operation, string Code, string Name, Boolean InActive)
        {

            if (Master == "CITY")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCitiesUpdate p = new MasterCitiesUpdate { itmId =id, itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //var response = client.PostAsJsonAsync<City>("api/Cities", p).Result;
                        var post = client.PutAsJsonAsync<MasterCitiesUpdate>("api/Cities/" + id, p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }
            else if (Master == "STATE")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCitiesUpdate p = new MasterCitiesUpdate {itmId = id, itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<MasterCitiesUpdate>("api/States", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }
            }
            else if (Master == "COUNTRY")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCountriesUpdate p = new MasterCountriesUpdate { itmId = id, itmCode = Code, itmDesc = Name, itmIsactive = InActive, phonecode = "" };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<MasterCountriesUpdate>("api/Countries", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "SITE GROUP")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        MasterSiteGroupsUpdate p = new MasterSiteGroupsUpdate {id = id, code = Code, description = Name, isActive = InActive, isDelete = false };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<MasterSiteGroupsUpdate>("api/SiteGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "SITE")
            {

                if (Operation == "A")
                {
                    using (var client = new HttpClient())
                    {
                        MasterSiteGroups p = new MasterSiteGroups { code = Code, description = Name, isActive = true, isDelete = false };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        //var response = client.PostAsJsonAsync<City>("api/Cities", p).Result;
                        var post = client.PutAsJsonAsync<MasterSiteGroups>("api/SiteGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "CUSTOMER TYPE")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerTypesUpdate p = new CustomerTypesUpdate { id = id,  typeCode = Code,  typeDesc = Name, typeIsactive = InActive};
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<CustomerTypesUpdate>("api/CustomerTypes", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "OCCUPATION TYPE")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        OccupationTypesUpdate p = new OccupationTypesUpdate { occupationId = id, occupationCode = Code, occupationDesc = Name, occupationSequence = 0, occupationIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<OccupationTypesUpdate>("api/Occupationtypes", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "SOURCE")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        SourcesUpdate p = new SourcesUpdate { id = id, sourceCode = Code, sourceDesc = Name, /*occupationSequence = 0*/ sourceIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<SourcesUpdate>("api/Sources", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "BlockReason")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        BlockReasonUpdate p = new BlockReasonUpdate { id = id, bNo = Code, bReason = Name, /*occupationSequence = 0*/ active = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<BlockReasonUpdate>("api/BlockReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "AdjustmentReason")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        AdjustmentReasonUpdate p = new AdjustmentReasonUpdate { id = id, revNo = Code, revDesc = Name, /*occupationSequence = 0*/ isActive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<AdjustmentReasonUpdate>("api/ReverseTrmtReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "Diagnosis")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        DiagnosisUpdate p = new DiagnosisUpdate { itmId = id, diagCode = Code, diagDesc = Name, /*occupationSequence = 0*/ diagIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<DiagnosisUpdate>("api/Diagnosissetups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }


            }

            //else if (Master == "ItemStatusGroup")
            //{
            //    if (Operation == "U")
            //    {
            //        using (var client = new HttpClient())
            //        {
            //            ItemStatusGroupsUpdate p = new ItemStatusGroupsUpdate { id = id, statusGroupCode = Code, statusGroupDesc = Name, statusGroupShortDesc = ShortDesc, isactive = InActive };
            //            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
            //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //            var post = client.PutAsJsonAsync<ItemStatusGroupsUpdate>("api/ItemStatusGroups", p);
            //            post.Wait();
            //            var response = post.Result;
            //            if (response.IsSuccessStatusCode)
            //            {
            //                Console.Write("Success");

            //            }
            //            else
            //                Console.Write("Error");
            //        }
            //    }


            //}

            else if (Master == "DiscountReason")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        DiscountReasonUpdate p = new DiscountReasonUpdate { id = id, rCode = Code, rDesc = Name, /*occupationSequence = 0*/ isactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<DiscountReasonUpdate>("api/PaymentRemarks", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "FocReason")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        FocReasonUpdate p = new FocReasonUpdate { id = id, focReasonCode = Code, focReasonLdesc = Name, /*occupationSequence = 0*/ focReasonIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<FocReasonUpdate>("api/FocReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "PaymentGroup")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        FocReasonUpdate p = new FocReasonUpdate { id = id, focReasonCode = Code, focReasonLdesc = Name, /*occupationSequence = 0*/ focReasonIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<FocReasonUpdate>("api/PayGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "PaymentType")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        FocReasonUpdate p = new FocReasonUpdate { id = id, focReasonCode = Code, focReasonLdesc = Name, /*occupationSequence = 0*/ focReasonIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<FocReasonUpdate>("api/Paytable", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "AppointmentGroup")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        AppointmentGroupUpdate p = new AppointmentGroupUpdate { id = id, apptGroupCode = Code, apptGroupDesc = Name, /*occupationSequence = 0*/ apptGroupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<AppointmentGroupUpdate>("api/AppointmentGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "TransactionReason")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        TransactionReasonUpdate p = new TransactionReasonUpdate { id = id, reasonCode = Code, reasonDesc = Name, /*occupationSequence = 0*/ isactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<TransactionReasonUpdate>("api/TransactionReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "VOIDTransactionReason")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        VoidReasonUpdate p = new VoidReasonUpdate { id = id, reasonCode = Code, reasonDesc = Name, /*occupationSequence = 0*/ isactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<VoidReasonUpdate>("api/VoidReasons", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "ItemUOM")
            {
                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        ItemUOMUpdate p = new ItemUOMUpdate { id = id, uomCode = Code, uomDesc= Name, uomIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<ItemUOMUpdate>("api/ItemUoms", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");
                    }
                }
            }

            else if (Master == "CUSTOMER GRP1")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerGroup1sUpdate p = new CustomerGroup1sUpdate { id = id, groupCode = Code, groupDesc = Name, seq = 0, groupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<CustomerGroup1sUpdate>("api/CustomerGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "CUSTOMER GRP2")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerGroup1sUpdate p = new CustomerGroup1sUpdate { id = id, groupCode = Code, groupDesc = Name, seq = 0, groupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<CustomerGroup1sUpdate>("api/CustomerGroup2s", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "CUSTOMER GRP3")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        CustomerGroup1sUpdate p = new CustomerGroup1sUpdate { id = id, groupCode = Code, groupDesc = Name, seq =0, groupIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<CustomerGroup1sUpdate>("api/CustomerGroup3s", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "PRODUCT GRP")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        ProductGroupsUpdate p = new ProductGroupsUpdate { id= id,  code = Code,  description = Name,  isActive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<ProductGroupsUpdate>("api/ProductGroups", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "RACE")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        RacesUpdate p = new RacesUpdate { itmId = id, itmCode = Code, itmName = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<RacesUpdate>("api/Races", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "SKIN TYPE")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        SkinTypesUpdate p = new SkinTypesUpdate { id = id,  code = Code,  description = Name,  isActive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<SkinTypesUpdate>("api/SkinTypes", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "LANGUAGE")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        MasterCitiesUpdate p = new MasterCitiesUpdate { itmId = id, itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<MasterCitiesUpdate>("api/Languages", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }
            else if (Master == "LOCATION")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        LocationsUpdate p = new LocationsUpdate { itmId = id,  locCode = Code, locName = Name, locIsactive = InActive, locAddress="",locFax="", locId="", locTel="" };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<LocationsUpdate>("api/Locations", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "GENDER")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        GenderUpdate p = new GenderUpdate { itmId = id, itmCode = Code, itmName = Name, itmIsactive = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<GenderUpdate>("api/Genders", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");

                        }
                        else
                            Console.Write("Error");

                    }
                }


            }

            else if (Master == "AppointmentChannel")
            {

                if (Operation == "U")
                {
                    using (var client = new HttpClient())
                    {
                        ApptChannelUpdate p = new ApptChannelUpdate { id = id, channelCode = Code, channelDesc = Name, active = InActive };
                        client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var post = client.PutAsJsonAsync<ApptChannelUpdate>("api/ApptChannels", p);
                        post.Wait();
                        var response = post.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write("Success");
                        }
                        else
                            Console.Write("Error");

                    }
                }

            }


        }

        [WebMethod]
        public static void AgeGroupMaster(string Code, string AgeGroup, string Name, Boolean InActive, string controlNo)
        {
            string siteCode = "HQ";

            if (!string.IsNullOrEmpty((string)HttpContext.Current.Session["User_SiteCode"]))
                siteCode = (string)HttpContext.Current.Session["User_SiteCode"];

            using (var client = new HttpClient())
            {
                AgeGroup p = new AgeGroup { itmCode = Code, ageCode = AgeGroup, itmDesc = Name, itmIsactive = InActive, fage = 0, tage = 0 };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<AgeGroup>("api/Agegroups", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "Age Group", sitecode = siteCode, controlnumber = controlNo };
                    string api = "api/ControlNos/updatecontrol";
                    post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                    post.Wait();
                    response = post.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void AgeGroupMasterUpdate(int id, string Code, string AgeGroup, string Name, Boolean InActive)
        {

            using (var client = new HttpClient())
            {
                AgeGroupUpdate p = new AgeGroupUpdate { itmId = id, ageCode = AgeGroup, itmCode = Code, itmDesc = Name, itmIsactive = InActive };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PutAsJsonAsync<AgeGroupUpdate>("api/Agegroups", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");

                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void SecurityLevelMaster(string Code,  string Name, string Description, Boolean InActive, string controlNo)
        {
            string siteCode = "HQ";

            if (!string.IsNullOrEmpty((string)HttpContext.Current.Session["User_SiteCode"]))
                siteCode = (string)HttpContext.Current.Session["User_SiteCode"];

            using (var client = new HttpClient())
            {
                SecurityInsert p = new SecurityInsert { levelCode = Code, levelName = Name, levelDescription = Description, levelIsActive = InActive,
                     levelPermitAnalysis=false,levelPermitAttendance=false,levelPermitAppointment = false, levelPermitClass= false, levelPermitCreditor=false,
                     levelPermitCrm= false, levelPermitDept= false, levelPermitDiscount = false, levelPermitDiv =false, levelPermitForex = false,
                     levelPermitInventory= false, levelPermitMaintain =false, levelPermitPayTable =false, levelPermitPos = false, levelPermitPromo =false,
                     levelPermitSecurity = false, levelPermitSendmail =false, levelPermitStaff = false, levelPermitStkAdj =false, levelPermitStkQuery = false,
                     levelPermitStkReceive = false, levelPermitStkTk = false, levelPermitStkTrans = false, levelPermitStkVar = false,
                     levelPermitStkWriteOff = false, levelPermitStockItem = false, levelPermitUserLogin = false};
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<SecurityInsert>("api/Securities", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "SECURITY_LEVEL", sitecode = siteCode, controlnumber = controlNo };
                    string api = "api/ControlNos/updatecontrol";
                    post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                    post.Wait();
                    response = post.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void SecurityLevelMasterUpdate(int id, string Code, string Name, string Description, Boolean InActive)
        {

            using (var client = new HttpClient())
            {
                SecurityUpdate p = new SecurityUpdate { levelItemId = id, levelCode = Code, levelName = Name, levelDescription = Description, levelIsActive = InActive };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PutAsJsonAsync<SecurityUpdate>("api/Securities", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");

                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void ApptBookingStatusMaster(string Code, string Name, string Description, Boolean InActive, string controlNo)
        {
            string siteCode = "HQ";

            if (!string.IsNullOrEmpty((string)HttpContext.Current.Session["User_SiteCode"]))
                siteCode = (string)HttpContext.Current.Session["User_SiteCode"];

            using (var client = new HttpClient())
            {
                ApptBookingStatus p = new ApptBookingStatus
                {
                    bsCode = Code,
                    bsColorCode = Name,
                    bsDesc = Description,
                    active = InActive,
                };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<ApptBookingStatus>("api/ApptBookingStatuses", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "APPOINTMENT BOOKING STATUS", sitecode = siteCode, controlnumber = controlNo };
                    string api = "api/ControlNos/updatecontrol";
                    post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                    post.Wait();
                    response = post.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void ApptBookingStatusMasterUpdate(int id, string Code, string Name, string Description, Boolean InActive)
        {

            using (var client = new HttpClient())
            {
                ApptBookingStatusUpdate p = new ApptBookingStatusUpdate { id = id, bsCode = Code, bsColorCode = Name, bsDesc = Description, active = InActive };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PutAsJsonAsync<ApptBookingStatusUpdate>("api/ApptBookingStatuses", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");

                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void ApptSecondaryStatusMaster(string Code, string Name, string Description, Boolean InActive, string controlNo)
        {
            string siteCode = "HQ";

            if (!string.IsNullOrEmpty((string)HttpContext.Current.Session["User_SiteCode"]))
                siteCode = (string)HttpContext.Current.Session["User_SiteCode"];

            using (var client = new HttpClient())
            {
                ApptSecondaryStatus p = new ApptSecondaryStatus
                {
                    ssCode = Code,
                    ssColorCode = Name,
                    ssDesc = Description,
                    active = InActive,
                };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PostAsJsonAsync<ApptSecondaryStatus>("api/ApptSecondaryStatuses", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                    ControlNosUpdate c = new ControlNosUpdate { controldescription = "APPOINTMENT SECONDARY STATUS", sitecode = siteCode, controlnumber = controlNo };
                    string api = "api/ControlNos/updatecontrol";
                    post = client.PostAsJsonAsync<ControlNosUpdate>(api, c);
                    post.Wait();
                    response = post.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void ApptSecondaryStatusMasterUpdate(int id, string Code, string Name, string Description, Boolean InActive)
        {

            using (var client = new HttpClient())
            {
                ApptSecondaryStatusUpdate p = new ApptSecondaryStatusUpdate { id = id, ssCode = Code, ssColorCode = Name, ssDesc = Description, active = InActive };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PutAsJsonAsync<ApptSecondaryStatusUpdate>("api/ApptSecondaryStatuses", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");

                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void GstTaxSettingUpdate(int id, string Code, string Description, int Tax, int Seq, Boolean InActive)
        {

            using (var client = new HttpClient())
            {
                GstSettingUpdate p = new GstSettingUpdate { id = id, itemCode = Code, itemDesc = Description, itemValue = Tax, itemSeq = Seq, isactive = InActive };
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["uri"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var post = client.PutAsJsonAsync<GstSettingUpdate>("api/GstSettings", p);
                post.Wait();
                var response = post.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");

                }
                else
                    Console.Write("Error");

            }

        }

        [WebMethod]
        public static void CalanderComment(string Comment,string EventID,string EventDate)
        {
          
            CommonEngine _CommonEngine = new CommonEngine();
            string _UserCode = (string)HttpContext.Current.Session["User_UserCode"];
            string _SiteCode = (string)HttpContext.Current.Session["User_SiteCode"];
            _CommonEngine.ExecuteNonQuery("Insert into  CalenderComments Values (GETDATE(),GETDATE(),'"+ _UserCode + "','" + _UserCode + "','" + _SiteCode + "','" + _SiteCode + "','"+ EventID + "','"+ EventDate + "','"+ Comment + "')");
        }

        [WebMethod]
        public static void MenuAuthorization(string User,  string Code,  string Active)
        {
         
            CommonEngine _CommonEngine = new CommonEngine();           
            _CommonEngine.ExecuteNonQuery("IF EXISTS(Select * from MenuAuth T0 Where T0.[User]='"+ User + "' And T0.MenuCode='"+ Code + "') BEGIN Update MenuAuth Set Active='"+ Active + "' Where [User]='" + User + "' And MenuCode='" + Code + "' END ELSE BEGIN Insert Into MenuAuth  Select '" + User + "','" + Code + "','" + Active + "' END");
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["User_UserCode"] == null)
                //{
                //    strUserCode = "";
                //    strSiteCode = "";
                //    Response.Redirect("~/Login.aspx");
                //}
                //else
                //{
                //    strUserCode = (string)Session["User_UserCode"];
                //    strSiteCode = (string)Session["User_SiteCode"];
                //}

                string strAPIURL = System.Configuration.ConfigurationManager.AppSettings["SequoiaUri"].ToString();

                if (!IsPostBack)
                {

                    if ((Request.QueryString["username"] != null) && (Request.QueryString["psw"] != null))
                    {
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strAPIURL + "/api/webBI_Login");
                        req.ContentType = "application/json;";
                        req.Method = "POST";
                        string postData = "{\"userName\":\"" + Request.QueryString["username"] + "\"," +
                              "\"password\":\"" + Request.QueryString["psw"] + "\"}";
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
                        dynamic MyDynamic = js.Deserialize<dynamic>(sr.ReadToEnd());
                        if (MyDynamic["success"] == "1")
                        {
                            //if (chkRememberMe.Checked == true)
                            //{
                            //    Response.Cookies["bck_webBIUser"].Value = txtUserName.Value.ToString().Trim();
                            //    Response.Cookies["bck_webBIPwd"].Value = txtPassword.Text.ToString().Trim();
                            //    Response.Cookies["bck_webBIUser"].Expires = DateTime.Now.AddYears(20);
                            //    Response.Cookies["bck_webBIPwd"].Expires = DateTime.Now.AddYears(20);
                            //}
                            //else
                            //{
                            //    Response.Cookies["bck_webBIUser"].Expires = DateTime.Now.AddDays(-1);
                            //    Response.Cookies["bck_webBIPwd"].Expires = DateTime.Now.AddDays(-1);
                            //}
                            Session["User_UserName"] = Request.QueryString["username"].ToString();
                            Session["strUserName"] = Request.QueryString["username"].ToString();
                            Session["isSettingEnabled"] = MyDynamic["isSettingEnabled"];
                            Session["User_UserCode"] = Request.QueryString["username"].ToString();
                            Session["User_SiteCode"] = System.Configuration.ConfigurationManager.AppSettings["SiteCode"].ToString(); //ddlSite_Login.Value.Trim();
                            Session["User_UserType"] = "";

                            Session["User_UserName"] = Request.QueryString["username"];

                            dynamic MyDynamic_Result = MyDynamic["reportAuthInfo"];
                            JavaScriptSerializer js_result = new JavaScriptSerializer();
                            js_result.MaxJsonLength = Int32.MaxValue;
                            js_result.RecursionLimit = 100;
                            var json = js_result.Serialize(MyDynamic_Result);

                        }
                        else
                        {

                        }

                    }
                }

            }
            catch (Exception Ex)
            {
                oCommonEngine.SetAlert(this.Page, Ex.Message, Utilities.CommonEngine.MessageType.Error, Utilities.CommonEngine.MessageDuration.Short);
            }
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptrTimeLineDetails = (Repeater)args.Item.FindControl("rptrTimeLineDetails");
                Label lblHeaderKey = (Label)args.Item.FindControl("lblHeaderKey");
                DataView oDV = new DataView(oDT_General);
                oDV.RowFilter = "DateInfo='" + lblHeaderKey.Text.Trim() + "'";
                rptrTimeLineDetails.DataSource = oDV.ToTable();
                rptrTimeLineDetails.DataBind();
            }
        }

        #endregion
    }
}