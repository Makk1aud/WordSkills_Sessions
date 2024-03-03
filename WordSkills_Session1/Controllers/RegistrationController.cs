using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Shared.DataTransferObjects;

namespace WordSkills_Session1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly WorldSkillsContext _context;
        
        public RegistrationController(WorldSkillsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegistrationPatient()
        {
            ViewBag.Genders = _context.Genders.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPatient(PatientForRegistrationDTO patientForRegistration)
        {
            ViewBag.Genders = _context.Genders.ToList();
            if (ModelState.IsValid)
            {
                var checkPatient = await _context.Patients.FirstOrDefaultAsync(x => x.Passport == patientForRegistration.Passport);
                if (checkPatient is null)
                {
                    var patient = new Patient
                    {
                        FirstName = patientForRegistration.FirstName,
                        LastName = patientForRegistration.LastName,
                        MiddleName = patientForRegistration.MiddleName,
                        Passport = patientForRegistration.Passport,
                        GenderId = patientForRegistration.GenderId,
                        Address = patientForRegistration.Address,
                        Phone = patientForRegistration.Phone,
                        Email = patientForRegistration.Email,
                        WorkPlace = patientForRegistration.WorkPlace
                    };
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("RegistrationPolicy", new { patientId = patient.PatientId});
                }
                ViewBag.Error = "Пользователь с таким паспортом уже зарегистрирован";
            }            
            return View(patientForRegistration);
        }

        [HttpGet]
        public async Task<IActionResult> RegistrationPolicy(int patientId)
        {
            ViewBag.PatientId = patientId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPolicy(PolesForCreationDTO policyForCreation, int patientId)
        {
            if(ModelState.IsValid)
            {
                var poles = new Insurancepole
                {
                    PolicyNum = policyForCreation.PolicyNum,
                    EndDate = (DateTime)policyForCreation.EndDate
                };

                _context.Insurancepoles.Add(poles);
                await _context.SaveChangesAsync();

                var medicineCard = new Medicalcard
                {
                    LastContactDate = DateTime.Now,
                    InsurancePolicyId = poles.InsurancePolicyId
                };
                _context.Medicalcards.Add(medicineCard);
                await _context.SaveChangesAsync();

                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == patientId);
                if (patient is null)
                    return BadRequest();

                patient.MedicalCardId = medicineCard.MedicalCardId;
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
    }
}
