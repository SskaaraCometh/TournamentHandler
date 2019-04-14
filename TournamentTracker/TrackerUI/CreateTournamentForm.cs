using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All(); //returns teams in database
        List<TeamModel> selectedTeams = new List<TeamModel>();
        //List<TournamentModel> tournament = List<TournamentModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            InitialiseLists();
        }

        private void InitialiseLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams; //Research
            selectTeamDropDown.DisplayMember = "TeamName"; //displays team names

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName"; //get string name of a function to display

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";

        }

        private void selectTeamDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem; //
            if(t != null)
            {
                availableTeams.Remove(t); //moves from one list to the other
                selectedTeams.Add(t); //adds to selected teams list

                InitialiseLists();
            }

        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            //call create prize form
            CreatePrizeForm frm = new CreatePrizeForm(this); //represents this specific instance
            frm.Show(); // displays form
            //get back from the form a prizemodel

        }

        public void PrizeComplete(PrizeModel model)
        {
            //take the prizemodel and put it into our list of selected prizes
            selectedPrizes.Add(model);
            InitialiseLists();
        }

        public void TeamComplete(TeamModel Model)
        {
            selectedTeams.Add(Model);
            InitialiseLists();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        private void removeSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem; //takes in selected item casts it and saves

            if(t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);
                InitialiseLists();
            }
        }

        private void removeSelectedPrize_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

            if(p != null)
            {
                selectedPrizes.Remove(p);
                InitialiseLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            //Validate data
            decimal fee = 0;

            bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out fee); //tries to convert value to decimal, returns value as fee variable, if wrong value, fee remains 0 and bool = false

            if(!feeAcceptable)
            {
                MessageBox.Show("Enter a valid amount", "Invalid Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            TournamentModel tm = new TournamentModel();
            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;
            tm.Prizes = selectedPrizes;
            tm.EnteredTeams = selectedTeams;

            //Create our matchups

            //Create tournament: Entry
            //Create all prize entries
            //Create all of the team entries
            GlobalConfig.Connection.CreateTournament(tm);
        }
    }
}
