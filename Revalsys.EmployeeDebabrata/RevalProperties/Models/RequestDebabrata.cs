/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  ListDTO
   * Modified By            : 
   * Description            :  This class have the API Request Properties.
*/
namespace Revalsys.EmployeeDebabrata.RevalProperties.Models
{
    public class RequestDebabrata
    {
        #region EmployeeId
        /// <summary>
        /// Gets the EmployeeId .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("EmployeeId", Required = Newtonsoft.Json.Required.Default)]
        public string EmployeeId { get; set; }
        #endregion

        #region EmployeeCode
        /// <summary>
        /// Gets the EmployeeCode .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("EmployeeCode", Required = Newtonsoft.Json.Required.Default)]
        public string EmployeeCode { get; set; }
        #endregion

        #region SearchWord
        /// <summary>
        /// Gets the SearchWord .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  20 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("SearchWord", Required = Newtonsoft.Json.Required.Default)]
        public string SearchWord { get; set; }
        #endregion

        #region Name
        /// <summary>
        /// Gets the Name .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.Default)]
        public string Name { get; set; }
        #endregion

        #region FirstName
        /// <summary>
        /// Gets the FirstName .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("FirstName", Required = Newtonsoft.Json.Required.Default)]
        public string FirstName { get; set; }
        #endregion

        #region Email
        /// <summary>
        /// Gets the Email .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Email", Required = Newtonsoft.Json.Required.Default)]
        public string Email { get; set; }
        #endregion

        #region Mobile
        /// <summary>
        /// Gets the Mobile .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Mobile", Required = Newtonsoft.Json.Required.Default)]
        public string Mobile { get; set; }
        #endregion

        #region CountryCode
        /// <summary>
        /// Gets the CountryCode .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Country", Required = Newtonsoft.Json.Required.Default)]
        public string Country { get; set; }
        #endregion

        #region StateCode
        /// <summary>
        /// Gets the StateCode .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("State", Required = Newtonsoft.Json.Required.Default)]
        public string State { get; set; }
        #endregion

        #region LastName
        /// <summary>
        /// Gets the LastName .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  19 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("LastName", Required = Newtonsoft.Json.Required.Default)]
        public string LastName { get; set; }
        #endregion

        #region Age
        /// <summary>
        /// Gets the Age .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Age", Required = Newtonsoft.Json.Required.Default)]
        public string Age { get; set; }
        #endregion

        #region Department
        /// <summary>
        /// Gets the Department .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Department", Required = Newtonsoft.Json.Required.Default)]
        public string Department { get; set; }
        #endregion

        #region Position
        /// <summary>
        /// Gets the Position .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("Position", Required = Newtonsoft.Json.Required.Default)]
        public string Position { get; set; }
        #endregion

        #region PageSize
        /// <summary>
        /// Gets the PageSize .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("PageSize", Required = Newtonsoft.Json.Required.Default)]
        public string PageSize { get; set; }
        #endregion

        #region PageNumber
        /// <summary>
        /// Gets the PageNumber .
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        [Newtonsoft.Json.JsonProperty("PageNumber", Required = Newtonsoft.Json.Required.Default)]
        public string PageNumber { get; set; }
        #endregion

    }
}
