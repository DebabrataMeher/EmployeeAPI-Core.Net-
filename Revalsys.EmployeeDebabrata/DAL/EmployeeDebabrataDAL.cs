using Revalsys.Common.RevalProperties;
using Revalsys.EmployeeDebabrata.RevalProperties;
using System;
using System.Data;
using System.Data.SqlClient;
/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  DAL
   * Modified By            : 
   * Description            :  This class have the Employee Module Data Access Related Code.
*/
namespace Revalsys.EmployeeDebabrata.DAL
{
    public class EmployeeDebabrataDAL
    {
        #region ConnectionString

        public string strConnectionString = string.Empty;

        private Int32 CommandTimeOut = 0;

        public EmployeeDebabrataDAL(ConfigurationSettingsListDebabrataDTO _objConfigurationSettingsListDTO)
        {
            strConnectionString = _objConfigurationSettingsListDTO.ConnectionString;
        }

        #endregion

        #region GetEmployeeDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   GetEmployeeDebabrataByCode
        // Method Description           :   This method is used to get the Employee Details based on EmployeeCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   19 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            19 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetEmployeeDebabrataByCode</c> This method is used to get the Employee Details based on EmployeeCode parameters.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>DataTable</returns> //It returns the Date Table.
        /// </summary>
        public DataTable GetEmployeeDebabrataByCode(EmployeeDebabrataListDTO employeeDebabrataListDTO)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_GetEmployeeDebabrataByCode";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("EmployeeCode", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.EmployeeCode;

                    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                    DataTable dtResult = new DataTable();
                    da.Fill(dtResult);
                    return dtResult;
                }
            }
        }
        #endregion

        #region InsertEmployeeDebabrata
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   InsertEmployeeDebabrata
        // Method Description           :   This method is used to Insert the Employee Details.
        // Author                       :   Debabrata Meher
        // Creation Date                :   18 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            18 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>InsertEmployeeByEmployee</c> This method is used to Insert the Employee Details.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>int</returns> //It returns the Date Table.
        /// </summary>
        public int InsertEmployeeDebabrata(EmployeeDebabrataListDTO employeeDebabrataListDTO)
        {
            int intEmployeeId = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_InsertEmployeeDebabrata";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.FirstName;
                    sqlCmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.Email;
                    sqlCmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.Mobile;
                    sqlCmd.Parameters.Add("CountryId", SqlDbType.Int).Value = employeeDebabrataListDTO.CountryId;
                    sqlCmd.Parameters.Add("StateId", SqlDbType.Int).Value = employeeDebabrataListDTO.StateId;
                    sqlCmd.Parameters.Add("EmployeeCode", SqlDbType.NVarChar, 16).Value = employeeDebabrataListDTO.EmployeeCode;
                    sqlConnection.Open();
                    intEmployeeId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlConnection.Close();
                    if (intEmployeeId > 0)
                    {
                        return intEmployeeId;
                    }
                    return intEmployeeId;
                }
            }
        }

        #endregion

        #region UpdateEmployeeDebabrataBycode
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   UpdateEmployeeDebabrataBycode
        // Method Description           :   This method is used to Update the Employee Details based on EmployeeCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   19 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            19 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>UpdateEmployeeDebabrataBycode</c> This method is used to update the Employee Details based on EmployeeCode parameters.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>int</returns> //It returns the Date Table.
        /// </summary>
        public int UpdateEmployeeDebabrataBycode(EmployeeDebabrataListDTO employeeDebabrataListDTO)
        {
            int intEmployeeId = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_UpdateEmployeeDebabrataByCode";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.FirstName;
                    sqlCmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.Email;
                    sqlCmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.Mobile;
                    sqlCmd.Parameters.Add("CountryId", SqlDbType.Int).Value = employeeDebabrataListDTO.CountryId;
                    sqlCmd.Parameters.Add("StateId", SqlDbType.Int).Value = employeeDebabrataListDTO.StateId;
                    sqlCmd.Parameters.Add("EmployeeCode", SqlDbType.NVarChar, 16).Value = employeeDebabrataListDTO.EmployeeCode;
                    sqlConnection.Open();

                    intEmployeeId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlConnection.Close();
                    if (intEmployeeId > 0)
                    {
                        return intEmployeeId;
                    }
                    return intEmployeeId;
                }
            }
        }
        #endregion

        #region GetEmployeeDebabrataBySearch
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   GetEmployeeDebabrataBySearch
        // Method Description           :   This method is used to get the Employee Details based on Searching Name.
        // Author                       :   Debabrata Meher
        // Creation Date                :   20 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            20 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetEmployeeDebabrataBySearch</c> This method is used to get the Employee Details based on EmployeeId parameters.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>Tuple<DataTable, int></returns> //It returns the Date Table.
        /// </summary>
        public Tuple<DataTable, int> GetEmployeeDebabrataBySearch(EmployeeDebabrataListDTO employeeDebabrataListDTO)
        {
            int intRowCount = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_GetEmployeeDebabrataBySearch";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("SearchWord", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.SearchWord;
                    sqlCmd.Parameters.Add("PageSize", SqlDbType.Int).Value = employeeDebabrataListDTO.PageSize;
                    sqlCmd.Parameters.Add("PageNumber", SqlDbType.Int).Value = employeeDebabrataListDTO.PageNumber;
                    sqlCmd.Parameters.Add("@TotalRows", SqlDbType.Int).Direction = ParameterDirection.Output;

                    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                    DataTable dtResult = new DataTable();
                    da.Fill(dtResult);
                    intRowCount = Convert.ToInt32(sqlCmd.Parameters["@TotalRows"].Value);
                    return Tuple.Create(dtResult, intRowCount);
                }
            }
        }
        #endregion

        #region DeleteEmployeeDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   DeleteEmployeeDebabrataByCode
        // Method Description           :   This method is used to Delete the Employee Details based on EmployeeCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   20 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            20 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetEmployeeDebabrataByCode</c> This method is used to Delete the Employee Details based on EmployeeCode parameters.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>DataTable</returns> //It returns the Date Table.
        /// </summary>
        public int DeleteEmployeeDebabrataByCode(EmployeeDebabrataListDTO employeeDebabrataListDTO)
        {
            int intAffectedrows = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_DeleteEmployeeDebabrataByCode";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("EmployeeCode", SqlDbType.NVarChar).Value = employeeDebabrataListDTO.EmployeeCode;
                    sqlConnection.Open();
                    intAffectedrows = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlConnection.Close();
                    if (intAffectedrows > 0)
                    {
                        return intAffectedrows;
                    }
                    return intAffectedrows;
                }
            }
        }
        #endregion

        #region GetCountryIdDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   GetCountryIdDebabrataByCode
        // Method Description           :   This method is used to get the CountryId Details based on CountryCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   19 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            22 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetCountryIdDebabrataByCode</c> This method is used to get the CountryId Details based on CountryCode parameters.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>int</returns> //It returns the Date Table.
        /// </summary>
        public int GetCountryIdDebabrataByCode(CountryDebabrataListDTO objCountryDebabrataListDTO)
        {
            int intcountryid = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_getCountryIdDebabrataByCountryCode";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("CountryCode", SqlDbType.NVarChar).Value = objCountryDebabrataListDTO.CountryCode;
                    sqlConnection.Open() ;
                    intcountryid = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlConnection.Close();
                    if (intcountryid > 0)
                    {
                        return intcountryid;
                    }
                    return intcountryid;
                }
            }
        }
        #endregion

        #region GetStateIdDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   DAL 
        // Method Name                  :   GetCountryIdDebabrataByCode
        // Method Description           :   This method is used to get the StateId Details based on StateCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   22 April 2024
        // Input Parameters             :   employeeDebabrataListDTO
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   DataTable
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher            22 APril 2024                   Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>GetStateIdDebabrataByCode</c> This method is used to get the StateId Details based on StateCode parameters.
        /// <param>employeeDebabrataListDTO</param>
        /// <returns>int</returns> //It returns the Date Table.
        /// </summary>
        public int GetStateIdDebabrataByCode(StateDebabrataListDTO stateDebabrataListDTO)
        {
            int intstateid = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"usp_getStateIdDebabrataByStateCode";
                    sqlCmd.CommandTimeout = CommandTimeOut;
                    sqlCmd.Parameters.Add("StateCode", SqlDbType.NVarChar).Value = stateDebabrataListDTO.StateCode;
                    sqlCmd.Parameters.Add("CountryId", SqlDbType.Int).Value = stateDebabrataListDTO.CountryId;
                    sqlConnection.Open();
                    intstateid = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlConnection.Close();
                    if (intstateid > 0)
                    {
                        return intstateid;
                    }
                    return intstateid;
                }
            }
        }
        #endregion

    }
}
