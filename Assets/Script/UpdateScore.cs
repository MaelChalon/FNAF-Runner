using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI Score = null;

    // Update is called once per frame
    void Update()
    {
        if (Score != null)
        {
            Score.text = "Score : " + GameManager.instance.getScore();
        }
    }
}
