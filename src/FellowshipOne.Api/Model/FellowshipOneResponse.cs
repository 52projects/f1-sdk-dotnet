using System.Net;

namespace FellowshipOne.Api.Model {
    public interface IFellowshipOneResponse {
        string RequestValue { get; set; }
        string JsonResponse { get; set; }
        HttpStatusCode StatusCode { get; set; }
        string ErrorMessage { get; set; }
    }
    public interface IFellowshipOneResponse<T> : IFellowshipOneResponse {
        T Data { get; set; }
    }

    public class FellowshipOneResponse : IFellowshipOneResponse {
        public string RequestValue { get; set; }

        public string JsonResponse { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class FellowshipOneResponse<T> : FellowshipOneResponse, IFellowshipOneResponse<T> where T : new() {
        public T Data { get; set; }
    }
}
