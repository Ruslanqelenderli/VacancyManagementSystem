using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.ApplicationInfo;
using VMS.BUSINESS.Helpers.Models.Request.Question;
using VMS.BUSINESS.Helpers.Models.Request.Vacancy;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.BUSINESS.Helpers.Models.Response.Action;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;
using Action = VMS.ENTITY.Entities.Application.Action;

namespace VMS.BUSINESS.Helpers.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<WorkType, WorkTypeUpdateRequest>().ReverseMap();
            CreateMap<WorkType, WorkTypeCreateRequest>().ReverseMap();
            CreateMap<WorkType, WorkTypeCommonResponse>().ReverseMap();

            CreateMap<BaseValueResponse<WorkType>, BaseValueResponse<WorkTypeUpdateRequest>>().ReverseMap();
            CreateMap<BaseValueResponse<WorkType>, BaseValueResponse<WorkTypeCreateRequest>>().ReverseMap();
            CreateMap<BaseValueResponse<WorkType>, BaseValueResponse<WorkTypeCommonResponse>>().ReverseMap();
            CreateMap<BaseListResponse<WorkType>, BaseListResponse<WorkTypeCommonResponse>>().ReverseMap();

            CreateMap<Answer, AnswerUpdateRequest>().ReverseMap();
            CreateMap<Answer, AnswerCreateRequest>().ReverseMap();
            CreateMap<Answer, AnswerCommonResponse>().ReverseMap();

            CreateMap<BaseValueResponse<Answer>, BaseValueResponse<AnswerUpdateRequest>>().ReverseMap();
            CreateMap<BaseValueResponse<Answer>, BaseValueResponse<AnswerCreateRequest>>().ReverseMap();
            CreateMap<BaseValueResponse<Answer>, BaseValueResponse<AnswerCommonResponse>>().ReverseMap();
            CreateMap<BaseListResponse<Answer>, BaseListResponse<AnswerCommonResponse>>().ReverseMap();

            CreateMap<Question, QuestionUpdateRequest>().ReverseMap();
            CreateMap<Question, QuestionCreateRequest>().ReverseMap();
            CreateMap<Question, QuestionCommonResponse>().ReverseMap();
            CreateMap<Question, QuestionGetByIdResponse>().ReverseMap();
            CreateMap<Question, QuestionGetByActionIdResponse>().ReverseMap();

            CreateMap<BaseValueResponse<Question>, BaseValueResponse<QuestionUpdateRequest>>().ReverseMap();
            CreateMap<BaseValueResponse<Question>, BaseValueResponse<QuestionCreateRequest>>().ReverseMap();
            CreateMap<BaseValueResponse<Question>, BaseValueResponse<QuestionGetByIdResponse>>().ReverseMap();
            CreateMap<BaseValueResponse<Question>, BaseValueResponse<QuestionGetByActionIdResponse>>().ReverseMap();
            CreateMap<BaseValueResponse<Question>, BaseValueResponse<QuestionCommonResponse>>().ReverseMap();
            CreateMap<BaseListResponse<Question>, BaseListResponse<QuestionCommonResponse>>().ReverseMap();
            CreateMap<BaseListResponse<Question>, BaseListResponse<QuestionGetByActionIdResponse>>().ReverseMap();

            CreateMap<ApplicationInfo, ApplicationInfoCreateRequest>().ReverseMap();

            CreateMap<Action, ActionApplyResponse>().ReverseMap();

            CreateMap<Vacancy, VacancyCreateRequest>().ReverseMap();
            CreateMap<Vacancy, VacancyUpdateRequest>().ReverseMap();
            CreateMap<Vacancy, VacancyCommonResponse>().ReverseMap();

            CreateMap<BaseValueResponse<Vacancy>, BaseValueResponse<VacancyCommonResponse>>().ReverseMap();
            CreateMap<BaseListResponse<Vacancy>, BaseListResponse<VacancyCommonResponse>>().ReverseMap();

            CreateMap<BaseValueResponse<Action>,BaseValueResponse<ActionApplyResponse>>().ReverseMap();





        }
    }
}
