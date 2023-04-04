using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{

    public GameObject RewardPanel;
    public Text RewardText;
    public Text LoginStreakText;

    private int reward = 100;

    public string coinBalanceKey = "Coins";
    public string lastLoginKey = "LastLogin";
    public string loginStreakKey = "LoginStreak";

    public void closeRewardOverlay()
    {
        RewardPanel.SetActive(false);
        Debug.Log("Disable Overlay Called");
    }

    //Initalize Player Prefs
    void Awake()
    {
        if (!PlayerPrefs.HasKey(coinBalanceKey))
        {
            PlayerPrefs.SetInt(coinBalanceKey, 100); //Save 100 starting coins to player's balance
        }
        if (!PlayerPrefs.HasKey(lastLoginKey))
        {
            PlayerPrefs.SetString(lastLoginKey, DateTime.Now.ToString()); //Initialize lastLogin as a string under the player's lastLoginKey
        }
        if (!PlayerPrefs.HasKey(loginStreakKey))
        {
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

            if (loginStreak >= 5 && loginStreak % 5 == 0 && reward < 500)
            {
                reward = 100 * (loginStreak / 5);

                Debug.Log("Reward increased to " + reward);
            }
        }

        TimeSpan timeSinceLastLogin = DateTime.Now - lastLogin;

        Debug.Log("Player's Last Login: " + lastLogin + "\n");
        Debug.Log("Time Since Last Login: " + timeSinceLastLogin + "\n");

        Debug.Log("Player Coin Balance: " + coins); //Debugging output for player coin balance

        if (timeSinceLastLogin.TotalHours >= 24) //If time since last login >24 && <48 hours give player reward, otherwise reset streak
        {
            if (timeSinceLastLogin.TotalHours < 48)
            {
                loginStreak += 1;
                coins += reward;

                RewardPanel.SetActive(true); // Show the reward panel
                RewardText.text = reward.ToString(); // Show the player what their reward is for the day
                LoginStreakText.text = "Current Streak: " + loginStreak.ToString() + " Days"; // Show the player what their login streak is that day
            }
            else
            {
                Debug.Log("Last login time >48 hours ago, login streak reset to 0");
                loginStreak = 0;
                RewardPanel.SetActive(false); // Hide the reward panel
            }

            PlayerPrefs.SetString(lastLoginKey, DateTime.Now.ToString()); //Save lastLogin as a string under the player's lastLoginKey
            PlayerPrefs.SetInt(loginStreakKey, loginStreak); //Save current long streak under player's loginStreakKey

            PlayerPrefs.SetInt("Coins", coins);

            Debug.Log("New last login time saved to play prefs: " + DateTime.Now.ToString() + "\n");
            Debug.Log("New coin balanced saved to player prefs: " + coins.ToString() + "\n");
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        //link to UI?
    }

}