using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTrackLink : MonoBehaviour
{
    [SerializeField] private ProtoDatabase database = default;

    public TMPro.TMP_Text trackName = default;
    public string username = default;

    public void UIOpen()
    {
        database.OpenTrack(username, trackName.text);
    }
}
