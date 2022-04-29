namespace OrderedJobs
{
    public interface ICircularBuffer<T>
    {
		void Add(T value);
		T Take();
		int Count();
		int Size();
	}
}
