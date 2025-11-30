using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlitchedProfile : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_Text title = default;
    [SerializeField] private TMP_Text bio = default;
    [SerializeField] private RectTransform loadBar = default;
    [SerializeField] private TrackPlayer songPlayer = default;

    private float glitchCounter;
    private float loadCounter;
    private bool openedSong;

    private const float GLITCH_TIME = 0.11f;
    private const float LOAD_SONG_TIME = 5f;

    public bool Open => canvasGroup.interactable;

    private void OnValidate()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    private void Start()
    {
        canvasGroup.SetFullVisibility(false);
    }

    private void Update()
    {
        if (!Open) return;

        glitchCounter += Time.deltaTime;
        loadCounter += Time.deltaTime;

        if (glitchCounter > GLITCH_TIME)
        {
            glitchCounter -= GLITCH_TIME;
            title.text = Tools.GetGlitchString(15);
            bio.text = Tools.GetGlitchString(25);
        }

        if (openedSong) return;

        loadBar.localScale = new Vector3(loadCounter / LOAD_SONG_TIME, 1f, 1f);
        if (loadCounter > LOAD_SONG_TIME)
        {
            openedSong = true;
            songPlayer.Activate(TrackPlayer.Option.quit);
        }
    }

    public void LoadGlitchedUser()
    {
        openedSong = false;
        glitchCounter = Random.value * GLITCH_TIME;
        loadCounter = 0f;
        loadBar.localScale = new Vector3(0f, 1f, 1f);
        canvasGroup.SetFullVisibility(true);
    }

    public void Hide()
    {
        canvasGroup.SetFullVisibility(false);
    }

    public void Show()
    {
        canvasGroup.SetFullVisibility(true);
    }

    public void UIClose()
    {
        Hide();
    }
}
