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

        Search("");
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

    public void Search(string searchPhrase)
    {
        searchPhrase = searchPhrase.Replace("@", string.Empty);

        searchBar.text = searchPhrase;
        if (searchPhrase.Trim().Length <= 0) // Show All Users
        {
            bool notPrivate = false;
            int count = 0;
            foreach (UserSearchResult result in results)
            {
                notPrivate = !SWDatabase.PRIVATE_USERS.Contains(result.username.text);
                result.gameObject.SetActive(notPrivate);
                count += (notPrivate) ? 1 : 0;
            }
            resultText.text = $"{count} users";
        }
        else if (searchPhrase.Length >= 3 && (searchPhrase[0] == '$' & searchPhrase[1] == '{' & searchPhrase[2] == '}')) // Search Even Private Users
        {
            searchPhrase = searchPhrase.Substring(3, searchPhrase.Length - 3);
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
        else // Search for specific user
        {
            int count = 0;
            bool containsPhrase = false;
            bool notPrivate = false;
            foreach (UserSearchResult result in results)
            {
                notPrivate = !SWDatabase.PRIVATE_USERS.Contains(result.username.text);
                containsPhrase = result.username.text.Contains(searchPhrase, System.StringComparison.CurrentCultureIgnoreCase);
                result.gameObject.SetActive(containsPhrase & notPrivate);
                count += (containsPhrase & notPrivate) ? 1 : 0;
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

    //
    // UI 
    //

    public void UIShow()
    {
        AudioController.instance.PlayEffectClick();
        Show();
    }

    public void UISearch()
    {
        AudioController.instance.PlayEffectClick();
        Search();
    }
}
