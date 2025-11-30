using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSearchResult : MonoBehaviour
{
    [SerializeField] private SWDatabase database = default;

    public TMPro.TMP_Text username = default;
    [HideInInspector] public bool glitched = default;

    public void UIOpen()
    {
        if (glitched) // Hacked User
        {
            database.OpenGlichedUser();
        }
        else // Normal User
        {
            database.OpenUser(username.text);
        }
    }
}
