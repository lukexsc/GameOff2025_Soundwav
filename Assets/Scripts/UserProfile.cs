using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserProfile : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_Text title = default;
    [SerializeField] private TMP_InputField bio = default;
    [SerializeField] private TMP_Text details = default;
    [SerializeField] private TMP_Text suspendText = default;
    [SerializeField] private GameObject trackPrefab = default;
    [SerializeField] private Transform tracksParent = default;
    [SerializeField] private GameObject friendPrefab = default;
    [SerializeField] private Transform friendsParent = default;

    private List<TrackLink> tracks;
    private List<UserSearchResult> friends;

    private const int TRACKS_COUNT = 12;
    private const int FRIENDS_COUNT = 12;

    private const string SUSPEND_TEXT = "[This account is suspended]";

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
        tracks = new List<TrackLink>();
        for (int i = 0; i < TRACKS_COUNT; i++)
        {
            GameObject resultObj = Instantiate(trackPrefab, tracksParent);
            resultObj.name = $"Track ({i})";
            resultObj.SetActive(true);
            TrackLink result = resultObj.GetComponent<TrackLink>();
            tracks.Add(result);
        }

        friends = new List<UserSearchResult>();
        for (int i = 0; i < FRIENDS_COUNT; i++)
        {
            GameObject resultObj = Instantiate(friendPrefab, friendsParent);
            resultObj.name = $"Friend ({i})";
            resultObj.SetActive(true);
            UserSearchResult result = resultObj.GetComponent<UserSearchResult>();
            friends.Add(result);
        }

        details.text = $"Tracks — {tracks.Count}\nFriends — {friends.Count}";
    }

    public void RandomUser(in string username)
    {
        title.text = username;
        bio.text = "[No bio added.]";
        details.text = $"Tracks — 0\nFriends — 0";
        suspendText.text = "";

        for (int i = 0; i < tracks.Count; i++)
        {
            tracks[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < friends.Count; i++)
        {
            friends[i].gameObject.SetActive(false);
        }
    }

    public void LoadUser(in UserData data)
    {
        if (data.Tracks.Length > tracks.Count)
        {
            for (int i = tracks.Count-1; i < data.Tracks.Length; i++)
            {
                GameObject resultObj = Instantiate(trackPrefab, tracksParent);
                resultObj.name = $"Track ({i})";
                resultObj.SetActive(true);
                TrackLink result = resultObj.GetComponent<TrackLink>();
                tracks.Add(result);
            }
        }

        if (data.Friends.Length > friends.Count)
        {
            for (int i = friends.Count-1; i < data.Friends.Length; i++)
            {
                GameObject resultObj = Instantiate(friendPrefab, friendsParent);
                resultObj.name = $"Friend ({i})";
                resultObj.SetActive(true);
                UserSearchResult result = resultObj.GetComponent<UserSearchResult>();
                friends.Add(result);
            }
        }

        title.text = data.Username;
        bio.text = data.Bio;
        details.text = $"Tracks — {data.Tracks.Length}\nFriends — {data.Friends.Length}";
        suspendText.text = (data.Suspended) ? SUSPEND_TEXT : "";

        for (int i = 0; i < tracks.Count; i++)
        {
            bool isActive = (i < data.Tracks.Length);
            tracks[i].gameObject.SetActive(isActive);

            if (isActive) tracks[i].SetValues(data.Username, data.Tracks[i]);
        }
        
        for (int i = 0; i < friends.Count; i++)
        {
            bool isActive = (i < data.Friends.Length);
            friends[i].gameObject.SetActive(isActive);

            friends[i].username.text = (isActive) ? data.Friends[i] : "";
        }
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
