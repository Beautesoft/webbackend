using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sequoia_BE
{

    public class LoginData
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class ControlNos
    {
        public string controlNo { get; set; }
        public string controlPrefix { get; set; }
        public string controlDescription { get; set; }
        public object controldate { get; set; }
        public string siteCode { get; set; }
        public object macCode { get; set; }
        public int controlId { get; set; }
    }

    public class ControlNosUpdate
    {
        public string controlnumber { get; set; }
        public string controldescription { get; set; }
        public string sitecode { get; set; }
    }

    public class MasterCities
    {

        public string itmDesc { get; set; }
        public string itmCode { get; set; }
        public bool itmIsactive { get; set; }

    }

    public class MasterCitiesUpdate
    {

        public int itmId { get; set; }
        public string itmDesc { get; set; }
        public string itmCode { get; set; }
        public bool itmIsactive { get; set; }

    }

    public class MasterCountries
    {
        public string itmDesc { get; set; }
        public string itmCode { get; set; }
        public bool itmIsactive { get; set; }
        public string phonecode { get; set; }

    }

    public class MasterCountriesUpdate
    {

        public int itmId { get; set; }
        public string itmDesc { get; set; }
        public string itmCode { get; set; }
        public bool itmIsactive { get; set; }
        public string phonecode { get; set; }

    }

    public class MasterSiteGroups
    {
        public string code { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }

    }

    public class MasterSiteGroupsUpdate
    {

        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }

    }

    public class MasterItemSiteLists
    {

        public string siteGroupIdId { get; set; }
        public string itemSiteCityIdId { get; set; }
        public string itemSiteCountryIdId { get; set; }
        public string itemSiteStateIdId { get; set; }
        public string itemSiteUserIdId { get; set; }
        public string itemsiteCode { get; set; }
        public string itemsiteDesc { get; set; }
        public object itemsiteType { get; set; }
        public object itemPurchasedept { get; set; }
        public string itemsiteAddress { get; set; }
        public string itemsitePostcode { get; set; }
        public string itemsiteCity { get; set; }
        public string itemsiteState { get; set; }
        public string itemsiteCountry { get; set; }
        public string itemsitePhone1 { get; set; }
        public string itemsitePhone2 { get; set; }
        public string itemsiteFax { get; set; }
        public string itemsiteEmail { get; set; }
        public string itemsiteUser { get; set; }
        public DateTime itemsiteDate { get; set; }
        public DateTime itemsiteTime { get; set; }
        public bool itemsiteIsactive { get; set; }
        public object itemsiteRefcode { get; set; }
        public string siteGroup { get; set; }
        public bool siteIsGst { get; set; }
        public string accountCode { get; set; }
        public object ratings { get; set; }
        public object picPath { get; set; }
        public object qrcode { get; set; }
        public bool systemlogMdplUpdate { get; set; }
        public object sitedbconnectionurl { get; set; }

    }

    public class MasterItemSiteListsUpdate
    {

        public int itemsiteId { get; set; }
        public string siteGroupIdId { get; set; }
        public string itemSiteCityIdId { get; set; }
        public string itemSiteCountryIdId { get; set; }
        public string itemSiteStateIdId { get; set; }
        public string itemSiteUserIdId { get; set; }
        public string itemsiteCode { get; set; }
        public string itemsiteDesc { get; set; }
        public object itemsiteType { get; set; }
        public object itemPurchasedept { get; set; }
        public string itemsiteAddress { get; set; }
        public string itemsitePostcode { get; set; }
        public string itemsiteCity { get; set; }
        public string itemsiteState { get; set; }
        public string itemsiteCountry { get; set; }
        public string itemsitePhone1 { get; set; }
        public string itemsitePhone2 { get; set; }
        public string itemsiteFax { get; set; }
        public string itemsiteEmail { get; set; }
        public string itemsiteUser { get; set; }
        public DateTime itemsiteDate { get; set; }
        public DateTime itemsiteTime { get; set; }
        public bool itemsiteIsactive { get; set; }
        public object itemsiteRefcode { get; set; }
        public string siteGroup { get; set; }
        public bool siteIsGst { get; set; }
        public object accountCode { get; set; }
        public object ratings { get; set; }
        public object picPath { get; set; }
        public object qrcode { get; set; }
        public bool systemlogMdplUpdate { get; set; }
        public object sitedbconnectionurl { get; set; }

    }

    public class CustomerClasses
    {
        public string classCode { get; set; }
        public string classDesc { get; set; }
        public bool classIsactive { get; set; }
        public int classProduct { get; set; }
        public int classService { get; set; }
    }
    
    public class CustomerClassUpdate
    {
        public int id { get; set; }
        public string classCode { get; set; }
        public string classDesc { get; set; }
        public bool classIsactive { get; set; }
        public int classProduct { get; set; }
        public int classService { get; set; }
    }

    public class CustomerTypes
    {
        public string typeCode { get; set; }
        public string typeDesc { get; set; }
        public bool typeIsactive { get; set; }
    }

    public class CustomerTypesUpdate
    {
        public int id { get; set; }
        public string typeCode { get; set; }
        public string typeDesc { get; set; }
        public bool typeIsactive { get; set; }
    }

    public class CustomerGroup1s
    {
        public string groupCode { get; set; }
        public string groupDesc { get; set; }
        public int seq { get; set; }
        public bool groupIsactive { get; set; }
    }

    public class CustomerGroup1sUpdate
    {
        public string groupCode { get; set; }
        public string groupDesc { get; set; }
        public int seq { get; set; }
        public bool groupIsactive { get; set; }
        public int id { get; set; }
    }

    public class ProductGroups
    {
        public string code { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
    }

    public class ProductGroupsUpdate
    {
        public string code { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public int id { get; set; }
    }

    public class ItemDeptDiscount
    {
        public int departmentid { get; set; }
        public int classid { get; set; }
        public int discount { get; set; }
        public int isactive { get; set; }

    }


    public class ItemDeptDiscountFetch
    {
        public int departmentid { get; set; }
        public int classid { get; set; }
        public int discount { get; set; }
        public int isactive { get; set; }
        public int id { get; set; }
    }

    public class ItemDeptDiscountUpdate
    {
        public int id { get; set; }
        public int departmentid { get; set; }
        public int classid { get; set; }
        public int discount { get; set; }
        public int isactive { get; set; }
    }


    public class AgeGroup
    {
        public string itmDesc { get; set; }
        public string itmCode { get; set; }
        public string ageCode { get; set; }
        public int fage { get; set; }
        public int tage { get; set; }
        public bool itmIsactive { get; set; }
    }

    public class AgeGroupUpdate
    {
        public int itmId { get; set; }
        public string itmDesc { get; set; }
        public string itmCode { get; set; }
        public string ageCode { get; set; }
        public int fage { get; set; }
        public int tage { get; set; }
        public bool itmIsactive { get; set; }
    }


    public class Races
    {

        public string itmName { get; set; }
        public string itmCode { get; set; }
        public bool itmIsactive { get; set; }

    }

    public class RacesUpdate
    {

        public int itmId { get; set; }
        public string itmName { get; set; }
        public string itmCode { get; set; }
        public bool itmIsactive { get; set; }

    }

    public class SkinTypes
    {
        public string code { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
    }

    public class SkinTypesUpdate
    {
        public string code { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public int id { get; set; }
    }

    public class Locations
    {
        public object locId { get; set; }
        public string locName { get; set; }
        public object locAddress { get; set; }
        public object locTel { get; set; }
        public object locFax { get; set; }
        public bool locIsactive { get; set; }
        public string locCode { get; set; }
    }

    public class LocationsUpdate
    {
        public object locId { get; set; }
        public string locName { get; set; }
        public object locAddress { get; set; }
        public object locTel { get; set; }
        public object locFax { get; set; }
        public bool locIsactive { get; set; }
        public string locCode { get; set; }
        public int itmId { get; set; }
    }

    public class Gender
    {
        public string itmName { get; set; }
        public bool itmIsactive { get; set; }
        public string itmCode { get; set; }
    }

    public class GenderUpdate
    {
        public string itmName { get; set; }
        public bool itmIsactive { get; set; }
        public string itmCode { get; set; }
        public int itmId { get; set; }
    }

    public class CorporateCustomers
    {
        public string code { get; set; }
        public string name { get; set; }
        public string add1 { get; set; }
        public string add2 { get; set; }
        public string add3 { get; set; }
        public string add4 { get; set; }
        public string add5 { get; set; }
        public bool isactive { get; set; }
    }

    public class CorporateCustomersUpdate
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string add1 { get; set; }
        public string add2 { get; set; }
        public string add3 { get; set; }
        public string add4 { get; set; }
        public string add5 { get; set; }
        public bool isactive { get; set; }
    }

    public class ItemSupply
    {
        public string splyCode { get; set; }
        public string supplydesc { get; set; }
        public string splyDate { get; set; }
        public string accountNumber { get; set; }
        public string splyAttn { get; set; }
        public string splyIc { get; set; }
        public string splyType { get; set; }
        public string splyAddr1 { get; set; }
        public string splyAddr2 { get; set; }
        public string splyAddr3 { get; set; }
        public string splyPoscd { get; set; }
        public string splyState { get; set; }
        public string splyCity { get; set; }
        public string splyCntry { get; set; }
        public string splymaddr1 { get; set; }
        public string splymaddr2 { get; set; }
        public string splymaddr3 { get; set; }
        public string splymposcd { get; set; }
        public string splymstate { get; set; }
        public string splymcity { get; set; }
        public string splymcntry { get; set; }
        public string splyTelno { get; set; }
        public string splyFaxno { get; set; }
        public object splyRemk1 { get; set; }
        public object splyRemk2 { get; set; }
        public object splyRemk3 { get; set; }
        public string splyTerm { get; set; }
        public string splyLimit { get; set; }
        public string splyBal { get; set; }
        public byte splyactive { get; set; }
        public string splyComm { get; set; }
        //public object firstName { get; set; }
        //public object netseq { get; set; }
        //public object createUser { get; set; }
        //public object createDate { get; set; }
        public string firstName { get; set; }
        public string netseq { get; set; }
        public string createUser { get; set; }
        public string createDate { get; set; }

    }


        public class ItemSupplyUpdate
    {
        public string splyCode { get; set; }
        public string supplydesc { get; set; }
        public string splyDate { get; set; }
        public string accountNumber { get; set; }
        public string splyAttn { get; set; }
        public string splyIc { get; set; }
        public string splyType { get; set; }
        public string splyAddr1 { get; set; }
        public string splyAddr2 { get; set; }
        public string splyAddr3 { get; set; }
        public string splyPoscd { get; set; }
        public string splyState { get; set; }
        public string splyCity { get; set; }
        public string splyCntry { get; set; }
        public string splymaddr1 { get; set; }
        public string splymaddr2 { get; set; }
        public string splymaddr3 { get; set; }
        public string splymposcd { get; set; }
        public string splymstate { get; set; }
        public string splymcity { get; set; }
        public string splymcntry { get; set; }
        public string splyTelno { get; set; }
        public string splyFaxno { get; set; }
        public object splyRemk1 { get; set; }
        public object splyRemk2 { get; set; }
        public object splyRemk3 { get; set; }
        public int splyTerm { get; set; }
        public int splyLimit { get; set; }
        public int splyBal { get; set; }
        public int splyactive { get; set; }
        public int splyComm { get; set; }
        public object firstName { get; set; }
        public object netseq { get; set; }
        public object createUser { get; set; }
        public object createDate { get; set; }
        public int splyId { get; set; }
    }


    public class EquipmentList
    {
        //id added on 16 Jul 19 for update
        //public int id { get; set; }
        public string equipmentName { get; set; }
        public string equipmentDescription { get; set; }
        public bool equipmentIsactive { get; set; }
        public string equipmentCode { get; set; }
    }

    public class EquipmentFetchList
    {
        //id added on 16 Jul 19 for update
        public int id { get; set; }
        public string equipmentName { get; set; }
        public string equipmentDescription { get; set; }
        public bool equipmentIsactive { get; set; }
        public string equipmentCode { get; set; }
    }


    public class EquipmentListUpdate
    {
        public int id { get; set; }
        public string equipmentCode { get; set; }
        public string equipmentDescription { get; set; }
        public bool equipmentIsactive { get; set; }
        public string equipmentName { get; set; }

    }


    public class RoomsList
    {
        //public string displayname { get; set; }
        public string displayname { get; set; }
        public string description { get; set; }
        public bool isactive { get; set; }
        public string equipment { get; set; }
        public string roomtype { get; set; }
        public string siteCode { get; set; }
        public string roomCode { get; set; }
    }

    public class BusinessHoursMaster
    {
        //public string displayname { get; set; }
        public string businessday { get; set; }
        public string status { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        //public DateTime starttime { get; set; }
        //public DateTime endtime { get; set; }
        public string sitecode { get; set; }
    }

    public class BusinessHoursMasterUpdate
    {
        //public string displayname { get; set; }
        public int id { get; set; }
        public string businessday { get; set; }
        public string status { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        //public DateTime starttime { get; set; }
        //public DateTime endtime { get; set; }
        public string sitecode { get; set; }
    }

    public class TaxTypeMaster
    {
        //public string displayname { get; set; }        
        public string itemCode { get; set; }
        public string taxCode { get; set; }
        public string taxDesc { get; set; }
        public string taxRatePercent { get; set; }
      //  public string siteCode { get; set; }
        public string itemSeq { get; set; }
        public bool isactive { get; set; }
    }

    public class TaxTypeMasterUpdate
    {
        public int id { get; set; }
        public string itemCode { get; set; }
        public string taxCode { get; set; }
        public string taxDesc { get; set; }
        public string taxRatePercent { get; set; }
        public string itemSeq { get; set; }
        public bool isactive { get; set; }
    }


    public class OccupationTypes
    {
        public string occupationDesc { get; set; }
        public string occupationCode { get; set; }
        public object occupationSequence { get; set; }
        public bool occupationIsactive { get; set; }
        public int operationStatus { get; set; }
        ////added on 11 Jul 2019
        //public int occupationId { get; set; }
    }

    public class OccupationTypesUpdate
    {
        public string occupationDesc { get; set; }
        public string occupationCode { get; set; }
        public object occupationSequence { get; set; }
        public bool occupationIsactive { get; set; }
        public int operationStatus { get; set; }
        public int occupationId { get; set; }
    }

    public class Sources
    {
        public string sourceCode { get; set; }
        public string sourceDesc { get; set; }
        public bool sourceIsactive { get; set; }
    }

    public class SourcesUpdate
    {
        public int id { get; set; }
        public string sourceCode { get; set; }
        public string sourceDesc { get; set; }
        public bool sourceIsactive { get; set; }
    }

    public class BlockReason
    {
        public string bNo { get; set; }
        public string bReason { get; set; }
        public bool active { get; set; }
    }

    public class BlockReasonUpdate
    {
        public int id { get; set; }
        public string bNo { get; set; }
        public string bReason { get; set; }
        public bool active { get; set; }
    }

    public class AdjustmentReason
    {
        public string revNo { get; set; }
        public string revDesc { get; set; }
        public string revRemark { get; set; }
        public bool isActive { get; set; }
    }

    public class AdjustmentReasonUpdate
    {
        public string revNo { get; set; }
        public string revDesc { get; set; }
        public string revRemark { get; set; }
        public bool isActive { get; set; }
        public int id { get; set; }
    }


    public class Diagnosis
    {
        public string diagCode { get; set; }
        public string diagDesc { get; set; }
        public bool diagIsactive { get; set; }
    }

    public class DiagnosisUpdate
    {
        public string diagCode { get; set; }
        public string diagDesc { get; set; }
        public bool diagIsactive { get; set; }
        public int itmId { get; set; }
    }

    public class ItemStatusGroups
    {
        public string statusGroupCode { get; set; }
        public string statusGroupDesc { get; set; }
        public bool isactive { get; set; }
        public string statusGroupShortDesc { get; set; }
    }

    public class ItemStatusGroupsUpdate
    {
        public int id { get; set; }
        public string statusGroupCode { get; set; }
        public string statusGroupDesc { get; set; }
        public bool isactive { get; set; }
        public string statusGroupShortDesc { get; set; }
    }


    public class ItemStatus
    {
        public string statusCode { get; set; }
        public string statusDesc { get; set; }
        public string statusShortDesc { get; set; }
        public bool itmIsactive { get; set; }
        public string statusGroupCode { get; set; }
    }

    public class ItemStatusUpdate
    {
        public int itmId { get; set; }
        public string statusCode { get; set; }
        public string statusDesc { get; set; }
        public string statusShortDesc { get; set; }
        public bool itmIsactive { get; set; }
        public string statusGroupCode { get; set; }
    }

    public class DiscountReason
    {
        public string rCode { get; set; }
        public string rDesc { get; set; }
        public bool isactive { get; set; }
    }


    public class DiscountReasonUpdate
    {
        public int id { get; set; }
        public string rCode { get; set; }
        public string rDesc { get; set; }
        public bool isactive { get; set; }
    }


    public class FocReason
    {
        public string focReasonCode { get; set; }
        public string focReasonSdesc { get; set; }
        public string focReasonLdesc { get; set; }
        public bool focReasonIsactive { get; set; }
    }

    public class FocReasonUpdate
    {
        public int id { get; set; }
        public string focReasonCode { get; set; }
        public string focReasonSdesc { get; set; }
        public string focReasonLdesc { get; set; }
        public bool focReasonIsactive { get; set; }
    }


    public class PayGroup
    {
        public string payGroupCode { get; set; }
        public string pictureLocation { get; set; }
        public int seq { get; set; }
        public bool iscreditcard { get; set; }
    }

    public class PayGroupUpdate
    {

        public int id { get; set; }
        public string payGroupCode { get; set; }
        public string pictureLocation { get; set; }
        public int seq { get; set; }
        public object iscreditcard { get; set; }
    }

    public class PaymentTypeList
    {
        public string payCode { get; set; }
        public string payDescription { get; set; }
        public string payGroup { get; set; }
        //public int payId { get; set; }
        public bool payIsactive { get; set; }
        public string gtGroup { get; set; }
        public bool rwUsebp { get; set; }
        public bool iscomm { get; set; }
        public string sequence { get; set; }
        public string bankCharges { get; set; }
        public string eps { get; set; }
         public bool voucherPaymentControl { get; set; }
         public bool showInReport { get; set; }
         public bool payIsGst { get; set; }
         public string creditcardcharges { get; set; }
         public string onlinepaymentcharges { get; set; }
         public bool iscreditcard { get; set; }
         public bool isonlinepayment { get; set; }
         public string accountCode { get; set; }
         public bool accountMapping { get; set; }
         public bool openCashdrawer { get; set; }
         public bool iscustapptpromo { get; set; }
         public bool isvoucherExtvoucher { get; set; }
        
    }

    public class PaymentTypeListUpdate
    {
        public string payCode { get; set; }
        public string payDescription { get; set; }
        public string payGroup { get; set; }
        public bool payIsactive { get; set; }
        public string gtGroup { get; set; }
        public bool rwUsebp { get; set; }
        public bool iscomm { get; set; }
        public string sequence { get; set; }
        public string bankCharges { get; set; }
        public string eps { get; set; }
        public bool voucherPaymentControl { get; set; }
        public bool showInReport { get; set; }
        public bool payIsGst { get; set; }
        public string creditcardcharges { get; set; }
        public string onlinepaymentcharges { get; set; }
        public bool iscreditcard { get; set; }
        public bool isonlinepayment { get; set; }
        public string accountCode { get; set; }
        public bool accountMapping { get; set; }
        public bool openCashdrawer { get; set; }
        public bool iscustapptpromo { get; set; }
        public bool isvoucherExtvoucher { get; set; }
        public int payId { get; set; }
    }

    public class AppointmentGroup
    {
        public string apptGroupCode { get; set; }
        public string apptGroupDesc { get; set; }
        public string apptGroupSeq { get; set; }
        public bool apptGroupIsactive { get; set; }
    }

    public class AppointmentGroupUpdate
    {
        public int id { get; set; }
        public string apptGroupCode { get; set; }
        public string apptGroupDesc { get; set; }
        public string apptGroupSeq { get; set; }
        public bool apptGroupIsactive { get; set; }
    }

    public class TransactionReason
    {
        public string reasonCode { get; set; }
        public string reasonDesc { get; set; }        
        public bool isactive { get; set; }
    }

    public class TransactionReasonUpdate
    {
        public int id { get; set; }
        public string reasonCode { get; set; }
        public string reasonDesc { get; set; }
        public bool isactive { get; set; }
    }

    public class VoidReason
    {
        public string reasonCode { get; set; }
        public string reasonDesc { get; set; }
        public bool isactive { get; set; }
    }

    public class VoidReasonUpdate
    {
        public int id { get; set; }
        public string reasonCode { get; set; }
        public string reasonDesc { get; set; }
        public bool isactive { get; set; }
    }

    public class ItemUOM
    {
        public string uomCode { get; set; }
        public string uomDesc { get; set; }
        public bool uomIsactive { get; set; }
    }

    public class ItemUOMUpdate
    {
        public int id { get; set; }
        public string uomCode { get; set; }
        public string uomDesc { get; set; }
        public bool uomIsactive { get; set; }
    }

    public class EmployeeLevelInsert
    {
        public string levelSequence { get; set; }
        public string minTarget { get; set; }
        public string fromSalary { get; set; }
        public string toSalary { get; set; }
        public string levelCode { get; set; }
        public string levelDesc { get; set; }
        public string groupCode { get; set; }
        public bool levelSpa { get; set; }
        public bool getGroupComm { get; set; }
        public bool levelIsActive { get; set; }
       
    }

    public class EmployeeLevelUpdate
    {
        public int id { get; set; }
        public string levelSequence { get; set; }
        public string minTarget { get; set; }
        public string fromSalary { get; set; }
        public string toSalary { get; set; }
        public string levelCode { get; set; }
        public string levelDesc { get; set; }
        public string groupCode { get; set; }
        public bool levelSpa { get; set; }
        public bool getGroupComm { get; set; }
        public bool levelIsActive { get; set; }
        
    }

    public class SecurityInsert
    {
        public string levelCode { get; set; }
        public string levelName { get; set; }
        public string levelDescription { get; set; }
        public bool levelPermitAppointment { get; set; }
        public bool levelPermitCrm { get; set; }
        public bool levelPermitCreditor { get; set; }
        public bool levelPermitStaff { get; set; }
        public bool levelPermitUserLogin { get; set; }
        public bool levelPermitStockItem { get; set; }
        public bool levelPermitSecurity { get; set; }
        public bool levelPermitSendmail { get; set; }
        public bool levelPermitInventory { get; set; }
        public bool levelPermitAnalysis { get; set; }
        public bool levelPermitMaintain { get; set; }
        public bool levelPermitPos { get; set; }
        public bool levelIsActive { get; set; }
        public bool levelPermitPayTable { get; set; }
        public bool levelPermitForex { get; set; }
        public bool levelPermitDiv { get; set; }
        public bool levelPermitDiscount { get; set; }
        public bool levelPermitDept { get; set; }
        public bool levelPermitClass { get; set; }
        public bool levelPermitPromo { get; set; }
        public bool levelPermitAttendance { get; set; }
        public bool levelPermitStkReceive { get; set; }
        public bool levelPermitStkAdj { get; set; }
        public bool levelPermitStkTrans { get; set; }
        public bool levelPermitStkWriteOff { get; set; }
        public bool levelPermitStkQuery { get; set; }
        public bool levelPermitStkTk { get; set; }
        public bool levelPermitStkVar { get; set; }

    }

    public class SecurityUpdate
    {
        public int levelItemId { get; set; }
        public string levelCode { get; set; }
        public string levelName { get; set; }
        public string levelDescription { get; set; }
        public bool levelPermitAppointment { get; set; }
        public bool levelPermitCrm { get; set; }
        public bool levelPermitCreditor { get; set; }
        public bool levelPermitStaff { get; set; }
        public bool levelPermitUserLogin { get; set; }
        public bool levelPermitStockItem { get; set; }
        public bool levelPermitSecurity { get; set; }
        public bool levelPermitSendmail { get; set; }
        public bool levelPermitInventory { get; set; }
        public bool levelPermitAnalysis { get; set; }
        public bool levelPermitMaintain { get; set; }
        public bool levelPermitPos { get; set; }
        public bool levelIsActive { get; set; }
        public bool levelPermitPayTable { get; set; }
        public bool levelPermitForex { get; set; }
        public bool levelPermitDiv { get; set; }
        public bool levelPermitDiscount { get; set; }
        public bool levelPermitDept { get; set; }
        public bool levelPermitClass { get; set; }
        public bool levelPermitPromo { get; set; }
        public bool levelPermitAttendance { get; set; }
        public bool levelPermitStkReceive { get; set; }
        public bool levelPermitStkAdj { get; set; }
        public bool levelPermitStkTrans { get; set; }
        public bool levelPermitStkWriteOff { get; set; }
        public bool levelPermitStkQuery { get; set; }
        public bool levelPermitStkTk { get; set; }
        public bool levelPermitStkVar { get; set; }

    }

    public class ApptBookingStatus
    {
        public string bsCode { get; set; }
        public string bsDesc { get; set; }
        public string bsColorCode { get; set; }
        public bool active { get; set; }
    }

    public class ApptBookingStatusUpdate
    {
        public string bsCode { get; set; }
        public string bsDesc { get; set; }
        public string bsColorCode { get; set; }
        public bool active { get; set; }
        public int id { get; set; }
    }

    public class ApptChannel
    {
        public string channelCode { get; set; }
        public string channelDesc { get; set; }
        public bool active { get; set; }
    }

    public class ApptChannelUpdate
    {
        public string channelCode { get; set; }
        public string channelDesc { get; set; }
        public bool active { get; set; }
        public int id { get; set; }
    }

    public class ApptSecondaryStatus
    {
        public string ssCode { get; set; }
        public string ssDesc { get; set; }
        public string ssColorCode { get; set; }
        public bool active { get; set; }
    }

    public class ApptSecondaryStatusUpdate
    {
        public string ssCode { get; set; }
        public string ssDesc { get; set; }
        public string ssColorCode { get; set; }
        public bool active { get; set; }
        public int id { get; set; }
    }

    public class GstSettingUpdate
    {
        public string itemCode { get; set; }
        public string itemDesc { get; set; }
        public int itemValue { get; set; }
        public int itemSeq { get; set; }
        public bool isactive { get; set; }
        public int id { get; set; }
    }


}