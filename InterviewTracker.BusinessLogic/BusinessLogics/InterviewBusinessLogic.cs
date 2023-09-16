﻿using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.BusinessLogic.Interfaces;
using InterviewTracker.DataAccess;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLogic
{
    public class InterviewBusinessLogic : IInterviewBusinessLogic
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly ILoggerBusinessLogic _loggerBusinessLogic;

        public InterviewBusinessLogic(IInterviewRepository interviewRepository, ILoggerBusinessLogic loggerBusinessLogic) {
            _interviewRepository = interviewRepository;
            _loggerBusinessLogic = loggerBusinessLogic;
        }

        public async Task<List<InterviewDto>> GetInterviews(int companyId) {
            try
            {
                return await _interviewRepository.GetInterviews(0, companyId);
            }
            catch (Exception e)
            {
                _loggerBusinessLogic.LogError(e.Message);
                throw new Exception("Unable to get interviews.");
            }
        }

        public async Task<InterviewDto> SaveInterview(InterviewDto interview)
        {
            try
            {
                return await _interviewRepository.SaveInterview(0, interview);
            }
            catch (Exception e)
            {
                _loggerBusinessLogic.LogError(e.Message);
                throw new Exception("Unable to save interview.");
            }
        }
    }
}
