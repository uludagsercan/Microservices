using Catalog.Domain.Entities;
using FreeCourse.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Repositories.CategoryRepositories
{
    public interface ICategoryWriteRepository:IWriteRepository<Category>
    {
    }
}
