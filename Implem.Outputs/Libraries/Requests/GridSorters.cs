﻿using Implem.Libraries.DataSources.SqlServer;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.Views;
using System.Linq;
namespace Implem.Pleasanter.Libraries.Requests
{
    public static class GridSorters
    {
        public static SqlOrderByCollection Get(
            FormData formData, SqlOrderByCollection sqlOrderByCollection)
        {
            if (formData.Any(o => o.Key.StartsWith("GridSorters_")))
            {
                sqlOrderByCollection = new SqlOrderByCollection();
            }
            return sqlOrderByCollection.Columns(formData);
        }

        private static SqlOrderBy.Types Type(string type)
        {
            switch (type)
            {
                case "Asc": return SqlOrderBy.Types.asc;
                case "Desc": return SqlOrderBy.Types.desc;
                default: return SqlOrderBy.Types.release;
            }
        }

        public static string TypeString(FormData formData, string key)
        {
            switch (formData.Get(key))
            {
                case "Asc": return "Desc";
                case "Desc": return string.Empty;
                default: return "Asc";
            }
        }

        public static HtmlBuilder SortIcon(this HtmlBuilder hb, FormData formData, string key)
        {
            switch (formData.Get(key))
            {
                case "Asc": return hb.Icon(iconCss: "ui-icon-triangle-1-n");
                case "Desc": return hb.Icon(iconCss: "ui-icon-triangle-1-s");
                default: return hb;
            }
        }

