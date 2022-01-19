using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverSreen : MonoBehaviour
{
    public Text pointsText;
    //To activate our GameOver Screen
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text=score.ToString()+" POINTS";
    }
    public void Restartbutton()
    {
        SceneManager.LoadScene("Level 1");
    }

    // public void Exitbutton()
    // {
    //     SceneManager.LoadScene("Main Menu");
    // }
}
