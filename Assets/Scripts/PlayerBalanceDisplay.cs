using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalanceDisplay : MonoBehaviour
{
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coinText.text = "$" + coins.ToString();
    }

    // Update is called once per frame
    void Update() { }
}
