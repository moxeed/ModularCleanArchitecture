using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectTypes
{
    public class GetProjectTypesHandler : IRequestHandler<GetProjectTypesRequest,Response<IEnumerable<ProjectTypeDto>>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public GetProjectTypesHandler(IProjectRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<IEnumerable<ProjectTypeDto>>> Handle(GetProjectTypesRequest request, CancellationToken cancellationToken)
        {
            var types = await _repository.GetProjectTypeViewAsync();
            return ResponseBuilder.Create(types.Select(t => _mapper.Map<ProjectTypeDto>(t)));
        }
    }
}