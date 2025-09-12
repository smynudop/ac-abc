namespace AtCoder.MyLib;

public class Deque<T>
{
    private T[] list;
    private int tail;
    private int head;
    public int Count {get; private set;}
    public Deque(int capacity)
    {
        this.list = new T[capacity * 2];
        this.tail = capacity;
        this.head = capacity;
        this.Count = 0;
    }

    public T Pop()
    {
        Count -= 1;
        return list[--tail];
    }

    public void Push(T value)
    {
        this.list[tail++] = value;
        Count += 1;
    }

    public T Shift()
    {
        Count--;
        return list[head++];
    }

    public void Unshift(T value)
    {
        this.list[--head] = value;
        Count += 1;
    }

    public T this[int index]
    {
        get
        {
            return this.list[head + index];
        }
    }
}
