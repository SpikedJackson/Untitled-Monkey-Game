using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{

    private bool hasGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //When the player passes the vine, it will allow the player to ascend it by calling the function that tells the player it may climb.
    {
        if(other.tag == "Player" && hasGrabbed == false && Input.GetAxisRaw("Grab") != 0)
        {
            hasGrabbed = true;
            Player player = other.GetComponent<Player>(); //accessing the player's player script through the collider, so it can call the player's climb toggle.
            player.ClimbToggle(); //Assuming the climb ability is on already, this turns it off in 1 function instead of 2 dedicated on/off functions
        }
    }
    private void OnTriggerStay2D(Collider2D other) //When the player passes the vine, it will allow the player to ascend it by calling the function that tells the player it may climb.
    {
        if(other.tag == "Player" && hasGrabbed == false && Input.GetAxisRaw("Grab") != 0)
        {
            hasGrabbed = true;
            Player player = other.GetComponent<Player>(); //accessing the player's player script through the collider, so it can call the player's climb toggle.
            player.ClimbToggle(); //Assuming the climb ability is on already, this turns it off in 1 function instead of 2 dedicated on/off functions
        }
    }
    private void OnTriggerExit2D(Collider2D other) //Upon jumping on, or walking by the vine, the vine will toggle off the ability to climb.
    {
        if (other.tag == "Player" && hasGrabbed == true)
        {
            Player player = other.GetComponent<Player>(); //accessing the player's player script through the collider, so it can call the player's climb toggle.
            player.ClimbToggle(); //Assuming the climb ability is on already, this turns it off in 1 function instead of 2 dedicated on/off functions
            hasGrabbed = false;
        }
    }
}
