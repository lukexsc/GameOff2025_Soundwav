using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailItem : MonoBehaviour
{
    [SerializeField] private SWDatabase database = default;

    public TMPro.TMP_Text email = default;
    public int mailIndex = default;

    public void UIOpen()
    {
        AudioController.instance.PlayEffectClick();
        database.OpenEmail(mailIndex);
    }
}
