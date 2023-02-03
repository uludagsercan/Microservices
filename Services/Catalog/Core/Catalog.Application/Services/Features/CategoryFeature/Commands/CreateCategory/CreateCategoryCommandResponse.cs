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
        public string Name { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
    }

    public class SuccessCreateCategoryCommadResponse : CreateCategoryCommandResponse
    {


    }

    public class ErrorsCategoryCommandResponse : CreateCategoryCommandResponse
    {

        public List<string> Errors { get; set; }
    }
}
