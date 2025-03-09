using System;

namespace Core.Http
{
  public class HttpException : Exception
  {
    public int StatusCode { get; private set; }

    public HttpException (int statusCode, string message) : base(message)
    {
      StatusCode = statusCode;
    }
  }
}
