using System.Collections.Generic;
/*
   * Author Name            :  Debabrata Meher 
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  General
   * Modified By            : 
   * Description            :  This class have the Enums and General Related Code.
*/
namespace Revalsys.Common
{
    public class GeneralDebabrata
    {
        #region ErrorCode
        public enum ErrorCode
        {
            Success=0,
            Insert_Successfully = 1,
            Update_Successfully = 2,
            Deleted_Sucessfully=3,
            Technical_Error_occured = 8,
            Invalid_FromDate = 111,
            Invalid_Todate = 121,
            Invalid_SearchWord = 4,
            Invalid_PageNumber = 5,
            Invalid_PageSize = 6,
            No_Records_Found = 7,
            Invalid_Sort_Expression = 8,
            Invalid_Sort_Direction = 9,
            Invalid_EmployeeId=10,
            Invalid_FirstName = 11,
            Invalid_LastName = 12,
            Invalid_Age=13,
            Invalid_department=14,
            Invalid_Position=15,
            Inserttion_intrupted=16,
            Invalid_Request=17,
            EmployeeIdLength_InBetween_10=18,
            Employee_Id_Null_Or_Empty = 19,
            Serialization_Error=20,
            Search_Name_Length_InBetween_50 = 21,
            Employee_Code_Can_Not_Be_Null = 22,
            Invalid_Employee_Code = 23,
            Employee_Code_Length_InBetween_16=24,
            First_Name_Can_Not_Be_Null=25,
            Email_Can_Not_Be_Null = 26,
            Employee_Code_Incrrect=27,
            Error_Code = -1,
            First_Name_Length_InBetween_32 = 28,
            Email_Length_InBetween_64 = 29,
            Age_Range_InBetween_100 = 30,
            Department_Length_InBetween_32 = 31,
            Position_Length_InBetween_32 = 32,
            Age_Can_Not_Be_Null=33,
            Department_Can_Not_Be_Null = 34,
            Position_Can_Not_Be_Null = 35,
            Update_intrupted=36,
            SQL_Error = 37,
            Invalid_Operation=38,
            Null_Reference=39,
            Request_TimeOut=40,
            Unauthorized_Access=41,
            Invalid_Format=42,
            Null_Reference_Error=43,
            Overflow_Error=44,
            Invalid_Format_Error=45,
            Invalid_Error_Code=46,
            Page_Size_Range_InBetween_100 = 47,
            Page_Number_Range_InBetween_100 = 48,
            PageNumber_Can_Not_Be_Null = 49,
            PageSize_Can_Not_Be_Null = 50,
            Search_Word_Length_InBetween_32 = 51,
            Invalid_Email=52,
            Mobile_Length_Should_be_10 = 53,
            Invalid_Mobile=54,
            Invalid_Country_Code=55,
            Invalid_State_Code=56,
            Country_Code_Length_InBetween_16 = 57,
            State_Code_Length_InBetween_16 = 58,
            Country_Code_Incorrect=59,
            State_Code_Incorrect=60,
            Country_Code_Can_Not_Be_Null = 61,
            State_Code_Can_Not_Be_Null = 62,
            Given_State_Is_Not_Inside_The_Country=63,
            Email_Already_Exist=64,
        }
        #endregion

        #region CommonResponseErrorCodes
        public enum CommonResponseErrorCodes
        {
            //http status codes
            Success = 200,
            RequestTimeOut = 408,
            BadRequest = 400,
            UnAuthorized = 401,
            Forbidden = 403,
            NotAcceptable = 406,
            InvalidRequest = -101,
            No_Records_Found = 22,
            Inserttion_intrupted=202,
            InvalidOperationError=404
        }

        public static Dictionary<string, string> dictCommonResponse
        {
            get
            {
                Dictionary<string, string> dictCommonResponse = new Dictionary<string, string>();
                dictCommonResponse.Add(CommonResponseErrorCodes.Success.ToString(), "Success");
                dictCommonResponse.Add(CommonResponseErrorCodes.RequestTimeOut.ToString(), "Request Time Out");
                dictCommonResponse.Add(CommonResponseErrorCodes.BadRequest.ToString(), "Bad Request");
                dictCommonResponse.Add(CommonResponseErrorCodes.UnAuthorized.ToString(), "UnAuthorized");
                dictCommonResponse.Add(CommonResponseErrorCodes.Forbidden.ToString(), "Forbidden");
                dictCommonResponse.Add(CommonResponseErrorCodes.NotAcceptable.ToString(), "Not Acceptable");
                dictCommonResponse.Add(CommonResponseErrorCodes.InvalidRequest.ToString(), "Invalid Request");
                dictCommonResponse.Add(CommonResponseErrorCodes.InvalidOperationError.ToString(), "Invalid Operation Error");
                dictCommonResponse.Add(CommonResponseErrorCodes.No_Records_Found.ToString(), "No Records Found");
                dictCommonResponse.Add(CommonResponseErrorCodes.Inserttion_intrupted.ToString(), "Inserttion Intrupted");

                return dictCommonResponse;
            }
        }
        #endregion
    }
}
