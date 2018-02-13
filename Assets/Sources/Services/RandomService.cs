using System;
using System.Collections.Generic;

public class RandomService {

    public static RandomService game = new RandomService();
    public static RandomService view = new RandomService();

    Random _random;

    public void Initialize(int seed) {
        _random = new Random(seed);
    }

    public bool Bool(float chance) {
        return Float() < chance;
    }

    public int Int() {
        return _random.Next();
    }

    public int Int(int maxValue) {
        return _random.Next(maxValue);
    }

    public int Int(int minValue, int maxValue) {
        return _random.Next(minValue, maxValue);
    }

    public float Float() {
        return (float)_random.NextDouble();
    }

    public float Float(float minValue, float maxValue) {
        return minValue + (maxValue - minValue) * Float();
    }

    public T Element<T>(IList<T> elements) {
        return elements[Int(0, elements.Count)];
    }
}
