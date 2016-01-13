using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.PortalEntities
{
    public class SurveyTemplate
    {
        [Key]
        public int Id { get; set; }
        public string TypeSurveyTemplateId { get; set; }
        public TypeSurveyTemplate TypeSurveyTemplate { get; set; }
        [StringLength(200)]
        public string SurveyName { get; set; }
        [StringLength(200)]
        public string NombreEncuesta { get; set; }
        [StringLength(300)]
        public string Welcome { get; set; }
        [StringLength(300)]
        public string Bienvenido { get; set; }
        [StringLength(600)]
        public string Objective { get; set; }
        [StringLength(600)]
        public string Objetivo { get; set; }
        [StringLength(350)]
        public string Footer { get; set; }
        [StringLength(350)]
        public string Pie { get; set; }
        [StringLength(300)]
        public string QuestionSatisfied { get; set; }
        [StringLength(300)]
        public string PreguntaSatisfaccion { get; set; }
        [StringLength(300)]
        public string QuestionFill { get; set; }
        [StringLength(300)]
        public string PreguntaLlenar { get; set; }
        public ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
