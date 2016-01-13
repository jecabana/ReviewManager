using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Data;
using Data.Repositories;
using Entity.ReviewManagerEntities;
using Entity.PortalEntities;
using Entity.CosmeticExpress;

//   .PortalEntities;
//using Entity.ReviewManagerEntities;

namespace Domain.Managers
{
    public static class Migrator
    {
        public static void MigrateSurveyCustomer()
        {
            PortalDbContext portalDbContext = new PortalDbContext();
            PortalDbRepository<Access> accesPortalDbRepository = new PortalDbRepository<Access>(portalDbContext);
            PortalDbRepository<SurveyCustomer> surveyCustomerRepository = new PortalDbRepository<SurveyCustomer>(portalDbContext);
            PortalDbRepository<SurveyQuestion> surveyQuestionRepository = new PortalDbRepository<SurveyQuestion>(portalDbContext);
            PortalDbRepository<SurveysGeneralAnswer> surveysGeneralAnswerRepository = new PortalDbRepository<SurveysGeneralAnswer>(portalDbContext);
            PortalDbRepository<SurveysPossibleAnswer> surveyPossibleAnswerRepository = new PortalDbRepository<SurveysPossibleAnswer>(portalDbContext);

            Manager portalDbManager = new Manager(accesPortalDbRepository);
            /////////////===================>>>>>>>>>>>>>>>>>>>
            SurveyCustomerDbManager SurveyCustomerDbManager = new SurveyCustomerDbManager(surveyCustomerRepository, portalDbManager);
            SurveyQuestionManager SurveyQuestionManager = new SurveyQuestionManager(surveyQuestionRepository, portalDbManager);
            SurveyGeneralAnswerManager SurveyGeneralAnswerManager = new SurveyGeneralAnswerManager(surveysGeneralAnswerRepository, portalDbManager);
            SurveyPossibleAnswerManager SurveyPossibleAnswerManager = new SurveyPossibleAnswerManager(surveyPossibleAnswerRepository, portalDbManager);

            //////////////////////////////////////////////////
            CosmeticExpressDbContext cosmeticExpressDbContext = new CosmeticExpressDbContext();
            CosmeticExpressDbRepository<Access> accesCosmeticExpressDbRepository = new CosmeticExpressDbRepository<Access>(cosmeticExpressDbContext);
            CosmeticExpressDbRepository<User> userRepository = new CosmeticExpressDbRepository<User>(cosmeticExpressDbContext);
            CosmeticExpressDbRepository<Schedule> scheduleRepository = new CosmeticExpressDbRepository<Schedule>(cosmeticExpressDbContext);
            CosmeticExpressDbRepository<Office> officeRepository = new CosmeticExpressDbRepository<Office>(cosmeticExpressDbContext);
            CosmeticExpressDbRepository<VWCompleteSurgery> VWCompleteSurgeryRepository = new CosmeticExpressDbRepository<VWCompleteSurgery>(cosmeticExpressDbContext);
            CosmeticExpressDbRepository<Entity.CosmeticExpress.Patient> CosmeticExpressPatientRepository = new CosmeticExpressDbRepository<Entity.CosmeticExpress.Patient>(cosmeticExpressDbContext);


            Manager cosmeticExpressDbManager = new Manager(accesCosmeticExpressDbRepository);
            UserManager userManager = new UserManager(userRepository, cosmeticExpressDbManager);
            ScheduleManager scheduleManager = new ScheduleManager(scheduleRepository, cosmeticExpressDbManager);
            OfficeManager officeManager = new OfficeManager(officeRepository, cosmeticExpressDbManager);
            VWCompleteSurgeryManager vwCompleteSurgeryManager = new VWCompleteSurgeryManager(VWCompleteSurgeryRepository, cosmeticExpressDbManager);
            CosmeticExpressPatientManager CosmeticExpressPatientManager = new CosmeticExpressPatientManager(CosmeticExpressPatientRepository, cosmeticExpressDbManager);

            //////////////////////////////////////////////////
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            ApplicationDbRepository<Access> accesApplicationDbRepository = new ApplicationDbRepository<Access>(applicationDbContext);
            ApplicationDbRepository<Review> reviewRepository = new ApplicationDbRepository<Review>(applicationDbContext);
            ApplicationDbRepository<Doctor> doctorRepository = new ApplicationDbRepository<Doctor>(applicationDbContext);
            ApplicationDbRepository<Lead> leadRepository = new ApplicationDbRepository<Lead>(applicationDbContext);
            ApplicationDbRepository<Expert> expertRepository = new ApplicationDbRepository<Expert>(applicationDbContext);
            ApplicationDbRepository<Center> centerRepository = new ApplicationDbRepository<Center>(applicationDbContext);
            ApplicationDbRepository<Entity.ReviewManagerEntities.Patient> ApplicationPatientRepository = new ApplicationDbRepository<Entity.ReviewManagerEntities.Patient>(applicationDbContext);


            Manager applicationDbManager = new Manager(accesApplicationDbRepository);
            ReviewManager reviewManager = new ReviewManager(reviewRepository, applicationDbManager);
            ///////////////////=============================>>>>>>>>>>>>>>>
            DoctorManager doctorManager = new DoctorManager(doctorRepository, applicationDbManager);
            LeadManager leadManager = new LeadManager(leadRepository, applicationDbManager);
            ExpertManager expertManager = new ExpertManager(expertRepository, applicationDbManager);
            CenterManager centerManager = new CenterManager(centerRepository, applicationDbManager);
            ApplicationPatientManager ApplicationPatientManager = new ApplicationPatientManager(ApplicationPatientRepository, cosmeticExpressDbManager);

            var SurveyQuestionCollection = SurveyQuestionManager.Get().ToArray();
            var SurveyCustomerCollection = SurveyCustomerDbManager.Get().ToArray();
            var SurveyPossibleAnswerCollection = SurveyPossibleAnswerManager.Get().ToArray();
            var SurveyGeneralAnswerCollection = SurveyGeneralAnswerManager.Get().ToArray();
            ICollection<VWCompleteSurgery> vwCompleteSurgeriesCollection = vwCompleteSurgeryManager.Get().ToArray();

            var doctors = doctorManager.Get().Select(d => new{ d.Id, d.FullName, d.Reviews.Count }).ToArray();
            var sources = reviewManager.Get().GroupBy(r => r.Source).ToArray().Select(group => new {Source = group.Key, Count = group.Count()});

            ICollection<Review> ReviewCollection = new List<Review>();

            foreach (var sgAnswer in SurveyGeneralAnswerCollection)
            {
                if (!reviewManager.Get().Any(review => review.ExternalId == sgAnswer.Id && review.Source == "Portal") && sgAnswer.SurveyTemplateId == 2)
                {
                    //Schedule Schedule = scheduleManager.Get(sched =>
                    //sched.PatientID == sgAnswer.SurveyCustomer.ExternalId
                    //&& sched.ServiceID == 5
                    //&& sched.dtStart.AddMonths(3) >= sgAnswer.SurveyDate).FirstOrDefault();

                    VWCompleteSurgery surgery = vwCompleteSurgeriesCollection.Where(surg => surg.PatientID == sgAnswer.SurveyCustomer.ExternalId && surg.dtStart.AddMonths(3) >= sgAnswer.SurveyDate).FirstOrDefault();


                    if (surgery != null)
                    {
                        Review review = new Review();
                        review.Source = "Portal";
                        review.ExternalId = sgAnswer.Id;
                        review.Rating = 0;

                        review.CreatedOn = surgery.dtStart;

                        //FROM CEXPRESS/Patient/Patient
                        Entity.CosmeticExpress.Patient CosmeticExpressPatient = CosmeticExpressPatientManager.Get(patient => patient.PatientID == surgery.PatientID).FirstOrDefault();
                        var existingApplicationPatient = ApplicationPatientManager.Get(patient => patient.ExternalId == CosmeticExpressPatient.PatientID && patient.Source == "CosmeticExpress").FirstOrDefault();
                        if (existingApplicationPatient != null)
                        {
                            review.PatientId = existingApplicationPatient.Id;
                        }
                        else
                        {
                            Entity.ReviewManagerEntities.Patient Patient = new Entity.ReviewManagerEntities.Patient()
                            {
                                ExternalId = CosmeticExpressPatient.PatientID,
                                FirstName = CosmeticExpressPatient.FirstName,
                                LastName = CosmeticExpressPatient.LastName,
                                MiddleName = CosmeticExpressPatient.MiddleName,
                                DOB = CosmeticExpressPatient.DOB,
                                Email = CosmeticExpressPatient.Email,
                                Source = "CosmeticExpress"
                            };
                            review.Patient = Patient;
                        }


                        //FROM CEXPRESS/USER TO APP/DOCTOR 
                        User User = userManager.Get(user => user.UserID == surgery.ProviderUserID).FirstOrDefault();
                        var existingDoctorinDb = doctorManager.Get(doc => doc.ExternalId == User.UserID && doc.Source == "CosmeticExpress").FirstOrDefault();
                        var reviewInCollectionWithSameDoctor = ReviewCollection.FirstOrDefault(rev => rev.Doctor != null && rev.Doctor.ExternalId == User.UserID && rev.Doctor.Source == "CosmeticExpress");
                        if (existingDoctorinDb != null)
                        {
                            review.DoctorId = existingDoctorinDb.Id;
                        }
                        else
                        {
                            if (reviewInCollectionWithSameDoctor != null)
                            {
                                review.Doctor = reviewInCollectionWithSameDoctor.Doctor;
                            }
                        }
                        if (review.Doctor == null && review.DoctorId == null)
                        {
                            {
                                Doctor Doctor = new Doctor()
                                {
                                    FullName = User.FullName,
                                    Source = "CosmeticExpress",
                                    ExternalId = User.UserID
                                };
                                review.Doctor = Doctor;
                            }
                        }

                        //FROM CEXPRESS/OFFICE TO APP/CENTER 
                        Office Office = officeManager.Get(office => office.OfficeId == surgery.OfficeID).FirstOrDefault();

                        var existingCenterinDb = centerManager.Get(center => center.ExternalId == surgery.OfficeID).FirstOrDefault();
                        var centerInCollectionWithSameDoctor = ReviewCollection.FirstOrDefault(rev => rev.Center != null && rev.Center.ExternalId == Office.OfficeId && rev.Center.Source == "CosmeticExpress");

                        if (existingCenterinDb != null)
                        {
                            review.CenterId = existingCenterinDb.Id;
                        }
                        else
                        {
                            if (centerInCollectionWithSameDoctor != null)
                            {
                                review.Center = centerInCollectionWithSameDoctor.Center;
                            }
                        }
                        if (review.Center == null && review.CenterId == null)
                        {
                            Center Center = new Center()
                            {
                                Name = Office.OfficeName,
                                Source = "CosmeticExpress",
                                ExternalId = Office.OfficeId
                            };
                            review.Center = Center;                           
                        }

                        //Recorriendo cada pregunta dentro del survey para calcular el rating
                        foreach (var answer in sgAnswer.SurveysAnswers)
                        {
                            if (SurveyQuestionCollection.FirstOrDefault(q => q.Id == answer.SurveyQuestionId).QuestionType == "edit")
                            {
                                review.Text = answer.Answer != null ? answer.Answer.ToString() : "Empty";
                            }
                            else
                            {
                                var anwersItem = SurveyPossibleAnswerCollection.FirstOrDefault(spa => spa.Id == answer.SurveysPossibleAnswerId);
                                review.Rating += anwersItem != null ? anwersItem.Weight : 0;
                            }
                        }
                        //anadiento el review a la coleccion
                        ReviewCollection.Add(review);
                    }
                }
            }
            //from ReviewCollection to reviewManager
            foreach (var review in ReviewCollection)
            {
                reviewManager.Add(review);               
            }
            reviewManager.SaveChanges();
        }
    }
}