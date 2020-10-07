namespace Charity.Application.Module.Wrappers
{
    public static class ResponseBuilder
    {
        public static Response<T> Create<T>(T data) => new Response<T>(data);
    }
}