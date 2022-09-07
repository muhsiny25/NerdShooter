using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Object : MonoBehaviour
{
    Vector3 target;
    bool isHold;
    public bool hitDamage;
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
            GameManager.instance.Explosion.transform.position = this.gameObject.transform.position;
            GameManager.instance.Explosion.Play();
        }
    }
    public void OnMouseUp()
    {
        if (GameManager.instance.obj.Contains(this.gameObject) && GameManager.instance.shootObj == null)
        {
            //Debug.Log("içinde var");

            GameManager.instance.shootObj = this.gameObject;
            transform.DOMove(GameManager.instance.hold.transform.position, 0.5f).OnComplete(() => {
                    isHold = true;
                    UIManager.Instance.ShootActive(true);
                    //Debug.Log(GameManager.instance.shootscript.isActiveAndEnabled);
                    GameManager.instance.isHold = true;
                });
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            //target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.Explosion.transform.position = this.gameObject.transform.position;
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Object"))
        {
            Destroy(this.gameObject);

            //Debug.Log(collision.gameObject);


        }
        if (collision.gameObject.CompareTag("Student"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(1, gameObject, this.gameObject);
            }
            Destroy(this.gameObject);
            Debug.Log("çarptı");
        }
        GameManager.instance.Explosion.Play();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Student"))
    //    {
    //        Health health = other.GetComponent<Health>();
    //        if (health != null)
    //        {
    //            health.TakeDamage(1, gameObject);
    //        }
    //        Destroy(this.gameObject);
    //        Debug.Log(other.gameObject);
    //        Debug.Log("çarptı");
    //    }
    //}
    //
}
