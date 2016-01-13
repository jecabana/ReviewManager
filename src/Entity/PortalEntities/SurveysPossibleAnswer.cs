using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class SurveysPossibleAnswer
    {
        public int Id { get; set; }
        public int SurveyQuestionId { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
        [StringLength(200)]
        public string possibleAnswer { get; set; }
        [StringLength(200)]
        public string posibleRespuesta { get; set; }
        public string Evaluation { get; set; }
        public int Weight { get; set; }
    }
}
