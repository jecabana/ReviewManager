using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class SurveysAnswer
    {
        public int Id { get; set; }
        public virtual SurveysGeneralAnswer SurveyGenAnswer { get; set; }
        public int SurveysGeneralAnswerId { get; set; }
        public int SurveyQuestionId { get; set; }
        public int SurveysPossibleAnswerId { get; set; }
        [StringLength(700)]
        public string Answer { get; set; }
    }
}
