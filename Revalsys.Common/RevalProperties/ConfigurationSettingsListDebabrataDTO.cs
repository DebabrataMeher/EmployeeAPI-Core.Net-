/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  ListDTO
   * Modified By            : 
   * Description            :  This class have the ConfigurationSettingsListDTO Properties.
*/
namespace Revalsys.Common.RevalProperties
{
    public class ConfigurationSettingsListDebabrataDTO
    {
        #region ConnectionString
        /// <summary>
        /// Gets the ConnectionString.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        public string ConnectionString { get; set; }
        #endregion

        #region DateFormat
        /// <summary>
        /// Gets the DateFormat.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        public string DateFormat { get; set; }
        #endregion

        #region EncryptionKey
        /// <summary>
        /// Gets the EncryptionKey.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        public string EncryptionKey { get; set; }
        #endregion
    }
}
