using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableInstaller", menuName = "Installers/ScriptableInstaller")]
public class ScriptableInstaller : ScriptableObjectInstaller<ScriptableInstaller>
{
    [SerializeField]
    private SOBattleBalance battleBalance;
    [SerializeField]
    private SOStartBuilding startBuildingGrig;

    public override void InstallBindings()
    {
        Container.BindInstance(battleBalance).AsSingle();
        Container.BindInstance(startBuildingGrig).AsSingle();
    }
}