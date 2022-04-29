using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedJobs
{
    public class CircularBuffer<T>
        : ICircularBuffer<T>
    {
        private T _value;
        public CircularBuffer(int v)
        {
            
        }

        public void Add(T value)
        {
            _value = value;
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
            return _value;
        }
    }
}