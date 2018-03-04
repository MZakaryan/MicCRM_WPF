using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MicCRM.Domain
{
    internal class MicCRMContext : DbContext
    {
        public MicCRMContext()
            : base("name=MicCRMDb")
        {
            Database.SetInitializer(new MyClass());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Technology> Technology { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }

    class MyClass : DropCreateDatabaseAlways<MicCRMContext>
    {
        protected override void Seed(MicCRMContext context)
        {
            List<Technology> technologiesList = new List<Technology>()
            {
                new Technology()
                {
                    Name = "Programming fundamentals-Evening hours"
                },
                new Technology()
                {
                    Name = "Programming fundamentals-Afternoon hour"
                },
                new Technology()
                {
                    Name = "Object-oriented programming with C# and .NET Framework"
                },
                new Technology()
                {
                    Name = "ASP MVC back-end programming"
                },
                new Technology()
                {
                    Name = "Introduction to JavaScript"
                },
                new Technology()
                {
                    Name = "Advanced JavaScript and JS Frameworks"
                },
                new Technology()
                {
                    Name = "QA Fundamentals"
                },
                new Technology()
                {
                    Name = "UI/UX Design"
                },
                new Technology()
                {
                    Name = "Introduction to Python"
                },
                new Technology()
                {
                    Name = "Network administration"
                },
            };
            context.Technology.AddRange(technologiesList);

            Applicant a = new Applicant()
            {
                FirstName = "On",
                LastName = "Asoyan",
                Phone1 = "+37477617517",
                Email = "media-onix@mail.ru",
                Description = "aklajsklajlkjl",
                Date = new DateTime(2018, 10, 12),
                Technology = context.Technology.Find(5),
            };
            context.Applicants.Add(a);
            Applicant a1 = new Applicant()
            {
                FirstName = "Suren",
                LastName = "Avagyan",
                Phone1 = "+37498252525",
                Email = "surenavagyan@gmail.com",
                Description = "Suro",
                Date = new DateTime(2018, 10, 12),
                Technology = context.Technology.Find(2),
            };
            context.Applicants.Add(a1);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
