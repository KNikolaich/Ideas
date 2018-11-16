
using System;
using System.ComponentModel;
using DevExpress.Web;

namespace DoctorDashboard.Models {
    public class AllInfo : HospitalDep {
        
        // � ��������
        public string InReceptionCase { get; set; }
        // �� ����������
        public string InDep { get; set; }


        [Description("��������")]
        public string Free { get; set; }

        // � ����������
        public string Include { get; set; }
        
        #region ����������

        public string IsRegistred { get; set; }
        public string FreeBeds { get; set; }

        #endregion

        #region �����������

        public string ScheduledVisits { get; set; }
        public string IssuedCoupons { get; set; }
        public string ConfirmedPatientsCame { get; set; }


        #endregion


        #region ������������

        public string OperatingIsBusy { get; set; }
        public string SurgeryConducted { get; set; }

        #endregion

        #region ���
        // ����� ������������ ������ 
        public decimal? DmsInvoicedAmount { get; set; }
        // ����� ���������� ������ 
        public decimal? DmsAmountOfPaidInvoices { get; set; }
        // ����� ���������� ������ 
        public decimal? DmsAmountOfdeniedInvoices { get; set; }


        #endregion

        #region ���
        // ����� ������������ ������ 
        public decimal? OmsInvoicedAmount { get; set; }
        // ����� ���������� ������ 
        public decimal? OmsAmountOfPaidInvoices { get; set; }
        // ����� ���������� ������ 
        public decimal? OmsAmountOfdeniedInvoices { get; set; }


        #endregion
    }
}
