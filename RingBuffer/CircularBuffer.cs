using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedJobs
{
    public class CircularBuffer<T>
        : ICircularBuffer<T>
    {
        private int _read;
        private int _write;

        private T[] _values;

        public CircularBuffer(int size)
        {
            _values = new T[size];
        }

        public void Add(T value)
        {
            _values[_write] = value;
            _write = (_write + 1) % _values.Length;
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
            return _values[_read++];
        }
    }
}