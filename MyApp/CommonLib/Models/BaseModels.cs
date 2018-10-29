using CommonLib.Library;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static CommonLib.CustomAttributes;

namespace CommonLib.Core
{
    // <copyright file="BaseModels.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>28/10/2018 08:20:00 AM </date>
    // <summary>Class representing base response and base request which all models can inherit</summary>

    public class BaseResponse
    {
        public bool HasError
        {
            get
            {
                if (Errors == null)
                    return false;
                if (Errors.Count == 0)
                    return false;
                else
                    return true;
            }
        }
        public List<ErrorResponse> Errors { get; set; }
        public void SetError(ErrorResponse error)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();

            if (error.HasError)
                Errors.Add(error);
        }
        public void SetError(ErrorCodes errorCode)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();
            ErrorResponse error = new ErrorResponse();
            error.SetError(errorCode);
            Errors.Add(error);
        }

        public void SetError(string ErrorMessage)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();
            ErrorResponse error = new ErrorResponse(ErrorMessage);
            Errors.Add(error);
        }

        public void SetError(List<ErrorResponse> errors)
        {
            Errors = errors;
        }

        public string GetErrorMessage()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HasError)
            {
                foreach (ErrorResponse error in Errors)
                {
                    errorMessage.AppendLine(error.ErrorMessage);
                }
            }
            return errorMessage.ToString();
        }
    }

    public class ErrorResponse
    {
        public ErrorCodes ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorResponse()
        {
            NoError();
        }

        public ErrorResponse(ErrorCodes errorCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorCode.GetDisplayName();
        }

        public ErrorResponse(ErrorCodes errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public ErrorResponse(string errorMessage)
        {
            ErrorCode = ErrorCodes.ValidationError;
            ErrorMessage = errorMessage;
        }

        public void NoError()
        {
            ErrorCode = ErrorCodes.NoError;
            ErrorMessage = string.Empty;
        }

        public static ErrorResponse GetNoError()
        {
            return new ErrorResponse(ErrorCodes.NoError, string.Empty);
        }

        public void SetError(ErrorCodes ErrorCode)
        {
            this.ErrorCode = ErrorCode;
            ErrorMessage = ErrorCode.GetDisplayName();
        }

        public void SetError(ErrorResponse err)
        {
            this.ErrorCode = err.ErrorCode;
            this.ErrorMessage = err.ErrorMessage;
        }

        public static ErrorResponse ForError(ErrorCodes ErrorCode)
        {
            return new ErrorResponse(ErrorCode);
        }

        public bool HasError
        {
            get
            {
                if (ErrorCode == ErrorCodes.NoError)
                    return false;
                else
                    return true;
            }
        }
    }

    public class SimpleResponse : BaseResponse
    {
        public object Result { get; set; }
    }

    public class ListResponse : BaseResponse
    {
        public object Result { get; set; }

        public ListResponse()
        {
        }

        public ListResponse(int TotalRecords, int CurrentPage, object Result)
        {
            this.Result = Result;
        }
    }

    public class ListRequest
    {
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int PageNumber { get; set; } = 1;
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int PageSize { get; set; } = 20;
        [SQLParam(Usage = SQLParamPlaces.None)]
        public string OrderBy { get; set; }
        
        public void AddInParameter(SqlCommand dbCommand, string parameterName, object value)
        {
            object finalVal = value;

            if (value == null)
                finalVal = DBNull.Value;
            else
            {
                if (value.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        finalVal = DBNull.Value;
                    }
                }
            }
            dbCommand.Parameters.AddWithValue(parameterName, finalVal);
        }

        public void GenerateSQLParams(SqlCommand cmd)
        {
            AddInParameter(cmd, "@PageNo", PageNumber);
            AddInParameter(cmd, "@PageSize", PageSize);
            AddInParameter(cmd, "@OrderBy", OrderBy);
        }

        public void GenerateSQLParams(DynamicParameters param)
        {
            param.Add("PageNo", PageNumber);
            param.Add("PageSize", PageSize);
            param.Add("OrderBy", OrderBy);
        }
    }
}
