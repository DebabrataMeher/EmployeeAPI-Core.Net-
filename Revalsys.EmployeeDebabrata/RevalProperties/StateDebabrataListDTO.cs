/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  22 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  ListDTO
   * Modified By            : 
   * Description            :  This class have the State Module Properties.
*/
namespace Revalsys.EmployeeDebabrata.RevalProperties
{
    public class StateDebabrataListDTO
    {
        #region StateCode
        /// <summary>
        /// Gets the StateCode.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        public string StateCode { get; set; }
        #endregion

        #region CountryId
        /// <summary>
        /// Gets the CountryId.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        public int CountryId { get; set; }
        #endregion
        #region Constructor
        public StateDebabrataListDTO()
        {
            StateCode = string.Empty;
            CountryId = 0;
        }
        #endregion
    }
}
