using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProtoMailbox : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private CanvasGroup backbutton = default;
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

    private void Start()
    {
        Show();
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
        canvasGroup.SetFullVisibility(false);
        backbutton.SetFullVisibility(true);
    }

    public void Show()
    {
        canvasGroup.SetFullVisibility(true);
        backbutton.SetFullVisibility(false);
    }
}
