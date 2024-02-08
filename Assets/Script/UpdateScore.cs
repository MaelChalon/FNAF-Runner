using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;

    void Update()
    {
        scoreText.text = "Score : " + GameManager.instance.getScore();
    }
}
