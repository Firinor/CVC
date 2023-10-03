public struct ResourcePack : IItem
{
    public ResourceAmount[] Resources;

    public ResourcePack(ResourceEnum resource, int count)
    {
        Resources = new ResourceAmount[1]
        {
            new ResourceAmount(resource, count)
        };
    }
}