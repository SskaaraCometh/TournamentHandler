using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelper;

namespace TrackerLibrary.DataAccess
{
    public class TextFileConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        /// <summary>
        /// Saves a new prize to the database
        ///For each model, store them in their own textfile
        ///Load all prizes, read highest id+1 for new ID 
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>the prize information including the unique identifier</returns>
        public PrizeModel CratePrize(PrizeModel model)
        {
            //Load Textfile
            //Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find the ID
            int currentId = 1;

            if(prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1; //Takes list and orders by decending id property,
            }

            model.Id = currentId;

            //Add the new record with the new ID
            prizes.Add(model);

            //Convert the prizes to list<string>
            //Save the list<string> to the textfile
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
