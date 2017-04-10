using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebAppMain.DAL;
using WebAppMain.Models;

namespace WebAppMain.Controllers
{
    public class CurriculumController : Controller
    {
        private CurriculumRepo curRepo = null;

        public static object RegEx { get; private set; }

        public CurriculumController()
        {
            curRepo = new CurriculumRepo();
        }

        // GET: Curriculum
        public ActionResult Index(string schoolyear)
        {
            int yearStart = DateTime.Today.Month > 5 ? DateTime.Today.Year : DateTime.Today.AddYears(-1).Year;
            int yearEnd = DateTime.Today.Month > 5 ? DateTime.Today.AddYears(1).Year : DateTime.Today.Year;
            if (!IsValidSchoolYear(schoolyear)) schoolyear = string.Format("{0}-{1}", yearStart, yearEnd);

            string cacheKey = "Curriculum" + schoolyear;
            CurriculumViewModel vm1 = WebCache.Get(cacheKey) as CurriculumViewModel;
            if(vm1 == null)
            {
                CurriculumViewModel vm = new CurriculumViewModel();
                vm.SchoolYear = schoolyear;
                vm.SchedulesInThisYear = curRepo.GetSchedulesBySchoolYear(schoolyear);
                vm.CoursesInThisYear = curRepo.GetCoursesBySchoolYear(schoolyear);
                vm.TeachersInThisYear = curRepo.GetTeachersBySchoolYear(schoolyear);
                vm.TeacherContacts = curRepo.GetTeacherContactsBySchooYear(schoolyear);
                vm.BooksInThisYear = curRepo.AllTextbooks();
                vm.RoomsInThisYear = curRepo.AllClassroooms();
                WebCache.Set(cacheKey, vm);
                vm1 = vm;
            }
                       
            string langCode = (string)this.RouteData.Values["lang"];
            if (string.IsNullOrEmpty(langCode)) langCode = "en";
            ViewBag.LangCode = langCode;

            return View(vm1);
        }

        private static bool IsValidSchoolYear(string schoolyear)
        {
            if (string.IsNullOrEmpty(schoolyear)) return false;

            Regex re = new Regex(@"\d{4}-\d{4}");
            return re.IsMatch(schoolyear);
        }

        public JsonResult GetCurriculum(string schoolyear)
        {
            int yearStart = DateTime.Today.Month > 5 ? DateTime.Today.Year : DateTime.Today.AddYears(-1).Year;
            int yearEnd = DateTime.Today.Month > 5 ? DateTime.Today.AddYears(1).Year : DateTime.Today.Year;
            if (!IsValidSchoolYear(schoolyear)) schoolyear = string.Format("{0}-{1}", yearStart, yearEnd);

            string cacheKey = "Curriculum-" + schoolyear;
            CurriculumViewModel1 vm1 = WebCache.Get(cacheKey) as CurriculumViewModel1;
            if (vm1 == null)
            {
                CurriculumViewModel1 vm = curRepo.GetCurriculumsBySchoolYear(schoolyear);
                WebCache.Set(cacheKey, vm);
                vm1 = vm;
            }
            return Json(vm1);
        }

        // GET: Curriculum/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Curriculum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curriculum/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curriculum/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Curriculum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curriculum/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Curriculum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
