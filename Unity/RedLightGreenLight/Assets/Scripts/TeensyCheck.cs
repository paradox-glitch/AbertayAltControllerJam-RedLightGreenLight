using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeensyCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("RED");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("GREEN");
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Player1-Down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Player2-Down");
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log("Player1-Up");
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Debug.Log("Player2-Up");
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sensor1-Down");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Sensor2-Down");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("Sensor1-Up");
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log("Sensor2-Up");
        }
    }
}
