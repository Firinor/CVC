public struct ResourceAmount
{
    public ResourceEnum Resource;
    public int Count;

    public ResourceAmount(ResourceEnum resource, int count)
    {
        Resource = resource;
        Count = count;
    }
}