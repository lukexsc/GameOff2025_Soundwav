using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmailData", menuName = "Data/Email", order = 3)]
[System.Serializable]
public class EmailData : ScriptableObject
{
    [SerializeField] private string sender = default;
    [SerializeField] private string subject = default;
    [SerializeField] [TextArea(32, 48)] private string content = default;

    public string Sender => sender;
    public string Subject => subject;
    public string Content => content;
}
