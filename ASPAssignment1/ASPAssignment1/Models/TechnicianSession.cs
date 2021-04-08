using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPAssignment1.Models
{
    public class TechnicianSession
    {
        private const string TechKey = "technicians";
        private const string CountKey = "techcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";

        private ISession session { get; set; }
        
        public TechnicianSession(ISession session)
        {
            this.session = session;
        }

        public void SetTech(List<Technician> technicians)
        {
            session.SetObject(TechKey, technicians);
            session.SetInt32(CountKey, technicians.Count);
        }

        public List<Technician> GetTech() =>
            session.GetObject<List<Technician>>(TechKey) ?? new List<Technician>();

        public int GetTechCount() => session.GetInt32(CountKey) ?? 0;

        public void SetActiveConf(string activeConf) =>
            session.SetString(ConfKey, activeConf);

        public string GetActiveConf() => session.GetString(ConfKey);

        public void SetActiveDiv(string activeDiv) =>
            session.SetString(DivKey, activeDiv);

        public string GetActiveDiv() => session.GetString(DivKey);

        public void RemoveTech()
        {
            session.Remove(TechKey);
            session.Remove(CountKey);
        }
    }
}
