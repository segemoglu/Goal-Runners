using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gamePanel,finalPanel,nextLevelPanel;

    public int shoes, yellowCard;

    public Text shoesText, yellowCardText, finalPoint;

    public bool nextLevel=false;

    void Start()
    {
        ArrangePoints();
    }

    public void ArrangePoints()
    {
        if (yellowCard == 2)
        {
            shoes--;
            yellowCard = 0;
        }

        if (shoes < 0)
        {
            GameOver();
        }

        shoesText.text = shoes.ToString();
        yellowCardText.text = yellowCard.ToString();
    }

    public void NextLevel()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        y = y % 3;
        SceneManager.LoadScene(y+1);
    }

    public void TryAgain()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void ArrangeFinalPoint()
    {
        finalPoint.text = shoes.ToString();
    }

    public void GameOver()
    {
        gamePanel.SetActive(false);
        finalPanel.SetActive(true);
        ArrangeFinalPoint();
        if (nextLevel)
        {
            nextLevelPanel.SetActive(true);
        }
    }
}
