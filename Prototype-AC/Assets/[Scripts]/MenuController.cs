using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void Level2()
    {
        SceneManager.LoadScene(2);

    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Options()
    {
        SceneManager.LoadScene(4);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
