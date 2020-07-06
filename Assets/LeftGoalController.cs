using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGoalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("test");
        BallController ballTemp = GetComponent<BallController>();

        if (ballTemp != null) 
        {
            ballTemp.changeP2Score(1);
        }
    }
}
