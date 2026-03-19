using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [Header("Health UI Settings")]
    public Image[] heartContainers; 
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private HealthComponent playerHealth;

    void Start()
    {
        
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
}