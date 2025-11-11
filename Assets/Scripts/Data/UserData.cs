using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "Data/User", order = 1)]
[System.Serializable]
public class UserData : ScriptableObject
{
    [SerializeField] private string username = default;
    [SerializeField] [TextArea(4, 8)] private string bio = default;
    [SerializeField] private string[] friends = default;
    [SerializeField] private UserTrack[] tracks = default;

    public string Username => username;
    public string Bio => bio;
    public string[] Friends => friends;
    public UserTrack[] Tracks => tracks;

    [System.Serializable]
    public class UserTrack
    {
        [SerializeField] private string trackName;
        [SerializeField] private TrackData data;

        public string TrackName => (data == null) ? trackName : data.TrackName;
        public TrackData Data => data;
    }
}
