using System;

namespace GradeBook
{
    public class Statistics
    {
       
        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 75.0:
                        return 'A';

                    case var d when d >= 65.0:
                        return 'B';

                    case var d when d >= 50.0:
                        return 'C';

                    case var d when d >= 40.0:
                        return 'A';

                    default:
                        return 'F';

                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }

        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
    }
}