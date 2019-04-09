using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        //TODO: Make the CreatePrize save to the database
        /// <summary>
        /// Saves a new prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>the prize information including the unique identifier</returns>
        public PrizeModel CratePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
