using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fårup_Sommerland.Entities
{
    public class Report
    {
        private int id;
        private Ride ride;
        private Status status;
        private DateTime reportTime;
        private string notes;

        public Report(string notes, DateTime reportTime, Status status, Ride ride)
        {
            Notes = notes;
            ReportTime = reportTime;
            Status = status;
            Ride = ride;
        }

        public Report(string notes, DateTime reportTime, Status status, Ride ride, int iD)
        {
            Notes = notes;
            ReportTime = reportTime;
            Status = status;
            Ride = ride;
            ID = iD;
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public DateTime ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public Ride Ride
        {
            get { return ride; }
            set { ride = value; }
        }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
