﻿public interface IResourceCreator : ITarget
{
    //public float GetAmountOfWork();
    public IItem GetResource();
    public bool TryCompleteWork(float workAmount);
}