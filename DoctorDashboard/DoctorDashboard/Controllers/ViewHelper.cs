using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using DevExpress.Web.Mvc.UI;
using DoctorDashboard.Models;

namespace DoctorDashboard.Controllers
{
    public static class ViewHelper
    {
        #region Стационар

        /// <summary>
        /// Блок сводка по стационару
        /// </summary>
        /// <param name="settings"></param>
        public static void GetStationarGroup(FormLayoutSettings<AllInfo> settings, HtmlHelper<AllInfo> html, ViewContext viewContext)
        {
            settings.SettingsAdaptivity.AdaptivityMode = FormLayoutAdaptivityMode.SingleColumnWindowLimit;
            settings.SettingsAdaptivity.SwitchToSingleColumnAtWindowInnerWidth = 200;
            var groupItem = settings.Items.AddGroupItem(groupSettingsStat =>
            {
                groupSettingsStat.Caption = "Стационар";
                groupSettingsStat.ShowCaption = DefaultBoolean.True;
                groupSettingsStat.GroupBoxDecoration = GroupBoxDecoration.HeadingLine;
                groupSettingsStat.Width = Unit.Percentage(100);
                //groupSettingsStat.ColSpan = 2;
                groupSettingsStat.ColCount = 8;
                //groupSettingsStat.CssClass = "formLayout";
            });

            groupItem.SettingsItems.ShowCaption = DefaultBoolean.False;
            groupItem.SettingsItemCaptions.Location = LayoutItemCaptionLocation.Top;

            //groupItem.SettingsItemHelpTexts.Position = HelpTextPosition.Auto;

            groupItem.Items.Add(m => m.Date, item =>
            {
                item.ColSpan = 1;
                item.RowSpan = 1;
                item.HelpText = "Актуально на ";
                item.HelpTextSettings.Position = HelpTextPosition.Top;

                item.Width = Unit.Pixel(100);
                item.NestedExtension().Label(l => { });
            });

            GetSubGroupSetting(groupItem, html, viewContext);



            //GetSubGroupSetting(groupItem);

        }

        private static void GetSubGroupSetting(MVCxFormLayoutGroup<AllInfo> subGroup, HtmlHelper<AllInfo> html, ViewContext viewContext)
        {
            
            var inboxingGroup = subGroup.Items.AddGroupItem(igs =>
            {
                igs.Caption = "В стационаре";
                igs.ShowCaption = DefaultBoolean.False;
                igs.GroupBoxDecoration = GroupBoxDecoration.None;
                //igs.SettingsItems.Width = System.Web.UI.WebControls.Unit.Pixel(170);
                igs.SettingsItems.ShowCaption = DefaultBoolean.False;
                //igs.ColCount = 2;
                igs.RowSpan = 3;
                igs.CssClass = "formLayout_group_small";
                
            });
            subGroup.Items.Add(m => m.Include,
                    i =>
                    {
                        i.HelpText = "в стационаре";
                        i.NestedExtension().Label(l => { });
                    });
            subGroup.Items.Add(m => m.Received,
                i =>
                {
                    i.HelpText = "Поступило с начала смены";
                    i.NestedExtension().Label(l => { });
                });


            var inboxingSubGroup = subGroup.Items.AddGroupItem(inbSubGr =>
            {
                inbSubGr.ShowCaption = DefaultBoolean.False;
                inbSubGr.GroupBoxDecoration = GroupBoxDecoration.None;
                inbSubGr.SettingsItems.ShowCaption = DefaultBoolean.False;

                inbSubGr.SettingsItems.Width = Unit.Pixel(170);
                //inbSubGr.ColCount = 2;
                inbSubGr.CssClass = "formLayout_group_small";
            });


            subGroup.Items.Add(m => m.InReceptionCase, item =>
            {
                item.HelpText = "в приемном";
                item.NestedExtension().Label(l => { });
            });
            subGroup.Items.Add(m => m.Free,
                i =>
                {
                    i.HelpText = "Свободных мест";
                    i.NestedExtension().Label(l => { });
                });
            subGroup.Items.Add(
                i => {
                    i.ShowCaption = DefaultBoolean.False;
                    //i.Width = Unit.Pixel(100);
                    i.HorizontalAlign = FormLayoutHorizontalAlign.Right;
                }).SetNestedContent(() => {
                    viewContext.Writer.Write("<table><tr><td style=\"padding-right:10px;\">");

                    //html.DevExpress().Button(s => {
                    //    s.Name = "Submit";
                    //    s.Width = Unit.Pixel(100);
                    //    s.Text = "Submit";
                    //    s.UseSubmitBehavior = true;
                    //}).Render();

                    //viewContext.Writer.Write("</td><td>");

                    html.DevExpress().HyperLink(s => {
                        s.Name = "hlByDepartments";
                        s.Properties.Text = "подробности...";
                        s.NavigateUrl = "..\\Home\\ByDepartments";
                    }).Render();

                    viewContext.Writer.Write("</td></tr></table>");
                }); 

            var groupItem = subGroup.Items.AddGroupItem(groupSettings =>
            {
                groupSettings.Caption = "Ушло";
                groupSettings.ShowCaption = DefaultBoolean.False;
                groupSettings.GroupBoxDecoration = GroupBoxDecoration.Box;
                groupSettings.SettingsItemHelpTexts.Position = HelpTextPosition.Right;
                groupSettings.SettingsItems.HorizontalAlign = FormLayoutHorizontalAlign.Right;
                groupSettings.SettingsItems.ShowCaption = DefaultBoolean.True;
                //groupSettings.SettingsItems.Width = System.Web.UI.WebControls.Unit.Pixel(170);
                groupSettings.ColSpan = 3;
                groupSettings.RowSpan = 3;
                groupSettings.CssClass = "formLayout_group_small";
            });
            groupItem.Items.Add(m => m.Discharged, item =>
            {
                item.Caption = "Выписано";
                item.NestedExtension().Label(l => { });
            });
            groupItem.Items.Add(m => m.Transferred, item =>
            {
                item.Caption = "Переведено в другие стационары";
                item.NestedExtension().Label(l => { });
            });
            groupItem.Items.Add(m => m.Death, item =>
            {
                item.Caption = "Умерло";
                item.NestedExtension().Label(l => { });
            });


        }

