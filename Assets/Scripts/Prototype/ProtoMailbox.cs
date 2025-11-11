using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProtoMailbox : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_Text emailText = default;
    [SerializeField] private TMP_InputField emailTextSelectable = default;
    [SerializeField] private GameObject emailPrefab = default;
    [SerializeField] private Transform emailParent = default;
    
    private void OnValidate()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }
    
    public void AddEmail(in EmailData data, in int index)
    {
        GameObject emailObj = Instantiate(emailPrefab, emailParent);
        emailObj.name = $"Email ({data.Subject})";
        ProtoMailItem email = emailObj.GetComponent<ProtoMailItem>();
        email.email.text = $"{data.Sender}\n{data.Subject}";
        email.mailIndex = index;
        emailObj.SetActive(true);
    }

    public void LoadEmail(in EmailData data)
    {
        emailText.text = data.Content;
        emailTextSelectable.text = data.Content;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
