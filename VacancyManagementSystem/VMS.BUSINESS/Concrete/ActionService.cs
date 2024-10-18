using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Action;
using VMS.BUSINESS.Helpers.Models.Response.Action;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;
using Action = VMS.ENTITY.Entities.Application.Action;

namespace VMS.BUSINESS.Concrete
{
    public class ActionService : IActionService
    {
        private readonly IUnitOfWork unitOfWork;
        public ActionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseValueResponse<bool>> Complete(ActionCompleteRequest request)
        {
            var action = await unitOfWork.Actions.GetByIdAsync(new List<Expression<Func<ENTITY.Entities.Application.Action, bool>>>()
            {
                x=>x.Id == request.ActionId
            },false,
            x=>x.Include(z=>z.ActionAnswers).ThenInclude(c=>c.Question).ThenInclude(v=>v.Answers));

            ushort point = CalculatePoint(action.Value);

            action.Value.UpdatedDate = DateTime.Now;
            action.Value.CVPath = request.CvPath;
            action.Value.Point = point;
            action.Value.Percent = Convert.ToByte(point * 100 / action.Value.ActionAnswers.Count());
            unitOfWork.Actions.Update(action.Value);
            await unitOfWork.SaveAsync();
            return new BaseValueResponse<bool>(true);
        }

        public async Task<BaseValueResponse<ActionGetByIdResponse>> GetByIdAsync(string id)
        {
            var result = await unitOfWork.Actions.GetByIdAsync(new List<System.Linq.Expressions.Expression<Func<Action, bool>>>()
            {
                x=>x.Id == id
            },true,
            x=>x.Include(c=>c.ApplicationInfo).Include(v=>v.ActionAnswers).ThenInclude(b=>b.Question).ThenInclude(t=>t.Answers).Include(v => v.ActionAnswers).ThenInclude(b => b.Answer).Include(n=>n.QuestionBank).ThenInclude(i=>i.Vacancy).ThenInclude(p=>p.WorkType));
            var action = result.Value;
            
            return new BaseValueResponse<ActionGetByIdResponse>(new ActionGetByIdResponse(action.ApplicationInfo.Name + " " + action.ApplicationInfo.Surname,action.ApplicationInfo.Email,action.ApplicationInfo.PhoneNumber,action.Point,action.Percent,action.QuestionBank.Vacancy.WorkType.Name,action.CVPath, action.ActionAnswers.Select(d => new Helpers.Models.Response.ActionAnswer.ActionAnswerActionGetByIdResponse(d.Answer != null ? d.Answer.Description : "", d.Question.Answers.FirstOrDefault(y => y.IsCorrect).Description, d.Question.Description)).ToList()));
        }

        public async Task<BaseListResponse<ActionPagingResponse>> GetByPagingAsync(PageRequest<object> request)
        {
            var result = await unitOfWork.Actions.GetAsync(null, true, x => x.Include(z => z.ApplicationInfo).Include(z=>z.QuestionBank).ThenInclude(c=>c.Vacancy).ThenInclude(v=>v.WorkType), new PageRequest<Action>()
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage
            },
            null,
             x => x.CreatedDate
             );
            return new BaseListResponse<ActionPagingResponse>()
            {
                List = result.List.Select(x=>new ActionPagingResponse( x.Id,x.ApplicationInfo.Name + " " + x.ApplicationInfo.Surname, x.QuestionBank.Vacancy.WorkType.Name,x.Percent)).ToList(),
                TotalCount = result.TotalCount,
            };
        }

        private ushort CalculatePoint(ENTITY.Entities.Application.Action action)
        {
            ushort point = 0;
            if(action != null && action.ActionAnswers.Count>0) 
            {
                foreach(var answer in action.ActionAnswers)
                {
                    if(answer.AnswerId !=null && answer.AnswerId == answer.Question.Answers.FirstOrDefault(x => x.IsCorrect).Id)
                    {
                        point++;
                    }
                }
            }
            return point;  
        }
    }
}
