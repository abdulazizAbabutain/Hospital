using Application.Common.Model;

namespace Web.Common.Extenstions
{
    public static class HTTPExtenstions
    {
        public static HttpResponse AddPagantionHeaders(this HttpResponse response, MetaData metaData)
        {
            response.Headers["x-Pagnation-TotalCount"] = metaData.TotalCount.ToString();
            response.Headers["x-Pagnation-TotalPages"] = metaData.TotalPages.ToString();
            response.Headers["x-Pagnation-HasNextPage"] = metaData.HasNextPage.ToString();
            response.Headers["x-Pagnation-HasPreviousPage"] = metaData.HasPreviousPage.ToString();
            response.Headers["x-Pagnation-PageNumber"] = metaData.PageNumber.ToString();
            return response; 
        }
    }
}
