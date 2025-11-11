using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoMailItem : MonoBehaviour
{
    [SerializeField] private ProtoDatabase database = default;

    public TMPro.TMP_Text email = default;
    public int mailIndex = default;

    public void UIOpen()
    {
        database.OpenEmail(mailIndex);
    }
}
