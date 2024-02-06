using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get { return instance; } }

    public static T instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Debug.LogError($"Already an instance of {GetType()} ! Destroying Object.");
            Destroy(gameObject);
        }
    }

}
