using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coinText;
    public GameObject shopPanel;
    public GameObject hudPanel;

    public MonoBehaviour driveScript;
    public LevelManager levelManager;

    public int hireCost = 5000;
    int coins; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        coins = 5000;
        UpdateCoinsUI();

        if(shopPanel) shopPanel.SetActive(true);
        if(hudPanel) hudPanel.SetActive(false);

        if (driveScript) driveScript.enabled= false;
    }

    void UpdateCoinsUI()
    {
        if (coinText) coinText.text = $"coins: {coins}";
    }

    public void onHire()
    {
        if (coins < hireCost)
        {
            return; 
        }
        coins -= hireCost;
        PlayerPrefs.SetInt("coins", coins);
        UpdateCoinsUI();

        StartMission();

    }

    void StartMission()
    {
        if (shopPanel) shopPanel.SetActive(false);
        if (hudPanel) hudPanel.SetActive(true);

        if (driveScript) driveScript.enabled = true;

        if (levelManager != null) 
        levelManager.BeginLevel();
    }
}
