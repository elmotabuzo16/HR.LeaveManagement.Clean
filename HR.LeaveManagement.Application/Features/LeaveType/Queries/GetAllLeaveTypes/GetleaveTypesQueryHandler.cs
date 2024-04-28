using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetleaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetleaveTypesQueryHandler> _logger;

        public GetleaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetleaveTypesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // Convert the query from above (data objects) to DTO objects
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // return list of DTO objects
            _logger.LogInformation("Leave types were retrieved successfully");
            return data;
        }
    }
}
