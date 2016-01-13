using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class SurveysGeneralAnswer
    {        
        public int Id { get; set; }
        public int SurveyCustomerId { get; set; }
        public virtual SurveyCustomer SurveyCustomer { get; set; }
        public int SurveyCustomerActionId { get; set; }
        public int SurveyTemplateId { get; set; }
        public virtual SurveyTemplate SurveyTemplate { get; set; }
        public DateTime SurveyDate { get; set; }
        public string Language { get; set; }
        public bool IsSatisfied { get; set; }
        public bool IsFillSurvey { get; set; }
        public virtual ICollection<SurveysAnswer> SurveysAnswers { get; set; }
    }
}
