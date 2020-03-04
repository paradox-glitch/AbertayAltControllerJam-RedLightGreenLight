using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner : MonoBehaviour
{
    float speed = 10.0f;        //How fast the runner moves
    public int lives = 3;       //How many lives the player has before they are out
    public bool hidden = false, dead = false;
    float input;
    public GameObject boxPrefab;
    public GameObject droppedBox, killBox;
    public GameObject Cage;
    float animTime = 0f;
    public GameObject catcher;
    int audioCounter = 0;
    public AudioClip[] chords = new AudioClip[9];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(00);

        if (this.gameObject.tag == "Player1")
        {
            handleInput(KeyCode.Alpha1, KeyCode.A);
        }

        if (this.gameObject.tag == "Player2")
        {
            handleInput(KeyCode.Alpha2, KeyCode.B);
        }
        Respawn();
    }

    void handleInput(KeyCode button, KeyCode sensor)
    {
        if (!hidden && !dead)
        {
            if (Input.GetKeyDown(button))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                GetComponent<Animator>().SetBool("Idle", false);
                animTime = 0.2f;
                GetComponent<AudioSource>().clip = chords[audioCounter];
                GetComponent<AudioSource>().Play();
                audioCounter++;
                if (audioCounter > 8)
                    audioCounter = 0;
            }
            else
            {
                animTime -= Time.deltaTime;
                if (animTime < 0)
                    GetComponent<Animator>().SetBool("Idle", true);
            }
        }

        if (Input.GetKeyDown(sensor) && !dead)
        {
            hidden = true;
            GetComponent<Animator>().SetBool("Idle", true);
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
        if (!dead)
        {
            dead = true;
            lives--;
            GetComponent<Animator>().SetBool("Idle", true);
            killBox = Instantiate(Cage, new Vector3(transform.position.x + 0.5f, transform.position.y + 20, transform.position.z), transform.rotation) as GameObject;
            //killBox.GetComponent<MeshRenderer>().enabled = false;
            killBox.GetComponent<Rigidbody>().AddForce(transform.up * -2000);
            killBox.GetComponent<AudioSource>().Play();
            //killBox.layer = LayerMask.NameToLayer("KillBox");
            //transform.Translate(Vector3.forward * -200 * Time.deltaTime);
        }
    }

    public void Respawn()
    {
        if (dead && lives > 0)
        {
            if (catcher.GetComponent<Catcher>().on[0] || catcher.GetComponent<Catcher>().on[3])
            {
                return;
            }
            else
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                killBox.GetComponent<Rigidbody>().useGravity = false;
                killBox.GetComponent<Rigidbody>().AddForce(transform.up * 5000);
                Destroy(killBox, 1f);
                dead = false;
            }
        }
    }
}