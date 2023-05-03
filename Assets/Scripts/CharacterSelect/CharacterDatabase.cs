using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public GameObject[] character;
    public int currCharacter;
    public GameObject GetCharacter(int index)
    {
        return character[index];
    }
}
