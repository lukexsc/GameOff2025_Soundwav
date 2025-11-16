using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProtoReportOne : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_InputField answerInput = default;
    [SerializeField] private TMP_Text outputText = default;
    [SerializeField] private string correctAnswer = default;

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
