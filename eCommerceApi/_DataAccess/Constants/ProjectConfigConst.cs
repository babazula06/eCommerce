using System;

namespace _DataAccess.Constants
{
    public class ProjectConfigConst
    {
        #region DB CONNECTION STRINGS
    
       
        public const String DEPOS_SQL_DB_CONNECTION_STRING = @"Data Source=xxxxxx;Initial Catalog=Depos;persist security info=True;user id=xxxxxx;password=xxxxxxx";


        #endregion

        #region PROJECT PATHS

        public static String ROOT_PATH { get; set; }
        public static String ERROR_LOG_PATH { get; set; }
        public static String EXCEL_FILE_PATH { get; set; }
        public const String RELATIVE_ERROR_LOG_PATH = "\\ErrorLogs";
        public const String RELATIVE_EXCEL_FILE_PATH = "\\ExcelFiles";

        #endregion

      

    }
}
