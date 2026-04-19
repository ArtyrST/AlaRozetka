using AlaBackEnd.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.Services
{
    public class TagServise
    {
        private readonly TagRepository _tag;
        public TagServise(TagRepository tag)
        {
            _tag = tag;
        }
        public async Task<ServiceResponse> GelAllAsync()
        {
            var entity = await _tag.tags.AsNoTracking().ToListAsync();
            return ServiceResponse.Success("Successfuly returned all tags!", entity);
        }
    }
}
