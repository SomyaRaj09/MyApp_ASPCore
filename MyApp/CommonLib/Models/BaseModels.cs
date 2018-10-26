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
        //public int TotalRecords { get; set; }
        //public int CurrentPage { get; set; }
        public object Result { get; set; }

        public ListResponse()
        {
        }

        public ListResponse(int TotalRecords, int CurrentPage, object Result)
        {
            //this.TotalRecords = TotalRecords;
            //this.CurrentPage = CurrentPage;
            this.Result = Result;
        }

        //public void SetPagingOutput(SqlCommand cmd)
        //{
        //    object obj = cmd.Parameters["@TotalRecords"].Value;
        //    if (obj == null || obj == DBNull.Value)
        //    {
        //        TotalRecords = 0;
        //        return;
        //    }

        //    TotalRecords = Convert.ToInt32(obj);
        //}

        //public void SetPagingOutput(DynamicParameters param)
        //{
        //    TotalRecords = param.Get<int>("TotalRecords");
        //}
    }

    public class ListRequest
    {
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int PageNumber { get; set; } = 1;
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int PageSize { get; set; } = 20;
        [SQLParam(Usage = SQLParamPlaces.None)]
        public string OrderBy { get; set; }
        [SQLParam(Usage = SQLParamPlaces.None)]
        public int Skip
        {
            get
            {
                return (PageNumber - 1) * PageSize;
            }
        }

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

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@TotalRecords";
            param.Direction = ParameterDirection.Output;
            param.Size = -1;
            cmd.Parameters.Add(param);
        }

        public void GenerateSQLParams(DynamicParameters param)
        {
            param.Add("PageNo", PageNumber);
            param.Add("PageSize", PageSize);
            param.Add("OrderBy", OrderBy);

            param.Add("TotalRecords", null, DbType.Int32, ParameterDirection.Output, -1);
        }
    }
}
