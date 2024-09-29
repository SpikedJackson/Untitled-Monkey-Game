using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int totalBananas;
    public int levelNum;
    public GameObject nextLevel;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.bananas == totalBananas)
        {
            GameManager.instance.Next_Level();
        }
        GameManager.instance.bananaText.text = ("Bananas Collected: " + GameManager.instance.bananas + " / " + totalBananas);
    }
    public void Reset(Vector3 initPos)
    {
        Debug.Log(initPos);
        player.Relocate(initPos);
        GameManager.instance.bananas = 0;
    } 
}
