using System.Xml.Linq;
using Task3;

namespace Task3
{

	public class Instructor
	{
		public int InstructorId;
		public string Name;
		public string Specialization;

		public Instructor()
		{
		}

		public Instructor(int instructorId, string name, string specialization="none")
		{
			InstructorId = instructorId;
			Name = name;
			Specialization = specialization;
		}

		public string PrintDetails()
		{
			string output = $"The Instructor Id: {InstructorId} \nThe Instructor Name: {Name} \nThe Instructor Specialization: {Specialization} ";
			return output;
		}
	}
	public class Course
	{
		public int CourseId;
		public string Title;
		public Instructor Instructor;

		public Course()
		{
		}

		public Course(int courseId, string title, Instructor instructor)
		{
			CourseId = courseId;
			Title = title;
			Instructor = instructor;
		}

		public string PrintDetails()
		{
			string output = $"The Course Id: {CourseId} \nThe Course Title: {Title} \nThe Instructor ID: {Instructor.InstructorId} \nThe Instructor Name: {Instructor.Name}";
			return output;
		}

	}
	public class Student
	{
		public int StudentId;
		public String Name;
		public int Age;
		public List<Course> Courses;

		public Student()
		{
		}

		public Student(int studentId, string name, int age, List<Course> courses)
		{
			StudentId = studentId;
			Name = name;
			Age = age;
			Courses = courses;
		}
		public bool Enroll(Course course)
		{
			if (!Courses.Contains(course))
			{
				Courses.Add(course);
				Console.WriteLine("Student Enrolled");
				return true;
			}
			return false;
		}
		public void PrintDetails()
		{

			Console.WriteLine($"The Student Id: {StudentId} \nThe Student Name: {Name} \nThe Student Age: {Age}");
			if( Courses.Count>0) 
			{
				Console.Write("Courses for the student: ");
				for(int i = 0; i < Courses.Count; i++)
				{
					Console.WriteLine(Courses[i].PrintDetails());

				}
				
			}

		}
	}
	public class School
	{
		public List<Student> Students;
		public List<Course> Courses;
		public List<Instructor> Instructors;

		public School(List<Student> students, List<Course> courses, List<Instructor> instructors)
		{
			Students = new List<Student>();
			Courses = new List<Course>();
			Instructors = new List<Instructor>();
		}

		public School()
		{

			Students = new List<Student>();
			Courses = new List<Course>();
			Instructors = new List<Instructor>();
		}

		public bool AddStudent(Student student)
		{
			for (int i = 0; i < Students.Count; i++)
			{
				if (student.StudentId == Students[i].StudentId || student.Name.ToLower() == Students[i].Name.ToLower())
				{
					Console.WriteLine("Student already exist");
					return false;

				}

			}
			Students.Add(student);
			Console.WriteLine("Student added successfully");
			return true;
		}
		public bool AddCourse(Course course)
		{
			for(int i = 0; i < Courses.Count; i++)
			{
				if (course.CourseId == Courses[i].CourseId || course.Title.ToLower() == Courses[i].Title.ToLower())
				{
					Console.WriteLine("Course already exist");
					return false;

				}

			}

			Courses.Add(course);
			Console.WriteLine("Course added successfully");
			return true;
			
		}
		public bool AddInsturctor(Instructor instructor)
		{
			for(int i = 0; i < Instructors.Count; i++)
			{
				if (instructor.InstructorId == Instructors[i].InstructorId || instructor.Name.ToLower() == Instructors[i].Name.ToLower())
				{
					Console.WriteLine("Instructor already exist");
					return false;
				}
	
			}
			Instructors.Add(instructor);
			Console.WriteLine("Instructor added successfully");
			return true;
		}
		public Student FindStudent(int studentId)
		{
		

			for (int i = 0; i < Students.Count; i++)
			{
				if (studentId == Students[i].StudentId)
				{
					
					return Students[i];
				}
			}

			Console.WriteLine("The Student not found");
			return null;
		}

		public Course FindCourse(int courseId)
		{
			for (int i = 0; i < Courses.Count; i++)
			{
				if (courseId == Courses[i].CourseId)
				{
					return Courses[i];
				}
			}

			Console.WriteLine("The Course not found");
			return null;

		}
		public Instructor FindInstructor(int instructorId)
		{

			for (int i = 0; i < Instructors.Count; i++)
			{
				if (instructorId == Instructors[i].InstructorId)
				{
					return Instructors[i];
				}
			}

			Console.WriteLine("The Instructor not found");
			return null;


		}
		public bool EnrollStudentInCourse(int studentId, int courseId)
		{
			Student student = FindStudent(studentId);	
			Course course = FindCourse(courseId);
			if(student == null || course == null)
			{
				return false;

			}
			return student.Enroll(course);



		} 
	}
	


