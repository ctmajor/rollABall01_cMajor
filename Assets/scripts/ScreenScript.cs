using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScreenScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pickup;
    public GameObject winTextObject;
    public GameObject instructionsObject;
    public GameObject countTextObject;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        pickup.SetActive(false);
        winTextObject.SetActive(false);
        instructionsObject.SetActive(false);
        countTextObject.SetActive(false);
    }
}
