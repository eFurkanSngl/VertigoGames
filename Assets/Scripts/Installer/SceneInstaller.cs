using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallSignalBus();
        Container.DeclareSignal<SpinButtonSignal>();
        Container.Bind<IWheelAnim>().To<WheelAnim>().AsSingle();
        Container.Bind<IKnobStabilizer>().To<KnobStabilizer>().AsSingle();
        Container.DeclareSignal<SpinCompletedSignal>();
        Container.Bind<SliceManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<WheelResultView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SpinStageManager>().AsSingle();
        Container.Bind<WheelUIManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RunInventoryManager>().AsSingle();
        Container.DeclareSignal<LeaveSignal>();

    }


    private void InstallSignalBus()
    {
        SignalBusInstaller.Install(Container);
    }
}