        #endregion

        #region Реанимация поликлиника операционная и деньги

        public static void GetReanimationGroup(MVCxFormLayoutGroup<AllInfo> settings)
        {
            var groupItemReanim = settings.Items.AddGroupItem(groupSettings =>
            {
                groupSettings.Caption = "Реанимация";
                groupSettings.ShowCaption = DefaultBoolean.True;
                groupSettings.GroupBoxDecoration = GroupBoxDecoration.HeadingLine;
                groupSettings.SettingsItemCaptions.Location = LayoutItemCaptionLocation.Left;
                groupSettings.ColCount = 1;
                groupSettings.ColSpan = 1;
                groupSettings.CssClass = "formLayout";
                groupSettings.SettingsItems.ShowCaption = DefaultBoolean.False;
                //groupSettings.SettingsItems.Width = Unit.Percentage(50);
            });
            groupItemReanim.Items.Add(m => m.IsRegistred,
               i =>
               {
                   i.HelpText = "Состоит";
                   i.NestedExtension().Label(l => { });
               });
            groupItemReanim.Items.Add(m => m.FreeBeds,
                i =>
                {
                    i.HelpText = "Свободных коек";
                    i.NestedExtension().Label(l => { });
                });
        }

        public static void GetAmbulanceGroup(MVCxFormLayoutGroup<AllInfo> settings)
        {
            var groupItemAmb = settings.Items.AddGroupItem(groupSettings =>
            {
                groupSettings.Caption = "Поликлиника";
                groupSettings.ShowCaption = DefaultBoolean.True;
                groupSettings.GroupBoxDecoration = GroupBoxDecoration.HeadingLine;
                groupSettings.SettingsItemCaptions.Location = LayoutItemCaptionLocation.Left;
                groupSettings.SettingsItems.ShowCaption = DefaultBoolean.False;
                //groupSettings.SettingsItems.Width = Unit.Pixel(170);
                groupSettings.CssClass = "formLayout";
                groupSettings.ColSpan = 2;
                groupSettings.ColCount = 3;
                groupSettings.Width = Unit.Percentage(50);
            });
            groupItemAmb.Items.Add(m => m.ScheduledVisits,
               i =>
               {
                   i.HelpText = "Запланировано посещений";
                   i.NestedExtension().Label(l => { });
               });
            groupItemAmb.Items.Add(m => m.IssuedCoupons,
                i =>
                {
                    i.HelpText = "Выдано талонов";
                    i.NestedExtension().Label(l => { });
                });
            groupItemAmb.Items.Add(m => m.ConfirmedPatientsCame,
                i =>
                {
                    i.HelpText = "Пришло пациентов";
                    i.NestedExtension().Label(l => { });
                });
            //throw new NotImplementedException();
        }

        public static void GetSurgeryesGroup(MVCxFormLayoutGroup<AllInfo> settings)
        {
            var groupItemSurgery = settings.Items.AddGroupItem(groupSettings =>
            {
                groupSettings.Caption = "Операционные";
                groupSettings.ShowCaption = DefaultBoolean.True;
                groupSettings.GroupBoxDecoration = GroupBoxDecoration.HeadingLine;
                groupSettings.SettingsItemCaptions.Location = LayoutItemCaptionLocation.Left;
                groupSettings.SettingsItems.ShowCaption = DefaultBoolean.False;
                groupSettings.ColCount = 1;
                groupSettings.ColSpan = 1;
                groupSettings.CssClass = "formLayout";

                //groupSettings.SettingsItems.Width = Unit.Percentage(50);
            });
            groupItemSurgery.Items.Add(m => m.SurgeryConducted,
               i =>
               {
                   i.HelpText = "Операции - проведено";
                   i.NestedExtension().Label(l => { });
               });
            groupItemSurgery.Items.Add(m => m.OperatingIsBusy,
                i =>
                {
                    i.HelpText = "Операционные - занято";
                    i.NestedExtension().Label(l => { });
                });
            //throw new NotImplementedException();
        }

