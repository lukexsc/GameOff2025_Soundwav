using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrackData", menuName = "Data/Track", order = 2)]
[System.Serializable]
public class TrackData : ScriptableObject
{
    [SerializeField] private int id = default;
    [SerializeField] private string trackName = default;
    [SerializeField] [TextArea(4, 8)] private string description = default;
    [SerializeField] private Comment[] comments = default;

    public int ID => id;
    public string TrackName => trackName;
    public string Description => description;
    public Comment[] Comments => comments;

    public void RandomizeID()
    {
        id = Random.Range(int.MinValue, int.MaxValue);
    }

    [System.Serializable]
    public class Comment
    {
        [SerializeField] private string username;
        [SerializeField] [TextArea(3, 6)] private string content;

        public string Username => username;
        public string Content => content;
    }
}
