using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Revalsys.Common;
using Revalsys.Common.RevalProperties;
using Revalsys.EmployeeDebabrata.BAL;
using Revalsys.EmployeeDebabrata.RevalProperties.Models;
using System;
using System.Threading.Tasks;

namespace RevalsysEmployeeDebarataApi.RevalWeb.com.Controllers
{
    [Route("api/DeleteEmployeeByCode")]
    [ApiController]
    public class DeleteEmployeeDebabrataByCodeController : ControllerBase
    {
        private ConfigurationSettingsListDebabrataDTO _ConfigurationSettingsListDTO = null;

        public DeleteEmployeeDebabrataByCodeController(IOptions<ConfigurationSettingsListDebabrataDTO> options)
        {
            _ConfigurationSettingsListDTO = options.Value;
        }

        #region DeleteEmployeeDebabrataByCode
        //***************************************************************************************************
        // Layer                        :   Controller 
        // Method Name                  :   DeleteEmployeeDebabrataByCode
        // Method Description           :   This method is used to Delete the Employee Details based on EmployeeCode parameters.
        // Author                       :   Debabrata Meher
        // Creation Date                :   19 April 2024
        // Input Parameters             :   objAPIRequest
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   objContentResult
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher              20 April 2024                 Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>DeleteEmployeeDebabrataByCode</c> This method is used to Delete the Employee Details based on EmployeeCode parameters.
        /// <param>objAPIRequest</param>
        /// <returns>objContentResult</returns> //It returns the Date Table.
        /// </summary>
        /// 
        [HttpPost]
        public async Task<ContentResult> DeleteEmployeeDebabrataByCode(RequestDebabrata objAPIRequest)
        {

            var HeaderType = Request.ContentType;
            EmployeeDebabrataBAL objEmployeeBAL = null;
            ContentResult objContentResult = null;
            ResponseDebabrata<object> objEmployeeDebabrataResponce = null;
            object objResult = null;
            ResponseDebabrata<object> objResponse = new ResponseDebabrata<object>
            {
                ReturnCode = Convert.ToInt32(((int)GeneralDebabrata.CommonResponseErrorCodes.InvalidRequest)),
                ReturnMessage = Enum.GetName(typeof(GeneralDebabrata.CommonResponseErrorCodes), GeneralDebabrata.CommonResponseErrorCodes.InvalidRequest)
            };
            Int32 StatusCode = 0;


            #region After validating request
            try
            {

                if (_ConfigurationSettingsListDTO != null)
                {
                    Task<ResponseDebabrata<object>> tskResponse = Task<ResponseDebabrata<object>>.Run(() =>
                    {
                        objEmployeeBAL = new EmployeeDebabrataBAL(_ConfigurationSettingsListDTO);
                        objEmployeeDebabrataResponce = objEmployeeBAL.DeleteEmployeeDebabrataByCode(objAPIRequest);
                        return objEmployeeDebabrataResponce;
                    });
                    objEmployeeDebabrataResponce = await tskResponse;

                    if (objEmployeeDebabrataResponce != null)
                    {
                        objResult = objEmployeeDebabrataResponce;
                    }
                    else
                    {
                        objResult = objResponse;
                    }
                }
                else
                {
                    objResult = objResponse;
                }
                StatusCode = (int)GeneralDebabrata.CommonResponseErrorCodes.Success;

            }
            catch (InvalidOperationException ex)
            {
                StatusCode = (int)GeneralDebabrata.CommonResponseErrorCodes.InvalidOperationError;
            }
            catch (Exception ex)
            {
                StatusCode = (int)GeneralDebabrata.CommonResponseErrorCodes.InvalidRequest;
            }
            finally
            {
                #region Nullifying Objects
                objResponse = null;
                #endregion
            }
            #endregion

            #region output converting xml or json
            if (HeaderType != null)
            {
                if (HeaderType.ToString().ToLower().Contains("application/xml")) //converting the xml
                {
                    //objContentResult = new ContentResult() { Content = clsSecurity.ConvertObjectToXml(objResult), ContentType = "application/xml", StatusCode = StatusCode };
                }
                else if (HeaderType.ToString().ToLower().Contains("application/json"))
                {
                    objContentResult = new ContentResult() { Content = JsonConvert.SerializeObject(objResult), ContentType = "application/json", StatusCode = StatusCode };
                }
                else
                {
                    objContentResult = new ContentResult() { Content = JsonConvert.SerializeObject(objResult), ContentType = "application/json", StatusCode = StatusCode };
                }
            }
            else
            {
                objContentResult = new ContentResult() { Content = JsonConvert.SerializeObject(objResult), ContentType = "application/json", StatusCode = StatusCode };
            }
            return objContentResult;
            #endregion
        }
        #endregion
    }
}
