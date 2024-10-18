using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Question;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.BUSINESS.Concrete
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseValueResponse<QuestionCommonResponse>> CreateAsync(QuestionCreateRequest request)
        {
            var question = mapper.Map<Question>(request);
            question.Id = Guid.NewGuid().ToString();
            var result = unitOfWork.Questions.Add(question);
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<QuestionCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<QuestionCommonResponse>> DeleteAsync(string id)
        {
            var result = unitOfWork.Questions.DeleteSoft(id);
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<QuestionCommonResponse>>(result);
        }

        public async Task<BaseListResponse<QuestionGetByActionIdResponse>> GetByActionIdAsync(string actionId)
        {
            var result = await unitOfWork.ActionAnswers.GetAsync(new List<System.Linq.Expressions.Expression<Func<ActionAnswer, bool>>>()
            {
                x=>x.ActionId == actionId
            },
           true,
           x => x.Include(z => z.Question).ThenInclude(c=>c.Answers)
           );
            var questions = new List<Question>();
            result.List.ForEach(x =>
            {
                questions.Add(x.Question);
            });

            return new BaseListResponse<QuestionGetByActionIdResponse>()
            {
                List = questions.Select(x => new QuestionGetByActionIdResponse(x.Id,x.Description,x.WorkTypeId,x.Answers.Select(c=>new AnswerCommonResponse(c.Id,c.Description,c.IsCorrect)).ToList())).ToList()
            };
        }

        public async Task<BaseValueResponse<QuestionGetByIdResponse>> GetByIdAsync(string id)
        {
            var result = await unitOfWork.Questions.GetByIdAsync(new List<System.Linq.Expressions.Expression<Func<Question, bool>>>()
            {
                x=>x.Id == id
            },
            true,
            x=>x.Include(z=>z.Answers));

            return mapper.Map<BaseValueResponse<QuestionGetByIdResponse>>(result);
        }

        public async Task<BaseListResponse<QuestionCommonResponse>> GetByPagingAsync(PageRequest<object> request)
        {
            var result = await unitOfWork.Questions.GetAsync(null, true, x => x.Include(z => z.WorkType), new PageRequest<Question>()
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage
            },
            null,
            x => x.CreatedDate
            );
            return mapper.Map<BaseListResponse<QuestionCommonResponse>>(result);
        }

        public async Task<BaseListResponse<QuestionCommonResponse>> GetByQuestionBankIdAsync(string questionBankId)
        {
            var result = await unitOfWork.QuestionBankQuestions.GetAsync(new List<System.Linq.Expressions.Expression<Func<QuestionBankQuestion, bool>>>()
            {
                x=>x.QuestionBankId == questionBankId
            },
            true,
            x=>x.Include(z=>z.Question)
            );
            var questions = new List<Question>();
            result.List.ForEach(x =>
            {
                questions.Add(x.Question);
            });

            return mapper.Map<BaseListResponse<QuestionCommonResponse>>(questions);
        }

        public async Task<BaseListResponse<QuestionCommonResponse>> GetByWorkTypeIdAsync(ushort workTypeId)
        {
            var result = await unitOfWork.Questions.GetAsync(new List<System.Linq.Expressions.Expression<Func<Question, bool>>>()
            {
                x=>x.WorkTypeId == workTypeId
            });

            return mapper.Map<BaseListResponse<QuestionCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<QuestionCommonResponse>> UpdateAsync(QuestionUpdateRequest request)
        {
            var result = unitOfWork.Questions.Update(mapper.Map<Question>(request));
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<QuestionCommonResponse>>(result);
        }
    }
}
