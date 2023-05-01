using MVC_SIS_Data;
using MVC_SIS_Models;
using MVC_SIS_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace MVC_SIS_UI.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new AddStateVM());
        }

        [HttpPost]
        public ActionResult AddState(AddStateVM viewModel)
        {
            //If not correct, it should redirect the user back to the AddState View showing

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            //The method should redirect the user to the States list view upon successful
            //completion of the Add operation.
           //the ValidationSummary at the top.

            StateRepository.Add(viewModel.currentState);
            return RedirectToAction("States");
        }

       

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new AddEditMajorVM());
        }

        [HttpPost]
        public ActionResult AddMajor(AddEditMajorVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            MajorRepository.Add(viewModel.currentMajor.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            AddEditMajorVM viewmodel = new AddEditMajorVM();
            viewmodel.currentMajor = MajorRepository.Get(id);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditMajor(AddEditMajorVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            MajorRepository.Edit(viewModel.currentMajor);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            EditCourseVM viewmodel = new EditCourseVM();
            viewmodel.currentCourse = CourseRepository.Get(id);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditCourse(EditCourseVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            CourseRepository.Edit(viewModel.currentCourse);
            return RedirectToAction("Courses");
        }



        [HttpGet]
        public ActionResult EditState(string stateAbbreviation)
        {
            EditStateVM viewmodel = new EditStateVM();
            viewmodel.currentState = StateRepository.Get(stateAbbreviation);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditState(EditStateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            StateRepository.Edit(viewModel.currentState);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            DeleteMajorVM viewModel = new DeleteMajorVM();
            viewModel.currentMajor = MajorRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteMajor(DeleteMajorVM viewModel)
        {
            MajorRepository.Delete(viewModel.currentMajor.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            DeleteCourseVM viewModel = new DeleteCourseVM();
            viewModel.currentCourse = CourseRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteCourse(DeleteCourseVM viewModel)
        {
            CourseRepository.Delete(viewModel.currentCourse.CourseId);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbbreviation)
        {
            DeleteStateVM viewModel = new DeleteStateVM();
            viewModel.currentState = StateRepository.Get(stateAbbreviation);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteState(DeleteStateVM viewModel)
        {
            StateRepository.Delete(viewModel.currentState.StateAbbreviation);
            return RedirectToAction("States");
        }



        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new AddCourseVM());
        }


        [HttpPost]
        public ActionResult AddCourse(AddCourseVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            CourseRepository.Add(viewModel.currentCourse.CourseName);
            return RedirectToAction("Courses");
        }




    }
}