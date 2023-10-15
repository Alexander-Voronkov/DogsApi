using Microsoft.AspNetCore.Mvc;

namespace WebApi.Modules.Dogs
{
    public class DogsQueryRequest
    {
        [FromQuery]
        public int? PageSize { get; set; } = 10;
        [FromQuery]
        public int? PageNumber { get; set; } = 1;
        [FromQuery]
        public int? Limit { get; set; } = 1000;
        [FromQuery]
        public string? Order { get; set; } = "asc";
        [FromQuery]
        public string? SortAttribute { get; set; } = "name";
    }
}
