using AspnetCoreWebAPI.Models.Response.Interfaces;
using System;

namespace AspnetCoreWebAPI.Models.Response
{
    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
