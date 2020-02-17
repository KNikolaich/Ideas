using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using DevExpress.Web;

namespace DXWebApplication.Models
{


    public class GridViewEditingDemosHelper
    {

        const string EditingModeSessionKey = "AA054892-1B4C-4158-96F7-894E1545C05C";

        public static GridViewEditingMode EditMode
        {
            get
            {
                if (Session[EditingModeSessionKey] == null)
                    Session[EditingModeSessionKey] = GridViewEditingMode.EditFormAndDisplayRow;
                return (GridViewEditingMode)Session[EditingModeSessionKey];
            }
            set { HttpContext.Current.Session[EditingModeSessionKey] = value; }
        }

        static List<GridViewEditingMode> availableEditModesList;
        public static List<GridViewEditingMode> AvailableEditModesList
        {
            get
            {
                if (availableEditModesList == null)
                    availableEditModesList = new List<GridViewEditingMode> {
                        GridViewEditingMode.Inline,
                        GridViewEditingMode.EditForm,
                        GridViewEditingMode.EditFormAndDisplayRow,
                        GridViewEditingMode.PopupEditForm
                    };
                return availableEditModesList;
            }
        }

        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}