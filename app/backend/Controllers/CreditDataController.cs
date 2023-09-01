using backend.CreditDataAPI;
using backend.CreditDataAPI.CreditDataModels;
using backend.LookUpServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("/credit-data")]
    public class CreditDataController : Controller
    {
        private readonly ICreditDataAPI creditDataService;

        public CreditDataController(ICreditDataAPI creditDataService)
        {
            this.creditDataService = creditDataService;
        }

        /// <summary>
        /// GetCreditData - Return aggregated credit data
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns>CreditData</returns>
        [HttpGet("{ssn}")]
        public ActionResult<CreditData> GetCreditData(string ssn)
        {
            // Repsponse object
            CreditData creditDataResponse  = new CreditData();

            PersonalDetails personalDetails = creditDataService.GetPersonalDetails(ssn);
            if(string.IsNullOrEmpty(personalDetails.first_name) || string.IsNullOrEmpty(personalDetails.last_name)) 
                return NotFound(); // Don't bother calling other services as no person exist with the given ssn number.

            AssessedIncomeDetails assessedIncomeDetails = creditDataService.GetAssessedIncome(ssn);
            DebtDetails debtDetails = creditDataService.GetDebt(ssn);

            // PersonalDetails
            creditDataResponse.address = personalDetails.address;
            creditDataResponse.first_name = personalDetails.first_name;
            creditDataResponse.last_name = personalDetails.last_name;
            
            // AssessedIncomeDetails
            creditDataResponse.assessed_income = assessedIncomeDetails.assessed_income;

            // DebtDetails 
            creditDataResponse.balance_of_debt = debtDetails.balance_of_debt;
            creditDataResponse.complaints = debtDetails.complaints;

            return Ok(creditDataResponse);
        }
    }
}

