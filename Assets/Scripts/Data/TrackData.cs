using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrackData", menuName = "Data/Track", order = 2)]
[System.Serializable]
public class TrackData : ScriptableObject
{
    [SerializeField] private string trackName = default;
    [SerializeField] private string username = default;
    [SerializeField] private string time = default;
    [SerializeField] [TextArea(4, 8)] private string description = default;
    [SerializeField] private Comment[] comments = default;
    
    public string TrackName => trackName;
    public string Username => username;
    public string Time => time;
    public string Description => description;
    public Comment[] Comments => comments;
    
    [System.Serializable]
    public class Comment
    {
        [SerializeField] private string username;
        [SerializeField] [TextArea(3, 6)] private string content;

        public string Username => username;
        public string Content => content;
    }
}
