using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class ReviveBtn : UIBTN
{
    [Inject] private WheelUIManager wheelUIManager;
    [SerializeField] private GameObject _closeGameOverScene;
    [SerializeField] private GameObject _openWheelScene;
    [SerializeField] private WheelResultView _wheelResultView;

    protected override void OnClick()
    {
        RefreshTheGame();
    }

    private void RefreshTheGame()
    {
        wheelUIManager.RefreshUI();
        _closeGameOverScene.SetActive(false);
        _openWheelScene.SetActive(true);
        _wheelResultView.Clear();

        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}