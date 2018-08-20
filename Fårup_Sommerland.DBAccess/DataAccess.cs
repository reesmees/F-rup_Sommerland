using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fårup_Sommerland.Entities;

namespace Fårup_Sommerland.DBAccess
{
    public class DataAccess : CommonDataAccess
    {
        public DataAccess(string conString) : base(conString) { }

        public List<Ride> GetAllRides()
        {
            return CreateRidesFromDataSet(ExecuteQuery("SELECT * FROM RIDES;"));
        }

        public bool Save(Ride ride)
        {
            bool success = ExecuteNonQuery($"INSERT INTO Rides([Name], [Category], [Status]) VALUES ('{ride.Name}', '{ride.Category.ToString()}', '{ride.Status.ToString()}');");
            return success;
        }

        public bool UpdateStatus(Ride ride)
        {
            bool success = ExecuteNonQuery($"UPDATE Rides SET [Name] = '{ride.Name}', [Category] = '{ride.Category.ToString()}', [Status] = '{ride.Status.ToString()}' WHERE [ID] = {ride.ID};");
            return success;
        }

        public bool Save(Report report)
        {
            bool success = ExecuteNonQuery($"INSERT INTO Reports([Status], [ReportTime], [Notes], [RideID]) VALUES ('{report.Status.ToString()}', '{report.ReportTime}', '{report.Notes}', '{report.Ride.ID}');");
            return success;
        }

        public void GetReportsAndAddTo(Ride ride)
        {
            DataSet data = ExecuteQuery($"SELECT * FROM Reports WHERE [RideID]={ride.ID};");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                int id = row.Field<int>("ID");
                string statusString = row.Field<string>("Status");
                Status status = (Status)Enum.Parse(typeof(Status), statusString);
                DateTime reportTime = row.Field<DateTime>("ReportTime");
                string notes = row.Field<string>("Notes");
                ride.Reports.Add(new Report(notes, reportTime, status, ride, id));
            }
        }

        public List<Ride> FindRidesWith(string searchTerm)
        {
            return CreateRidesFromDataSet(ExecuteQuery($"SELECT * FROM Rides WHERE [Name] LIKE '%{searchTerm}%';"));
        }

        public List<Ride> CreateRidesFromDataSet(DataSet data)
        {
            List<Ride> rides = new List<Ride>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                int id = row.Field<int>("ID");
                string name = row.Field<string>("Name");
                string categoryString = row.Field<string>("Category");
                Category category = (Category)Enum.Parse(typeof(Category), categoryString);
                string statusString = row.Field<string>("Status");
                Status status = (Status)Enum.Parse(typeof(Status), statusString);
                Ride r = new Ride(status, category, name, id);
                GetReportsAndAddTo(r);
                rides.Add(r);
            }
            return rides;
        }
    }
}
