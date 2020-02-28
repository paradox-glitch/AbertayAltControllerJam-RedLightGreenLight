using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    float speed = 10.0f;//How fast the runner moves
    public int lives = 3;//How many lives the player has before they are out
    public bool hidden = false;
    float input;
    public GameObject boxPrefab;
    public GameObject droppedBox, killBox;
    bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Player1")
        {
            handleInput(KeyCode.Alpha1, KeyCode.A);
        }

        if (this.gameObject.tag == "Player2")
        {
            handleInput(KeyCode.Alpha2, KeyCode.B);
        }

        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void handleInput(KeyCode button, KeyCode sensor)
    {
        if (!hidden)
        {
            if (Input.GetKeyDown(button))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(sensor))
        {
            hidden = true;
            droppedBox = Instantiate(boxPrefab, new Vector3(transform.position.x +0.5f, transform.position.y +20, transform.position.z), transform.rotation) as GameObject;
            droppedBox.GetComponent<Rigidbody>().AddForce(transform.up * -2000);
        }
        else if (Input.GetKeyUp(sensor))
        {
            droppedBox.GetComponent<Rigidbody>().useGravity = false;
            droppedBox.GetComponent<Rigidbody>().AddForce(transform.up * 5000);
            Destroy(droppedBox, 1f);
            hidden = false;
        }
    }

    public void DoDamage()
    {
        if (firstTime)
        {
            lives--;
            killBox = Instantiate(boxPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y + 20, transform.position.z), transform.rotation) as GameObject;
            killBox.GetComponent<MeshRenderer>().enabled = false;
            killBox.GetComponent<Rigidbody>().AddForce(transform.up * -2000);
            killBox.layer = LayerMask.NameToLayer("KillBox");
            //transform.Translate(Vector3.forward * -200 * Time.deltaTime);
            firstTime = false;
        }
    }
}
