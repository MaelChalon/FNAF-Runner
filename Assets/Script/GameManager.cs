using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private int score = 0;
    private int pizza = 0;
    public bool isEnded = false;
    public Button restartBtn;
    public List<GameObject> Coridors = new List<GameObject>();
    private static int Position = 0;


    private void Start()
    {
        restartBtn.gameObject.SetActive(false);
        InitScene();
    }

    public void addScore()
    {
        score++;
    }

    public int getDistanceScore()
    {
        return score;
    }

    public void addPizza() { pizza++; }

    public int getPizza() { return pizza; }

    public void InitScene()
    {
        restartBtn.gameObject.SetActive(false);
        for (int i = 0; i < 11; i++)
        {
            spawnNewCoridor();
        }
    }

    public void ClearScene()
    {

    }

    public void spawnNewCoridor()
    {
        if (Coridors.Count > 0)
        {
            Position += 10;
            Vector3 spawnPoint = new Vector3(0, 0, Position);

            GameObject.Instantiate(Coridors[UnityEngine.Random.Range(0, 10)], spawnPoint, Quaternion.identity);
        }
    }

    public int getPosition()
    {
        return Position;
    }

    public void endGame()
    {
        isEnded = true;
        restartBtn.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        score = 0;
        pizza = 0;
        restartBtn.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}