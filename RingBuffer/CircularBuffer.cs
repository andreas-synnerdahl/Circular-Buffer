using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedJobs
{
    public class CircularBuffer<T>
        : ICircularBuffer<T>
    {
        public CircularBuffer(int v)
        {
        }

        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public T Take()
        {
            throw new NotImplementedException();
        }
    }
}