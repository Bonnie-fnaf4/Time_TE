using UnityEngine;
using Zenject;

public class TimeInstaller : MonoInstaller
{
    [SerializeField] private DataTimeController _dataTimeController;
    [SerializeField] private NetworkController _networkController;
    public override void InstallBindings()
    {
        Container.Bind<DataTimeController>().FromInstance(_dataTimeController).AsSingle();
        Container.Bind<NetworkController>().FromInstance(_networkController).AsSingle();
    }
}
