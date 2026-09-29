namespace PARP_LR1_CSharp.Part2;

public struct ComparisonResult
{
    public double TimeWithoutObjects;
    public double TimeWithObjects;

    public ComparisonResult(double timeWithoutObjects, double timeWithObjects)
    {
        TimeWithoutObjects = timeWithoutObjects;
        TimeWithObjects = timeWithObjects;
    }
}