using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserSearch : MonoBehaviour
{
    [SerializeField] private SWHistory history = default;
    [SerializeField] private CanvasGroup canvasGroup = default;
    [SerializeField] private TMP_InputField searchBar = default;
    [SerializeField] private TMP_Text resultText = default;
    [SerializeField] private ScrollRect resultScroll = default;
    [SerializeField] private GameObject userResultPrefab = default;
    [SerializeField] private Transform resultParent = default;

    private List<UserSearchResult> results;
    
    private void OnValidate()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    private void Start()
    {
        results = new List<UserSearchResult>(SWDatabase.ALL_USERS.Count);

        foreach (string user in SWDatabase.ALL_USERS)
        {
            GameObject resultObj = Instantiate(userResultPrefab, resultParent);
            resultObj.name = user;
            resultObj.SetActive(true);

            UserSearchResult result = resultObj.GetComponent<UserSearchResult>();
            result.username.text = user;
            results.Add(result);
        }

        resultText.text = $"{results.Count} users";
    }

    private void Update()
    {
        if (canvasGroup.interactable & Input.GetKeyDown(KeyCode.Return))
        {
            Search();
        }
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
            foreach (UserSearchResult result in results)
            {
                result.gameObject.SetActive(true);
            }
            resultText.text = $"{results.Count} users";
        }
        else // Search for specific user
        {
            int count = 0;
            bool containsPhrase = false;
            foreach (UserSearchResult result in results)
            {
                containsPhrase = result.username.text.Contains(searchPhrase, System.StringComparison.CurrentCultureIgnoreCase);
                result.gameObject.SetActive(containsPhrase);
                count += (containsPhrase) ? 1 : 0;
            }
            resultText.text = $"{count} users containing \"{searchPhrase}\"";
        }
        resultScroll.ResetScroll();
    }

    public void Hide()
    {
        canvasGroup.SetFullVisibility(false);
    }

    public void Show()
    {
        canvasGroup.SetFullVisibility(true);
    }
}
