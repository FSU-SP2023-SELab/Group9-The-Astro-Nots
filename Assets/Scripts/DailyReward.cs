using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct PlayerState                                                        //Placeholder subject to removal
{
    public int coins;
}

public class DailyReward : MonoBehaviour
{
    private int reward = 100;

    public string lastLoginKey = "LastLogin";
    public string loginStreakKey = "LoginStreak";
    
    public PlayerState playerState;                                              //Placeholder struct to demonstrate how PlayerState would be updated moving forward


    // Start is called before the first frame update
    void Start()
    {
        DateTime lastLogin = DateTime.MinValue;
        int loginStreak = 0;

        if (PlayerPrefs.HasKey(lastLoginKey))
        {
            lastLogin = DateTime.Parse(PlayerPrefs.GetString(lastLoginKey));     //Use DateTime parse method to translate string into DateTime object
        }

        if (PlayerPrefs.HasKey(loginStreakKey)) {                                 //Retrieve login streak and calculate how large player's reward should be
            loginStreak = PlayerPrefs.GetInt(loginStreakKey);

            if (loginStreak > 0 && loginStreak % 5 == 0 && reward < 500)      
            {
                reward = 100 * (loginStreak / 5);

                Debug.Log("Reward increased to " + reward);
            }
        }

        TimeSpan timeSinceLastLogin = DateTime.Now - lastLogin;

        Debug.Log("Player's Last Login: " + lastLogin + "\n");
        Debug.Log("Time Since Last Login: " + timeSinceLastLogin + "\n");

        if (timeSinceLastLogin.TotalHours >= 24)                                 //If time since last login >24 && <48 hours give player reward, otherwise reset streak
        {
            if (timeSinceLastLogin.TotalHours < 48) {  
                loginStreak += 1;
                playerState.coins += reward;

                Debug.Log("Login Streak: " + loginStreak + " Days\n");
            } else {
                Debug.Log("Last login time >48 hours ago, login streak reset to 0");
                loginStreak = 0;
            }
            
            PlayerPrefs.SetString(lastLoginKey, DateTime.Now.ToString());        //Save lastLogin as a string under the player's lastLoginKey
            PlayerPrefs.SetInt(loginStreakKey, loginStreak);                      //Save current long streak under player's loginStreakKey
            
            Debug.Log("New last login time saved to play prefs: " + DateTime.Now.ToString() + "\n");

            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //link to UI?
    }
}
