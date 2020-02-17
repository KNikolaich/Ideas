using System;
using System.Threading.Tasks;
using ExamServiceReference;

namespace ExamClient
{
    public class Methods
    {
        ExaminationServiceClient client = new ExaminationServiceClient();

        public async Task<BookMedicalServiceResult> BookingAsync(string idLpu, string idPat, System.Guid idMedicalExamination, System.Guid idMedicalService, System.Guid idMedicalResource, System.Guid idSlot, System.Nullable<System.DateTime> visitStart, System.Guid guid)
        {
            await client.OpenAsync();
            var result = await client.BookMedicalServiceAsync(idLpu, idPat, idMedicalExamination, idMedicalService, idMedicalResource, idSlot, visitStart, guid);
            await client.CloseAsync();
            return result;
        }
        
    }
}
