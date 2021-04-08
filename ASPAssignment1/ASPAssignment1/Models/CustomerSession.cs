using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPAssignment1.Models
{
    public class CustomerSession
    {
        private const string CustKey = "customers";
        private const string CountKey = "custcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";

        private ISession session { get; set; }

        public CustomerSession(ISession session)
        {
            this.session = session;
        }

        public void SetTech(List<Customer> customers)
        {
            session.SetObject(CustKey, customers);
            session.SetInt32(CountKey, customers.Count);
        }

        public List<Customer> GetCust() =>
            session.GetObject<List<Customer>>(CustKey) ?? new List<Customer>();

        public int GetCustCount() => session.GetInt32(CountKey) ?? 0;

        public void SetActiveConf(string activeConf) =>
            session.SetString(ConfKey, activeConf);

        public string GetActiveConf() => session.GetString(ConfKey);

        public void SetActiveDiv(string activeDiv) =>
            session.SetString(DivKey, activeDiv);

        public string GetActiveDiv() => session.GetString(DivKey);

        public void RemoveTech()
        {
            session.Remove(CustKey);
            session.Remove(CountKey);
        }
    }
}
