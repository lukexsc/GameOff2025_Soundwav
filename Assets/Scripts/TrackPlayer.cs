using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackPlayer : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_Text timeCount = default;
    [SerializeField] private RectTransform timeIndicator = default;
    [SerializeField] private RectTransform[] waveformLines = default;
    [SerializeField] private AudioSource musicPlayer = default;

    private float counter = 0f;

    private const string WAVEFORM_SEED = "TheSong";
    private const float WAVE_MIN_HEIGHT = 12f;
    private const float WAVE_MAX_HEIGHT = 130f;
    private const float LINE_MAX_POS = 1760f;
    private const float SONG_LENGTH_SECONDS = 291f;
    private const float QUIT_TIME = 17.5f;

    private void Start()
    {
        canvasGroup.SetFullVisibility(false);
    }

    private void Update()
    {
        counter += Time.deltaTime;
        timeCount.text = (counter < 10f) ? $"0:0{Mathf.FloorToInt(counter)}" : $"0:{Mathf.FloorToInt(counter)}";

        timeIndicator.anchoredPosition = Vector2.right * LINE_MAX_POS * (counter / SONG_LENGTH_SECONDS);

        if (counter > QUIT_TIME)
        {
            Application.Quit();
            musicPlayer.Stop();
        }
    }

    public void Activate()
    {
        canvasGroup.SetFullVisibility(true);

        timeCount.text = "0:00";
        timeIndicator.anchoredPosition = Vector2.zero;

        Random.InitState(WAVEFORM_SEED.GetHashCode());
        SetWaveform();

        musicPlayer.Play();
    }

    private void SetWaveform()
    {
        float height = 0f;
        foreach (RectTransform line in waveformLines)
        {
            height = Random.value * WAVE_MAX_HEIGHT;
            height = Mathf.Max(WAVE_MIN_HEIGHT, height);
            line.sizeDelta = new Vector2(line.sizeDelta.x, height);
        }
    }
}
