using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//WARNING: THIS SCRIPT DELETES ALL PLAYER PREFS FOR TESTING PURPOSES
public class FlushPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
