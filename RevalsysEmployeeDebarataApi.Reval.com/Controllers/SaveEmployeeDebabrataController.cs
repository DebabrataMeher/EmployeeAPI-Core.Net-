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
    [Route("api/SaveEmployee")]
    [ApiController]
    public class SaveEmployeeDebabrataController : ControllerBase
    {
        private ConfigurationSettingsListDebabrataDTO _ConfigurationSettingsListDTO = null;

        public SaveEmployeeDebabrataController(IOptions<ConfigurationSettingsListDebabrataDTO> options)
        {
            _ConfigurationSettingsListDTO = options.Value;
        }

        #region SaveEmployeeDebabrata
        //***************************************************************************************************
        // Layer                        :   Controller 
        // Method Name                  :   SaveEmployeeDebabrata
        // Method Description           :   This method is used to Save the Employee Details .
        // Author                       :   Debabrata Meher
        // Creation Date                :   18 April 2024
        // Input Parameters             :   objAPIRequest
        // Modified Date                : 
        // Modified Reason              :
        // Return Values                :   objContentResult
        //----------------------------------------------------------------------------------------------------
        //  Version             Author                      Date                        Remarks       
        // ---------------------------------------------------------------------------------------------------
        //  1.0              Debabrata Meher              19 April 2024                 Creation
        //****************************************************************************************************
        /// <summary>
        /// <c>SaveEmployeeDebabrata</c> This method is used to Save the Employee Details .
        /// <param>objAPIRequest</param>
        /// <returns>objContentResult</returns> //It returns the Date Table.
        /// </summary>
        /// 
        [HttpPost]
        public async Task<ContentResult> SaveEmployeeDebabrata(RequestDebabrata objAPIRequest)
        {

            var HeaderType = Request.ContentType;
            EmployeeDebabrataBAL objEmployeeDebabrataBAL = null;
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
                        objEmployeeDebabrataBAL = new EmployeeDebabrataBAL(_ConfigurationSettingsListDTO);
                        objEmployeeDebabrataResponce = objEmployeeDebabrataBAL.SaveEmployeeDebabrata(objAPIRequest);
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
