public struct ResourcePack
{
    public ResourceAmount[] Resourses;

    public ResourcePack(Resource resource, int count)
    {
        Resourses = new ResourceAmount[1]
        {
            new ResourceAmount(resource, count)
        };
    }
}