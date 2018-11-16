
using System;
using System.ComponentModel;
using DevExpress.Web;

namespace DoctorDashboard.Models {
    public class AllInfo : HospitalDep {
        
        // в приемном
        public string InReceptionCase { get; set; }
        // на стационаре
        public string InDep { get; set; }


        [Description("Свободно")]
        public string Free { get; set; }

        // в стационаре
        public string Include { get; set; }
        
        #region Реанимация

        public string IsRegistred { get; set; }
        public string FreeBeds { get; set; }

        #endregion

        #region Поликлиника

        public string ScheduledVisits { get; set; }
        public string IssuedCoupons { get; set; }
        public string ConfirmedPatientsCame { get; set; }


        #endregion


        #region Операционные

        public string OperatingIsBusy { get; set; }
        public string SurgeryConducted { get; set; }

        #endregion

        #region ДМС
        // Сумма выставленных счетов 
        public decimal? DmsInvoicedAmount { get; set; }
        // Сумма оплаченных счетов 
        public decimal? DmsAmountOfPaidInvoices { get; set; }
        // Сумма отказанных счетов 
        public decimal? DmsAmountOfdeniedInvoices { get; set; }


        #endregion

        #region ОМС
        // Сумма выставленных счетов 
        public decimal? OmsInvoicedAmount { get; set; }
        // Сумма оплаченных счетов 
        public decimal? OmsAmountOfPaidInvoices { get; set; }
        // Сумма отказанных счетов 
        public decimal? OmsAmountOfdeniedInvoices { get; set; }


        #endregion
    }
}
