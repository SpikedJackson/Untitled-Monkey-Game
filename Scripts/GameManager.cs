using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public int level = 1;
    public int bananas = 0;
    public GameObject[] levels = new GameObject[5];
    public Vector3[] initalPositions = new Vector3[5];
    public AudioSource bananaSource;
    public AudioSource musicSource;
    public Text levelText;
    public Text bananaText;
    public GameObject message;
    // Awake is called before the start function

    void Awake()
    {
        
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    private void Start()
    {
        StartLevel();
        levelText.text = ("Level: " + level);
    }
    void StartLevel()
    {
        Instantiate(levels[level - 1]);
        Debug.Log("level " + level);
        if (level == 7)
        {
            message.SetActive(true);
            levelText.gameObject.SetActive(false);
            bananaText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            Application.Quit();
        
    }

    public void UpdateBananas() // When banana is eaten, it calls this function to tell the game manager to update the banana count by 1. If we did multiple bunch bananas, we could pass in a value.
    {
        Debug.Log("banana eaten");
        bananaSource.Play();
        bananas++;
    }
    public void Next_Level()
    {
        if (level == 7)
            level = 1;
        else
        {
            level += 1;
            levelText.text = ("Level: " + level);
            Restart_Level();
        }
    }

    public void Restart_Level()
    {
        Destroy(GameObject.FindGameObjectWithTag("Level"));
        StartLevel();
        LevelManager levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        levelManager.Reset(initalPositions[level - 1]);
    }

}
