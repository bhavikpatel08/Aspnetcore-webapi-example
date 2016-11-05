using AspnetCoreWebAPI.Models.Response.Interfaces;
using System;
using System.Collections.Generic;

namespace AspnetCoreWebAPI.Models.Response
{
    public class ListModelResponse<TModel> : IListModelResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
