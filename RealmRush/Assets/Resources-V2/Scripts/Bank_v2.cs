using UnityEngine;
using TMPro;

public class Bank_v2 : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int enemiesKilled = 0;

    [SerializeField] int currentBalance;
    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI displayKillCount;
    [SerializeField] GameObject gameOverPanel;

    void Awake()
    {
        Application.targetFrameRate = 60;

        Time.timeScale = 1;

        currentBalance = startingBalance;

        gameOverPanel.SetActive(false);

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;

        displayKillCount.text = "Enemies killed: " + enemiesKilled;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);

        enemiesKilled++;

        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        UpdateDisplay();

        if (currentBalance < 0)
        {
            DisplayGameOver();
        }
    }

    void DisplayGameOver()
    {
        if (gameOverPanel != null)
        {
            displayBalance.enabled = false;

            displayKillCount.enabled = false;

            gameOverPanel.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
