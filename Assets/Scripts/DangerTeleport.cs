using AOT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerTeleport : PlayerTeleport
{
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
    }
}
