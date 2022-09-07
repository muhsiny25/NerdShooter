using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    public AnimationController anim;
    void Start()
    {

        InvokeRepeating("SetAnimation", 2.0f, 2.0f);

    }

    void Update()
    {

    }
    public void SetAnimation()
    {
        StartCoroutine(SetAnimationC());
    }
    
    public IEnumerator SetAnimationC()
    {
        anim.Idle();
        yield return new WaitForSeconds(2);
        anim.Idle2();
        Debug.Log("deneme");
    }
}
