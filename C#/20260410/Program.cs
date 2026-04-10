using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20260410
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student();

            s1.Name = "홍길동";
            s1.Grade = 1;
            s1.Id = 20260001;
            s1.Addr = "폴리텍대학";

            s2.Name = "전우치";
            s2.Grade = 3;
            s2.Id = 20260002;
            s2.Addr = "폴리텍대학";

            s1.showInfo();
            s2.showInfo();

            
        }
    }

    public class Student
    {
        //private string name;
        //private int id;
        //private int grade;

        //public Student setId(int id)
        //{
        //    this.id = id;
        //    return this;
        //}

        //public Student setGrade(int grade)
        //{
        //    this.grade = grade;
        //    return this;
        //}
        //public Student setName(string name)
        //{
        //    this.name = name;
        //    return this;
        //}
        //public int getId()
        //{
        //    return id;
        //}

        //public int getGrade()
        //{
        //    return grade;
        //}

        //public string getName()
        //{
        //    return name;
        //}

        public string Name { get; set; }
        public int Grade { get; set; }
        public int Id { get; set; }

        private string addr;

        public String Addr
        {
            get {
                if(addr != null)
                    return addr;
                else
                    return null;
            }
            set { 
                if(value != null)
                    addr = value; }
        }

        public void showInfo()
        {
            Console.WriteLine($"학생이름 : {Name}, 학년 : {Grade}, 학번 : {Id}, 주소 : {Addr}");
        }
    }
}
