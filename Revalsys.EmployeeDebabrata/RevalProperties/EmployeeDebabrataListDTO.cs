/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  ListDTO
   * Modified By            : 
   * Description            :  This class have the Employee Module Properties.
*/
namespace Revalsys.EmployeeDebabrata.RevalProperties
{
    public class EmployeeDebabrataListDTO
    {
        #region EmployeeId
        /// <summary>
        /// Gets the EmployeeId.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        public int EmployeeId { get; set; }
        #endregion

        #region EmployeeCode
        /// <summary>
        /// Gets the EmployeeCode.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  19 April 2024       Creation 
        //=======================================================
        public string EmployeeCode { get; set; }
        #endregion

        #region SearchWord
        /// <summary>
        /// Gets the SearchWord.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  20 April 2024       Creation 
        //=======================================================
        public string SearchWord { get; set; }
        #endregion

        #region Name
        /// <summary>
        /// Gets the Name.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public string Name { get; set; }
        #endregion

        #region FirstName
        /// <summary>
        /// Gets the FirstName.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public string FirstName { get; set; }
        #endregion

        #region Email
        /// <summary>
        /// Gets the Email.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        public string Email { get; set; }
        #endregion

        #region Mobile
        /// <summary>
        /// Gets the FirstName.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        public string Mobile { get; set; }
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

        #region StateId
        /// <summary>
        /// Gets the StateId.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  22 April 2024       Creation 
        //=======================================================
        public int StateId { get; set; }
        #endregion

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

        #region LastName
        /// <summary>
        /// Gets the LastName.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public string LastName { get; set; }
        #endregion

        #region Age
        /// <summary>
        /// Gets the Age.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public int Age { get; set; }
        #endregion

        #region Department
        /// <summary>
        /// Gets the Department.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public string Department { get; set; }
        #endregion

        #region Position
        /// <summary>
        /// Gets the Position.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public string Position { get; set; }
        #endregion

        #region PageSize
        /// <summary>
        /// Gets the PageSize.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public int PageSize { get; set; }
        #endregion

        #region PageNumber
        /// <summary>
        /// Gets the PageNumber.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  18 April 2024       Creation 
        //=======================================================
        public int PageNumber { get; set; }
        #endregion

        #region Constructor
        public EmployeeDebabrataListDTO()
        {
            EmployeeId = 0;
            EmployeeCode = string.Empty;
            Name= string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Age = 0;
            Department = string.Empty;
            Position = string.Empty;
            PageSize = 0;
            PageNumber = 0;
            SearchWord = string.Empty;
            CountryId = 0;
            StateId = 0;
            CountryCode= string.Empty;
            StateCode= string.Empty;
        }
        #endregion
    }
}
