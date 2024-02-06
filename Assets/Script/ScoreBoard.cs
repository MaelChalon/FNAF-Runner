using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI distanceBoard;
    public TextMeshProUGUI pizzaBoard;

    void Update()
    {
        distanceBoard.text = "Score : " + GameManager.Instance.getDistanceScore().ToString();
        pizzaBoard.text = "Pizza : " + GameManager.Instance.getPizza().ToString();
    }
}
