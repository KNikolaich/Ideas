using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DXWebApplication1.KostaN3Exam;

namespace DXWebApplication1.Models.Examination
{
    public class PlanRequest
    {
        [Display(Name = "ЛПУ")]
        public string IdLpu => "17";

        [Display(Name = "Пациент №")]
        public int IdPat { set; get; }
        [Display(Name = "Диспансеризация")]
        public string Servid { set; get; }

        [Display(Name = "token")] public Guid Guid => Guid.NewGuid();

        [Display(Name = "Диспансеризация")]
        public static GetMedicalExaminationPlanResult Response { private set; get; }


        public void CalcRequest()
        {
            if (Response == null)
            {
                ExaminationServiceClient client = new ExaminationServiceClient();
                Response = client.GetMedicalExaminationPlan(IdLpu, IdPat.ToString(), new Guid(Servid), Guid);

            }

        }

        public static string GetMedicalServiceStatus(object value)
        {
            MedicalServiceStatusEnum enumValue = (MedicalServiceStatusEnum)int.Parse(value.ToString());
            switch (enumValue)
            {
                case MedicalServiceStatusEnum.Available:
                    return "Доступна";
                case MedicalServiceStatusEnum.Passed:
                    return "Оказана";
                case MedicalServiceStatusEnum.Planned:
                    return "Запланирована";
                case MedicalServiceStatusEnum.Unavailable:
                    return "Недоступна";
                default:
                    return "неопределенное состояниe";
            }

        }

        public static string GetMedicalServiceBookingStatus(object value)
        {
            MedicalServiceBookingStatusEnum enumValue = (MedicalServiceBookingStatusEnum)int.Parse(value.ToString());
            switch (enumValue)
            {
                case MedicalServiceBookingStatusEnum.CencelledFromPacient:
                    return "Запись отменена по инициативе пациента";
                case MedicalServiceBookingStatusEnum.Passed:
                    return "посещение состоялось (услуга оказана)";
                case MedicalServiceBookingStatusEnum.Planned:
                    return "запись оформлена";
                case MedicalServiceBookingStatusEnum.CencelledFromMo:
                    return "Запись отменена по инициативе МО";
                case MedicalServiceBookingStatusEnum.DidNotCome:
                    return "Пациент не явился";
                default:
                    return "не определено";
            }

        }
    }

    /// <summary>
    /// Статус медицинского осмотра 1.2.643.2.69.1.1.1.109
    /// </summary>
    public enum MedicalServiceStatusEnum
    {
        /// <summary> "неопределенное состояниe" </summary>
        NotDefine = 0,
        /// <summary> "Запланирована" </summary>
        Planned = 1,
        /// <summary> "Оказана" </summary>
        Passed = 2,
        /// <summary> "Доступна" </summary>
        Available = 3,
        /// <summary> "недоступна" </summary>
        Unavailable = 4,
    }

    /// <summary>
    /// Статус медицинского осмотра 1.2.643.2.69.1.1.1.114
    /// </summary>
    public enum MedicalServiceBookingStatusEnum
    {
        /// <summary> "не определено" </summary>
        NotDefine = 0,
        /// <summary> "запись оформлена" </summary>
        Planned = 1,
        /// <summary> "посещение состоялось (услуга оказана)" </summary>
        Passed = 2,
        /// <summary> "	Запись отменена по инициативе МО" </summary>
        CencelledFromMo = 3,
        /// <summary> "Запись отменена по инициативе пациента" </summary>
        CencelledFromPacient = 4,
        /// <summary> "Пациент не явился" </summary>
        DidNotCome = 5,
    }

}