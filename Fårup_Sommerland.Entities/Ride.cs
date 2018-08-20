using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fårup_Sommerland.Entities
{
    public class Ride
    {
        private int id;
        private string name;
        private Category category;
        private Status status;
        private List<Report> reports;

        public Ride(Status status, Category category, string name)
        {
            Status = status;
            Category = category;
            Name = name;
            Reports = new List<Report>();
        }

        public Ride(Status status, Category category, string name, int iD)
        {
            Status = status;
            Category = category;
            Name = name;
            ID = iD;
            Reports = new List<Report>();
        }

        public List<Report> Reports
        {
            get { return reports; }
            set { reports = value; }
        }

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int NumberOfShutdowns()
        {
            int shutdowns = 0;
            foreach (Report r in Reports)
            {
                if (r.Status == Status.Nedbrudt)
                {
                    shutdowns++;
                }
            }
            return shutdowns;
        }

        public int DaysSinceLastShutdown()
        {
            return 1;
        }
    }
}