        #endregion


        public static void GetMonyesGroup(FormLayoutSettings<AllInfo> settings, HtmlHelper<AllInfo> html, ViewContext viewContext)
        {
            var groupItemMony = settings.Items.AddGroupItem(groupSettingsMony =>
            {
                groupSettingsMony.Caption = "Деньги";
                groupSettingsMony.ShowCaption = DefaultBoolean.True;
                groupSettingsMony.GroupBoxDecoration = GroupBoxDecoration.HeadingLine;
                groupSettingsMony.SettingsItemCaptions.Location = LayoutItemCaptionLocation.Left;

                groupSettingsMony.SettingsItems.Width = Unit.Percentage(100);

                //groupSettingsMony.SettingsItems.Width = Unit.Percentage(50);
                groupSettingsMony.CssClass = "formLayout";
            });

            groupItemMony.Items.Add(i => {
                i.ShowCaption = DefaultBoolean.False;
                i.Width = Unit.Pixel(100);
                i.HorizontalAlign = FormLayoutHorizontalAlign.Right;
            }).SetNestedContent(() => {
                viewContext.Writer.Write("<table><tr><td style=\"padding-right:10px;\">");

                //html.DevExpress().Button(s => {
                //    s.Name = "Submit";
                //    s.Width = Unit.Pixel(100);
                //    s.Text = "Submit";
                //    s.UseSubmitBehavior = true;
                //}).Render();

                //viewContext.Writer.Write("</td><td>");

                html.DevExpress().HyperLink(s => {
                    s.Name = "KassaGraph";
                    s.Properties.Text = "касса за месяц";
                    s.NavigateUrl = "..\\Home\\KassaGraph";
                }).Render();

                viewContext.Writer.Write("</td></tr></table>");
            });

            AddDmsGroup(groupItemMony);



            AddOmsGroup(groupItemMony);
            //throw new NotImplementedException();
        }

        private static void AddOmsGroup(MVCxFormLayoutGroup<AllInfo> groupItemMony)
        {
            var omsGroup = groupItemMony.Items.AddGroupItem(igs =>
            {
                igs.Caption = "ОМС";
                igs.ShowCaption = DefaultBoolean.True;
                igs.GroupBoxDecoration = GroupBoxDecoration.Box;
                //igs.SettingsItems.Width = System.Web.UI.WebControls.Unit.Pixel(170);
                igs.SettingsItems.ShowCaption = DefaultBoolean.False;
                igs.ColCount = 2;

                igs.SettingsItems.Width = Unit.Pixel(170);
                igs.RowSpan = 3;
                igs.CssClass = "formLayout_group_small";
            });

            omsGroup.Items.Add(m => m.OmsInvoicedAmount,
               i =>
               {
                   i.HelpText = "Сумма выставленных счетов с начала месяца";
                   i.NestedExtension().Label(l => { });
               });
            omsGroup.Items.Add(m => m.OmsAmountOfPaidInvoices,
                i =>
                {
                    i.HelpText = "Сумма оплаченных счетов с начала месяца";
                    i.NestedExtension().Label(l => { });
                });
            omsGroup.Items.Add(m => m.OmsAmountOfdeniedInvoices,
                i =>
                {
                    i.HelpText = "Сумма отказанных счетов с начала месяца";
                    i.NestedExtension().Label(l => { });
                });
        }

        private static void AddDmsGroup(MVCxFormLayoutGroup<AllInfo> groupItemMony)
        {
            var dmsGroup = groupItemMony.Items.AddGroupItem(igs =>
            {
                igs.Caption = "ДМС";
                igs.ShowCaption = DefaultBoolean.True;
                igs.GroupBoxDecoration = GroupBoxDecoration.Box;
                //igs.SettingsItems.Width = System.Web.UI.WebControls.Unit.Pixel(170);
                igs.SettingsItems.ShowCaption = DefaultBoolean.False;
                igs.ColCount = 2;

                igs.SettingsItems.Width = Unit.Pixel(170);
                igs.RowSpan = 3;
            });

            dmsGroup.Items.Add(m => m.DmsInvoicedAmount,
               i =>
               {
                   i.HelpText = "Сумма выставленных счетов с начала месяца";
                   i.NestedExtension().Label(l => { });
               });
            dmsGroup.Items.Add(m => m.DmsAmountOfPaidInvoices,
                i =>
                {
                    i.HelpText = "Сумма оплаченных счетов с начала месяца";
                    i.NestedExtension().Label(l => { });
                });
            dmsGroup.Items.Add(m => m.DmsAmountOfdeniedInvoices,
                i =>
                {
                    i.HelpText = "Сумма отказанных счетов с начала месяца";
                    i.NestedExtension().Label(l => { });
                });
        }
    }
}