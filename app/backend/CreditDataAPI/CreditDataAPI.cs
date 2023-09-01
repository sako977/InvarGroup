using backend.CreditDataAPI.CreditDataModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace backend.CreditDataAPI
{
    public class CreditDataAPI : ICreditDataAPI
    {
        HttpClient sharedHttpClient = new HttpClient()
        {
            BaseAddress = new System.Uri($"https://infra.devskills.app")
        };

        public AssessedIncomeDetails GetAssessedIncome(string ssn)
        {
            var response =  sharedHttpClient.GetAsync($"/api/credit-data/assessed-income/{ssn}");
            AssessedIncomeDetails assessedIncomeDetailsObject = JsonConvert.DeserializeObject<AssessedIncomeDetails>(response.Result.Content.ReadAsStringAsync().Result);
            return assessedIncomeDetailsObject;

        }

        public DebtDetails GetDebt(string ssn)
        {
            var response = sharedHttpClient.GetAsync($"/api/credit-data/debt/{ssn}");
            DebtDetails debtDetailsObject = JsonConvert.DeserializeObject<DebtDetails>(response.Result.Content.ReadAsStringAsync().Result);
            return debtDetailsObject;

        }

        public PersonalDetails GetPersonalDetails(string ssn)
        {
            var response = sharedHttpClient.GetAsync($"/api/credit-data/personal-details/{ssn}");
            PersonalDetails personalDetailsObject = JsonConvert.DeserializeObject<PersonalDetails>(response.Result.Content.ReadAsStringAsync().Result);
            return personalDetailsObject;
        }
        
    }
}
