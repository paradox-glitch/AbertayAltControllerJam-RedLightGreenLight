using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject catcher;
    public int lightNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trig");

        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            Debug.Log("Trigplay");


            if (catcher.GetComponent<Catcher>().on[lightNum] && !other.GetComponent<Runner>().hidden)
            {
                Debug.Log("TrigDam");

                other.GetComponent<Runner>().DoDamage();
            }
        }
    }
}
