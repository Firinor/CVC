public interface IResourceCreator : ITarget
{
    //public float GetAmountOfWork();
    public ResourcePack GetResource();
    public bool TryCompleteWork(float workAmount);
}