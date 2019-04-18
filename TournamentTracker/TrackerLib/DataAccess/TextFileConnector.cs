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


        /// <summary>
        /// Saves a new prize to the database
        ///For each model, store them in their own textfile
        ///Load all prizes, read highest id+1 for new ID 
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>the prize information including the unique identifier</returns>
        public void CratePrize(PrizeModel model)
        {
            //Load Textfile
            //Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

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
            prizes.SaveToPrizeFile(GlobalConfig.PrizesFile);
        }

        public void CreatePerson(PersonModel model)
        {
            //Load Textfile
            //Convert the text to List<PrizeModel>
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            //Find the ID
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1; //Takes list and orders by decending id property
            }

            model.Id = currentId;

            //Add the new record with the new ID
            people.Add(model);

            //Convert the prizes to list<string>
            //Save the list<string> to the textfile
            people.SaveToPeopleFile();

        }

        public void CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            //Find the ID
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1; //Takes list and orders by decending id property
            }

            model.Id = currentId;

            //Add the new record with the new ID
            teams.Add(model);

            //Convert the teams to list<string>
            //Save the list<string> to the textfile
            teams.SaveToTeamFile();
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels();

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1; //Takes list and orders by decending id property
            }

            model.Id = currentId;
            model.SaveRoundsToFile();

            tournaments.Add(model);
            tournaments.SaveToTournamentFile();
           
        }

        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(); // returns list of teammodel
        }

        public List<TournamentModel> GetTournament_All()
        {
           return GlobalConfig.TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels();
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }
    }
}
