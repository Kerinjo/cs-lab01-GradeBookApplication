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
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            else
            {
                int numTop20Percent = (int)(Students.Count * 0.2);
                int studentsWithBetterGrades = 0;

                foreach (var student in Students)
                    if (student.AverageGrade > averageGrade)
                        studentsWithBetterGrades++;

                char gradeLetter = 'A';

                for (int i = 1; i <= studentsWithBetterGrades / numTop20Percent; i++)
                    gradeLetter++;

                if (gradeLetter == 'E')
                    return 'F';

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
