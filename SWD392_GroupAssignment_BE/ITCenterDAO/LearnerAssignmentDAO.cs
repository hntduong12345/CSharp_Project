using AutoMapper;
using ITCenterBO.DTOs.Request.LearnerAssignment;
using ITCenterBO.DTOs.Response.LearnerAssignment;
using ITCenterBO.Models;
using ITCenterDAO.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO
{
    public class LearnerAssignmentDAO
    {
        private readonly ITCenterContext _context = null;
        private readonly IMapper _mapper;
        private static LearnerAssignmentDAO instance;
        public static LearnerAssignmentDAO Instance
        {
            get {
                if(instance == null)
                {
                    instance = new LearnerAssignmentDAO();
                }
                return instance; 
            }
        }

        public LearnerAssignmentDAO()
        {
            if (_context == null)
            {
                _context = new ITCenterContext();
            }
            if (_mapper == null)
            {
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new LearnerAssignmentMapper())).CreateMapper().ConfigurationProvider);
            }
        }

        public async void CreateLearnerAssignment(CreateLearnerAssignmentRequest request)
        {
            _context.LearnerAssignments.Add(_mapper.Map<LearnerAssignment>(request));
            await _context.SaveChangesAsync();
        }

        public async Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(UpdateLearnerAssignmentRequest request)
        {
            var learnerAssign = await _context.LearnerAssignments.AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.AccountId == request.AccountId
                                            && x.AssignmentId == request.AssignmentId
                                            && x.LearnerAssignmentId == request.LearnerAssignmentId);
            if (learnerAssign != null)
            {
                _context.LearnerAssignments.Update(_mapper.Map<LearnerAssignment>(request));
                await _context.SaveChangesAsync();
                var response = _mapper.Map<UpdateLearnerAssignmentResponse>(learnerAssign);
                return response;
            }
            return null;
        }

        public async Task<GetLearnerAssignmentResponse> GetLearnerAssignment(int learnerAssignmentId)
        {
            var learnerAssign = await (from a in _context.LearnerAssignments.AsNoTracking()
                                       join b in _context.Accounts.AsNoTracking()
                                       on a.AccountId equals b.AccountId
                                       join c in _context.Assignments.AsNoTracking()
                                       on a.AssignmentId equals c.AssignmentId 
                                       select new
                                       {
                                           Assignment = c,
                                           Account = b,
                                           LearnerAssignment = a
                                       }).FirstOrDefaultAsync(x => x.LearnerAssignment.LearnerAssignmentId == learnerAssignmentId);
            var mapperLA = _mapper.Map<GetLearnerAssignmentResponse>(learnerAssign.LearnerAssignment);
            if (learnerAssign != null) {
                mapperLA.Email = learnerAssign.Account.Email;
                mapperLA.LastName = learnerAssign.Account.LastName;
                mapperLA.FirstName = learnerAssign.Account.FirstName;
                return mapperLA;
            }
            return null;
        } 
    }
}
