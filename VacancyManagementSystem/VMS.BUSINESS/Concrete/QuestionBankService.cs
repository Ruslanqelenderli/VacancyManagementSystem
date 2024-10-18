using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.QuestionBank;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.BUSINESS.Concrete
{
    public class QuestionBankService : IQuestionBankService
    {
        private readonly IUnitOfWork unitOfWork;
        public QuestionBankService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseValueResponse<bool>> Assign(QuestionBankAssignRequest request)
        {
            unitOfWork.QuestionBankQuestions.Add(new QuestionBankQuestion(request.QuestionId, request.QuestionBankId));
            await unitOfWork.SaveAsync();
            return new BaseValueResponse<bool>(true);
        }

        public async Task<BaseValueResponse<bool>> DeleteAssignment(string id)
        {
            unitOfWork.QuestionBankQuestions.DeleteHard(id);
            await unitOfWork.SaveAsync();
            return new BaseValueResponse<bool>(true);
        }
    }
}
