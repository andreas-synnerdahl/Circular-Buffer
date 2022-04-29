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
            Assert.That(buffer.Count(), Is.Zero);

            buffer.Add(value);            
            Assert.That(buffer.Count(), Is.EqualTo(1));

            var actual = buffer.Take();
            Assert.That(buffer.Count(), Is.Zero);

            return actual;
        }
        
        [TestCase(2, 3, ExpectedResult =new int[] {2, 3})]
        [TestCase(8, 9, ExpectedResult = new int[] { 8, 9 })]
        public int[] RegisterOneTest(int a, int b)
        {
            var buffer = new CircularBuffer<int>(3);
            buffer.Add(a);
            buffer.Add(b);

            return new int[] {buffer.Take(), buffer.Take()};
        }

        [TestCase(1, 2, ExpectedResult = 2)]
        public int SmallBufferTest(int a, int b)
        {
            var buffer = new CircularBuffer<int>(1);

            buffer.Add(a);
            buffer.Add(b);

            return buffer.Take();
        }

        [TestCase(1, 2, 3, ExpectedResult = new int[] { 2, 3 })]
        public int[] AddTwoTakeOneAddAnother(int a, int b, int c)
        {
            var buffer = new CircularBuffer<int>(2);

            buffer.Add(a);
            buffer.Add(b);

            buffer.Take();

            buffer.Add(c);

            return new int[] { buffer.Take(), buffer.Take() }; ;
        }

        [TestCase(2, ExpectedResult =2)]
        [TestCase(8, ExpectedResult = 8)]
        public int TestSize(int size)
        {
            var buffer = new CircularBuffer<int>(size);
            return buffer.Size();
        }


        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 4)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 3)]
        public int TestOverWrite(int size, int[] values)
        {
            var expectedCount = Math.Min(size, values.Length);
            var buffer = new CircularBuffer<int>(size);

            foreach (var value in values)
                buffer.Add(value);

            Assert.That(buffer.Count(), Is.EqualTo(expectedCount));

            var actual = buffer.Take();

            Assert.That(buffer.Count(), Is.EqualTo(expectedCount-1));

            return actual;
        }
    }
}
