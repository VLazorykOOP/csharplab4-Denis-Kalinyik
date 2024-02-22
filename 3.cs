using System;

class Program
{
    static void Main(string[] args)
    {
        // Тут можна створити об'єкти класу MatrixUshort та викликати його методи
        MatrixUshort matrix1 = new MatrixUshort(2, 3, 5);
        MatrixUshort matrix2 = new MatrixUshort(2, 3, 10);
        
        Console.WriteLine("Matrix 1:");
        matrix1.DisplayElements();
        
        Console.WriteLine("Matrix 2:");
        matrix2.DisplayElements();
        
        MatrixUshort sum = matrix1 + matrix2;
        Console.WriteLine("Sum:");
        sum.DisplayElements();
        
        Console.WriteLine("Matrix 1 == Matrix 2: " + (matrix1.Equals(matrix2)));
        
        Console.WriteLine("Matrix 1 code error: " + matrix1.CodeError);
        
        Console.WriteLine("Matrix count: " + MatrixUshort.GetNumMs());
        
        matrix1++;
        Console.WriteLine("Increment Matrix 1:");
        matrix1.DisplayElements();
        
        matrix2--;
        Console.WriteLine("Decrement Matrix 2:");
        matrix2.DisplayElements();
    }
}

public class MatrixUshort
{
    // Поля
    protected ushort[,] ShortIntArray; 
    protected int n, m; 
    protected int codeError; 
    protected static int num_m; 

    // Конструктори
    public MatrixUshort()
    {
        ShortIntArray = new ushort[1, 1];
        n = 1;
        m = 1;
        ShortIntArray[0, 0] = 0;
        codeError = 0;
        num_m++;
    }

    public MatrixUshort(int size1, int size2)
    {
        ShortIntArray = new ushort[size1, size2];
        n = size1;
        m = size2;
        for (int i = 0; i < size1; i++)
        {
            for (int j = 0; j < size2; j++)
            {
                ShortIntArray[i, j] = 0;
            }
        }
        codeError = 0;
        num_m++;
    }

    public MatrixUshort(int size1, int size2, ushort initialValue)
    {
        ShortIntArray = new ushort[size1, size2];
        n = size1;
        m = size2;
        for (int i = 0; i < size1; i++)
        {
            for (int j = 0; j < size2; j++)
            {
                ShortIntArray[i, j] = initialValue;
            }
        }
        codeError = 0;
        num_m++;
    }

    // Деструктор
    ~MatrixUshort()
    {
        Console.WriteLine("Деструктор класу MatrixUshort викликаний.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Введіть елемент [{i},{j}]: ");
                ShortIntArray[i, j] = ushort.Parse(Console.ReadLine());
            }
        }
    }

    public void DisplayElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{ShortIntArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public void AssignValueToElements(ushort value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = value;
            }
        }
    }

    public static int GetNumMs()
    {
        return num_m;
    }

    // Властивості
    public int Size1
    {
        get { return n; }
    }

    public int Size2
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатори
    public ushort this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                codeError = 0;
                return ShortIntArray[i, j];
            }
        }
        set
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
            }
            else
            {
                codeError = 0;
                ShortIntArray[i, j] = value;
            }
        }
    }

    // Перевантаження операторів
    public static MatrixUshort operator +(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            return matrix1;
        }

        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = (ushort)(matrix1[i, j] + matrix2[i, j]);
            }
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        MatrixUshort other = (MatrixUshort)obj;
        
        if (n != other.n || m != other.m)
        {
            return false;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (ShortIntArray[i, j] != other.ShortIntArray[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator ==(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        return matrix1.Equals(matrix2);
    }

    public static bool operator !=(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        return !(matrix1 == matrix2);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + n.GetHashCode();
            hash = hash * 23 + m.GetHashCode();
            return hash;
        }
    }

    public static MatrixUshort operator ++(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix[i, j]++;
            }
        }

        return matrix;
    }

    public static MatrixUshort operator --(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix[i, j]--;
            }
        }

        return matrix;
    }
}

