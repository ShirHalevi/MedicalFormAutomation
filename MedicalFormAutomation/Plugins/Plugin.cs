using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace MedicalFormAutomation.Plugins
{
    public class InitDate : WebTestPlugin
    {
        public string StartDate { get; set; }
        public string NameAndSign
        {
            get { return "NameAndSign"; }
            set { NameAndSign = value; }
        }
        public string Passport
        {
            get { return "Passport"; }
            set { Passport = value; }
        }
        public string Temp
        {
            get { return "Temp"; }
            set { Temp = value; }
        }
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            e.WebTest.Context[StartDate] = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.888'Z'");
            e.WebTest.Context.Add(Passport, e.WebTest.Context["DataSource1.UsersDataMedicalForm#csv.passport"].ToString());
            e.WebTest.Context.Add(NameAndSign, e.WebTest.Context["DataSource1.UsersDataMedicalForm#csv.NameAndSign"].ToString());
            e.WebTest.Context.Add(Temp,string.Format("{0:0.0}",GetRandomNumber(36.0, 36.5)));
            base.PreWebTest(sender, e);
        }
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
 

    //public class SubmitDate : WebTestRequestPlugin
    //{
    //    public string SubmitDateParameter { get; set; }
    //    public override void PostRequest(object sender, PostRequestEventArgs e)
    //    {
    //        e.WebTest.Context[SubmitDateParameter] = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.888'Z'");
    //        base.PostRequest(sender, e);
    //    }
    //}
}
