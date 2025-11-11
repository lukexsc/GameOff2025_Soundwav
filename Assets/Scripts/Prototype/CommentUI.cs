using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommentUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scalingText = default;
    [SerializeField] private TMP_Text username = default;
    [SerializeField] private TMP_Text comment = default;

    public void SetUsername(in string username)
    {
        this.username.text = username;
    }

    public void SetComment(in string comment)
    {
        scalingText.text = "\n" + comment;
        this.comment.text = comment;
    }
}
