using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Post.Queries.GetPostList
{
    public class GetPostListQueryHandler
        : IRequestHandler<GetPostListQuery, GetPostListVm>
    {
        private readonly IProject_UniverseDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPostListQueryHandler(IProject_UniverseDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetPostListVm> Handle(GetPostListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Post
                .ProjectTo<GetPostLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetPostListVm { Post = entityQuery };
        }
    }
}
