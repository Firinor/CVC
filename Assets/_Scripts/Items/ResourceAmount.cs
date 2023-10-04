public struct ResourceAmount : IItem
{
    public EResource Resource;
    public int Count;

    public ResourceAmount(EResource resource, int count)
    {
        Resource = resource;
        Count = count;
    }
}