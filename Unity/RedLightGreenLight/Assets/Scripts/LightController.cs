using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public Light light01;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            light01.GetComponent<Light>().color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            light01.GetComponent<Light>().color = Color.green;
        }
    }
}
