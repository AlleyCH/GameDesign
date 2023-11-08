using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public Vector3 originalPos;

    public int SCORE = 1;

    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        originalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosScreen = Input.mousePosition;
        print($"mousePosScreen = {mousePosScreen}");

        mousePosScreen.z = originalPos.z;

        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);
        print($"mousePosWorld = {mousePosWorld}");

       

        Vector3 newPos = this.transform.position;
        newPos.x = mousePosWorld.x;

        this.transform.position = newPos;

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            gameController.AddScore(SCORE);

            Destroy(collision.gameObject);
        }
    }
}
