using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameObject lastSender;
    public int health = 5;
    public AnimationController anim;
    public void TakeDamage(int amount, GameObject sender, GameObject collision)
    {
        if (sender != lastSender)
        {
            health--;
            lastSender = sender;
            if (health < 0)
            {
                Debug.Log(health);
            }
            else if (collision.GetComponent<Object>().hitDamage)
            {
                anim.HitDamage();
            }
            else anim.LowDamage();

            Debug.Log(collision.GetComponent<Object>().hitDamage);
        }
    }

}
