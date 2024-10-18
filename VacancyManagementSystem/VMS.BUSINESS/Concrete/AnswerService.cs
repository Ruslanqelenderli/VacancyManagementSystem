using AutoMapper;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.Question;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.BUSINESS.Concrete
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseValueResponse<AnswerCommonResponse>> CreateAsync(AnswerCreateRequest request)
        {
            if (request.IsCorrect)
            {
                await CheckAndNormalizeIsCorrect(request.QuestionId);
            }
            var answer = mapper.Map<Answer>(request);
            answer.Id = Guid.NewGuid().ToString();
            var result = unitOfWork.Answers.Add(answer);
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<AnswerCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<AnswerCommonResponse>> DeleteAsync(string id)
        {
            var result = unitOfWork.Answers.DeleteSoft(id);
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<AnswerCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<AnswerCommonResponse>> GetByIdAsync(string id)
        {
            var result =  await unitOfWork.Answers.GetByIdAsync(new List<System.Linq.Expressions.Expression<Func<Answer, bool>>>()
            {
                x=>x.Id == id
            });

            return mapper.Map<BaseValueResponse<AnswerCommonResponse>>(result);
        }

        public async Task<BaseListResponse<AnswerCommonResponse>> GetByQuestionIdAsync(string questionId)
        {
            var result = await unitOfWork.Answers.GetAsync(new List<System.Linq.Expressions.Expression<Func<Answer, bool>>>()
            {
                x=>x.QuestionId == questionId
            });

            return mapper.Map<BaseListResponse<AnswerCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<AnswerCommonResponse>> UpdateAsync(AnswerUpdateRequest request)
        {
            if (request.IsCorrect)
            {
                await CheckAndNormalizeIsCorrect(request.QuestionId);
            }
            var result = unitOfWork.Answers.Update(mapper.Map<Answer>(request));
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<AnswerCommonResponse>>(result);
        }

        //Bir question-un içində birdən çox düzgün cavab olmaması üçün nəzərdə tutulub

        private async Task CheckAndNormalizeIsCorrect(string questionId)
        {
            var result = await unitOfWork.Answers.GetAsync(new List<System.Linq.Expressions.Expression<Func<Answer, bool>>>()
            {
                x=>x.QuestionId == questionId && x.IsCorrect
            });

            if (result != null && result.List != null && result.List.Count > 0)
            {
                foreach (var answer in result.List)
                {
                    answer.IsCorrect = false;
                    unitOfWork.Answers.Update(answer);
                }
                await unitOfWork.SaveAsync();
            }
        }
    }
}