	internal class Program
	{

		static void Main(string[] args)
		{
			School school = new School();
			while (true)
			{

				Console.WriteLine(" 1.Add Student\n 2.Add Instructor\n 3.Add Course\n 4.Enroll Student in Course\n 5.Show All Students\n 6.Show All Courses\n 7.Show All Instructors\n 8.Find the student by id\n 9.Fine the course by id\n 10.Exit");
				Console.Write("   Enter your choice: ");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						{
							Console.Write("Enter the Student ID: \n");
							int studentId = Convert.ToInt32(Console.ReadLine());
							Console.Write("Enter the Student Name: \n");
							string studentName = Console.ReadLine().ToLower();
							Console.Write("Enter the Student Age: \n");
							int studentAge = Convert.ToInt32(Console.ReadLine());
							List<Course> emptyCourses = new List<Course>();
							Student student=new Student(studentId,studentName,studentAge,emptyCourses);
							school.AddStudent(student);
							break;
						}
					case 2:
						{
							Console.Write("Enter the Instructor ID: \n");
							int instructorId = Convert.ToInt32(Console.ReadLine());
							Console.Write("Enter the Instructor Name: \n");
							string name = Console.ReadLine().ToLower();
							Console.Write("Enter the Instructor Specialization: \n");
							string specialization = Console.ReadLine().ToLower();
							Instructor instr = new Instructor(instructorId, name, specialization);
							school.AddInsturctor(instr);
							break;
						}
					case 3:
						{
							Console.Write("Enter the Course Id: \n");
							int courseId = Convert.ToInt32(Console.ReadLine());
							Console.Write("Enter the Course Title: \n");
							string courseTitle = Console.ReadLine().ToLower();
							Console.Write("Enter the Instructor ID : \n");
							int instructorId = Convert.ToInt32(Console.ReadLine());
							Console.Write("Enter the Instructor Name : \n");
							string instructorName = Console.ReadLine().ToLower();
							Instructor instructor = new Instructor(instructorId, instructorName);
							Course course = new Course(courseId,courseTitle,instructor);
							school.AddCourse(course);
							break;
						}
					case 4:
						{
							Console.Write("Enter The Student ID: ");
							int studentID = Convert.ToInt32(Console.ReadLine());
							
							Console.Write("Enter The Course ID: ");
							int courseID = Convert.ToInt32(Console.ReadLine());
							
							school.EnrollStudentInCourse(studentID, courseID);
							break;
						}	
					case 5:
						{
							if (school.Students.Count > 0)
							{
								for (int i = 0; i < school.Students.Count; i++)
								{
									school.Students[i].PrintDetails();
									Console.WriteLine("============================");
								}

							}
							else 
							   Console.WriteLine("No Students To Show");
							
							break;
						}
					case 6:
						{
							if (school.Courses.Count > 0)
							{
								for (int i = 0; i < school.Courses.Count; i++)
								{
									string output=school.Courses[i].PrintDetails();
									Console.WriteLine($"{output}");
									Console.WriteLine("============================");
								}

							}
							else
								Console.WriteLine("No Courses To Show");

							break;

						}
					case 7:
				        {
							if (school.Instructors.Count > 0)
							{
								for (int i = 0; i < school.Instructors.Count; i++)
								{
									string output=school.Instructors[i].PrintDetails();
									Console.WriteLine($"{output}");
									Console.WriteLine("============================");
								}

							}
							else
								Console.WriteLine("No Instructors To Show");

							break;
						}
					case 8:
						{
							Console.Write("Enter the Student id: ");
							int inputId = Convert.ToInt32(Console.ReadLine());
							Student student=school.FindStudent(inputId);
							if (student != null)
							{
								student.PrintDetails();
							}
							
							break;

						}
					case 9:
						{
							Console.Write("Enter the Course id: ");
							int inputId = Convert.ToInt32(Console.ReadLine());
							Course course=school.FindCourse(inputId);
							if (course != null)
							{
								Console.WriteLine(course.PrintDetails());
							}
							
							break;
							
						}
					case 10:
						{
							Console.WriteLine(" Goodbye");
							break;

						}
					default:
						{
							Console.WriteLine("Unknown selection, please try again");
							break;
						}	

				}



			}


		}

	}
}





	