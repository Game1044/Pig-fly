using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}