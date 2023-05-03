using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public CharacterDatabase charDB;
    
    public void chooseAstro()
    {
        charDB.currCharacter = 0;
    }
    public void chooseShinyAstro()
    {
        charDB.currCharacter = 1;
    }
    public void chooseUgh()
    {
        charDB.currCharacter = 2;
    }
    public void chooseFrog()
    {
        charDB.currCharacter = 3;
    }
    public void chooseShinyFrog()
    {
        charDB.currCharacter = 4;
    }
    public void chooseMask()
    {
        charDB.currCharacter = 5;
    }
    public void chooseUMask()
    {
        charDB.currCharacter = 6;
    }
    public void choosePink()
    {
        charDB.currCharacter = 7;
    }
    public void chooseBlue()
    {
        charDB.currCharacter = 8;
    }
    public void chooseEmo()
    {
        charDB.currCharacter = 9;
    }
}