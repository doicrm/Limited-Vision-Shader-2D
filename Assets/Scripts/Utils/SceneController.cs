using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            ExitGame();
        if (Input.GetKey(KeyCode.N))
            LoadNextScene();
    }

    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(0);
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
