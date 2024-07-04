CustomList<int> customList = new CustomList<int>();
customList.Add(4);
customList.Add(2);
customList.Add(3);
customList.Add(1);
customList.Add(7);

Console.WriteLine("ALL ITEMS HERE:");
customList.GetAll();
int item = customList.Get(1);
Console.WriteLine($"Итем с индексом 1 = {item}");
bool removed = customList.Remove(2);
Console.WriteLine($"Item 2 removed: {removed}");

Console.WriteLine("All items in the list after removal:");
customList.GetAll();

int foundItem = customList.Find(x => x == 3);
Console.WriteLine($"Found item: {foundItem}");


class CustomList<T>
{
    private T[] items;
    private int count;

    public CustomList()
    {
        items = new T[10];
        count = 0;
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }
        items[count] = item;
        count++;
    }

    public bool Remove(T item)
    {
        int index = Array.IndexOf(items, item, 0, count);
        if (index < 0)
        {
            return false;
        }

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[count - 1] = default(T);
        count--;
        return true;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Индекс выходит за пределы списка.");
        }

        return items[index];
    }

    public T Find(Predicate<T> match)
    {
        for (int i = 0; i < count; i++)
        {
            if (match(items[i]))
            {
                return items[i];
            }
        }

        return default(T);
    }

    public void GetAll()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }
}