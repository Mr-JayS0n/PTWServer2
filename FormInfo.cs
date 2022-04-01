using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PTWServer1
{
    public class FormInfo
    {
        private int id; //field 
        public int ID   //property
        {
            get { return id; } //get method
            set { id = value; } //set method
        }

        private string name;

        public string Name
        {
            get { return name; } //get method
            set { name = value; } //set method
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        FormInfo(int formID, string formName, DateTime formDate)
        {
            ID = formID;
            Name = formName;
            Date = formDate;
        }
    }
}
