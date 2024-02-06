using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    private int score = 0;
    public List<GameObject> Coridors = new List<GameObject>();
    private static int Position = 0;

    public void addScore()
    {
        score++;
    }

    public void InitScene()
    {
        for (int i = 0; i< 11; i++) {
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

            GameObject.Instantiate(Coridors[0], spawnPoint, Quaternion.identity);
        }
    }

    public int getPosition()
    {
        return Position;
    }
     
}