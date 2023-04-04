using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DailyReward : MonoBehaviour {

    public GameObject rewardPanel;
    public Text rewardText;
    public Text loginStreakText;

    private int reward = 100;

    public string coinBalanceKey = "Coins";
    public string lastLoginKey = "LastLogin";
    public string loginStreakKey = "LoginStreak";

    public void closeRewardOverlay()
    {
        rewardPanel.SetActive(false);
        Debug.Log("Disable Overlay Called");
    }

    //Initalize Player Prefs
    void Awake()
    {
        if (!PlayerPrefs.HasKey(coinBalanceKey))
        {
            PlayerPrefs.SetInt(coinBalanceKey, 100); //Save 100 starting coins to player's balance
        }
        if (!PlayerPrefs.HasKey(lastLoginKey)) {
            PlayerPrefs.SetString(lastLoginKey, DateTime.Now.ToString()); //Initialize lastLogin as a string under the player's lastLoginKey
        }
        if(!PlayerPrefs.HasKey(loginStreakKey)) {
            PlayerPrefs.SetInt(loginStreakKey, 0); //Initialize login streak to 0
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        DateTime lastLogin = DateTime.MinValue;
        int loginStreak = 0;

        if (PlayerPrefs.HasKey(lastLoginKey))
        {
            lastLogin = DateTime.Parse(PlayerPrefs.GetString(lastLoginKey)); //Use DateTime parse method to translate string into DateTime object
        }

        if (PlayerPrefs.HasKey(loginStreakKey))
        { //Retrieve login streak and calculate how large player's reward should be
            loginStreak = PlayerPrefs.GetInt(loginStreakKey);

            if (reward < 500) {
                reward = Mathf.Min(100 + 50 * (loginStreak - 1), 500);
                Debug.Log("Reward increased to " + reward);
            }

        }

        TimeSpan timeSinceLastLogin = DateTime.Now - lastLogin;

        Debug.Log("Player's Last Login: " + lastLogin + "\n");
        Debug.Log("Time Since Last Login: " + timeSinceLastLogin + "\n");

        Debug.Log("Player Coin Balance: " + coins); //Debugging output for player coin balance

        if (timeSinceLastLogin.TotalHours >= 24  && timeSinceLastLogin.TotalHours < 48) //If time since last login >24 && <48 hours give player reward, otherwise reset streak
        {
                loginStreak += 1;
                coins += reward;

                rewardText.text = reward.ToString(); // Show the player what their reward is for the day
                loginStreakText.text = "Current Streak: " + loginStreak.ToString() + " Days"; // Show the player what their login streak is that day

                rewardPanel.SetActive(true); // Show the reward panel
        }
        else
        {
                Debug.Log("Last login time >48 hours ago, login streak reset to 0");
                loginStreak = 0;
<<<<<<< Updated upstream
            }
            
            PlayerPrefs.SetString(lastLoginKey, DateTime.Now.ToString());        //Save lastLogin as a string under the player's lastLoginKey
            
            Debug.Log("New last login time saved to play prefs: " + DateTime.Now.ToString() + "\n");

            PlayerPrefs.Save();
=======
                rewardPanel.SetActive(false); // Hide the reward panel
>>>>>>> Stashed changes
        }

            PlayerPrefs.SetString(lastLoginKey, DateTime.Now.ToString()); //Save lastLogin as a string under the player's lastLoginKey
            PlayerPrefs.SetInt(loginStreakKey, loginStreak); //Save current long streak under player's loginStreakKey

            PlayerPrefs.SetInt("Coins", coins);

            Debug.Log("New last login time saved to play prefs: " + DateTime.Now.ToString() + "\n");
            Debug.Log("New coin balanced saved to player prefs: " + coins.ToString() + "\n");
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        //link to UI?
    }
<<<<<<< Updated upstream
}
=======

}
>>>>>>> Stashed changes
