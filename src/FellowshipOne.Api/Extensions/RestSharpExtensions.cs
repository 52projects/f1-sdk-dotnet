using FellowshipOne.Api.Model;
using RestSharp;

namespace FellowshipOne.Api.Extensions {
    public static class RestSharpExtensions {
        public static IFellowshipOneResponse ToFellowshipOneResponse(this IRestResponse restResponse) {
            var response = new FellowshipOneResponse();

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if (restResponse.StatusCode != System.Net.HttpStatusCode.OK) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }

            return response;
        }

        public static IFellowshipOneResponse<S> ToFellowshipOneResponse<S>(this IRestResponse<S> restResponse) where S : new() {
            var response = new FellowshipOneResponse<S>();

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if ((int)restResponse.StatusCode >= 300) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }
            else {
                response.Data = restResponse.Data;
            }
            return response;
        }

        public static IFellowshipOneResponse<S> ToFellowshipOneResponse<S>(this IRestResponse<S> restResponse, string requestInput) where S : new() {
            var response = restResponse.ToFellowshipOneResponse();
            response.RequestValue = requestInput;
            return response;
        }
    }
}
