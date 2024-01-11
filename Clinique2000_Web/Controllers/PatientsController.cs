using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Clinique2000_Web.Controllers
{
    public class PatientsController : Controller
    {
        private Clinique2000DbContext _db;
        private IPatientService _serviceP;
        public PatientsController(Clinique2000DbContext db, IPatientService serviceP)
        {
            _db = db;
            _serviceP = serviceP;
        }
        // GET: PatientsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientsController/Create
        public ActionResult Create(User utilisateur)
        {
            Patient patient = new Patient();
            patient.UserId = utilisateur.Id;
            patient.Courriel = utilisateur.Email;
            return View(patient);
        }



        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Patient patient)
        {
            DateTime dateLimite = DateTime.Now.AddYears(-18);
            if (patient.DatedeNaissance > dateLimite)
            {
                ModelState.AddModelError(nameof(patient.DatedeNaissance), "Le patient doit être majeur de 18 ans.");
            }

            if (ModelState.IsValid)
            {

                if (_serviceP.PatientExist(patient.NumeroAssuranceMaladie))
                {
                    ModelState.AddModelError("NumeroAssuranceMaladie", "Il existe déjà un patient avec ce numéro d'assurance maladie");
                    return View(patient);
                }


                await _serviceP.CreateAsync(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }


        // POST: PatientsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create(Patient patient)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        await _serviceP.CreateAsync(patient);
        //    }
        //    return View("Index");
        //}




        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
