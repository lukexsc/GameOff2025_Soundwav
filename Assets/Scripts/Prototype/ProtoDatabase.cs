using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDatabase : MonoBehaviour
{
    [SerializeField] private ProtoUserProfile userProfile = default;
    [SerializeField] private ProtoTrackWindow trackWindow = default;

    [Header("Users")]
    [SerializeField] private UserData[] users = default;

    [Header("Tracks")]
    [SerializeField] private TrackData[] tracks = default;

    public Optional<UserData> FindUser(in string username)
    {
        foreach (UserData user in users)
        {
            if (user.Username.Equals(username, System.StringComparison.CurrentCultureIgnoreCase))
            {
                return new Optional<UserData>(user);
            }
        }
        return new Optional<UserData>();
    }

    public Optional<TrackData> FindTrack(in string username, in string trackName)
    {
        bool matchUsername = false;
        bool matchTrackName = false;
        foreach (TrackData track in tracks)
        {
            matchUsername = track.Username.Equals(username, System.StringComparison.CurrentCultureIgnoreCase);
            matchTrackName = track.TrackName.Equals(trackName, System.StringComparison.CurrentCultureIgnoreCase);
            
            if (matchUsername & matchTrackName)
            {
                return new Optional<TrackData>(track);
            }
        }
        return new Optional<TrackData>();
    }

    public void OpenUser(in string username)
    {
        trackWindow.Hide();
        userProfile.Show();
        Optional<UserData> user = FindUser(username);

        if (user.Enabled)
        {
            userProfile.LoadUser(user.Value);
        }
        else
        {
            userProfile.RandomUser(username);
        }
    }

    public void OpenTrack(in string username, in string trackName)
    {
        trackWindow.Show();
        Optional<TrackData> track = FindTrack(username, trackName);

        if (track.Enabled)
        {
            trackWindow.LoadTrack(track);
        }
        else
        {
            trackWindow.RandomTrack(username, trackName);
        }
    }
}
