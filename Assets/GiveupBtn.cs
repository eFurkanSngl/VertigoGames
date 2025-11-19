using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveupBtn : UIBTN
{
    [SerializeField] private GameObject _canvas;
    protected override void OnClick()
    {
        ExitTheGame();
    }

    private void ExitTheGame()
    {
        Application.Quit();
    }
}
