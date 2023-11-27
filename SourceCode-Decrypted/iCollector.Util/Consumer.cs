namespace iCollector.Util;

internal class Consumer<T>
{
	public delegate void Accept(T item);
}
