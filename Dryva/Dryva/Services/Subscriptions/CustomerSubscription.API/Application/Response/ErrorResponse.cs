using System.Collections.Generic;

namespace CustomerSubscription.API.Application.Response {
    public class ErrorResponse {
        public List<ErrorModel> Errors { get; } = new List<ErrorModel>();
    }
}