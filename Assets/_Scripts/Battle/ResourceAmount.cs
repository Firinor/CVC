public struct ResourceAmount
{
    public Resource Resource;
    public int Count;

    public ResourceAmount(Resource resource, int count)
    {
        Resource = resource;
        Count = count;
    }
}