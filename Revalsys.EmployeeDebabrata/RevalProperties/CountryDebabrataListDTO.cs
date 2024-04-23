/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  ListDTO
   * Modified By            : 
   * Description            :  This class have the Country Module Properties.
*/
namespace Revalsys.EmployeeDebabrata.RevalProperties
{
    public class CountryDebabrataListDTO
    {
        #region CountryCode
        /// <summary>
        /// Gets the CountryCode.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        public string CountryCode { get; set; }
        #endregion

        #region Constructor
        public CountryDebabrataListDTO()
        {
            CountryCode = string.Empty;
        }
        #endregion
    }
}
