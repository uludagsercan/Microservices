using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Features.CategoryFeature.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse
    {
        public ResponseDto<Category> Response { get; set; }
    }

 
}
