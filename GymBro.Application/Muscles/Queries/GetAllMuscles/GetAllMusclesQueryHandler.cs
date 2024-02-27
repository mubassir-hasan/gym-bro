using GymBro.Abstractions;
using GymBro.Abstractions.Caching;
using GymBro.Abstractions.Messaging;
using GymBro.Application.Common.Extentions;
using GymBro.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Muscles.Queries.GetAllMuscles
{

    public class GetAllMusclesQueryHandler : IQueryHandler<GetAllMusclesQuery, PaginatedList<MuscleListItemDTO>?>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICacheService _cacheService;

        public GetAllMusclesQueryHandler(IApplicationDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task<Result<PaginatedList<MuscleListItemDTO>?>> Handle(GetAllMusclesQuery request, CancellationToken cancellationToken)
        {
            var response = await _cacheService.GetAsync(CacheKeys.MuscleList, async () =>
            {
                var query = _context.Muscles.AsQueryable();
                if (!string.IsNullOrEmpty(request.Query))
                    query = query.Where(x => x.Title.Value.StartsWith(request.Query));

                var result =await query
                .Select(x=>new MuscleListItemDTO(x.Id,x.Title,x.Image))
                .PaginatedListAsync(request.PageNumber, request.PageSize);
                return result;
            }, cancellationToken);

            return Result.Success(response);
        }
    }
}
