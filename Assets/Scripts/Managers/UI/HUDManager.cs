using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [Header("Health UI Settings")]
    public Image[] heartContainers; 
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject hudPanel;

    private HealthComponent playerHealth;

    void Start()
    {   
        pausePanel.SetActive(false);
        hudPanel.SetActive(true);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerHealth = player.GetComponent<HealthComponent>();

           
            playerHealth.OnDamaged += UpdateHealthUI;

           
            UpdateHealthUI();
        }
        else
        {
            Debug.LogWarning("HUDManager: No object with tag 'Player' found in scene!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void UpdateHealthUI()
    {
        if (playerHealth == null) return;

        float currentHP = playerHealth.GetCurrentHealth();

        for (int i = 0; i < heartContainers.Length; i++)
        {
            int heartThreshold = i * 2;

            if (currentHP >= heartThreshold + 2)
                heartContainers[i].sprite = fullHeart;
            else if (currentHP >= heartThreshold + 1)
                heartContainers[i].sprite = halfHeart;
            else
                heartContainers[i].sprite = emptyHeart;
        }
    }

    private void OnDisable() 
    {
        if (playerHealth != null)
            playerHealth.OnDamaged -= UpdateHealthUI;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        hudPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        hudPanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}