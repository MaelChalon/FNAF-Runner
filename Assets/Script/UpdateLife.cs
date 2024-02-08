using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLife : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;

    void Update()
    {
        scoreText.text = "Life : " + GameManager.instance.getLife();
    }
}
