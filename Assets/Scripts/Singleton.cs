using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool n_ShuttingDown = false;
    private static Object n_Lock = new Object();
    private static T n_Instance;


    public static T Instance
    {
        get
        {
            if (n_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance " + typeof(T)
                    + " already destroyed.Returning null");
                return null;

            }
            lock (n_Lock)
            {
                if (n_Instance == null)
                {
                    n_Instance = (T)FindObjectOfType(typeof(T));

                    if (n_Instance == null)
                    {
                        var singletonObject = new GameObject();
                        n_Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (singleton)";
                    }
                }
                
                //DontDestroyOnLoad(n_Instance.gameObject);
                return n_Instance;
            }
        }

    }

    private void OnApplicationQuit()
    {
        n_ShuttingDown = true;
    }
    private void OnDestroy()
    {
        n_ShuttingDown = true;
    }

}