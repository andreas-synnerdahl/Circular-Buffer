using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs.Test
{
    public class Test
    {


        [TestCase(2, ExpectedResult = 2)]
        public int RegisterOneTest(int value)
        {
            var buffer = new CircularBuffer<int>(3);
            buffer.Add(value);
            return buffer.Take();
        }
        
        [TestCase(2, 3, ExpectedResult =new int[] {2, 3})]
        public int[] RegisterOneTest(int a, int b)
        {
            var buffer = new CircularBuffer<int>(3);
            buffer.Add(a);
            buffer.Add(b);

            return new int[] {buffer.Take(), buffer.Take()};
        }
    }
}
