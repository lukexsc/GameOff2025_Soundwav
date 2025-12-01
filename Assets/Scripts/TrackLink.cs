using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackLink : MonoBehaviour
{
    [SerializeField] private SWDatabase database = default;
    [SerializeField] private TMP_Text nameText = default;
    [SerializeField] private TMP_Text detailsText = default;
    
    private string username = default;

    public void SetValues(in string username, in string trackName, in string time, in int comments)
    {
        this.username = username;
        nameText.text = trackName;
        detailsText.text = $"{time}\nComments: {comments}";
    }
    
    public void SetValues(in string username, UserData.UserTrack track)
    {
        this.username = username;
        nameText.text = track.TrackName;
        
        if (track.Data == null)
        {
            int randomSeed = (username + track.TrackName).GetHashCode();
            Random.InitState(randomSeed);

            int minutes = Random.Range(1, 6);
            int seconds = Random.Range(10, 60);

            detailsText.text = $"{minutes}:{seconds}\nComments: 0";
        }
        else
        {
            detailsText.text = $"{track.Data.Time}\nComments: {track.Data.Comments.Length}";
        }
    }

    public void UIOpen()
    {
        AudioController.instance.PlayEffectClick();
        database.OpenTrack(username, nameText.text);
    }
}
