using VMS.BUSINESS.Helpers.Models.Response.ActionAnswer;

namespace VMS.BUSINESS.Helpers.Models.Response.Action
{
    public record ActionGetByIdResponse(string FullName,string Email, string PhoneNumber, ushort Point, byte Percent ,string WorkTypeName,string CVPath, List<ActionAnswerActionGetByIdResponse> Questions);
}
