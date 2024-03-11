using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            else
            {
                int greaterGradeCount = 0;
                foreach (Student student in Students)
                    if (student.AverageGrade > averageGrade)
                        greaterGradeCount += 1;

                int numTop20Percent = (int)(Students.Count * 0.2);
                char gradeLetter = 'A';

                for (int i = 1; i <= Students.Count; i++)
                {
                    if (i % numTop20Percent == 0)
                        gradeLetter++;
                }

                return gradeLetter;
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
