using UnityEngine;
 
/// <summary>
/// Inherit from this base class to create a singleton.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError($"Cannot find the instance of {typeof(T).FullName}");
                }

            }
            return instance;
        }

    }

    // Start is called before the first frame update
    protected void Awake()
    {

        if (instance == null)
        {
            instance = this as T;
        }

        else
        {
            Debug.LogError($"Duplicate instance of {typeof(T).FullName}");
        }

    }

    private void OnApplicationQuit()
    {
        instance = null;
    }

}