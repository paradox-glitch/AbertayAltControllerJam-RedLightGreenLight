using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public Runner player1;
    public Runner player2;
    public Catcher The_Catcher;
    public Text VictorText;
    public AudioSource horray;

    // Start is called before the first frame update
    void Start()
    {
        VictorText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        WinConditions();

        if(Input.GetKeyDown(KeyCode.F))
            horray.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            Debug.Log("Player 1 Wins!");
            VictorText.text = "Player 1 Wins";
            player2.hidden = true;
            horray.Play();
            //Output text to screen
            //Press any button to restart
        }

        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("Player 2 Wins");
            VictorText.text = "Player 2 Wins";
            player1.hidden = true;
            horray.Play();
            //Stop player 2 from moving
            //Output text to screen
            //Press any button to restart
        }
    }

    void WinConditions()
    {
        if (player1.lives == 0 && player2.lives == 0)
        {
            Debug.Log("The Catcher wins");
            VictorText.text = "The Catcher Wins";
            horray.Play();
            //Output text to screen
            //Press any button to restart or restart after set time
        }

    }
}
