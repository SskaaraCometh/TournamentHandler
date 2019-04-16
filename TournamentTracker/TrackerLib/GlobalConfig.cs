using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    /// <summary>
    /// Abstract/Static base class which will be used to set to database or textfile
    /// </summary>
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModel.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";
        /// <summary>
        /// Allows to read the database connections, but not set them
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db)
        {         
            if(db == DatabaseType.Sql)
            {
                //TODO: Set SQL connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if(db == DatabaseType.TextFile)
            {
                //TODO: create text file connection
                TextFileConnector text = new TextFileConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
