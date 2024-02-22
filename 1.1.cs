using System;

enum Color
{
    Red,
    Green,
    Blue,
    Yellow,
    White
}

class Romb
{
    protected int a; // сторона
    protected int d1; // діагональ
    protected Color color; // колір ромба

    // Конструктор
    public Romb(int side, int diagonal, Color c)
    {
        a = side;
        d1 = diagonal;
        color = c;
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return a;
                case 1:
                    return d1;
                case 2:
                    return color;
                default:
                    throw new ArgumentOutOfRangeException("Невірний індекс");
            }
        }
    }

    // Перевантаження операторів ++ і --
    public static Romb operator ++(Romb r)
    {
        r.a++;
        r.d1++;
        return r;
    }

    public static Romb operator --(Romb r)
    {
        r.a--;
        r.d1--;
        return r;
    }

    // Перевантаження сталих true і false
    public static bool operator true(Romb r)
    {
        return r.IsSquare();
    }

    public static bool operator false(Romb r)
    {
        return !r.IsSquare();
    }

    // Перевантаження оператора *
    public static Romb operator *(Romb r, int scalar)
    {
        r.a *= scalar;
        r.d1 *= scalar;
        return r;
    }

    // Перетворення типу Romb в string
    public static implicit operator string(Romb r)
    {
        return $"Сторона: {r.a}, Діагональ: {r.d1}, Колір: {r.color}";
    }

    // Перетворення string в Romb
    public static implicit operator Romb(string s)
    {
        string[] parts = s.Split(',');
        int side = int.Parse(parts[0].Split(':')[1]);
        int diagonal = int.Parse(parts[1].Split(':')[1]);
        Color color = (Color)Enum.Parse(typeof(Color), parts[2].Split(':')[1].Trim());
        return new Romb(side, diagonal, color);
    }

    // Вивести довжини на екран
    public void PrintDimensions()
    {
        Console.WriteLine($"Сторона ромба: {a}");
        Console.WriteLine($"Діагональ ромба: {d1}");
    }

    // Розрахунок периметра ромба
    public int CalculatePerimeter()
    {
        return 4 * a;
    }

    // Розрахунок площі ромба
    public double CalculateArea()
    {
        return 0.5 * a * d1;
    }

    // Перевірка, чи є ромб квадратом
    public bool IsSquare()
    {
        return a == d1;
    }

    // Властивості
    public int Side
    {
        get { return a; }
        set { a = value; }
    }

    public int Diagonal
    {
        get { return d1; }
        set { d1 = value; }
    }

    public Color Color
    {
        get { return color; }
        set { color = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Romb[] rombs = new Romb[5]; // Заданий масив ромбів

        // Ініціалізація ромбів
        rombs[0] = new Romb(3, 4, Color.Red);
        rombs[1] = new Romb(5, 5, Color.Green);
        rombs[2] = new Romb(4, 6, Color.Blue);
        rombs[3] = new Romb(7, 7, Color.Yellow);
        rombs[4] = new Romb(8, 9, Color.White);

        // Виведення інформації про ромби
        for (int i = 0; i < rombs.Length; i++)
        {
            Console.WriteLine($"Ромб {i + 1}:");
            rombs[i].PrintDimensions();
            Console.WriteLine($"Колір ромба: {rombs[i].Color}");
            Console.WriteLine($"Периметр: {rombs[i].CalculatePerimeter()}");
            Console.WriteLine($"Площа: {rombs[i].CalculateArea()}");
            Console.WriteLine($"Чи є квадратом: {rombs[i].IsSquare()}");
            Console.WriteLine();
        }

        // Підрахунок кількості квадратів
        int squareCount = 0;
        foreach (Romb romb in rombs)
        {
            if (romb.IsSquare())
                squareCount++;
        }

        Console.WriteLine($"Кількість квадратів: {squareCount}");

        // Перевірка роботи перевантажених операторів
        Romb testRomb = new Romb(3, 3, Color.Red);
        Console.WriteLine("Початковий ромб: " + testRomb);
        testRomb++;
        Console.WriteLine("Після ++: " + testRomb);
        testRomb--;
        Console.WriteLine("Після --: " + testRomb);
        Console.WriteLine("Перевірка на квадрат: " + (testRomb ? "Так" : "Ні"));
        Console.WriteLine("Перевірка на квадрат (за false): " + (testRomb ? "Ні" : "Так"));
        testRomb = testRomb * 2;
        Console.WriteLine("Після множення на 2: " + testRomb);

        // Перевірка перетворення типів
        string rombString = "Сторона: 4, Діагональ: 4, Колір: Red";
        Romb convertedRomb = rombString;
        Console.WriteLine("Перетворення з string в Romb: " + convertedRomb);
    }
}
