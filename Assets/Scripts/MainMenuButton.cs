using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    private const string MAIN_MENU_SCENE = "Main Menu";

    public void UIMainMenu()
    {
        AudioController.instance.PlayEffectClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
