using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    private GameManager gameManager;
    public LayerMask restartLayer;

    private void Start()
    {
        // Assuming GameManager is a singleton, you can get the instance like this.
        gameManager = GameManager.Instance;

        // Ensure the GameManager instance is not null before using it.
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found! Make sure GameManager is in the scene.");
        }
    }

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(gameManager.isEnded)
            {
                gameManager.restartGame();
            }
        }
    }
}
