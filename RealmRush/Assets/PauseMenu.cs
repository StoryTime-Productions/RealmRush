using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] PostProcessVolume postProcessVolume;
    [SerializeField] TMP_Text toggleText;

    public static bool gameIsPaused;

    public static bool postProcessingOff;

    void Start()
    {
        gameIsPaused = false;

        Application.targetFrameRate = 60;

        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);

        if (postProcessingOff)
        {
            postProcessVolume.enabled = false;

            toggleText.text = "Enable Post Processing";
        }
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

    public void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

    public void TogglePostProcessing()
    {
        if (postProcessVolume != null)
        {
            postProcessingOff = !postProcessingOff;

            postProcessVolume.enabled = !postProcessingOff;

            toggleText.text = postProcessingOff ? "Enable Post Processing" : "Disable Post Processing";
        }
    }
}
