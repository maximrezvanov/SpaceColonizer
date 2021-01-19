using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


//[System.Serializable] public class EventGameState: UnityEvent<GameManager.GameState, GameManager.GameState>
//{

//}

public class GameManager : MonoBehaviour
{
    #region Singelton

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager instance = null;



    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
    }
    #endregion


    //public EventGameState OnGameStateChanged;

    public enum GameState
    {
        Running,
        Pause,
        GameOver
    }

    GameState _currentGameState = GameState.Running;
    public GameState CurrentGameState
    {
        get
        {
            return _currentGameState;
        }
        set
        {
            _currentGameState = value;
        }
    }


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        //EventManager.Instance.AddListener(EVENT_TYPE.NEXT_LEVEL, this);
        //EventManager.Instance.AddListener(EVENT_TYPE.DEAD, this);


    }

    public void LoadFirstLevel()//lose
    {
        
        Debug.Log("LoadFirstLevel");
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(NextLevel());
        Debug.Log("LoadNextLevel");

    }

   

    public void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        //OnGameStateChanged.Invoke(_currentGameState, previousGameState);

        switch (_currentGameState)
        {
            case GameState.Pause:
                //TODO: PAUSE
                break;
            case GameState.GameOver:
                break;
            default:
                break;
        }

    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1.5f);

        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 1;
        }
        SceneManager.LoadScene(nextLevelIndex);

    }


    //public void OnEvent(EVENT_TYPE Event_Type)
    //{
    //    switch (Event_Type)
    //    {
    //        case EVENT_TYPE.NEXT_LEVEL:
    //            LoadNextLevel();
    //            break;

    //        case EVENT_TYPE.DEAD:
    //            Debug.Log("dead");
    //            _currentGameState = GameState.GameOver;

    //            break;
    //    }

    //}
}
