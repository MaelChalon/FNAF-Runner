using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePizzaCounter : MonoBehaviour
{
    public TextMeshProUGUI PizzaCounter = null;

    // Update is called once per frame
    void Update()
    {
        if (PizzaCounter != null)
        {
            PizzaCounter.text = "Pizza : " + GameManager.instance.getPizza();
        }
    }
}
