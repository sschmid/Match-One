using System;
using System.Collections.Generic;

public class Rand
{
    public static Rand game;

    readonly Random _random;

    public Rand(int seed)
    {
        _random = new Random(seed);
    }

    public bool Bool(float chance) => Float() < chance;
    public int Int() => _random.Next();
    public int Int(int maxValue) => _random.Next(maxValue);
    public int Int(int minValue, int maxValue) => _random.Next(minValue, maxValue);
    public float Float() => (float)_random.NextDouble();
    public float Float(float minValue, float maxValue) => minValue + (maxValue - minValue) * Float();
    public T Element<T>(IList<T> elements) => elements[Int(0, elements.Count)];
}
