public enum SceneDirection { basic, exit, options }

public interface ILoadingManager
{
    public bool TheSceneHasLoaded();
    public void SwitchPanels(SceneDirection direction);
    public void SetLoadSceneActive();
}
