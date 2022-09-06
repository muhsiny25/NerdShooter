using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shoot : MonoBehaviour
{
    public RectTransform crosshair;

    Vector3 mousePosition;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isHold)
        {
            //Debug.Log("ishold");
            if (Input.GetMouseButtonDown(0))
            {
                crosshair.position = mousePosition;
                crosshair.DOScale(new Vector3(1, 1, 1), 0.25f);
                

            }
            else if (Input.GetMouseButton(0))
            {
                crosshair.position += Input.mousePosition - mousePosition;
                crosshair.position = new Vector3(Mathf.Clamp(crosshair.position.x, 0, Screen.width), Mathf.Clamp(crosshair.position.y, 200, Screen.height), 0);

                mousePosition = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0))
            {
                GameManager.instance.shootObj.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameManager.instance.shootObj.transform.parent = null;

                GameManager.instance.shootObj.transform.position = Camera.main.transform.position + Camera.main.ScreenPointToRay(crosshair.position).direction * 1.5f;
                GameManager.instance.shootObj.transform.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(crosshair.position).direction * 5000);

                GameManager.instance.obj.Remove(GameManager.instance.shootObj);
                GameManager.instance.isHold = false;
                UIManager.Instance.ShootActive(false);
                crosshair.DOScale(new Vector3(0, 0, 0), 0.25f).OnComplete(() => {
                    });

            }
        }
    }
}
