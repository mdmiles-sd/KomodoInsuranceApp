using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceApp
{
    public class DeveloperRepository
    {
        private List<Developer> _listofdeveloper = new List<Developer>();

        //create
        public void AddDeveloperToList(Developer list)
        {
            _listofdeveloper.Add(list);
        }
        //read
        public List<Developer> GetDeveloperList()
        {
            return _listofdeveloper;
        }

        //update
        public bool UpdateExistinglist(int originaldeveloper, Developer newdeveloper)
        {
            Developer oldDeveloper = GetDeveloperById(originaldeveloper);

            if(oldDeveloper != null)
            {
                oldDeveloper.ID = newdeveloper.ID;
                oldDeveloper.Name = newdeveloper.Name;
                oldDeveloper.Pluralsight = newdeveloper.Pluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete ????????
        public bool RemoveDeveloperFromList(int id)
        {
            Developer list = GetDeveloperById(id);

            if(list == null)
            {
                return false;
            }
            int initalcount = _listofdeveloper.Count;
            _listofdeveloper.Remove(list);

            if (initalcount > _listofdeveloper.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //helper method
        public Developer GetDeveloperById(int id)
        {
            foreach(Developer list in _listofdeveloper) 
            {
                if (list.ID == id)
                {
                    return list;
                }
            }
            return null;
        }

       
    }
}
