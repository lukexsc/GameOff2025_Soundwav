using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWHistory : MonoBehaviour
{
    public enum Window { UserSearch, User, Track}

    [SerializeField] private SWDatabase database = default;

    private Stack<GameState> history = default;

    private void Start()
    {
        history = new Stack<GameState>();
        AddUserSearch("");
    }

    public void AddUserSearch(in string search)
    {
        GameState userSearchState = new GameState
        {
            window = Window.UserSearch,
            search = search
        };
        history.Push(userSearchState);
    }
    
    public void AddUser(in string username)
    {
        GameState userState = new GameState
        {
            window = Window.User,
            username = username
        };
        history.Push(userState);
    }

    public void AddTrack(in string username, in string trackName)
    {
        GameState trackState = new GameState
        {
            window = Window.Track,
            username = username,
            trackName = trackName
        };
        history.Push(trackState);
    }

    public void UIGoBack()
    {
        AudioController.instance.PlayEffectClick();

        if (history.Count > 1) history.Pop();

        GameState backState = history.Peek();

        database.LoadHistory(backState);
    }

    public class GameState
    {
        public Window window = default;
        public string search = default;
        public string username = default;
        public string trackName = default;
    }
}
