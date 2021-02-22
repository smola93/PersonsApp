using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjektApp
{
    class Data
    {
        string conString = @"Data source = localhost\SQLEXPRESS;Initial Catalog = Programowanie;Integrated Security =True;";

        public void SavePerson(Person person)
        {
            string query = $"INSERT INTO Person(Name, Surname, Pesel, EmploymentType, Brutto, Netto, Tax, PensionContribution, DisabilityPensionContribution)" +
            $"VALUES('{person.name}', '{person.surname}', '{person.pesel}', '{person.employmentType}', '{person.brutto}', '{person.netto}', '{person.tax}', '{person.pensionContribution}', '{person.disabilityPensionContribution}')";
            EditData(query);
        }

        public IEnumerable<Person> PersonsList(string query)
        {
            DataRowCollection rows = GetData(query);
            foreach (DataRow row in rows)
            {
                Person person = new Person();
                person.name = row["Name"].ToString();
                person.surname = row["Surname"].ToString();
                person.pesel = row["Pesel"].ToString();
                person.employmentType = row["EmploymentType"].ToString();
                person.bruttoString = row["Brutto"].ToString();
                person.nettoString = row["Netto"].ToString();
                person.taxString = row["Tax"].ToString();
                person.pensionContributionString = row["PensionContribution"].ToString();
                person.disabilityPensionContributionString = row["DisabilityPensionContribution"].ToString();
                yield return person;
            }
        }
        private void EditData(string query)
        {
            using (SqlConnection sCon = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(query, sCon);
                sCon.Open();
                cmd.ExecuteNonQuery();
                sCon.Close();

            }
        }

        private DataRowCollection GetData(string query)
        {
            using (SqlConnection scan = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(query, scan);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds.Tables[0].Rows;
            }
        }
        public List<Person> GetAllPersons()
        {
            string query = $"SELECT Name, Surname, Pesel, EmploymentType, Brutto, Netto, Tax, PensionContribution, DisabilityPensionContribution FROM Person";
            List<Person> answer = PersonsList(query).ToList();
            return answer;
        }
        public List<Person> GetByPesel(string pesel)
        {
            string peselquery = $"SELECT Name, Surname, Pesel, EmploymentType, Brutto, Netto, Tax, PensionContribution, DisabilityPensionContribution FROM Person WHERE Pesel='{pesel}' ";
            List<Person> answer = PersonsList(peselquery).ToList();
            return answer;
        }
        public IEnumerable<Person> GetByNameAndSurname(string name, string surname)
        {
            string namequery = $"SELECT Name, Surname, Pesel, EmploymentType, Brutto, Netto, Tax, PensionContribution, DisabilityPensionContribution FROM Person WHERE Name='{name}' AND Surname='{surname}'";
            List<Person> answer = PersonsList(namequery).ToList();
            return answer;
        }
    }
}