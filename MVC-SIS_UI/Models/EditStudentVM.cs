﻿using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVC_SIS_UI.Models
{
    public class EditStudentVM : IValidatableObject
    {
        public Student Student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public EditStudentVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            Student = new Student();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Student == null || Student.FirstName == "" || Student.FirstName == null)
            {
                errors.Add(new ValidationResult("Please enter a Student First Name",
                    new[] { "Student.FirstName" }));

            }


            if (Student == null || Student.LastName == "" || Student.LastName == null)
            {
                errors.Add(new ValidationResult("Please enter a Student Last Name",
                    new[] { "Student.LastName" }));

            }
                
            if (Student == null || Student.Major == null)
            {
                errors.Add(new ValidationResult("Please select a major",
                    new[] { "Student.Major.MajorItems" }));

            }

            if (Student == null || Student.Courses == null)
            {
                errors.Add(new ValidationResult("Please select courses",
                    new[] { "Student.Courses.CourseItems" }));


            }

            if (Student == null || Student.Address == null)
            {
                errors.Add(new ValidationResult("Please enter a valid address",
                    new[] { "Student.Address" }));

            }

            return errors;
            
            }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }
    }

 }
