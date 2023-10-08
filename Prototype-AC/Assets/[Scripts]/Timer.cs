using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timescale = 1f;
    public float time;
    
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Time.timeScale = timescale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

    }
    private void OnCollisionEnter(Collision col)
    {
        float calcTime = Mathf.Sqrt(-2 *10 / Physics.gravity.y);
        Debug.Log("Time = " + time + ", calcTime = " + calcTime);
    }

}
