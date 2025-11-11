using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDatabase : MonoBehaviour
{
    [SerializeField] private ProtoHistory history = default;
    [SerializeField] private ProtoUserSearch userSearch = default;
    [SerializeField] private ProtoUserProfile userProfile = default;
    [SerializeField] private ProtoTrackWindow trackWindow = default;

    [Header("Users")]
    [SerializeField] private UserData[] users = default;

    [Header("Tracks")]
    [SerializeField] private TrackData[] tracks = default;
    
    public void OpenUser(in string username)
    {
        userProfile.Show();
        trackWindow.Hide();
        Optional<UserData> user = FindUser(username);

        if (user.Enabled)
        {
            userProfile.LoadUser(user.Value);
        }
        else
        {
            userProfile.RandomUser(username);
        }

        history.AddUser(username);
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

        history.AddTrack(username, trackName);
    }

    public void LoadHistory(in ProtoHistory.GameState backState)
    {
        if (backState.window == ProtoHistory.Window.UserSearch)
        {
            userProfile.Hide();
            trackWindow.Hide();
            userSearch.Search(backState.search);
        }
        else if (backState.window == ProtoHistory.Window.User)
        {
            userProfile.Show();
            trackWindow.Hide();
            Optional<UserData> user = FindUser(backState.username);

            if (user.Enabled) userProfile.LoadUser(user.Value);
            else userProfile.RandomUser(backState.username);
        }
        else if (backState.window == ProtoHistory.Window.Track)
        {
            trackWindow.Show();
            Optional<TrackData> track = FindTrack(backState.username, backState.trackName);

            if (track.Enabled) trackWindow.LoadTrack(track);
            else trackWindow.RandomTrack(backState.username, backState.trackName);
        }
    }

    private Optional<UserData> FindUser(in string username)
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

    private Optional<TrackData> FindTrack(in string username, in string trackName)
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
}
