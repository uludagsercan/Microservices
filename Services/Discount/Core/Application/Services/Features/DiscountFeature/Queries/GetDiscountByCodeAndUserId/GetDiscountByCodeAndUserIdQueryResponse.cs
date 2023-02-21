﻿using Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Application.Services.Features.DiscountFeature.Queries.GetDiscountByCodeAndUserId
{
    public class GetDiscountByCodeAndUserIdQueryResponse
    {
        public ResponseDto<Discount> Response { get; set; }
    }
}
