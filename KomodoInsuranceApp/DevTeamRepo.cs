using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceApp
{
    public class DevTeamRepo
    {
        private List<DevTeam> _listOfTeams = new List<DevTeam>();

        //create
        public void AddDevTeamToList(DevTeam list)
        {
            _listOfTeams.Add(list);
        }
        //read
        public List<DevTeam> GetDevTeamList()
        {
            return _listOfTeams;
        }

        //update
        public bool UpdateExistinglist(Developer originalTeamMember, DevTeam newTeamMember)
        {
            DevTeam oldTeamMember = GetDevTeambyTeamMember(originalTeamMember);

            if (oldTeamMember != null)
            {
                oldTeamMember.TeamMembers = newTeamMember.TeamMembers;
               
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete ????????
        public bool RemoveTeamMemberFromList(Developer teamMember)
        {
            DevTeam list = GetDevTeambyTeamMember(teamMember);

            if (list == null)
            {
                return false;
            }
            int initalcount = _listOfTeams.Count();
            _listOfTeams.Remove(list);

            if (initalcount > _listOfTeams.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //helper method
        private DevTeam GetDevTeambyTeamMember(Developer teamMember)
        {
            foreach (DevTeam list in _listOfTeams)
            {
                if (list.TeamMembers.Contains(teamMember))
                {
                    return list;
                }
            }
            return null;
        }


    }


}
