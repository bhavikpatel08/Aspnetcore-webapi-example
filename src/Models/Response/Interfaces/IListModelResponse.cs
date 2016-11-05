using System;
using System.Collections.Generic;

namespace AspnetCoreWebAPI.Models.Response.Interfaces
{
    public interface IListModelResponse<TModel> : IResponse
    {
        int PageSize { get; set; }

        int PageNumber { get; set; }

        IEnumerable<TModel> Model { get; set; }
    }
}
