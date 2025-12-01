using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private const string GAME_SCENE = "Prototype";

    public void UIStartGame()
    {
        AudioController.instance.PlayEffectClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME_SCENE);
    }

    public void UIQuitGame()
    {
        AudioController.instance.PlayEffectClick();
        Application.Quit();
    }
}
