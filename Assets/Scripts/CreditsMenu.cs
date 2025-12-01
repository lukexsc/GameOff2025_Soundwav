using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup credits = default;

    private float counter = 0f;
    private bool done = false;

    private const float WAIT_TIME = 2f;
    private const float FADE_TIME = 1f;
    private const string MAIN_MENU_SCENE = "Main Menu";

    private void Start()
    {
        credits.SetFullVisibility(false);
    }

    private void Update()
    {
        if (done) return;

        counter += Time.deltaTime;

        if (counter > WAIT_TIME + FADE_TIME)
        {
            done = true;
            credits.SetFullVisibility(true);
        }
        else if (counter > WAIT_TIME)
        {
            credits.alpha = (counter - WAIT_TIME) / FADE_TIME;
        }
    }

    public void UIMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MAIN_MENU_SCENE);
    }

    public void UIQuitGame()
    {
        Application.Quit();
    }
}
