using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedJobs
{
    public class CircularBuffer<T>
        : ICircularBuffer<T>
    {
        
        private int _read;
        private int _count;

        private T[] _values;

        public CircularBuffer(int size)
        {
            _values = new T[size];
        }

        public void Add(T value)
        {
            _values[(_read + _count) % _values.Length] = value;
            if (_count < _values.Length)
                _count++;
            else
                _read = (_read + 1) % _values.Length;
        }

        public int Count()
        {
            return _count;
        }

        public int Size()
        {
            return _values.Length;
        }

        public T Take()
        {
            if (_count <= 0)
                throw new Exception("Nothing to take");
            var value =  _values[_read];
            _read = (_read + 1)  % _values.Length;
            _count--;
            return value;
        }
    }
}