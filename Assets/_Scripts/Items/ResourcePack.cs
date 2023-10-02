public struct ResourcePack : IItem
{
    public ResourceAmount[] Resourses;

    public ResourcePack(ResourceEnum resource, int count)
    {
        Resourses = new ResourceAmount[1]
        {
            new ResourceAmount(resource, count)
        };
    }
}