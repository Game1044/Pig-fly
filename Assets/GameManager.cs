using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] birds;

    public GameObject youWinText;

    public GameObject youLostText;

    private int currentBird = 0;

    private bool gameEnded = false;

    void Update()
    {
        if (!gameEnded)
        {
            CheckWin();
        }
    }

    public void SpawnNextBird()
    {
        currentBird++;

        // ยังมีนก
        if (currentBird < birds.Length)
        {
            birds[currentBird].SetActive(true);
        }
        else
        {
            // นกหมดแล้ว
            Invoke("CheckLose", 3f);
        }
    }

    void CheckWin()
    {
        Enemy[] enemies =
            FindObjectsOfType<Enemy>();

        if (enemies.Length == 0)
        {
            gameEnded = true;

            youWinText.SetActive(true);
        }
    }

    void CheckLose()
    {
        Enemy[] enemies =
            FindObjectsOfType<Enemy>();

        // ถ้ายังมีศัตรู
        if (enemies.Length > 0)
        {
            gameEnded = true;

            youLostText.SetActive(true);
        }
    }
}