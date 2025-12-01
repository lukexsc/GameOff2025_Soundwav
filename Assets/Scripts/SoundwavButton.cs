using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwavButton : MonoBehaviour
{
    [SerializeField] private SWHistory history = default;
    [SerializeField] private UserSearch userSearch = default;
    [SerializeField] private UserProfile userProfile = default;
    [SerializeField] private TrackWindow trackWindow = default;
    [SerializeField] private Mailbox mailbox = default;
    [SerializeField] private ReportOne report = default;

    public void OpenSoundwav()
    {
        AudioController.instance.PlayEffectClick();

        if (!mailbox.Open && !report.Open)
        {
            userProfile.Hide();
            trackWindow.Hide();
            userSearch.Search("");
            history.AddUserSearch("");
        }

        mailbox.Hide();
        report.Hide();
    }
}
