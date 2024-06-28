using AutoMapper;
using ITCenterBO.DTOs.Request.Assignment;
using ITCenterBO.DTOs.Response.Account;
using ITCenterBO.DTOs.Response.Assignment;
using ITCenterBO.Models;
using ITCenterDAO.Helper;
using ITCenterDAO.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO
{
    public class AssignmentDAO
    {
        private readonly ITCenterContext _context = null;
        private readonly IMapper _mapper;
        private static AssignmentDAO instance;
        public static AssignmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssignmentDAO();
                }
                return instance;
            }
        }
        public AssignmentDAO()
        {
            if(_context == null)
            {
                _context = new ITCenterContext();
            }
            if(_mapper == null)
            {
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new AssignmentMapper())).CreateMapper().ConfigurationProvider);
            }
        }

        public async void CreateAssignment(CreateAssignmentRequest request)
        {
            _context.Assignments.Add(_mapper.Map<Assignment>(request));
            await _context.SaveChangesAsync();
        }

        public async Task<UpdateAssignmentResponse> UpdateAssignment(UpdateAssignmentRequest request)
        {
            var getAssigment = await _context.Assignments.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.AssignmentId == request.AssignmentId 
                                && x.CourseId == request.CourseId);
            if(getAssigment != null)
            {
                _context.Assignments.Update(_mapper.Map(request, getAssigment));
                await _context.SaveChangesAsync();
                var updatedAssign = _mapper.Map<UpdateAssignmentResponse>(getAssigment);
                return updatedAssign;
            }
            
            return null;
        }

        public async Task<IList<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId)
        {
            var assignments = await (from a in _context.Assignments.AsNoTracking()
                                               join b in _context.Courses on a.CourseId equals b.CourseId
                                               where a.CourseId == courseId
                                               select new
                                               {
                                                   Assignment = a,
                                                   Courses = b
                                               }
                                               ).ToListAsync();
            var getAssignmentInCourse = _mapper.Map<IList<GetAssignmentResponse>>(assignments.Select(x => x.Assignment));
            foreach(var assignmentResponse in getAssignmentInCourse)
            {
                var matchingCourse = assignments.FirstOrDefault(x => x.Assignment.AssignmentId == assignmentResponse.AssignmentId)?.Courses;
                if(matchingCourse != null)
                {
                    assignmentResponse.CourseName = matchingCourse.CourseName;
                    assignmentResponse.ImageUrl = matchingCourse.ImageUrl;
                }
            }
            return getAssignmentInCourse;
        }

        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId)
        {
            var getAssignmentById = await _context.Assignments.FirstOrDefaultAsync(x => x.AssignmentId == assignmentId);

            if (getAssignmentById != null)
            {
                TimeSpan time = getAssignmentById.EndDate - DateTimeHelper.GetDateTimeNow();
                double deadline = ((time.Days * 24) * time.Hours) / 24;

                var result = new GetAssignmentResponse
                {
                    AssignmentId = getAssignmentById.AssignmentId,
                    AssignmentDuration = getAssignmentById.AssignmentDuration,
                    AssignmentTitle= getAssignmentById.AssignmentTitle,
                    CourseId= getAssignmentById.CourseId,
                    EndDate = getAssignmentById.EndDate,
                    Deadline = deadline,
                    Question = getAssignmentById.Question,
                    StartDate= getAssignmentById.StartDate,
                    Type = getAssignmentById.Type
                    
                };
                return result;
            }
            
                return null;
        }
    }
}
