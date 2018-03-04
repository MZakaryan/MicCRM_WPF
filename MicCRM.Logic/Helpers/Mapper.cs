using MicCRM.Logic.Helpers;
using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicCRM.Info.Models;
using MicCRM.Domain.Concrete;
using MicCRM.Logic.Controllers;

namespace MicCRM.Logic.Mappers
{
    public static class Mapper
    {
        #region Data-Model Mappers
        public static ApplicantViewModel MapingApplicantViewModel(Applicant applicant)
        {
            return new ApplicantViewModel()
            {
                Id = applicant.ID,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                Phone1 = applicant.Phone1,
                IsStudent = applicant.IsStudent,
                Deleted = applicant.Deleted,
                Description = applicant.Description,
                Date = applicant.Date,
                Technology = Mapper.MapingTechnologyViewModel(applicant.Technology)
            };
        }

        public static TechnologyViewModel MapingTechnologyViewModel(Technology technology)
        {
            return new TechnologyViewModel()
            {
                Id = technology.ID,
                Name = technology.Name
            };
        }
        public static LessonViewModel MapingLessonViewModel(Lesson lesson)
        {
            return new LessonViewModel()
            {
                Id = lesson.ID,
                StartingDate = lesson.StartingDate,
                EndingDate = lesson.EndingDate,  
                Teachers = MapingTeacherViewModel(lesson.Teachers)
            };
        }
        public static StudentViewModel MapingStudentViewModel(Student student)
        {
            return new StudentViewModel()
            {
                ApplicantViewModel = MapingApplicantViewModel(student.Applicant),
                ApplicantViewModelId = student.ApplicantId,
                Lessons = MapingLessonViewModel(student.Lessons).ToList(),
                LastTechnology = Mapper.MapingTechnologyViewModel(student.Applicant.Technology),
                IsWorker = student.IsWorker
            };
        }
        public static TeacherViewModel MapingTeacherViewModel(Teacher teacher)
        {
            return new TeacherViewModel()
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                Lessons = MapingLessonViewModel(teacher.Lessons),
                Phone = teacher.Phone,

            };
        }
        public static UserViewModel MapingUserViewModel(User user)
        {
            return new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                PasswordHash = user.PasswordHash
            };

        }
        internal static IEnumerable<ApplicantViewModel> MapingApplicantViewModel(ICollection<Applicant> applicants)
        {
            foreach (Applicant item in applicants)
            {
                yield return MapingApplicantViewModel(item);
            }
        }
        internal static IEnumerable<StudentViewModel> MapingStudentViewModel(ICollection<Student> students)
        {
            foreach (Student item in students)
            {
                yield return MapingStudentViewModel(item);
            }
        }
        internal static IEnumerable<LessonViewModel> MapingLessonViewModel(ICollection<Lesson> lessons)
        {
            foreach (Lesson item in lessons)
            {
                yield return MapingLessonViewModel(item);
            }
        }
        internal static IEnumerable<TeacherViewModel> MapingTeacherViewModel(ICollection<Teacher> teachers)
        {
            foreach (Teacher item in teachers)
            {
                yield return MapingTeacherViewModel(item);
            }
        }
        internal static IEnumerable<TechnologyViewModel> MapingTechnologyViewModel(ICollection<Technology> Technologies)
        {
            foreach (Technology item in Technologies)
            {
                yield return MapingTechnologyViewModel(item);
            }
        }
        internal static IEnumerable<TeacherViewModel> MapingTeacherViewModels(ICollection<Teacher> teachers)
        {
            foreach (Teacher item in teachers)
            {
                yield return MapingTeacherViewModel(item);
            }
        }
        #endregion

        #region Model-Data Mappers
        public static Lesson MapingLesson(LessonViewModel lesson)
        {
            return new Lesson()
            {
                StartingDate = lesson.StartingDate,
                EndingDate = lesson.EndingDate,  
                Teachers = MapingTeacher(lesson.Teachers),
            };
        }
        internal static ICollection<Applicant> MapingApplicant(IEnumerable<ApplicantViewModel> applicants)
        {
            List<Applicant> newapplicants = new List<Applicant>();
            foreach (ApplicantViewModel item in applicants)
            {
                newapplicants.Add(MapingApplicant(item));
            }
            return newapplicants;
        }
        internal static ICollection<Teacher> MapingTeacher(IEnumerable<TeacherViewModel> teachers)
        {
            List<Teacher> newteachers = new List<Teacher>();
            foreach (TeacherViewModel item in teachers)
            {
                newteachers.Add(MapingTeacher(item));
            }
            return newteachers;
        }
        internal static ICollection<Lesson> MapingLesson(IEnumerable<LessonViewModel> lessons)
        {
            List<Lesson> newlessons = new List<Lesson>();
            foreach (LessonViewModel item in lessons)
            {
                newlessons.Add(MapingLesson(item));
            }
            return newlessons;
        }
        public static Technology MapingTechnology(TechnologyViewModel technology)
        {
            return new Technology()
            { 
                Name = technology.Name
            };
        }
        public static Teacher MapingTeacher(TeacherViewModel teacher)
        {
            return new Teacher()
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Deleted = teacher.IsDeleted,
                Lessons = MapingLesson(teacher.Lessons) 
            };
        }
        public static Applicant Mapaplicant(ApplicantViewModel applicant)
        {
            return new Applicant()
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                Phone1 = applicant.Phone1,
                Deleted = applicant.Deleted, 
                 Date = applicant.Date,
                  Description = applicant.Description,
                   IsStudent = applicant.IsStudent,
                   // Technology = MapingTechnology(applicant.Technology),
                     ID = applicant.Id,
               TechnologyID = applicant.Technology.Id


            };
        }
        public static User MapingUser(UserViewModel user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                PasswordHash = user.PasswordHash
            };
        }
        public static Student MapingStudent(StudentViewModel students)
        {
            return new Student()
            {
               // Applicant = MapingApplicant(students.ApplicantViewModel),
                ApplicantId = students.ApplicantViewModelId,
                Description = students.Description,
                Deleted = students.IsDeleted,
                IsWorker = students.IsWorker,
                Lessons = MapingLesson(students.Lessons)
                
            };
        }

        internal static Applicant MapingApplicant(ApplicantViewModel ap)
        {
            return new Applicant()
            {
                ID = ap.Id,
                FirstName = ap.FirstName,
                LastName = ap.LastName,
                Phone1 = ap.Phone1,
                Email = ap.Email,
                Date = ap.Date,
                Description = ap.Description,
                TechnologyID = ap.Technology.Id,
                //Technology = Mapper.MapingTechnology(ap.Technology)
            };

        }
        #endregion

        #region View-Model Mappers
        public static TeacherViewModel MapingTeacherViewModel(string firstname,
                                                                string lastname,
                                                                string phone,
                                                                string email)
        {
            return new TeacherViewModel()
            {
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Email = email
            };
        }

        public static LessonViewModel MapingLessonViewModel(DateTime startingDate,
                                                             DateTime endingDate,
                                                             int technologyViewModelId,
                                                             TechnologyViewModel technologyViewModel)
        {
            return new LessonViewModel()
            {

                StartingDate = startingDate, 
                EndingDate = endingDate, 
            };
        }

        private static TechnologyViewModel MapingTechnologyViewModel(string name)
        {
            return new TechnologyViewModel()
            {
                Name = name

            };
        }

        public static ApplicantViewModel MapingApplicantViewModel(string firstname,
                                                                     string lastname,
                                                                     string phone,
                                                                     string email,
                                                                     string desc,
                                                                     DateTime date,
                                                                     int lessonId,
                                                                     string techName)
        {

            LessonController lessonController = new LessonController();
            return new ApplicantViewModel()
            {
                FirstName = firstname,
                LastName = lastname,
                Phone1 = phone,
                Email = email,
                Description = desc,
                Date = date,
                Technology = Mapper.MapingTechnologyViewModel(techName)
            };
        }

        //TODO Change User-UserViewModel. Create UserViewModel in MicCRM.Info.Models
        public static UserViewModel MapingUserViewModel(string firstname,
                                                         string lastname,
                                                         string login,
                                                         string password)
        {
            return new UserViewModel()
            {
                FirstName = firstname,
                LastName = lastname,
                Login = login,
                PasswordHash = Helper.HashSHA1(password)
            };
        }

        #endregion
    }
}