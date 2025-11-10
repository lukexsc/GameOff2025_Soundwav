using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDatabase : MonoBehaviour
{
    [SerializeField] private ProtoUserSearch userSearch = default;
    [SerializeField] private ProtoUserProfile userProfile = default;

    [Header("Users")]
    [SerializeField] private UserData defaultUser = default;
    [SerializeField] private UserData[] users = default;

    [Header("Tracks")]
    [SerializeField] private TrackData defaultTrack = default;
    [SerializeField] private TrackData[] tracks = default;

    public UserData FindUser(in string username)
    {
        foreach (UserData user in users)
        {
            if (user.Username.Equals(username, System.StringComparison.CurrentCultureIgnoreCase))
            {
                return user;
            }
        }
        return defaultUser;
    }

    public TrackData FindTrack(in int trackID)
    {
        foreach (TrackData track in tracks)
        {
            if (track.ID == trackID)
            {
                return track;
            }
        }
        return defaultTrack;
    }

    public void OpenUser(in string username)
    {
        //userSearch.Hide();
        userProfile.Show();
        userProfile.LoadUser(username, FindUser(username));
    }
}
