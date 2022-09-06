using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                //new GameObject("Canvas").AddComponent<UIManager>();
            }
            return instance;
        }
    }

    public GameObject shootPanel;

    //[Header("Start Panel")]
    //[SerializeField] public GameObject startPanel;
    //[SerializeField] private GameObject startButton;
    //
    //[Header("In Game Panel")]
    //[SerializeField] private GameObject inGamePanel;
    //[SerializeField] private TextMeshProUGUI levelText;
    //[SerializeField] public TextMeshProUGUI orderText;
    //[SerializeField] private GameObject pie;
    //[SerializeField] private GameObject joystick;
    //
    //[Header("Fail Panel")]
    //public GameObject failPanel;
    //[SerializeField] private GameObject failButton;
    //
    //[Header("Victory Panel")]
    //public GameObject victoryPanel;
    //[SerializeField] private GameObject nextButton;
    //
    //[Header("Button Scale Animation Settings")]
    //[SerializeField] float buttonScaleAnimationSpeed = 0.3f;
    //[SerializeField] float buttonScaleAnimationLength = 0.2f;
    //[SerializeField] float buttonScaleAnimationStartPosition = 0.8f;

    private void Awake()
    {
        instance = this;
        //victoryPanel.SetActive(false);
        //failPanel.SetActive(false);
        //pie.SetActive(false);
        //joystick.SetActive(false);
    }

    void Start()
    {
        ShootActive(false);
        //levelText.text = "Level" + PlayerPrefs.GetInt("lastLevel", 1).ToString();
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
        InvokeRepeating("StartPanel", 0.00f, 0.001f);
    }

    public void ShootActive(bool avtive)
    {
        shootPanel.SetActive(avtive);
        GameManager.instance.shootscript.enabled = avtive;
    }
   
    public void FixedUpdate()
    {
        //ScaleButton(startButton);
        //ScaleButton(nextButton);
        //ScaleButton(failButton);
    }
    public void StartPanel()
    {
        Time.timeScale = 1;
        //startPanel.SetActive(true);
        CancelInvoke("StartPanel");
    }
    public void StartLevel()
    {
        //startPanel.SetActive(false);
    }

    public void NextLevel()
    {
        //LevelManager.Instance.NextLevel();
    }
    public void RestartLevel()
    {
        //LevelManager.Instance.LevelRestart();
    }

    void ScaleButton(GameObject button)
    {
        //float t = Time.time * buttonScaleAnimationSpeed;
        //button.transform.localScale = new Vector3(Mathf.PingPong(t, buttonScaleAnimationLength) + buttonScaleAnimationStartPosition, Mathf.PingPong(t, buttonScaleAnimationLength) + buttonScaleAnimationStartPosition, 1);
    }
}