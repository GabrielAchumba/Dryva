using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CustomerApp.Services
{
    public class Envelope<T>
    {
        public EnvelopeData<T> ReportSuccess(T data)
        {
            return new EnvelopeData<T>(ResponseStatus.success.ToString(), (int)HttpStatusCode.OK, "success", true, data);
        }

        public EnvelopeData<T> ReportNotFound()
        {
            return new EnvelopeData<T>(ResponseStatus.notfound.ToString(), (int)HttpStatusCode.NotFound, "notfound", true, default(T));
        }
        public virtual EnvelopeData<T> ReportError(string message)
        {
            return new EnvelopeData<T>(ResponseStatus.error.ToString(), (int)HttpStatusCode.InternalServerError, message, false, default(T));
        }
    }

    public class Envelope : Envelope<bool>
    {
        public static EnvelopeData ReportSuccess()
        {
            return new EnvelopeData(ResponseStatus.success.ToString(), (int)HttpStatusCode.OK, "success", true);
        }

        public static new EnvelopeData ReportError(string message)
        {
            return new EnvelopeData(ResponseStatus.error.ToString(), (int)HttpStatusCode.InternalServerError, message, false);
        }

        public static EnvelopeData ReportInvalidLength()
        {
            return new EnvelopeData(ResponseStatus.invalidlength.ToString(), (int)HttpStatusCode.LengthRequired, "invalidlength", true);
        }
    }

    public class EnvelopeData
    {
        public string Status { get; }
        public int Code { get; }
        public string Message { get; }
        public bool IsSuccess { get; }

        public EnvelopeData(string status, int code, string message, bool isSuccess)
        {
            Status = status;
            Code = code;
            Message = message;
            IsSuccess = isSuccess;
        }

    }
    public class EnvelopeData<T> : EnvelopeData
    {
        public T Data { get; }

        public EnvelopeData(string status, int code, string message, bool isSuccess, T data) :
            base(ResponseStatus.success.ToString(), (int)HttpStatusCode.OK, "success", isSuccess)
        {
            Data = data;
        }
    }
    public enum ResponseStatus
    {
        success,
        fail,
        error,
        notfound,
        invalidlength
    }
}
