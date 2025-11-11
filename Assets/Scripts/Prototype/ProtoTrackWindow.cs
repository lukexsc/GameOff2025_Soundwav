using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProtoTrackWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_Text title = default;
    [SerializeField] private TMP_Text username = default;
    [SerializeField] private TMP_Text time = default;
    [SerializeField] private TMP_Text description = default;
    [SerializeField] private GameObject commentPrefab = default;
    [SerializeField] private Transform commentParent = default;
    [SerializeField] private RectTransform[] waveformLines = default;

    private int trackID;
    private List<CommentUI> comments;

    private const int COMMENTS_COUNT = 12;
    private const float WAVE_MIN_HEIGHT = 12f;
    private const float WAVE_MAX_HEIGHT = 130f;
    
    private void OnValidate()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    private void Start()
    {
        comments = new List<CommentUI>();
    }

    public void RandomTrack(in string username, in string trackName)
    {
        title.text = trackName;
        this.username.text = username;

        int randomSeed = (username + trackName).GetHashCode();
        Random.InitState(randomSeed);

        int minutes = Random.Range(1, 6);
        int seconds = Random.Range(10, 60);

        time.text = $"{minutes}:{seconds}";
        description.text = "[No description added.]";

        foreach (CommentUI comment in comments)
        {
            comment.gameObject.SetActive(false);
        }

        SetWaveform();
    }

    public void LoadTrack(in TrackData data)
    {
        title.text = data.TrackName;
        username.text = data.Username;
        time.text = data.Time;
        description.text = data.Description;

        if (comments.Count < data.Comments.Length)
        {
            for (int i = comments.Count; i < data.Comments.Length; i++)
            {
                GameObject commentObj = Instantiate(commentPrefab, commentParent);
                commentObj.name = $"Comment ({i})";
                CommentUI comment = commentObj.GetComponent<CommentUI>();
                comments.Add(comment);
            }
        }

        for (int i=0; i < comments.Count; i++)
        {
            bool isActive = (i < data.Comments.Length);
            comments[i].gameObject.SetActive(isActive);
            comments[i].SetUsername(data.Comments[i].Username);
            comments[i].SetComment(data.Comments[i].Content);
        }

        int randomSeed = (data.Username + data.TrackName).GetHashCode();
        Random.InitState(randomSeed);
        SetWaveform();
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
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
