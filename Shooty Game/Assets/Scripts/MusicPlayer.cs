using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("Music").Length >= 2) {
          Destroy(gameObject);
        }
    }
}
