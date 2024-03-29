﻿using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }

        //static factory method
        public static ResponseDto<T> Success(T data,int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode,IsSuccessful=true };
        }
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> {Data=default(T) ,StatusCode = statusCode, IsSuccessful = true };
        }

        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new() { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new() { Errors = new() { error}, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
