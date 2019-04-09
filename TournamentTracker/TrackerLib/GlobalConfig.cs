using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Abstract/Static base class which will be used to set to database or textfile
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Allows to read the database connections, but not set them
        /// </summary>
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool dataBase, bool textFiles)
        {
            if(dataBase == true)
            {
                //TODO: Set SQL connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if(textFiles == true)
            {
                //TODO: create text file connection
                TextFileConnector text = new TextFileConnector();
                Connections.Add(text);
            }
        }
    }
}
