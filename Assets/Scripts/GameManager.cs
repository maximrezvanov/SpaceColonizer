using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



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
     
    }

    public void LoadFirstLevel()
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


    
}
