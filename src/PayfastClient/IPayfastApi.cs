using Refit;

namespace PayfastClient
{
    internal interface IPayfastApi
    {
        [Get("/query/{id}")]
        Task<ApiResponse<string>> QueryTransaction([AliasAs("id")] string transactionId);
    }
}
