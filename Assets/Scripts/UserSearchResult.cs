using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSearchResult : MonoBehaviour
{
    [SerializeField] private SWDatabase database = default;

    public TMPro.TMP_Text username = default;

    public void UIOpen()
    {
        database.OpenUser(username.text);
    }
}
