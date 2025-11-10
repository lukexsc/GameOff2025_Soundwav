using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProtoUserSearch : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchBar = default;
    [SerializeField] private TMP_Text resultText = default;
    [SerializeField] private GameObject userResultPrefab = default;
    [SerializeField] private Transform resultParent = default;

    private List<ProtoUserSearchResult> results;

    private static readonly List<string> USERNAMES = new List<string>
    {
        "Shagkem74", "Krankenwagen", "Symphilism", "Botterscutch", "scarylisa", "DrBear", "Baltholly", "Smish2Smush","RadioKilledTheVideoStar", "zyxxyz", "user72838", "user61753", "user18845", "user21283", "user55810", "user33638", "user29606", "user98861", "user83752", "user94638", "user55837", "user72411", "user95161", "user28470", "user17823", "user46954", "user29059", "user16681", "user83063", "user36559", "user16890", "user42215", "user17506", "user93053", "user97790", "user50769", "user39514", "user93828", "user62099", "user78952", "user19526", "user77288", "user58050", "user35401", "user77820", "user26012", "user65685", "user88198", "user21224", "user61810", "user12667", "user53053", "user65773", "user45492", "user63831", "user29860", "user98054", "user63233", "user40771", "user95641", "user41556", "user84261", "user21831", "user17144", "user92587", "user46548", "user50375", "user37538", "user38563", "user13090", "user33246", "user85345", "user55681", "user82041", "user32246", "user13898", "user93830", "user18181", "user52025", "user21875", "user12784", "user17704", "user38941", "user70558", "user13634", "user86212", "user75773", "user44211", "user54919", "user70774", "user14455", "user45244", "user56442", "user70619", "user18499", "user18031", "user41681", "user28205", "user26865", "user35582", "user98593", "user95602", "user98529", "user33404", "user39712", "user88934", "user79578", "user96937", "user93281", "user57896", "user98915", "user43811", "user19833", "user41304", "user50456", "user54812", "user82136", "user82361"
    };

    private void Start()
    {
        USERNAMES.Sort();
        results = new List<ProtoUserSearchResult>(USERNAMES.Count);

        foreach (string user in USERNAMES)
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
        string searchPhrase = searchBar.text;

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
}
