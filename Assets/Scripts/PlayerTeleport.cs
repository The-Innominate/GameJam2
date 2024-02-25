using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleport;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
                Console.WriteLine("woks?");
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleport = collision.gameObject;
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
