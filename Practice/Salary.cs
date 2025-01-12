using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Salary:IComparable
    {
        public Salary()
        {

        }
        public int RMB { get; set; }

        public int CompareTo(object obj)
        {

            Salary other = obj as Salary;
            return RMB.CompareTo(other.RMB);
        }

        public static Salary operator+(Salary s1, Salary s2)
        {
            s2.RMB += s1.RMB;
            return s2;     
        }

        class BonuComparer : IComparer
        {
            public int Compare(object? x, object? y)
            {
                throw new NotImplementedException();
            }
        }
    }
}
