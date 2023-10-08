using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    public float speed = 2f;
    public float timeToStart = 2f;
    public float repeatRate = 0.5f;
    public GameObject applePrefab;
    public float edgeDistance = 24;// appletree will move between -24 to 24
    public float chanceToChangeDirection = 0.1f;
    public int dir = 1;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropApple", timeToStart, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    public void Moving()
    {

        Vector3 newPos = this.transform.position; 
        newPos.x +=  speed* Time.deltaTime * dir;
        this.transform.position = newPos;
     

        if (this.transform.position.x > edgeDistance)
        {
            ChangeDircection(-1);
        }
        // left edge
        else if (this.transform.position.x < -edgeDistance)
        {
            ChangeDircection(1);
        }
        else if (chanceToChangeDirection > Random.value)
        {
            ChangeDircection(-dir);
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab, this.transform.position, Quaternion.identity);

    }

     void ChangeDircection(int dir)
    {
        this.dir = dir;
    }
}
