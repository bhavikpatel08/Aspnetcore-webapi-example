﻿using AspnetCoreWebAPI.Models;
using AspnetCoreWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWebAPI.Extensions
{
    public static class ProductViewModelMapper
    {
        public static ProductViewModel ToViewModel(this Product entity)
        {
            return entity == null ? null : new ProductViewModel
            {
                ProductID = entity.ProductID,
                ProductName = entity.Name,
                ProductNumber = entity.ProductNumber
            };
        }

        public static Product ToEntity(this ProductViewModel viewModel)
        {
            return viewModel == null ? null : new Product
            {
                Name = viewModel.ProductName,
                ProductNumber = viewModel.ProductNumber
            };
        }
    }
}
