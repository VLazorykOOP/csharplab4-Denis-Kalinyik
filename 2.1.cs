class Program
{
    static void Main(string[] args)
    {
        // Тут можна створити об'єкти класу VectorUshort та викликати його методи
        VectorUshort vector1 = new VectorUshort(3, 5);
        VectorUshort vector2 = new VectorUshort(3, 10);
        
        Console.WriteLine("Vector 1:");
        vector1.DisplayElements();
        
        Console.WriteLine("Vector 2:");
        vector2.DisplayElements();
        
        VectorUshort sum = vector1 + vector2;
        Console.WriteLine("Sum:");
        sum.DisplayElements();
        
        Console.WriteLine("Vector 1 == Vector 2: " + (vector1 == vector2));
        
        Console.WriteLine("Vector 1 code error: " + vector1.CodeError);
        
        Console.WriteLine("Vector count: " + VectorUshort.GetNumVs());
        
        vector1++;
        Console.WriteLine("Increment Vector 1:");
        vector1.DisplayElements();
        
        vector2--;
        Console.WriteLine("Decrement Vector 2:");
        vector2.DisplayElements();
    }
}

public class VectorUshort
{
    // Поля
    protected ushort[] ArrayUShort; 
    protected uint num; 
    protected uint codeError; 
    protected static uint num_vs; 

    // Конструктори
    public VectorUshort()
    {
        ArrayUShort = new ushort[1];
        num = 1;
        ArrayUShort[0] = 0;
        codeError = 0;
        num_vs++;
    }

    public VectorUshort(uint size)
    {
        ArrayUShort = new ushort[size];
        num = size;
        for (int i = 0; i < size; i++)
        {
            ArrayUShort[i] = 0;
        }
        codeError = 0;
        num_vs++;
    }

    public VectorUshort(uint size, ushort initialValue)
    {
        ArrayUShort = new ushort[size];
        num = size;
        for (int i = 0; i < size; i++)
        {
            ArrayUShort[i] = initialValue;
        }
        codeError = 0;
        num_vs++;
    }

    // Деструктор
    ~VectorUshort()
    {
        Console.WriteLine("Деструктор класу VectorUshort викликаний.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент {i}: ");
            ArrayUShort[i] = ushort.Parse(Console.ReadLine());
        }
    }

    public void DisplayElements()
    {
        foreach (ushort element in ArrayUShort)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    public void AssignValueToElements(ushort value)
    {
        for (int i = 0; i < num; i++)
        {
            ArrayUShort[i] = value;
        }
    }

    public static uint GetNumVs()
    {
        return num_vs;
    }

    // Властивості
    public uint Size
    {
        get { return num; }
    }

    public uint CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public ushort this[int index]
    {
        get
        {
            if (index < 0 || index >= num)
            {
                codeError = 1;
                return 0;
            }
            else
            {
                codeError = 0;
                return ArrayUShort[index];
            }
        }
        set
        {
            if (index < 0 || index >= num)
            {
                codeError = 1;
            }
            else
            {
                codeError = 0;
                ArrayUShort[index] = value;
            }
        }
    }

    // Перевантаження операторів
    public static VectorUshort operator +(VectorUshort v1, VectorUshort v2)
    {
        uint size = Math.Max(v1.num, v2.num);
        VectorUshort result = new VectorUshort(size);
        for (int i = 0; i < size; i++)
        {
            result[i] = (ushort)(v1[i] + v2[i]);
        }
        return result;
    }

    public static VectorUshort operator ++(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v[i]++;
        }
        return v;
    }

    public static VectorUshort operator --(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v[i]--;
        }
        return v;
    }

    public static bool operator ==(VectorUshort v1, VectorUshort v2)
    {
        if (v1.num != v2.num)
            return false;
        for (int i = 0; i < v1.num; i++)
        {
            if (v1[i] != v2[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(VectorUshort v1, VectorUshort v2)
    {
        return !(v1 == v2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        VectorUshort other = (VectorUshort)obj;
        if (num != other.num)
            return false;
        for (int i = 0; i < num; i++)
        {
            if (ArrayUShort[i] != other.ArrayUShort[i])
                return false;
        }
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ArrayUShort, num, codeError);
    }

    // Перевантаження операторів порівняння
    public static bool operator >(VectorUshort v1, VectorUshort v2)
    {
        int minLength = (int)Math.Min(v1.num, v2.num);
        for (int i = 0; i < minLength; i++)
        {
            if (v1[i] > v2[i])
                return true;
            else if (v1[i] < v2[i])
                return false;
        }
        return v1.num > v2.num;
    }

    public static bool operator <(VectorUshort v1, VectorUshort v2)
    {
        int minLength = (int)Math.Min(v1.num, v2.num);
        for (int i = 0; i < minLength; i++)
        {
            if (v1[i] < v2[i])
                return true;
            else if (v1[i] > v2[i])
                return false;
        }
        return v1.num < v2.num;
    }

    public static bool operator >=(VectorUshort v1, VectorUshort v2)
    {
        return v1 == v2 || v1 > v2;
    }

    public static bool operator <=(VectorUshort v1, VectorUshort v2)
    {
        return v1 == v2 || v1 < v2;
    }
}
