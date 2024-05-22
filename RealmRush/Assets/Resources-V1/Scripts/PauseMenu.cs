using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    bool gameIsPaused = false;

    // Static reference to the PauseMenu instance
    static PauseMenu instance;

    void Start()
    {
        Application.targetFrameRate = 60;

        pauseMenuUI.SetActive(false);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void StartFixed()
    {
        SceneManager.LoadScene("FixedRoadGame");
    }

    public void StartDynamic()
    {
        SceneManager.LoadScene("DynamicGame");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);

        Resume();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
