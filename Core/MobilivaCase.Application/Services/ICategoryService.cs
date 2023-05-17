﻿using MobilivaCase.Application.DTOs.Category;
using MobilivaCase.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryDto model);
       
    }
}
