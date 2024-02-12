using TMPro;
using UnityEngine;

public class UpdateLife : MonoBehaviour
{
    public TextMeshProUGUI Life = null;

    // Update is called once per frame
    void Update()
    {
        if (Life != null)
        {
            Life.text = "Life : " + GameManager.instance.getLife();
        }
    }
}
