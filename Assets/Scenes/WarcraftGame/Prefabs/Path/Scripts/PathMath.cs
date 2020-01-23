public static class PathMath
{
    public static int Factorial(int number)
    {
        if (number == 0) return 1;
        return (number * Factorial(number - 1));
    }

    public static int BinomialСoefficient(int max, int current)
    {
        return Factorial(max) / (Factorial(current) * Factorial(max - current));
    }
}
