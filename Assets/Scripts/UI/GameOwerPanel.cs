using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public abstract class GameOwerPanel : MonoBehaviour
{
    SceneManager sceneManager;
    Button[] _buttons;

    private void Start() {
        _buttons = GetComponentsInChildren<Button>();
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        DisableButtons();
    }

    public void OutToMenu()
    {
        SceneManager.LoadScene(0);
        DisableButtons();
    }

    private void DisableButtons()
    {
        foreach (var button in _buttons)
        {
            button.SetEnabled(false);
        }
    }

}
