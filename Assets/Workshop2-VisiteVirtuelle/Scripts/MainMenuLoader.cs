using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); 
    }
}
