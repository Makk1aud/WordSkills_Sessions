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
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Passport == patientForRegistration.Passport);
                if (patient is null)
                    return Ok("Успешно!");
                ViewBag.Error = "Пользователь с таким паспортом уже зарегистрирован";
            }            
            return View(patientForRegistration);
        }
    }
}
