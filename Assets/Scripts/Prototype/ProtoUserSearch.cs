using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProtoUserSearch : MonoBehaviour
{
    [SerializeField] private ProtoHistory history = default;
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_InputField searchBar = default;
    [SerializeField] private TMP_Text resultText = default;
    [SerializeField] private GameObject userResultPrefab = default;
    [SerializeField] private Transform resultParent = default;

    private List<ProtoUserSearchResult> results;
    
    private void OnValidate()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    private void Start()
    {
        results = new List<ProtoUserSearchResult>(ProtoDatabase.ALL_USERS.Count);

        foreach (string user in ProtoDatabase.ALL_USERS)
        {
            GameObject resultObj = Instantiate(userResultPrefab, resultParent);
            resultObj.name = user;
            resultObj.SetActive(true);

            ProtoUserSearchResult result = resultObj.GetComponent<ProtoUserSearchResult>();
            result.username.text = user;
            results.Add(result);
        }

        resultText.text = $"{results.Count} users";
    }
    
    public void Search()
    {
        Search(searchBar.text);
        history.AddUserSearch(searchBar.text);
    }

    public void Search(in string searchPhrase)
    {
        searchBar.text = searchPhrase;
        if (searchPhrase.Trim().Length <= 0) // Show All Users
        {
            foreach (ProtoUserSearchResult result in results)
            {
                result.gameObject.SetActive(true);
            }
            resultText.text = $"{results.Count} users";
        }
        else // Search for specific user
        {
            int count = 0;
            bool containsPhrase = false;
            foreach (ProtoUserSearchResult result in results)
            {
                containsPhrase = result.username.text.Contains(searchPhrase, System.StringComparison.CurrentCultureIgnoreCase);
                result.gameObject.SetActive(containsPhrase);
                count += (containsPhrase) ? 1 : 0;
            }
            resultText.text = $"{count} users containing \"{searchPhrase}\"";
        }
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
