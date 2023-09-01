using backend.CreditDataAPI.CreditDataModels;
using System.Threading.Tasks;

namespace backend.CreditDataAPI
{
    /// <summary>
    /// ICreditDataAPI Interface
    /// </summary>
    public interface ICreditDataAPI
    {
        PersonalDetails GetPersonalDetails(string ssn);
        AssessedIncomeDetails GetAssessedIncome(string ssn);
        DebtDetails GetDebt(string ssn);
    }
}
