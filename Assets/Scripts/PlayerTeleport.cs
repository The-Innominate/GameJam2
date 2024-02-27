using System;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleport;
    [SerializeField] GameManager gameManager;
    [SerializeField] public string tagName;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleport != null)
            {
                if(tagName == null || tagName != null) 
                { 
                    tagName = "Finish";
                    //Check that the teleporter is tagged as a finish
                    if(currentTeleport.CompareTag(tagName))
                    {
                        //If the teleporter is tagged as a finish, call the player win function from the game manager
                        //gameManager.PlayerWin();
                        gameManager.state = GameManager.State.PLAYER_WIN;
                    }

                }
                
                transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
                Console.WriteLine("woks?");

                //Grab the teleporter audio source and play the sound
                currentTeleport.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleport = collision.gameObject;
        }
        if(collision.CompareTag("Finish"))
        {
            gameManager.state = GameManager.State.PLAYER_WIN;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleport) currentTeleport = null;
        }
    }
}
