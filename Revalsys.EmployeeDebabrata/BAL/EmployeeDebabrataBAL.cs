using Newtonsoft.Json;
using Revalsys.Common;
using Revalsys.Common.RevalProperties;
using Revalsys.EmployeeDebabrata.DAL;
using Revalsys.EmployeeDebabrata.RevalProperties;
using Revalsys.EmployeeDebabrata.RevalProperties.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  BAL
   * Modified By            : 
   * Description            :  This class have the Employee Module Business Logic Code.
*/
namespace Revalsys.EmployeeDebabrata.BAL
{
    public class EmployeeDebabrataBAL
    {
        #region Constructor
        private ConfigurationSettingsListDebabrataDTO objConfigurationSettingsListDTO { get; set; }
        public EmployeeDebabrataBAL(ConfigurationSettingsListDebabrataDTO _objConfigurationSettingsListDTO)
        {
            if (objConfigurationSettingsListDTO == null)
            {
                objConfigurationSettingsListDTO = _objConfigurationSettingsListDTO;
            }
        }
        #endregion

        #region GetEmployeeDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   BAL 
        // Method Name                  :   GetEmployeeDebabrataByCode
        // Method Description           :   This method is used to get the Employee Details based on EmployeeCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   19 April 2024
        // Input Parameters             :   objEmployeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0               Debabrata Meher            19 April 2024                  Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetEmployeeDebabrataByCode</c> This method is used to get the Employee Details based on EmployeeCode parameters.
        /// <param>objEmployeeDebabrataListDTO</param>
        /// <returns>DataTable</returns> //It returns the Date Table.
        /// </summary> 
        /// 
        public ResponseDebabrata<object> GetEmployeeDebabrataByCode(RequestDebabrata objAPIRequest)
        {

            #region Common Variables
            string strResponse = string.Empty;
            int ErrorCode = 0;
            DateTime startResponseTime = DateTime.Now;
            #endregion

            #region Specific Variables
            ResponseDebabrata<object> objDebabrataResponse = null;
            EmployeeDebabrataListDTO objEmployeeDebabrataListDTO = null;
            EmployeeDebabrataDAL objDebabrataEmployeeDAL = null;
            DataTable dtEmployeeDetails = null;
            string strEmployeeCode = string.Empty;
            RegularExpressionDebabrata objRegularExpressionDebabrata = null;
            #endregion

            try
            {
                objRegularExpressionDebabrata = new RegularExpressionDebabrata();

                #region Request data Validations
                #region  EmployeeCode Validation
                if (ErrorCode == 0)
                {

                    if (objAPIRequest.EmployeeCode != null && !String.IsNullOrWhiteSpace(objAPIRequest.EmployeeCode))
                    {
                        if (Regex.IsMatch(objAPIRequest.EmployeeCode.Trim(), objRegularExpressionDebabrata.RegExCode))
                        {
                            if (Regex.IsMatch(objAPIRequest.EmployeeCode.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForCode))
                            {
                                strEmployeeCode = objAPIRequest.EmployeeCode;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Length_InBetween_16);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Employee_Code);
                        }
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Can_Not_Be_Null);
                    }
                }
                #endregion
                #endregion


                #region Calling DAL
                if (ErrorCode == 0)
                {
                    objEmployeeDebabrataListDTO = new EmployeeDebabrataListDTO();
                    objEmployeeDebabrataListDTO.EmployeeCode = strEmployeeCode;
                }

