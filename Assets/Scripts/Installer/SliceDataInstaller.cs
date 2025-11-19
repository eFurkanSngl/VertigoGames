using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName ="Installer / SliceDataInstaller")]
public class SliceDataInstaller : ScriptableObjectInstaller<SliceDataInstaller>
{
    [Header("All Slice Data")]
    public List<SliceData> Allslices;


    public override void InstallBindings()
    {
        Container.Bind<List<SliceData>>().FromInstance(Allslices).AsSingle();
    }
}
