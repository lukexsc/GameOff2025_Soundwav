using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportOne : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_InputField answerInput = default;
    [SerializeField] private TMP_Text outputText = default;
    [SerializeField] private string correctAnswer = default;
    [SerializeField] private Mailbox mail = default;
    [SerializeField] private SWDatabase database = default;
    [SerializeField] private GameObject reportButton = default;

    public bool Open => canvasGroup.interactable;

    private void OnValidate()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public void SubmitAnswer()
    {
        bool isCorrect = correctAnswer.Equals(answerInput.text, System.StringComparison.CurrentCultureIgnoreCase);
        outputText.text = (isCorrect) ? "Correct!" : "Incorrect";

        if (isCorrect)
        {
            mail.Show();
            mail.ClearEmail();
            Hide();
            database.AddEmail(1);
            reportButton.SetActive(false);
        }
    }

    public void Hide()
    {
        canvasGroup.SetFullVisibility(false);
        outputText.text = "";
    }

    public void Show()
    {
        canvasGroup.SetFullVisibility(true);
    }
}
