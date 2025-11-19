using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventListenerMono : MonoBehaviour
{
    private void OnEnable()
    {
        RegisterEvents();
    }

    private void OnDisable()
    {
        UnRegisterEvents();
    }

    protected abstract void RegisterEvents();
    protected abstract void UnRegisterEvents();
}
