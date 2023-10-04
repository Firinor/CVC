public interface IResourceCreator : ITarget
{
    //public float GetAmountOfWork();
    public ResourceAmount GetResource();
    public bool TryCompleteWork(float workAmount);
    public void ConnectToBuilding(Worker worker);
    public void DisconnectFromBuilding(Worker worker);
}