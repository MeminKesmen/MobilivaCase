﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.DTOs.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
