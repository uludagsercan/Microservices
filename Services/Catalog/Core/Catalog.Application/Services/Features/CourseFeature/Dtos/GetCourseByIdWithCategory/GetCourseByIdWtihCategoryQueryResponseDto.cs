using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Features.CourseFeature.Dtos.GetCourseByIdWithCategory
{
    public class GetCourseByIdWtihCategoryQueryResponseDto
    {
        public string Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public Feature Feature { get; set; }
        public Category Category { get; set; }
    }
}
