using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedJobs.Test
{
    public class Test
    {
        private ICircularBuffer<T> target;

        [SetUp]
        public void Setup()
        {
            target = new CircularBuffer<int>(10);
        }

        [TestCase('a', ExpectedResult = "a")]
        [TestCase('b', ExpectedResult = "b")]
        [TestCase('x', ExpectedResult = "x")]
        public string RegisterOneTest(char value)
        {
            throw new NotImplementedException()
        }
    }
}
