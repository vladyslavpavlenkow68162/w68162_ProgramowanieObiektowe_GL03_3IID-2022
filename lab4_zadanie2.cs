  using System;
  using System.Collections.Generic;
  using System.Linq;

  abstract class Person
  {
      public string Name { get; set; }
      public string Surname { get; set; }
      public string Pesel { get; set; }

      public void SetFirstName(string firstName)
      {
          Name = firstName;
      }

      public void SetLastName(string lastName)
      {
          Surname = lastName;
      }

      public int GetAge()
      {
          return (DateTime.Today - GetBirthDate()).Days / 365;
      }

      private DateTime GetBirthDate()
      {
          if (string.IsNullOrEmpty(Pesel) || Pesel.Length != 11 || !long.TryParse(Pesel, out _))
          {
              throw new ArgumentException("Invalid PESEL");
          }

          var year = int.Parse(Pesel.Substring(0, 2));
          var month = int.Parse(Pesel.Substring(2, 2));
          var day = int.Parse(Pesel.Substring(4, 2));

          if (month > 80)
          {
              year += 1800;
              month -= 80;
          }
          else if (month > 60)
          {
              year += 2200;
              month -= 60;
          }
          else if (month > 40)
          {
              year += 2100;
              month -= 40;
          }
          else if (month > 20)
          {
              year += 2000;
              month -= 20;
          }
          else
          {
              year += 1900;
          }

          return new DateTime(year, month, day);
      }

      public string GetGender()
      {
          if (string.IsNullOrEmpty(Pesel) || Pesel.Length != 11)
          {
              throw new ArgumentException("Invalid PESEL");
          }

          return int.Parse(Pesel[9].ToString()) % 2 == 0 ? "Woman" : "Man";
      }

      public abstract string GetEducationInfo();
      public abstract string GetFullName();
      public abstract bool CanGoHomeAlone();
  }

  class Student : Person
  {
      public string School { get; set; }
      public bool HasPermissionToGoHomeAlone { get; set; }

      public override bool CanGoHomeAlone()
      {
          return GetAge() >= 12 || HasPermissionToGoHomeAlone;
      }

      public override string GetEducationInfo()
      {
          return $"School: {School}";
      }

      public string Info()
      {
          if (GetAge() >= 12 && HasPermissionToGoHomeAlone)
          {
              return "Can go home alone";
          }
          else if (GetAge() >= 12 && !HasPermissionToGoHomeAlone)
          {
              return "Needs permission to go home alone";
          }
          else
          {
              return "Under 12 and needs permission";
          }
      }

      public override string GetFullName()
      {
          return $"{Name} {Surname}";
      }

      public void SetSchool(string school)
      {
          School = school;
      }

      public void ChangeSchool(string school)
      {
          School = school;
      }

      public void SetCanGoHomeAlone(bool canGoAloneToHome)
      {
          HasPermissionToGoHomeAlone = canGoAloneToHome;
      }

      public void SetPesel(string pesel)
      {
          Pesel = pesel;
      }
  }

  class Teacher
  {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Title { get; set; }
      public List<Student> Students { get; set; } = new List<Student>();

      public void SetFullName(string firstName, string lastName)
      {
          FirstName = firstName;
          LastName = lastName;
      }

      public void DisplayClass(DateTime date)
      {
          Console.WriteLine($"Data: {date.DayOfWeek}");
          Console.WriteLine($"Teacher: {Title} {FirstName} {LastName}");
          Console.WriteLine($"List of students");

          var i = 1;
          foreach (var student in Students)
          {
              Console.WriteLine($"{i}. {student.GetFullName()} {student.GetGender()} {student.CanGoHomeAlone()} {student.Info()}");
              i++;
          }
      }
  }

  class Program
  {
      static void Main(string[] args)
      {
          var teacher = new Teacher();
          teacher.SetFullName("Nauczyciel", "Nauczyciel");
          teacher.Title = "Dr";

          var pesels = new List<string>()
          {
              "13292313574",
              "11272558326",
              "11252623556",
              "14222195514",
              "13260515371",
              "14281248851",
              "13211445544",
              "13290928392",
              "14240472824",
              "12310555824"
          };

          var students = new List<Student>();

          var i = 0;
          foreach (var pesel in pesels)
          {
              var student = new Student();
              student.SetPesel(pesel);
              student.SetFirstName("Student");
              student.SetLastName(i.ToString());
              if (i == 4)
                  student.SetCanGoHomeAlone(true);
              student.ChangeSchool("School");
              students.Add(student);
              i++;
          }

          teacher.Students.AddRange(students);

          teacher.DisplayClass(DateTime.Today);
      }
  }
