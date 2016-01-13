using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class SurveyQuestion
    {
        [Key]
        public int Id { get; set; }
        public SurveyTemplate SurveyTemplate { get; set; }
        [StringLength(600)]
        public string Question { get; set; }
        [StringLength(600)]
        public string Pregunta { get; set; }
        public string QuestionType { get; set; }
        public virtual ICollection<SurveysAnswer> SurveysAnswers { get; set; }
        public virtual ICollection<SurveysPossibleAnswer> SurveysPossiblesAnswers { get; set; }
    }
}
