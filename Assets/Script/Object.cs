﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Object : MonoBehaviour
{
    Vector3 target;
    bool isHold;
    void Start()
    {
        isHold = false;
        GameManager.instance.obj.Add(gameObject);
    }

    void Update()
    {
        if (isHold)
        {
            transform.Rotate(0, 1, 0);
        }
        if (this.transform.position.y < 0 )
        {
            Destroy(this.gameObject);
            GameManager.instance.obj.Remove(GameManager.instance.shootObj);
        }
    }
    public void OnMouseUp()
    {
        if (GameManager.instance.obj.Contains(this.gameObject) && GameManager.instance.shootObj == null)
        {
            Debug.Log("içinde var");

            GameManager.instance.shootObj = this.gameObject;
            transform.DOMove(GameManager.instance.hold.transform.position, 0.5f).OnComplete(() => {
                    isHold = true;
                    UIManager.Instance.ShootActive(true);
                    Debug.Log(GameManager.instance.shootscript.isActiveAndEnabled);
                    GameManager.instance.isHold = true;
                });
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            //target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Object"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Student"))
        {
            Debug.Log("çarptı");
        }
    }
}