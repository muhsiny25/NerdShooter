using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public List<GameObject> obj;
    public GameObject shootObj;
    public Shoot shootscript;

    public GameObject hold;
    public bool isHold;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        shootscript = FindObjectOfType<Shoot>();

    }
    void Start()
    {
        isHold = false;
        shootscript.enabled = false;
    }
}
