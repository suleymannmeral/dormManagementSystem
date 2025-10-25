using System.Net;

namespace YurtYonetimSistemi.Application;

public class ServiceResult<T>
{
    public T? Data { get; set; } // başarılı ise data döner

    public List<string>? ErrorMessage { get; set; } // başarısız ise hata mesajları döner

    public bool IsSuccess=> ErrorMessage == null || ErrorMessage.Count == 0;

    public bool IsFail=> !IsSuccess;

    public HttpStatusCode StatusCode { get; set; }

    // static factory methodlar
    public static ServiceResult<T> Success(T data,HttpStatusCode statusCode=HttpStatusCode.OK) // başarılı sonuç
    {
        return new ServiceResult<T>()
        {
            Data = data,
            StatusCode = statusCode
        };
    }

    public static ServiceResult<T> Fail(List<string> errorMessages, HttpStatusCode statusCode=HttpStatusCode.BadRequest)  // çoklu hata mesajı
    {
        return new ServiceResult<T>()
        {
            ErrorMessage = errorMessages,
            StatusCode = statusCode
        };
    }

    public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)  // tek hata mesajı
    {
        return new ServiceResult<T>()
        {
            ErrorMessage = new List<string>() { errorMessage },
            StatusCode = statusCode
        };
    }




}
