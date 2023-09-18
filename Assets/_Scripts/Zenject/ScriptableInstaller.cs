using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableInstaller", menuName = "Installers/ScriptableInstaller")]
public class ScriptableInstaller : ScriptableObjectInstaller<ScriptableInstaller>
{
    [SerializeField]
    private BattleBalanceScriptableObject battleBalance;
    [SerializeField]
    private StartBuildingScriptableObject startBuildingGrig;

    public override void InstallBindings()
    {
        Container.BindInstance(battleBalance).AsSingle();
        Container.BindInstance(startBuildingGrig).AsSingle();
    }
}