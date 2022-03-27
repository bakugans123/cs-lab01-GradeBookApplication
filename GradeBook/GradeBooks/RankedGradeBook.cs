using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;

        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int BetterGrade = 0;

            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                {
                    BetterGrade++;
                }
            }
            if (BetterGrade >= 0.8 * Students.Count)
            {
                return 'A';
            }
            else if (BetterGrade >= 0.6 * Students.Count)
            {
                return 'B';
            }
            else if (BetterGrade >= 0.4 * Students.Count)
            {
                return 'C';
            }
            else if (BetterGrade >= 0.2 * Students.Count)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }





    }
}
