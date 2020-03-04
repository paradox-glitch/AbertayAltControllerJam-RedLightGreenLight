using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catcher : MonoBehaviour
{
    float changeDelay;//Delay between catcher changing lights
    [SerializeField]
    private GameObject[] lights = new GameObject[4];    //The lights which are passed through into the catcher script
    public bool[] on = new bool[4];
    public bool red = false;
    public float[] countdown = new float[4];
    public float charge = 100;
    public Image bar;
    public float N_Green_Presses = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
        if (red)
        {
            lightCountdown();
        }



        bar.fillAmount = Mathf.Lerp(bar.fillAmount, charge / 100, 0.5f);


    }

    void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            red = false;
            
            recharge();
            for (int i = 0; i < 4; i++)
            {
                on[i] = false;
                lights[i].SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.R) && charge >= 100)
        {
            charge = 0;
            red = true;

            //All lights turn amber
            StartCoroutine(AmberLights());


            for (int i = 0; i < 4; i++)
            {
                countdown[i] = Random.Range(0.1f, 0.7f);
            }
            countdown[2] += countdown[3];
            countdown[1] += countdown[2];
            countdown[0] += countdown[1];
        }
    }

    IEnumerator AmberLights()
    {
        yield return new WaitForSeconds(0.0f);
        lights[3].SetActive(true);
        lights[3].GetComponent<Light>().color = Color.white /*new Color(255, 191, 0)*/;
        yield return new WaitForSeconds(0.2f);
        lights[2].SetActive(true);
        lights[2].GetComponent<Light>().color = Color.white /*new Color(255, 191, 0)*/;
        yield return new WaitForSeconds(0.2f);
        lights[1].SetActive(true);
        lights[1].GetComponent<Light>().color = Color.white /*new Color(255, 191, 0)*/;
        yield return new WaitForSeconds(0.2f);
        lights[0].SetActive(true);
        lights[0].GetComponent<Light>().color = Color.white /*new Color(255, 191, 0)*/;
    }

    void lightCountdown()
    {
        //Light countdown routine

        for (int i = 0; i < 4; i++)//Loops for each light
        {
            if (on[i] == false)
                countdown[i] -= Time.deltaTime;//Countdown time decreases over time

            if (countdown[i] <= 0.0f)
            {
                lights[i].GetComponent<Light>().color = Color.red /*new Color(204, 6, 5)*/;
                on[i] = true;//Changes each light when countdown at 0
            }
        }
    }

    void recharge()
    {
        if (charge < 99)
            charge += 100 / N_Green_Presses;
        print(charge);
        if (charge > 99)
            charge = 100;

    }
}