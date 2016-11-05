using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreWebAPI.Models.Interfaces;
using AspnetCoreWebAPI.Models.Response;
using AspnetCoreWebAPI.Models.ViewModels;
using AspnetCoreWebAPI.Models.Response.Interfaces;
using AspnetCoreWebAPI.Extensions;

namespace AspnetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private IProductRepository ProductRepository;

        public ProductController(IProductRepository repository)
        {
            ProductRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? pageSize = 10, int? pageNumber = 1, string name = null)
        {
            var response = new ListModelResponse<ProductViewModel>() as IListModelResponse<ProductViewModel>;

            try
            {
                response.PageSize = (int)pageSize;
                response.PageNumber = (int)pageNumber;

                response.Model = await Task.Run(() =>
                {
                    var data = ProductRepository
                        .GetProducts(response.PageSize, response.PageNumber, name).ToList();
                    return ProductRepository
                        .GetProducts(response.PageSize, response.PageNumber, name)
                        .Select(item => item.ToViewModel())
                        .ToList();
                });

                response.Message = string.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return ProductRepository.GetProduct(id).ToViewModel();
                });
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductViewModel value)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return ProductRepository.AddProduct(value.ToEntity());
                });

                response.Model = entity.ToViewModel();
                response.Message = "The data was saved successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        // PUT Production/Product/5
        [HttpPut]
        [Route("Product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]ProductViewModel value)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return ProductRepository.UpdateProduct(id, value.ToEntity());
                });

                response.Model = entity.ToViewModel();
                response.Message = "The record was updated successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // DELETE Production/Product/5
        [HttpDelete]
        [Route("Product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = new SingleModelResponse<ProductViewModel>() as ISingleModelResponse<ProductViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return ProductRepository.DeleteProduct(id);
                });

                response.Model = entity.ToViewModel();
                response.Message = "The record was deleted successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
