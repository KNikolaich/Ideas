using DevExpress.Web;
using DevExpress.Web.Mvc;
using DXWebApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DXWebApplication1.Model {
    public static class GridViewHelper {
        public static List<Issue> GetIssues() {
            return DataProvider.GetIssues();
        }
        public static List<Contact> GetCustomers() {
            return DataProvider.GetContacts();
        }
        public static GridViewModel GetGridViewModel() {
            return new GridViewModel();
        }
        public static void AddNewRecord(Issue issue) {
            DataProvider.AddNewIssue(issue);
        }

        public static void UpdateRecord(Issue issue) {
            DataProvider.UpdateIssue(issue);
        }

        public static void DeleteRecords(string selectedRowIds) {
            List<long> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => long.Parse(id));
            DataProvider.DeleteIssues(selectedIds);
        }
    }
}