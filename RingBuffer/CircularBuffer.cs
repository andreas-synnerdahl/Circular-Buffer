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
            return _write - _read;
        }

        public int Size()
        {
            return _values.Length;
        }

        public T Take()
        {
            var value =  _values[_read];
            _read = (_read + 1) % _values.Length;
            return value;
        }
    }
}