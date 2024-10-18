using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.ActionAnswer;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Concrete
{
    public class ActionAnswerService : IActionAnswerService
    {
        private readonly IUnitOfWork unitOfWork;
        public ActionAnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseValueResponse<bool>> ToAnswer(ActionAnswerToAnswerRequest request)
        {
            var actionAnswer = await unitOfWork.ActionAnswers.GetByIdAsync(new List<System.Linq.Expressions.Expression<Func<ENTITY.Entities.Application.ActionAnswer, bool>>>()
            {
                x=>x.ActionId == request.ActionId && x.QuestionId == request.QuestionId
            },
            false);
            actionAnswer.Value.AnswerId = request.AnswerId;
            unitOfWork.ActionAnswers.Update(actionAnswer.Value);
            await unitOfWork.SaveAsync();
            return new BaseValueResponse<bool>(true);
        }
    }
}