        private static SqlOrderByCollection Columns(
            this SqlOrderByCollection orderBy,
            FormData formData)
        {
            formData.Keys.ForEach(key =>
            {
                var type = Type(formData[key]);
                switch (key)
                {
                    case "GridSorters_Tenants_TenantId": orderBy.Tenants_TenantId(type); break;
                    case "GridSorters_Tenants_Ver": orderBy.Tenants_Ver(type); break;
                    case "GridSorters_Tenants_TenantName": orderBy.Tenants_TenantName(type); break;
                    case "GridSorters_Tenants_Title": orderBy.Tenants_Title(type); break;
                    case "GridSorters_Tenants_Body": orderBy.Tenants_Body(type); break;
                    case "GridSorters_Tenants_Comments": orderBy.Tenants_Comments(type); break;
                    case "GridSorters_Tenants_Creator": orderBy.Tenants_Creator(type); break;
                    case "GridSorters_Tenants_Updator": orderBy.Tenants_Updator(type); break;
                    case "GridSorters_Tenants_CreatedTime": orderBy.Tenants_CreatedTime(type); break;
                    case "GridSorters_Tenants_UpdatedTime": orderBy.Tenants_UpdatedTime(type); break;
                    case "GridSorters_SysLogs_CreatedTime": orderBy.SysLogs_CreatedTime(type); break;
                    case "GridSorters_SysLogs_SysLogId": orderBy.SysLogs_SysLogId(type); break;
                    case "GridSorters_SysLogs_Ver": orderBy.SysLogs_Ver(type); break;
                    case "GridSorters_SysLogs_SysLogType": orderBy.SysLogs_SysLogType(type); break;
                    case "GridSorters_SysLogs_OnAzure": orderBy.SysLogs_OnAzure(type); break;
                    case "GridSorters_SysLogs_MachineName": orderBy.SysLogs_MachineName(type); break;
                    case "GridSorters_SysLogs_ServiceName": orderBy.SysLogs_ServiceName(type); break;
                    case "GridSorters_SysLogs_TenantName": orderBy.SysLogs_TenantName(type); break;
                    case "GridSorters_SysLogs_Application": orderBy.SysLogs_Application(type); break;
                    case "GridSorters_SysLogs_Class": orderBy.SysLogs_Class(type); break;
                    case "GridSorters_SysLogs_Method": orderBy.SysLogs_Method(type); break;
                    case "GridSorters_SysLogs_RequestData": orderBy.SysLogs_RequestData(type); break;
                    case "GridSorters_SysLogs_HttpMethod": orderBy.SysLogs_HttpMethod(type); break;
                    case "GridSorters_SysLogs_RequestSize": orderBy.SysLogs_RequestSize(type); break;
                    case "GridSorters_SysLogs_ResponseSize": orderBy.SysLogs_ResponseSize(type); break;
                    case "GridSorters_SysLogs_Elapsed": orderBy.SysLogs_Elapsed(type); break;
                    case "GridSorters_SysLogs_ApplicationAge": orderBy.SysLogs_ApplicationAge(type); break;
                    case "GridSorters_SysLogs_ApplicationRequestInterval": orderBy.SysLogs_ApplicationRequestInterval(type); break;
                    case "GridSorters_SysLogs_SessionAge": orderBy.SysLogs_SessionAge(type); break;
                    case "GridSorters_SysLogs_SessionRequestInterval": orderBy.SysLogs_SessionRequestInterval(type); break;
                    case "GridSorters_SysLogs_WorkingSet64": orderBy.SysLogs_WorkingSet64(type); break;
                    case "GridSorters_SysLogs_VirtualMemorySize64": orderBy.SysLogs_VirtualMemorySize64(type); break;
                    case "GridSorters_SysLogs_ProcessId": orderBy.SysLogs_ProcessId(type); break;
                    case "GridSorters_SysLogs_ProcessName": orderBy.SysLogs_ProcessName(type); break;
                    case "GridSorters_SysLogs_BasePriority": orderBy.SysLogs_BasePriority(type); break;
                    case "GridSorters_SysLogs_Url": orderBy.SysLogs_Url(type); break;
                    case "GridSorters_SysLogs_UrlReferer": orderBy.SysLogs_UrlReferer(type); break;
                    case "GridSorters_SysLogs_UserHostName": orderBy.SysLogs_UserHostName(type); break;
                    case "GridSorters_SysLogs_UserHostAddress": orderBy.SysLogs_UserHostAddress(type); break;
                    case "GridSorters_SysLogs_UserLanguage": orderBy.SysLogs_UserLanguage(type); break;
                    case "GridSorters_SysLogs_UserAgent": orderBy.SysLogs_UserAgent(type); break;
                    case "GridSorters_SysLogs_SessionGuid": orderBy.SysLogs_SessionGuid(type); break;
                    case "GridSorters_SysLogs_ErrMessage": orderBy.SysLogs_ErrMessage(type); break;
                    case "GridSorters_SysLogs_ErrStackTrace": orderBy.SysLogs_ErrStackTrace(type); break;
                    case "GridSorters_SysLogs_InDebug": orderBy.SysLogs_InDebug(type); break;
                    case "GridSorters_SysLogs_AssemblyVersion": orderBy.SysLogs_AssemblyVersion(type); break;
                    case "GridSorters_SysLogs_Comments": orderBy.SysLogs_Comments(type); break;
                    case "GridSorters_SysLogs_Creator": orderBy.SysLogs_Creator(type); break;
                    case "GridSorters_SysLogs_Updator": orderBy.SysLogs_Updator(type); break;
                    case "GridSorters_SysLogs_UpdatedTime": orderBy.SysLogs_UpdatedTime(type); break;
                    case "GridSorters_Depts_TenantId": orderBy.Depts_TenantId(type); break;
                    case "GridSorters_Depts_DeptId": orderBy.Depts_DeptId(type); break;
                    case "GridSorters_Depts_Ver": orderBy.Depts_Ver(type); break;
                    case "GridSorters_Depts_ParentDeptId": orderBy.Depts_ParentDeptId(type); break;
                    case "GridSorters_Depts_ParentDept": orderBy.Depts_ParentDept(type); break;
                    case "GridSorters_Depts_DeptCode": orderBy.Depts_DeptCode(type); break;
                    case "GridSorters_Depts_Dept": orderBy.Depts_Dept(type); break;
                    case "GridSorters_Depts_DeptName": orderBy.Depts_DeptName(type); break;
                    case "GridSorters_Depts_Body": orderBy.Depts_Body(type); break;
                    case "GridSorters_Depts_Comments": orderBy.Depts_Comments(type); break;
                    case "GridSorters_Depts_Creator": orderBy.Depts_Creator(type); break;
                    case "GridSorters_Depts_Updator": orderBy.Depts_Updator(type); break;
                    case "GridSorters_Depts_CreatedTime": orderBy.Depts_CreatedTime(type); break;
                    case "GridSorters_Depts_UpdatedTime": orderBy.Depts_UpdatedTime(type); break;
                    case "GridSorters_Users_TenantId": orderBy.Users_TenantId(type); break;
                    case "GridSorters_Users_UserId": orderBy.Users_UserId(type); break;
                    case "GridSorters_Users_Ver": orderBy.Users_Ver(type); break;
                    case "GridSorters_Users_LoginId": orderBy.Users_LoginId(type); break;
                    case "GridSorters_Users_Disabled": orderBy.Users_Disabled(type); break;
                    case "GridSorters_Users_UserCode": orderBy.Users_UserCode(type); break;
                    case "GridSorters_Users_Password": orderBy.Users_Password(type); break;
                    case "GridSorters_Users_LastName": orderBy.Users_LastName(type); break;
                    case "GridSorters_Users_FirstName": orderBy.Users_FirstName(type); break;
                    case "GridSorters_Users_Birthday": orderBy.Users_Birthday(type); break;
                    case "GridSorters_Users_Sex": orderBy.Users_Sex(type); break;
                    case "GridSorters_Users_Language": orderBy.Users_Language(type); break;
                    case "GridSorters_Users_TimeZone": orderBy.Users_TimeZone(type); break;
                    case "GridSorters_Users_DeptId": orderBy.Users_DeptId(type); break;
                    case "GridSorters_Users_Dept": orderBy.Users_Dept(type); break;
                    case "GridSorters_Users_FirstAndLastNameOrder": orderBy.Users_FirstAndLastNameOrder(type); break;
                    case "GridSorters_Users_LastLoginTime": orderBy.Users_LastLoginTime(type); break;
                    case "GridSorters_Users_PasswordChangeTime": orderBy.Users_PasswordChangeTime(type); break;
                    case "GridSorters_Users_NumberOfLogins": orderBy.Users_NumberOfLogins(type); break;
                    case "GridSorters_Users_NumberOfDenial": orderBy.Users_NumberOfDenial(type); break;
                    case "GridSorters_Users_TenantAdmin": orderBy.Users_TenantAdmin(type); break;
                    case "GridSorters_Users_ServiceAdmin": orderBy.Users_ServiceAdmin(type); break;
                    case "GridSorters_Users_Developer": orderBy.Users_Developer(type); break;
                    case "GridSorters_Users_Comments": orderBy.Users_Comments(type); break;
                    case "GridSorters_Users_Creator": orderBy.Users_Creator(type); break;
                    case "GridSorters_Users_Updator": orderBy.Users_Updator(type); break;
                    case "GridSorters_Users_CreatedTime": orderBy.Users_CreatedTime(type); break;
                    case "GridSorters_Users_UpdatedTime": orderBy.Users_UpdatedTime(type); break;
                    case "GridSorters_MailAddresses_OwnerId": orderBy.MailAddresses_OwnerId(type); break;
                    case "GridSorters_MailAddresses_OwnerType": orderBy.MailAddresses_OwnerType(type); break;
                    case "GridSorters_MailAddresses_MailAddressId": orderBy.MailAddresses_MailAddressId(type); break;
                    case "GridSorters_MailAddresses_Ver": orderBy.MailAddresses_Ver(type); break;
                    case "GridSorters_MailAddresses_MailAddress": orderBy.MailAddresses_MailAddress(type); break;
                    case "GridSorters_MailAddresses_Comments": orderBy.MailAddresses_Comments(type); break;
                    case "GridSorters_MailAddresses_Creator": orderBy.MailAddresses_Creator(type); break;
                    case "GridSorters_MailAddresses_Updator": orderBy.MailAddresses_Updator(type); break;
                    case "GridSorters_MailAddresses_CreatedTime": orderBy.MailAddresses_CreatedTime(type); break;
                    case "GridSorters_MailAddresses_UpdatedTime": orderBy.MailAddresses_UpdatedTime(type); break;
                    case "GridSorters_Permissions_ReferenceType": orderBy.Permissions_ReferenceType(type); break;
                    case "GridSorters_Permissions_ReferenceId": orderBy.Permissions_ReferenceId(type); break;
                    case "GridSorters_Permissions_DeptId": orderBy.Permissions_DeptId(type); break;
                    case "GridSorters_Permissions_UserId": orderBy.Permissions_UserId(type); break;
                    case "GridSorters_Permissions_Ver": orderBy.Permissions_Ver(type); break;
                    case "GridSorters_Permissions_DeptName": orderBy.Permissions_DeptName(type); break;
                    case "GridSorters_Permissions_FullName1": orderBy.Permissions_FullName1(type); break;
                    case "GridSorters_Permissions_FullName2": orderBy.Permissions_FullName2(type); break;
                    case "GridSorters_Permissions_FirstAndLastNameOrder": orderBy.Permissions_FirstAndLastNameOrder(type); break;
                    case "GridSorters_Permissions_PermissionType": orderBy.Permissions_PermissionType(type); break;
                    case "GridSorters_Permissions_Comments": orderBy.Permissions_Comments(type); break;
                    case "GridSorters_Permissions_Creator": orderBy.Permissions_Creator(type); break;
                    case "GridSorters_Permissions_Updator": orderBy.Permissions_Updator(type); break;
                    case "GridSorters_Permissions_CreatedTime": orderBy.Permissions_CreatedTime(type); break;
                    case "GridSorters_Permissions_UpdatedTime": orderBy.Permissions_UpdatedTime(type); break;
                    case "GridSorters_OutgoingMails_ReferenceType": orderBy.OutgoingMails_ReferenceType(type); break;
                    case "GridSorters_OutgoingMails_ReferenceId": orderBy.OutgoingMails_ReferenceId(type); break;
                    case "GridSorters_OutgoingMails_ReferenceVer": orderBy.OutgoingMails_ReferenceVer(type); break;
                    case "GridSorters_OutgoingMails_OutgoingMailId": orderBy.OutgoingMails_OutgoingMailId(type); break;
                    case "GridSorters_OutgoingMails_Ver": orderBy.OutgoingMails_Ver(type); break;
                    case "GridSorters_OutgoingMails_Host": orderBy.OutgoingMails_Host(type); break;
                    case "GridSorters_OutgoingMails_Port": orderBy.OutgoingMails_Port(type); break;
                    case "GridSorters_OutgoingMails_From": orderBy.OutgoingMails_From(type); break;
                    case "GridSorters_OutgoingMails_To": orderBy.OutgoingMails_To(type); break;
                    case "GridSorters_OutgoingMails_Cc": orderBy.OutgoingMails_Cc(type); break;
                    case "GridSorters_OutgoingMails_Bcc": orderBy.OutgoingMails_Bcc(type); break;
                    case "GridSorters_OutgoingMails_Title": orderBy.OutgoingMails_Title(type); break;
                    case "GridSorters_OutgoingMails_Body": orderBy.OutgoingMails_Body(type); break;
                    case "GridSorters_OutgoingMails_SentTime": orderBy.OutgoingMails_SentTime(type); break;
                    case "GridSorters_OutgoingMails_Comments": orderBy.OutgoingMails_Comments(type); break;
                    case "GridSorters_OutgoingMails_Creator": orderBy.OutgoingMails_Creator(type); break;
                    case "GridSorters_OutgoingMails_Updator": orderBy.OutgoingMails_Updator(type); break;
                    case "GridSorters_OutgoingMails_CreatedTime": orderBy.OutgoingMails_CreatedTime(type); break;
                    case "GridSorters_OutgoingMails_UpdatedTime": orderBy.OutgoingMails_UpdatedTime(type); break;
                    case "GridSorters_SearchIndexes_Word": orderBy.SearchIndexes_Word(type); break;
                    case "GridSorters_SearchIndexes_ReferenceId": orderBy.SearchIndexes_ReferenceId(type); break;
                    case "GridSorters_SearchIndexes_Ver": orderBy.SearchIndexes_Ver(type); break;
                    case "GridSorters_SearchIndexes_Priority": orderBy.SearchIndexes_Priority(type); break;
                    case "GridSorters_SearchIndexes_ReferenceType": orderBy.SearchIndexes_ReferenceType(type); break;
                    case "GridSorters_SearchIndexes_Title": orderBy.SearchIndexes_Title(type); break;
                    case "GridSorters_SearchIndexes_Subset": orderBy.SearchIndexes_Subset(type); break;
                    case "GridSorters_SearchIndexes_PermissionType": orderBy.SearchIndexes_PermissionType(type); break;
                    case "GridSorters_SearchIndexes_Comments": orderBy.SearchIndexes_Comments(type); break;
                    case "GridSorters_SearchIndexes_Creator": orderBy.SearchIndexes_Creator(type); break;
                    case "GridSorters_SearchIndexes_Updator": orderBy.SearchIndexes_Updator(type); break;
                    case "GridSorters_SearchIndexes_CreatedTime": orderBy.SearchIndexes_CreatedTime(type); break;
                    case "GridSorters_SearchIndexes_UpdatedTime": orderBy.SearchIndexes_UpdatedTime(type); break;
                    case "GridSorters_Items_ReferenceId": orderBy.Items_ReferenceId(type); break;
                    case "GridSorters_Items_Ver": orderBy.Items_Ver(type); break;
                    case "GridSorters_Items_ReferenceType": orderBy.Items_ReferenceType(type); break;
                    case "GridSorters_Items_SiteId": orderBy.Items_SiteId(type); break;
                    case "GridSorters_Items_Title": orderBy.Items_Title(type); break;
                    case "GridSorters_Items_Subset": orderBy.Items_Subset(type); break;
                    case "GridSorters_Items_UpdateTarget": orderBy.Items_UpdateTarget(type); break;
                    case "GridSorters_Items_Comments": orderBy.Items_Comments(type); break;
                    case "GridSorters_Items_Creator": orderBy.Items_Creator(type); break;
                    case "GridSorters_Items_Updator": orderBy.Items_Updator(type); break;
                    case "GridSorters_Items_CreatedTime": orderBy.Items_CreatedTime(type); break;
                    case "GridSorters_Items_UpdatedTime": orderBy.Items_UpdatedTime(type); break;
                    case "GridSorters_Sites_TenantId": orderBy.Sites_TenantId(type); break;
                    case "GridSorters_Sites_SiteId": orderBy.Sites_SiteId(type); break;
                    case "GridSorters_Sites_UpdatedTime": orderBy.Sites_UpdatedTime(type); break;
                    case "GridSorters_Sites_Ver": orderBy.Sites_Ver(type); break;
                    case "GridSorters_Sites_Title": orderBy.Sites_Title(type); break;
                    case "GridSorters_Sites_Body": orderBy.Sites_Body(type); break;
                    case "GridSorters_Sites_TitleBody": orderBy.Sites_TitleBody(type); break;
                    case "GridSorters_Sites_ReferenceType": orderBy.Sites_ReferenceType(type); break;
                    case "GridSorters_Sites_ParentId": orderBy.Sites_ParentId(type); break;
                    case "GridSorters_Sites_InheritPermission": orderBy.Sites_InheritPermission(type); break;
                    case "GridSorters_Sites_PermissionType": orderBy.Sites_PermissionType(type); break;
                    case "GridSorters_Sites_SiteSettings": orderBy.Sites_SiteSettings(type); break;
                    case "GridSorters_Sites_Comments": orderBy.Sites_Comments(type); break;
                    case "GridSorters_Sites_Creator": orderBy.Sites_Creator(type); break;
                    case "GridSorters_Sites_Updator": orderBy.Sites_Updator(type); break;
                    case "GridSorters_Sites_CreatedTime": orderBy.Sites_CreatedTime(type); break;
                    case "GridSorters_Orders_ReferenceId": orderBy.Orders_ReferenceId(type); break;
                    case "GridSorters_Orders_ReferenceType": orderBy.Orders_ReferenceType(type); break;
                    case "GridSorters_Orders_OwnerId": orderBy.Orders_OwnerId(type); break;
                    case "GridSorters_Orders_Ver": orderBy.Orders_Ver(type); break;
                    case "GridSorters_Orders_Data": orderBy.Orders_Data(type); break;
                    case "GridSorters_Orders_Comments": orderBy.Orders_Comments(type); break;
                    case "GridSorters_Orders_Creator": orderBy.Orders_Creator(type); break;
                    case "GridSorters_Orders_Updator": orderBy.Orders_Updator(type); break;
                    case "GridSorters_Orders_CreatedTime": orderBy.Orders_CreatedTime(type); break;
                    case "GridSorters_Orders_UpdatedTime": orderBy.Orders_UpdatedTime(type); break;
                    case "GridSorters_ExportSettings_ReferenceType": orderBy.ExportSettings_ReferenceType(type); break;
                    case "GridSorters_ExportSettings_ReferenceId": orderBy.ExportSettings_ReferenceId(type); break;
                    case "GridSorters_ExportSettings_Title": orderBy.ExportSettings_Title(type); break;
                    case "GridSorters_ExportSettings_ExportSettingId": orderBy.ExportSettings_ExportSettingId(type); break;
                    case "GridSorters_ExportSettings_Ver": orderBy.ExportSettings_Ver(type); break;
                    case "GridSorters_ExportSettings_AddHeader": orderBy.ExportSettings_AddHeader(type); break;
                    case "GridSorters_ExportSettings_ExportColumns": orderBy.ExportSettings_ExportColumns(type); break;
                    case "GridSorters_ExportSettings_Comments": orderBy.ExportSettings_Comments(type); break;
                    case "GridSorters_ExportSettings_Creator": orderBy.ExportSettings_Creator(type); break;
                    case "GridSorters_ExportSettings_Updator": orderBy.ExportSettings_Updator(type); break;
                    case "GridSorters_ExportSettings_CreatedTime": orderBy.ExportSettings_CreatedTime(type); break;
                    case "GridSorters_ExportSettings_UpdatedTime": orderBy.ExportSettings_UpdatedTime(type); break;
                    case "GridSorters_Links_DestinationId": orderBy.Links_DestinationId(type); break;
                    case "GridSorters_Links_SourceId": orderBy.Links_SourceId(type); break;
                    case "GridSorters_Links_Ver": orderBy.Links_Ver(type); break;
                    case "GridSorters_Links_ReferenceType": orderBy.Links_ReferenceType(type); break;
                    case "GridSorters_Links_SiteId": orderBy.Links_SiteId(type); break;
                    case "GridSorters_Links_Title": orderBy.Links_Title(type); break;
                    case "GridSorters_Links_Subset": orderBy.Links_Subset(type); break;
                    case "GridSorters_Links_SiteTitle": orderBy.Links_SiteTitle(type); break;
                    case "GridSorters_Links_Comments": orderBy.Links_Comments(type); break;
                    case "GridSorters_Links_Creator": orderBy.Links_Creator(type); break;
                    case "GridSorters_Links_Updator": orderBy.Links_Updator(type); break;
                    case "GridSorters_Links_CreatedTime": orderBy.Links_CreatedTime(type); break;
                    case "GridSorters_Links_UpdatedTime": orderBy.Links_UpdatedTime(type); break;
                    case "GridSorters_Binaries_ReferenceId": orderBy.Binaries_ReferenceId(type); break;
                    case "GridSorters_Binaries_BinaryId": orderBy.Binaries_BinaryId(type); break;
                    case "GridSorters_Binaries_Ver": orderBy.Binaries_Ver(type); break;
                    case "GridSorters_Binaries_BinaryType": orderBy.Binaries_BinaryType(type); break;
                    case "GridSorters_Binaries_Title": orderBy.Binaries_Title(type); break;
                    case "GridSorters_Binaries_Body": orderBy.Binaries_Body(type); break;
                    case "GridSorters_Binaries_Bin": orderBy.Binaries_Bin(type); break;
                    case "GridSorters_Binaries_Thumbnail": orderBy.Binaries_Thumbnail(type); break;
                    case "GridSorters_Binaries_Icon": orderBy.Binaries_Icon(type); break;
                    case "GridSorters_Binaries_FileName": orderBy.Binaries_FileName(type); break;
                    case "GridSorters_Binaries_Extension": orderBy.Binaries_Extension(type); break;
                    case "GridSorters_Binaries_Size": orderBy.Binaries_Size(type); break;
                    case "GridSorters_Binaries_BinarySettings": orderBy.Binaries_BinarySettings(type); break;
                    case "GridSorters_Binaries_Comments": orderBy.Binaries_Comments(type); break;
                    case "GridSorters_Binaries_Creator": orderBy.Binaries_Creator(type); break;
                    case "GridSorters_Binaries_Updator": orderBy.Binaries_Updator(type); break;
                    case "GridSorters_Binaries_CreatedTime": orderBy.Binaries_CreatedTime(type); break;
                    case "GridSorters_Binaries_UpdatedTime": orderBy.Binaries_UpdatedTime(type); break;
                    case "GridSorters_Issues_SiteId": orderBy.Issues_SiteId(type); break;
                    case "GridSorters_Issues_UpdatedTime": orderBy.Issues_UpdatedTime(type); break;
                    case "GridSorters_Issues_IssueId": orderBy.Issues_IssueId(type); break;
                    case "GridSorters_Issues_Ver": orderBy.Issues_Ver(type); break;
                    case "GridSorters_Issues_Title": orderBy.Issues_Title(type); break;
                    case "GridSorters_Issues_Body": orderBy.Issues_Body(type); break;
                    case "GridSorters_Issues_TitleBody": orderBy.Issues_TitleBody(type); break;
                    case "GridSorters_Issues_StartTime": orderBy.Issues_StartTime(type); break;
                    case "GridSorters_Issues_CompletionTime": orderBy.Issues_CompletionTime(type); break;
                    case "GridSorters_Issues_WorkValue": orderBy.Issues_WorkValue(type); break;
                    case "GridSorters_Issues_ProgressRate": orderBy.Issues_ProgressRate(type); break;
                    case "GridSorters_Issues_RemainingWorkValue": orderBy.Issues_RemainingWorkValue(type); break;
                    case "GridSorters_Issues_Status": orderBy.Issues_Status(type); break;
                    case "GridSorters_Issues_Manager": orderBy.Issues_Manager(type); break;
                    case "GridSorters_Issues_Owner": orderBy.Issues_Owner(type); break;
                    case "GridSorters_Issues_ClassA": orderBy.Issues_ClassA(type); break;
                    case "GridSorters_Issues_ClassB": orderBy.Issues_ClassB(type); break;
                    case "GridSorters_Issues_ClassC": orderBy.Issues_ClassC(type); break;
                    case "GridSorters_Issues_ClassD": orderBy.Issues_ClassD(type); break;
                    case "GridSorters_Issues_ClassE": orderBy.Issues_ClassE(type); break;
                    case "GridSorters_Issues_ClassF": orderBy.Issues_ClassF(type); break;
                    case "GridSorters_Issues_ClassG": orderBy.Issues_ClassG(type); break;
                    case "GridSorters_Issues_ClassH": orderBy.Issues_ClassH(type); break;
                    case "GridSorters_Issues_ClassI": orderBy.Issues_ClassI(type); break;
                    case "GridSorters_Issues_ClassJ": orderBy.Issues_ClassJ(type); break;
                    case "GridSorters_Issues_ClassK": orderBy.Issues_ClassK(type); break;
                    case "GridSorters_Issues_ClassL": orderBy.Issues_ClassL(type); break;
                    case "GridSorters_Issues_ClassM": orderBy.Issues_ClassM(type); break;
                    case "GridSorters_Issues_ClassN": orderBy.Issues_ClassN(type); break;
                    case "GridSorters_Issues_ClassO": orderBy.Issues_ClassO(type); break;
                    case "GridSorters_Issues_ClassP": orderBy.Issues_ClassP(type); break;
                    case "GridSorters_Issues_NumA": orderBy.Issues_NumA(type); break;
                    case "GridSorters_Issues_NumB": orderBy.Issues_NumB(type); break;
                    case "GridSorters_Issues_NumC": orderBy.Issues_NumC(type); break;
                    case "GridSorters_Issues_NumD": orderBy.Issues_NumD(type); break;
                    case "GridSorters_Issues_NumE": orderBy.Issues_NumE(type); break;
                    case "GridSorters_Issues_NumF": orderBy.Issues_NumF(type); break;
                    case "GridSorters_Issues_NumG": orderBy.Issues_NumG(type); break;
                    case "GridSorters_Issues_NumH": orderBy.Issues_NumH(type); break;
                    case "GridSorters_Issues_DateA": orderBy.Issues_DateA(type); break;
                    case "GridSorters_Issues_DateB": orderBy.Issues_DateB(type); break;
                    case "GridSorters_Issues_DateC": orderBy.Issues_DateC(type); break;
                    case "GridSorters_Issues_DateD": orderBy.Issues_DateD(type); break;
                    case "GridSorters_Issues_DateE": orderBy.Issues_DateE(type); break;
                    case "GridSorters_Issues_DateF": orderBy.Issues_DateF(type); break;
                    case "GridSorters_Issues_DateG": orderBy.Issues_DateG(type); break;
                    case "GridSorters_Issues_DateH": orderBy.Issues_DateH(type); break;
                    case "GridSorters_Issues_DescriptionA": orderBy.Issues_DescriptionA(type); break;
                    case "GridSorters_Issues_DescriptionB": orderBy.Issues_DescriptionB(type); break;
                    case "GridSorters_Issues_DescriptionC": orderBy.Issues_DescriptionC(type); break;
                    case "GridSorters_Issues_DescriptionD": orderBy.Issues_DescriptionD(type); break;
                    case "GridSorters_Issues_DescriptionE": orderBy.Issues_DescriptionE(type); break;
                    case "GridSorters_Issues_DescriptionF": orderBy.Issues_DescriptionF(type); break;
                    case "GridSorters_Issues_DescriptionG": orderBy.Issues_DescriptionG(type); break;
                    case "GridSorters_Issues_DescriptionH": orderBy.Issues_DescriptionH(type); break;
                    case "GridSorters_Issues_Comments": orderBy.Issues_Comments(type); break;
                    case "GridSorters_Issues_Creator": orderBy.Issues_Creator(type); break;
                    case "GridSorters_Issues_Updator": orderBy.Issues_Updator(type); break;
                    case "GridSorters_Issues_CreatedTime": orderBy.Issues_CreatedTime(type); break;
                    case "GridSorters_Results_SiteId": orderBy.Results_SiteId(type); break;
                    case "GridSorters_Results_UpdatedTime": orderBy.Results_UpdatedTime(type); break;
                    case "GridSorters_Results_ResultId": orderBy.Results_ResultId(type); break;
                    case "GridSorters_Results_Ver": orderBy.Results_Ver(type); break;
                    case "GridSorters_Results_Body": orderBy.Results_Body(type); break;
                    case "GridSorters_Results_TitleBody": orderBy.Results_TitleBody(type); break;
                    case "GridSorters_Results_Title": orderBy.Results_Title(type); break;
                    case "GridSorters_Results_Manager": orderBy.Results_Manager(type); break;
                    case "GridSorters_Results_Owner": orderBy.Results_Owner(type); break;
                    case "GridSorters_Results_ClassA": orderBy.Results_ClassA(type); break;
                    case "GridSorters_Results_ClassB": orderBy.Results_ClassB(type); break;
                    case "GridSorters_Results_Status": orderBy.Results_Status(type); break;
                    case "GridSorters_Results_ClassC": orderBy.Results_ClassC(type); break;
                    case "GridSorters_Results_ClassD": orderBy.Results_ClassD(type); break;
                    case "GridSorters_Results_ClassE": orderBy.Results_ClassE(type); break;
                    case "GridSorters_Results_ClassF": orderBy.Results_ClassF(type); break;
                    case "GridSorters_Results_ClassG": orderBy.Results_ClassG(type); break;
                    case "GridSorters_Results_ClassH": orderBy.Results_ClassH(type); break;
                    case "GridSorters_Results_ClassI": orderBy.Results_ClassI(type); break;
                    case "GridSorters_Results_ClassJ": orderBy.Results_ClassJ(type); break;
                    case "GridSorters_Results_ClassK": orderBy.Results_ClassK(type); break;
                    case "GridSorters_Results_ClassL": orderBy.Results_ClassL(type); break;
                    case "GridSorters_Results_ClassM": orderBy.Results_ClassM(type); break;
                    case "GridSorters_Results_ClassN": orderBy.Results_ClassN(type); break;
                    case "GridSorters_Results_ClassO": orderBy.Results_ClassO(type); break;
                    case "GridSorters_Results_ClassP": orderBy.Results_ClassP(type); break;
                    case "GridSorters_Results_NumA": orderBy.Results_NumA(type); break;
                    case "GridSorters_Results_NumB": orderBy.Results_NumB(type); break;
                    case "GridSorters_Results_NumC": orderBy.Results_NumC(type); break;
                    case "GridSorters_Results_NumD": orderBy.Results_NumD(type); break;
                    case "GridSorters_Results_NumE": orderBy.Results_NumE(type); break;
                    case "GridSorters_Results_NumF": orderBy.Results_NumF(type); break;
                    case "GridSorters_Results_NumG": orderBy.Results_NumG(type); break;
                    case "GridSorters_Results_NumH": orderBy.Results_NumH(type); break;
                    case "GridSorters_Results_DateA": orderBy.Results_DateA(type); break;
                    case "GridSorters_Results_DateB": orderBy.Results_DateB(type); break;
                    case "GridSorters_Results_DateC": orderBy.Results_DateC(type); break;
                    case "GridSorters_Results_DateD": orderBy.Results_DateD(type); break;
                    case "GridSorters_Results_DateE": orderBy.Results_DateE(type); break;
                    case "GridSorters_Results_DateF": orderBy.Results_DateF(type); break;
                    case "GridSorters_Results_DateG": orderBy.Results_DateG(type); break;
                    case "GridSorters_Results_DateH": orderBy.Results_DateH(type); break;
                    case "GridSorters_Results_DescriptionA": orderBy.Results_DescriptionA(type); break;
                    case "GridSorters_Results_DescriptionB": orderBy.Results_DescriptionB(type); break;
                    case "GridSorters_Results_DescriptionC": orderBy.Results_DescriptionC(type); break;
                    case "GridSorters_Results_DescriptionD": orderBy.Results_DescriptionD(type); break;
                    case "GridSorters_Results_DescriptionE": orderBy.Results_DescriptionE(type); break;
                    case "GridSorters_Results_DescriptionF": orderBy.Results_DescriptionF(type); break;
                    case "GridSorters_Results_DescriptionG": orderBy.Results_DescriptionG(type); break;
                    case "GridSorters_Results_DescriptionH": orderBy.Results_DescriptionH(type); break;
                    case "GridSorters_Results_Comments": orderBy.Results_Comments(type); break;
                    case "GridSorters_Results_Creator": orderBy.Results_Creator(type); break;
                    case "GridSorters_Results_Updator": orderBy.Results_Updator(type); break;
                    case "GridSorters_Results_CreatedTime": orderBy.Results_CreatedTime(type); break;
                    case "GridSorters_Wikis_SiteId": orderBy.Wikis_SiteId(type); break;
                    case "GridSorters_Wikis_UpdatedTime": orderBy.Wikis_UpdatedTime(type); break;
                    case "GridSorters_Wikis_WikiId": orderBy.Wikis_WikiId(type); break;
                    case "GridSorters_Wikis_Ver": orderBy.Wikis_Ver(type); break;
                    case "GridSorters_Wikis_Title": orderBy.Wikis_Title(type); break;
                    case "GridSorters_Wikis_Body": orderBy.Wikis_Body(type); break;
                    case "GridSorters_Wikis_TitleBody": orderBy.Wikis_TitleBody(type); break;
                    case "GridSorters_Wikis_Comments": orderBy.Wikis_Comments(type); break;
                    case "GridSorters_Wikis_Creator": orderBy.Wikis_Creator(type); break;
                    case "GridSorters_Wikis_Updator": orderBy.Wikis_Updator(type); break;
                    case "GridSorters_Wikis_CreatedTime": orderBy.Wikis_CreatedTime(type); break;
                    default: break;
                }
            });
            return orderBy;
        }
    }
}
