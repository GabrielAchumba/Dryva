namespace CustomerSubscription.API.Application.Response {
    public class ErrorModel {

        public ErrorModel(string field, string message) {
            Field = field;
            Message = message;
        }
        
        public string Field { get; }
        
        public string Message { get; }
    }
}