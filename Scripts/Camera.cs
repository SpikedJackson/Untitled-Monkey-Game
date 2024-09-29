using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public GameObject playerObject;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject == null){
            playerObject = GameObject.FindGameObjectWithTag("Player");
            player = playerObject.GetComponent<Transform>();
        }
        if(transform.position.y > -1){
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
        if(transform.position.y<=-1 && player.position.y > - 1)
        {
            transform.position = player.position;
        }
        // https://answers.unity.com/questions/878913/how-to-get-camera-to-follow-player-2d.html
    }
}
