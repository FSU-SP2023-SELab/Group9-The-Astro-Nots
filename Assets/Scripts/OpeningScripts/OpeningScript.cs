using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{
    public Canvas openingCanvas, levelCanvas, shopCanvas, customizeCanvas;

    public void openLevel()
    {
        openingCanvas.enabled = false;
        levelCanvas.enabled = true;
    }
    public void returnLevel()
    {
        levelCanvas.enabled = false;
        openingCanvas.enabled = true;
    }

    public void openShop()
    {
        openingCanvas.enabled = false;
        shopCanvas.enabled = true;
    }
    public void returnShop()
    {
        shopCanvas.enabled = false;
        openingCanvas.enabled = true;
    }
    public void openCustom()
    {
        openingCanvas.enabled = false;
        customizeCanvas.enabled = true;
    }
    public void returnCustom()
    {
        customizeCanvas.enabled = false;
        openingCanvas.enabled = true;
    }

    public void playLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void playLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