                if (objEmployeeDebabrataListDTO != null)
                {
                    try
                    {
                        objDebabrataEmployeeDAL = new EmployeeDebabrataDAL(objConfigurationSettingsListDTO);
                        dtEmployeeDetails = objDebabrataEmployeeDAL.GetEmployeeDebabrataByCode(objEmployeeDebabrataListDTO);

                        if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                        {
                            strResponse = JsonConvert.SerializeObject(dtEmployeeDetails, Formatting.Indented);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Incrrect);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is JsonException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Serialization_Error);
                        }
                        else if (ex is SqlException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.SQL_Error);
                        }
                        else if (ex is NullReferenceException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference);
                        }
                        else if (ex is UnauthorizedAccessException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Unauthorized_Access);
                        }
                        else if (ex is TimeoutException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Request_TimeOut);
                        }
                        else if (ex is InvalidOperationException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Operation);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Request);
                        }
                    }
                    finally
                    {
                        objEmployeeDebabrataListDTO = null;
                        objConfigurationSettingsListDTO = null;
                    }
                }

            }
            #endregion
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format);
                }
                else if (ex is NullReferenceException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference_Error);
                }
                else if (ex is OverflowException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Overflow_Error);
                }
                else
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                }
            }

            finally
            {
                objDebabrataEmployeeDAL = null;

                try
                {
                    if (ErrorCode > 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = ErrorCode;
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), ErrorCode).Replace('_', ' ');
                        objDebabrataResponse.Data = null;
                    }
                    else if (ErrorCode == 0 && dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Success);
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), Convert.ToInt32(GeneralDebabrata.ErrorCode.Success)).Replace('_', ' ');
                        objDebabrataResponse.RecordCount = dtEmployeeDetails.Rows.Count;
                        objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                        var json = JsonConvert.DeserializeObject<dynamic>(strResponse);
                        objDebabrataResponse.Data = json;
                    }

                    objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format_Error);
                    }
                    else if (ex is ArgumentException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Error_Code);
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                    }
                }
                finally
                {
                    #region Nullifying Objects
                    #endregion
                }
            }

            return objDebabrataResponse;

        }
        #endregion

        #region SaveEmployeeDebabrata
        //***************************************************************************************************
        // Layer                        :   BAL 
        // Method Name                  :   SaveEmployeeDebabrata
        // Method Description           :   This method is used to Save Employee.
        // Author                       :   Debabrata Meher
        // Creation Date                :   19 April 2024
        // Input Parameters             :   objEmployeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0               Debabrata Meher            19 April 2024                  Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>SaveEmployeeDebabrata</c> This method is used to Save Employee.
        /// <param>objEmployeeDebabrataListDTO</param>
        /// <returns>DataTable</returns> //It returns the Date Table.
        /// </summary> 
        /// 
        public ResponseDebabrata<object> SaveEmployeeDebabrata(RequestDebabrata objAPIRequest)
        {

            #region Common Variables
            string strResponse = string.Empty;
            int ErrorCode = 0;
            DateTime startResponseTime = DateTime.Now;
            #endregion

            #region Specific Variables
            ResponseDebabrata<object> objDebabrataResponse = null;
            EmployeeDebabrataListDTO objEmployeeDebabrataListDTO = null;
            CountryDebabrataListDTO objCountryDebabrataListDTO = null;
            StateDebabrataListDTO objstateDebabrataListDTO = null;
            EmployeeDebabrataDAL objDebabrataEmployeeDAL = null;
            int intEmployeeId = 0;
            string strFirstName = string.Empty;
            string strEmail = string.Empty;
            string strMobile = string.Empty;
            int intCountryId = 0;
            int intStateId = 0;
            string strCountryCode= string.Empty;
            string strStateCode = string.Empty;
            string strEmployeeCode=string.Empty;
            RegularExpressionDebabrata objRegularExpressionDebabrata = null;
            #endregion

            try
            {
                objRegularExpressionDebabrata = new RegularExpressionDebabrata();
                #region Request data Validations
                #region  FirstName Validation
                if (ErrorCode == 0)
                {
                    if (objAPIRequest.FirstName != null && !String.IsNullOrWhiteSpace(objAPIRequest.FirstName))
                    {
                        if (Regex.IsMatch(objAPIRequest.FirstName.Trim(), objRegularExpressionDebabrata.RegExForName))
                        {
                            if (Regex.IsMatch(objAPIRequest.FirstName.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForFirstName))
                            {
                                strFirstName = objAPIRequest.FirstName;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.First_Name_Length_InBetween_32);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_FirstName);
                        }
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.First_Name_Can_Not_Be_Null);
                    }

                }
                #endregion

                #region  Email Validation
                if (ErrorCode == 0)
                {
                    if (objAPIRequest.Email != null && !String.IsNullOrWhiteSpace(objAPIRequest.Email))
                    {
                        if (Regex.IsMatch(objAPIRequest.Email.Trim(), objRegularExpressionDebabrata.RegExForEmail))
                        {
                            if (Regex.IsMatch(objAPIRequest.Email.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForEmail))
                            {
                                strEmail = objAPIRequest.Email;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Email_Length_InBetween_64);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Email);
                        }
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Email_Can_Not_Be_Null);
                    }
                }
                #endregion

                #region  Mobile Validation
                if (ErrorCode == 0)
                {
                    if (objAPIRequest.Mobile != null && !String.IsNullOrWhiteSpace(objAPIRequest.Mobile))
                    {
                        if (Regex.IsMatch(objAPIRequest.Mobile.Trim(), objRegularExpressionDebabrata.RegExForMobile))
                        {
                            if (Regex.IsMatch(objAPIRequest.Mobile.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForMobile))
                            {
                                strMobile = objAPIRequest.Mobile;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Mobile_Length_Should_be_10);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Mobile);
                        }
                    }
                    

                }
                #endregion

                #region  CountryCode Validation
                if (ErrorCode == 0)
                {
                    if (objAPIRequest.Country != null && !String.IsNullOrWhiteSpace(objAPIRequest.Country))
                    {
                        if (Regex.IsMatch(objAPIRequest.Country.Trim(), objRegularExpressionDebabrata.RegExCode))
                        {
                            if (Regex.IsMatch(objAPIRequest.Country.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForCode))
                            {
                                strCountryCode = objAPIRequest.Country;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Country_Code_Length_InBetween_16);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Country_Code);
                        }
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Country_Code_Can_Not_Be_Null);
                    }
                    
                }
                #endregion

                #region  StateCode Validation
                if (ErrorCode == 0)
                {
                    if (objAPIRequest.State != null && !String.IsNullOrWhiteSpace(objAPIRequest.State))
                    {
                        if (Regex.IsMatch(objAPIRequest.State.Trim(), objRegularExpressionDebabrata.RegExCode))
                        {
                            if (Regex.IsMatch(objAPIRequest.State.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForCode))
                            {
                                strStateCode = objAPIRequest.State;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.State_Code_Length_InBetween_16);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_State_Code);
                        }
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.State_Code_Can_Not_Be_Null);
                    }

                }
                #endregion

                #region  EmployeeCode Validation
                if (ErrorCode == 0)
                {
                    if (objAPIRequest.EmployeeCode != null && !String.IsNullOrWhiteSpace(objAPIRequest.EmployeeCode))
                    {
                        if (Regex.IsMatch(objAPIRequest.EmployeeCode.Trim(), objRegularExpressionDebabrata.RegExCode))
                        {
                            if (Regex.IsMatch(objAPIRequest.EmployeeCode.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForCode))
                            {
                                strEmployeeCode = objAPIRequest.EmployeeCode;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Length_InBetween_16);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Employee_Code);
                        }
                    }
                }
                #endregion
                #endregion

                #region Master Validation
                #region Master Country Validation
                if (ErrorCode == 0)
                {
                    objCountryDebabrataListDTO = new CountryDebabrataListDTO();
                    objCountryDebabrataListDTO.CountryCode = strCountryCode;
                }
                if (objCountryDebabrataListDTO != null)
                {

                    try
                    {
                        objDebabrataEmployeeDAL = new EmployeeDebabrataDAL(objConfigurationSettingsListDTO);
                        intCountryId = objDebabrataEmployeeDAL.GetCountryIdDebabrataByCode(objCountryDebabrataListDTO);
                        if (intCountryId <= 0)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Country_Code_Incorrect);
                        }
                    }
                    catch (Exception ex)
                    {
                        {
                            if (ex is SqlException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.SQL_Error);
                            }
                            else if (ex is NullReferenceException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference);
                            }
                            else if (ex is UnauthorizedAccessException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Unauthorized_Access);
                            }
                            else if (ex is TimeoutException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Request_TimeOut);
                            }
                            else if (ex is InvalidOperationException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Operation);
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Request);
                            }
                        }
                    }
                    finally
                    {
                        objCountryDebabrataListDTO = null;
                    }

                }
                #endregion

                #region Master State Validation
                if (ErrorCode == 0)
                {
                    objstateDebabrataListDTO = new StateDebabrataListDTO()
                    {
                        StateCode = strStateCode,
                        CountryId = intCountryId
                    };
                }
                if (objstateDebabrataListDTO != null)
                {
                    try
                    {
                        objDebabrataEmployeeDAL = new EmployeeDebabrataDAL(objConfigurationSettingsListDTO);
                        intStateId = objDebabrataEmployeeDAL.GetStateIdDebabrataByCode(objstateDebabrataListDTO);
                        if (intStateId == 0)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Given_State_Is_Not_Inside_The_Country);
                        }
                    }
                    catch (Exception ex)
                    {
                        {
                            if (ex is SqlException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.SQL_Error);
                            }
                            else if (ex is NullReferenceException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference);
                            }
                            else if (ex is UnauthorizedAccessException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Unauthorized_Access);
                            }
                            else if (ex is TimeoutException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Request_TimeOut);
                            }
                            else if (ex is InvalidOperationException)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Operation);
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Request);
                            }
                        }
                    }
                    finally
                    {
                        objstateDebabrataListDTO = null;
                    }
                }
                #endregion
                #endregion

                #region Calling DAL
                if (ErrorCode == 0)
                {
                    objEmployeeDebabrataListDTO = new EmployeeDebabrataListDTO()
                    {
                        FirstName = strFirstName,
                        Email= strEmail,
                        Mobile=strMobile,
                        CountryId=  intCountryId,
                        StateId= intStateId,
                        EmployeeCode= strEmployeeCode
                    };
                }

                if (objEmployeeDebabrataListDTO != null)
                {
                    try
                    {
                        objDebabrataEmployeeDAL = new EmployeeDebabrataDAL(objConfigurationSettingsListDTO);
                        
                        if (objEmployeeDebabrataListDTO.EmployeeCode != string.Empty)
                        {
                            intEmployeeId = objDebabrataEmployeeDAL.UpdateEmployeeDebabrataBycode(objEmployeeDebabrataListDTO);
                            if (intEmployeeId == 0)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Incrrect);
                            }
                            else if (intEmployeeId == -1)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Email_Already_Exist);
                            }

                        }
                        else
                        {
                            objEmployeeDebabrataListDTO.EmployeeCode = Guid.NewGuid().ToString("N").Substring(0, 16);
                            intEmployeeId = objDebabrataEmployeeDAL.InsertEmployeeDebabrata(objEmployeeDebabrataListDTO);
                            if (intEmployeeId == 0)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Inserttion_intrupted);
                            }
                            else if (intEmployeeId == -1)
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Email_Already_Exist);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if(ex is SqlException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.SQL_Error);
                        }
                        else if (ex is NullReferenceException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference);
                        }
                        else if (ex is UnauthorizedAccessException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Unauthorized_Access);
                        }
                        else if (ex is TimeoutException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Request_TimeOut);
                        }
                        else if (ex is InvalidOperationException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Operation);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Request);
                        }
                    }
                    finally
                    {
                        objEmployeeDebabrataListDTO = null;
                        objConfigurationSettingsListDTO = null;
                    }
                }

            }
            #endregion
            catch (Exception ex)
            {
                if(ex is FormatException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format);
                }
                else if (ex is NullReferenceException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference_Error);
                }
                else if (ex is OverflowException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Overflow_Error);
                }
                else
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                }
            }
            finally
            {
                objDebabrataEmployeeDAL = null;

                try
                {
                    if (ErrorCode > 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = ErrorCode;
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), ErrorCode).Replace('_', ' ');
                        objDebabrataResponse.Data = null;
                    }
                    else if (ErrorCode == 0 && intEmployeeId == 1)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Success);
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), Convert.ToInt32(GeneralDebabrata.ErrorCode.Update_Successfully)).Replace('_', ' ');
                        objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                        objDebabrataResponse.Data = null;
                    }

                    else if (ErrorCode == 0 && intEmployeeId >= 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();

                        objDebabrataResponse.ReturnCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Success);
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), Convert.ToInt32(GeneralDebabrata.ErrorCode.Insert_Successfully)).Replace('_', ' ');
                        objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                        //objDebabrataResponse.Data = strEmployeeCode;
                        objDebabrataResponse.Data = null;
                    }

                    objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                }
                catch (Exception ex)
                {
                    if(ex is FormatException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format_Error);
                    }
                    else if(ex is ArgumentException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Error_Code);
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                    }
                }
                finally
                {
                    #region Nullifying Objects
                    objRegularExpressionDebabrata = null;
                    #endregion
                }
            }

            return objDebabrataResponse;

        }
        #endregion

        #region GetEmployeeDebabrataBySearch
        //***************************************************************************************************
        // Layer                        :   BAL 
        // Method Name                  :   GetEmployeeDebabrataBySearch
        // Method Description           :   This method is used to get the Employee Details based on SearchWord.
        // Author                       :   Debabrata Meher
        // Creation Date                :   18 April 2024
        // Input Parameters             :   objEmployeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0               Debabrata Meher            18 April 2024                  Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetEmployeeDebabrataBySearch</c> This method is used to get the Employee Details based on SearchWord.
        /// <param>objEmployeeDebabrataListDTO</param>
        /// <returns>DataTable</returns> //It returns the Date Table.
        /// </summary> 
        /// 
        public ResponseDebabrata<object> GetEmployeeDebabrataBySearch(RequestDebabrata objAPIRequest)
        {

            #region Common Variables
            string strResponse = string.Empty;
            int ErrorCode = 0;
            DateTime startResponseTime = DateTime.Now;
            #endregion

            #region Specific Variables
            ResponseDebabrata<object> objDebabrataResponse = null;
            EmployeeDebabrataListDTO objEmployeeDebabrataListDTO = null;
            EmployeeDebabrataDAL objDebabrataEmployeeDAL = null;
            DataTable dtEmployeeDetails = null;
            Tuple<DataTable, int> tupleEmployeeDetails = null;      
            string SearchWord = string.Empty;
            int intPageSize = 0;
            int intPageNumber = 0;
            int intrtnRecordCount = 0;
            RegularExpressionDebabrata objRegularExpressionDebabrata = null;
            #endregion

            try
            {
                objRegularExpressionDebabrata = new RegularExpressionDebabrata();

                #region Request data Validations
                if (ErrorCode == 0)
                {
                    #region  PageNumber Validation
                    if (ErrorCode == 0)
                    {
                        if (objAPIRequest.PageNumber != null && !String.IsNullOrWhiteSpace(objAPIRequest.PageNumber))
                        {
                            if (Regex.IsMatch(objAPIRequest.PageNumber.Trim(), objRegularExpressionDebabrata.RegExForId))
                            {
                                if(Regex.IsMatch(objAPIRequest.PageNumber.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForPageNumber))
                                {
                                    intPageNumber = Convert.ToInt32(objAPIRequest.PageNumber);
                                }
                                else
                                {
                                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Page_Number_Range_InBetween_100);
                                }
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_PageNumber);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.PageNumber_Can_Not_Be_Null);
                        }
                    }
                    #endregion

                    #region  PageSize Validation
                    if (ErrorCode == 0)
                    {
                        if (objAPIRequest.PageSize != null && !String.IsNullOrWhiteSpace(objAPIRequest.PageSize))
                        {
                            if (Regex.IsMatch(objAPIRequest.PageSize.Trim(), objRegularExpressionDebabrata.RegExForId))
                            {
                                if (Regex.IsMatch(objAPIRequest.PageSize.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForPageSize))
                                {
                                        intPageSize = Convert.ToInt32(objAPIRequest.PageSize);
                                }
                                else
                                {
                                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Page_Size_Range_InBetween_100);
                                }
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_PageSize);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.PageSize_Can_Not_Be_Null);
                        }
                    }
                    #endregion

                    #region  SearchWord Validation
                    if (objAPIRequest.SearchWord != null && !String.IsNullOrWhiteSpace(objAPIRequest.SearchWord))
                    {
                        if (Regex.IsMatch(objAPIRequest.SearchWord.Trim(), objRegularExpressionDebabrata.RegExForSearchWord))
                        {
                            if (Regex.IsMatch(objAPIRequest.SearchWord.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForSearchWord))
                            {
                                SearchWord = objAPIRequest.SearchWord;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Search_Word_Length_InBetween_32);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Sort_Expression);
                        }
                    }
                }
                #endregion
                #endregion


                #region Calling DAL
                if (ErrorCode == 0)
                {
                    if (intPageNumber <= 0 || intPageSize <= 0)
                    {
                        intPageNumber = 1;
                        intPageSize = 999999999;
                    }
                    objEmployeeDebabrataListDTO = new EmployeeDebabrataListDTO()
                    {
                        SearchWord = SearchWord,
                        PageNumber = intPageNumber,
                        PageSize = intPageSize,

                    };
                }

                if (objEmployeeDebabrataListDTO != null)
                {
                    try
                    {
                        objDebabrataEmployeeDAL = new EmployeeDebabrataDAL(objConfigurationSettingsListDTO);
                        tupleEmployeeDetails = objDebabrataEmployeeDAL.GetEmployeeDebabrataBySearch(objEmployeeDebabrataListDTO);
                        dtEmployeeDetails = tupleEmployeeDetails.Item1;
                        intrtnRecordCount = tupleEmployeeDetails.Item2;
                        if (dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                        {
                            strResponse = JsonConvert.SerializeObject(dtEmployeeDetails, Formatting.Indented);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.No_Records_Found);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is JsonException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Serialization_Error);
                        }
                        else if (ex is SqlException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.SQL_Error);
                        }
                        else if (ex is NullReferenceException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference);
                        }
                        else if (ex is UnauthorizedAccessException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Unauthorized_Access);
                        }
                        else if (ex is TimeoutException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Request_TimeOut);
                        }
                        else if (ex is InvalidOperationException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Operation);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Request);
                        }
                    }
                    finally
                    {
                        objEmployeeDebabrataListDTO = null;
                        objConfigurationSettingsListDTO = null;
                    }
                }

            }
            #endregion
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format);
                }
                else if (ex is NullReferenceException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference_Error);
                }
                else if (ex is OverflowException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Overflow_Error);
                }
                else
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                }
            }

            finally
            {
                objDebabrataEmployeeDAL = null;

                try
                {
                    if (ErrorCode > 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = ErrorCode;
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), ErrorCode).Replace('_', ' ');
                        objDebabrataResponse.Data = null;
                    }
                    else if (ErrorCode == 0 && dtEmployeeDetails != null && dtEmployeeDetails.Rows.Count > 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Success);
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), Convert.ToInt32(GeneralDebabrata.ErrorCode.Success)).Replace('_', ' ');
                        objDebabrataResponse.RecordCount = intrtnRecordCount;
                        objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                        var json = JsonConvert.DeserializeObject<dynamic>(strResponse);
                        objDebabrataResponse.Data = json;
                    }

                    objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format_Error);
                    }
                    else if (ex is ArgumentException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Error_Code);
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                    }
                }
                finally
                {
                    #region Nullifying Objects
                    #endregion
                }
            }

            return objDebabrataResponse;

        }
        #endregion

        #region DeleteEmployeeDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   BAL 
        // Method Name                  :   DeleteEmployeeDebabrataByCode
        // Method Description           :   This method is used to Delete the Employee Details based on EmployeeCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   20 April 2024
        // Input Parameters             :   objEmployeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0               Debabrata Meher            20 April 2024                  Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>DeleteEmployeeDebabrataByCode</c> This method is used to Delete the Employee Details based on EmployeeCode parameters.
        /// <param>objEmployeeDebabrataListDTO</param>
        /// <returns>DataTable</returns> //It returns the Date Table.
        /// </summary> 
        /// 
        public ResponseDebabrata<object> DeleteEmployeeDebabrataByCode(RequestDebabrata objAPIRequest)
        {

            #region Common Variables
            string strResponse = string.Empty;
            int ErrorCode = 0;
            DateTime startResponseTime = DateTime.Now;
            #endregion

            #region Specific Variables
            ResponseDebabrata<object> objDebabrataResponse = null;
            EmployeeDebabrataListDTO objEmployeeDebabrataListDTO = null;
            EmployeeDebabrataDAL objDebabrataEmployeeDAL = null;
            int intAffectedrows = 0;
            string strEmployeeCode = string.Empty;
            RegularExpressionDebabrata objRegularExpressionDebabrata = null;
            #endregion

            try
            {
                objRegularExpressionDebabrata = new RegularExpressionDebabrata();

                #region Request data Validations
                #region  EmployeeCode Validation
                if (ErrorCode == 0)
                {

                    if (objAPIRequest.EmployeeCode != null && !String.IsNullOrWhiteSpace(objAPIRequest.EmployeeCode))
                    {
                        if (Regex.IsMatch(objAPIRequest.EmployeeCode.Trim(), objRegularExpressionDebabrata.RegExCode))
                        {
                            if (Regex.IsMatch(objAPIRequest.EmployeeCode.Trim(), objRegularExpressionDebabrata.RegExMaxLengthForCode))
                            {
                                strEmployeeCode = objAPIRequest.EmployeeCode;
                            }
                            else
                            {
                                ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Length_InBetween_16);
                            }
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Employee_Code);
                        }
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Can_Not_Be_Null);
                    }
                }
                #endregion
                #endregion


                #region Calling DAL
                if (ErrorCode == 0)
                {
                    objEmployeeDebabrataListDTO = new EmployeeDebabrataListDTO();
                    objEmployeeDebabrataListDTO.EmployeeCode = strEmployeeCode;
                }

                if (objEmployeeDebabrataListDTO != null)
                {
                    try
                    {
                        objDebabrataEmployeeDAL = new EmployeeDebabrataDAL(objConfigurationSettingsListDTO);
                        intAffectedrows = objDebabrataEmployeeDAL.DeleteEmployeeDebabrataByCode(objEmployeeDebabrataListDTO);

                        if (intAffectedrows == 1)
                        {
                            strResponse = JsonConvert.SerializeObject(intAffectedrows, Formatting.Indented);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Employee_Code_Incrrect);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is JsonException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Serialization_Error);
                        }
                        else if (ex is SqlException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.SQL_Error);
                        }
                        else if (ex is NullReferenceException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference);
                        }
                        else if (ex is UnauthorizedAccessException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Unauthorized_Access);
                        }
                        else if (ex is TimeoutException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Request_TimeOut);
                        }
                        else if (ex is InvalidOperationException)
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Operation);
                        }
                        else
                        {
                            ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Request);
                        }
                    }
                    finally
                    {
                        objEmployeeDebabrataListDTO = null;
                        objConfigurationSettingsListDTO = null;
                    }
                }

            }
            #endregion
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format);
                }
                else if (ex is NullReferenceException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Null_Reference_Error);
                }
                else if (ex is OverflowException)
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Overflow_Error);
                }
                else
                {
                    ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                }
            }
            finally
            {
                objDebabrataEmployeeDAL = null;

                try
                {
                    if (ErrorCode > 0)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        objDebabrataResponse.ReturnCode = ErrorCode;
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), ErrorCode).Replace('_', ' ');
                        objDebabrataResponse.Data = null;
                    }
                    else if (ErrorCode == 0 && intAffectedrows ==1)
                    {
                        objDebabrataResponse = new ResponseDebabrata<object>();
                        //objDebabrataResponse.ReturnCode =Convert.ToInt32(GeneralDebabrata.ErrorCode.Deleted_Sucessfully);
                        objDebabrataResponse.ReturnCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Success);
                        objDebabrataResponse.ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.ErrorCode), Convert.ToInt32(GeneralDebabrata.ErrorCode.Deleted_Sucessfully)).Replace('_', ' ');
                        objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                        objDebabrataResponse.Data = null;
                    }

                    objDebabrataResponse.ResponseTime = Math.Round((DateTime.Now - startResponseTime).TotalMilliseconds).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Format_Error);
                    }
                    else if (ex is ArgumentException)
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Invalid_Error_Code);
                    }
                    else
                    {
                        ErrorCode = Convert.ToInt32(GeneralDebabrata.ErrorCode.Technical_Error_occured);
                    }
                }
                finally
                {
                    #region Nullifying Objects
                    #endregion
                }
            }

            return objDebabrataResponse;

        }
        #endregion
    }
}
