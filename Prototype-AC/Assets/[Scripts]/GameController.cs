using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [Header("Public Properties")]
    public GameObject basketPrefab;
    public int numberOfBaskets = 3;

    public int basketCount = 3;
    public float basketBottomY = 25f;
    public float basketsInterval = 1.5f;
    public Scoring scoringManager;

    public List<GameObject> baskets;

    // Start is called before the first frame update
    void Start()
    {
       
        scoringManager = GameObject.Find("UI").GetComponent<Scoring>();

        for (int i = 0; i < basketCount; i++)
       {
            GameObject goBasket = Instantiate(basketPrefab);
            Vector3 basketPos = Vector3.zero;
            basketPos.y = basketBottomY+ i* basketsInterval;
            goBasket.transform.position = basketPos;
            baskets.Add(goBasket);
       }        
    }   

    public void AddScore(int amount)
    {
        scoringManager.score += amount;
        scoringManager.TRY_TO_SET_HIGHSCORE(scoringManager.score);
    }
    public void AppleMissed()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        
        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }
        int lastBasketIndex = baskets.Count - 1;
        
        GameObject goBasket = baskets[lastBasketIndex];
        baskets.RemoveAt(lastBasketIndex);

        Destroy(goBasket);
        if (baskets.Count == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
