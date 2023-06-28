using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> // T parameter to say that we can pass any Type we want there
{
    private static T instance;
    public static T Instance { get { return instance; } } // public getter

    // protected are only visible to the class AND to the ones inheriting from it
    protected virtual void Awake() {
        // Destroy instance duplicata
        if (instance != null && this.gameObject != null) {
            Destroy(gameObject);
        } else {
            instance = (T)this;
        }

        // Escape parent objects on scene
        if (!gameObject.transform.parent) {
            DontDestroyOnLoad(gameObject); // Don't destroy object when loading a new scene
        }


    }
}
