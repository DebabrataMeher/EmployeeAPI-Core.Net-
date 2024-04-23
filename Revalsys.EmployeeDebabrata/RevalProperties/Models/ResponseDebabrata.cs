using System.Runtime.Serialization;
/*
   * Author Name            :  Debabrata Meher
   * Create Date            :  17 April 2024
   * Modified Date          : 
   * Modified Reason        : 
   * Layer                  :  ListDTO
   * Modified By            : 
   * Description            :  This class have the API Response Properties.
*/
namespace Revalsys.EmployeeDebabrata.RevalProperties.Models
{
    public class ResponseDebabrata<T>
    {
        #region ReturnCode
        /// <summary>
        /// Gets the ReturnCode.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        private int _ReturnCode;
        [DataMember]
        public int ReturnCode
        {
            get
            { return _ReturnCode; }
            set
            { _ReturnCode = value; }
        }
        #endregion

        #region ReturnMessage
        /// <summary>
        /// Gets the ReturnMessage.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        private string _ReturnMessage;
        [DataMember]
        public string ReturnMessage
        {
            get
            { return _ReturnMessage; }
            set
            { _ReturnMessage = value; }
        }
        #endregion

        #region ResponseTime
        /// <summary>
        /// Gets the ResponseTime.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        private string _ResponseTime;
        [DataMember]
        public string ResponseTime
        {
            get
            { return _ResponseTime; }
            set
            { _ResponseTime = value; }
        }
        #endregion

        #region RecordCount
        /// <summary>
        /// Gets the RecordCount.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        private long _RecordCount;
        [DataMember]
        public long RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }
        #endregion

        //#region TotalRecordCount
        ///// <summary>
        ///// Gets the RecordCount.
        ///// </summary>
        ////=======================================================
        ////Version       Author          Date               Remark
        ////=======================================================
        ////1.0       Debabrata Meher  17 April 2024       Creation 
        ////=======================================================
        //private long _TotalRecordCount;
        //[DataMember]
        //public long TotalRecordCount
        //{
        //    get { return _TotalRecordCount; }
        //    set { _TotalRecordCount = value; }
        //}
        //#endregion

        #region Headers
        /// <summary>
        /// Gets the Headers.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        private T _Headers;
        [DataMember]
        public T Headers
        {
            //get
            //{ return _Headers; }
            set
            { _Headers = value; }
        }
        #endregion

        #region Data
        /// <summary>
        /// Gets the Data.
        /// </summary>
        //=======================================================
        //Version       Author          Date               Remark
        //=======================================================
        //1.0       Debabrata Meher  17 April 2024       Creation 
        //=======================================================
        private T _Data;
        [DataMember]
        public T Data
        {
            get
            { return _Data; }
            set
            { _Data = value; }
        }
        #endregion

        #region Constructor
            public ResponseDebabrata()
        {
            _ReturnCode = 0;
            _ReturnMessage = string.Empty;
            _ResponseTime = string.Empty;
            _RecordCount = 0;
            _Data = default(T);
            _Headers = default(T);
            //_TotalRecordCount= 0;
        }
        #endregion
    }
}

