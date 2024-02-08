using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePizza : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;

    void Update()
    {
        scoreText.text = "Pizza : " + GameManager.instance.getPizza();
    }
}
