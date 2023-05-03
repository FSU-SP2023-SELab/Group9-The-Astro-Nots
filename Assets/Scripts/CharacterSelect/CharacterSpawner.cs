using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public CharacterDatabase charDB;
    private GameObject character;
    void Start()
    {
        character = charDB.character[charDB.currCharacter];
        Instantiate(character, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
