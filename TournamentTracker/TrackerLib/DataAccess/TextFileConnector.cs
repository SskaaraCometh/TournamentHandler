using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextFileConnector : IDataConnection
    {
        //TODO: Make the TFC save to the textfile
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
