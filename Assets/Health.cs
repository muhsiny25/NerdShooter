using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameObject lastSender;
    public int health = 5;
    public void TakeDamage(int amount, GameObject sender)
    {
        if (sender != lastSender)
        {
            health--;
            Debug.Log(health);
            lastSender = sender;
        }
    }
}
