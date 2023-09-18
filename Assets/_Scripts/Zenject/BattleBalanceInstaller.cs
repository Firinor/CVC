using UnityEngine;
using Zenject;

public class BattleBalanceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BattleBalance>().AsSingle();
        Container.Bind<Player>().WithId("RedPlayer").AsCached();
        Container.Bind<Player>().WithId("BluePlayer").AsCached();
    }
}