using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private Vector2 newBananaLocation = new Vector2 ();
    private Vector2 nBLOffset = new Vector2();
    [SerializeField]
    private float _bounceAmplitude = 0.05f;
    [SerializeField]
    private float _bounceFrequency = 2f;
    [SerializeField]
    private float _spinFrequency = 50f;
    [SerializeField]
    private float _direction = 1f;
    [SerializeField]
    private float _spin;
    [SerializeField]
    GameManager gameManager;
    public bool _badBanana;

    void Start()
    {
        //takes the current banana location and sets the offset of the new banana location to that position in the level
        nBLOffset = transform.position;
        _bounceAmplitude = 0.05f;
        _bounceFrequency = 2f;
        _spinFrequency = 50f;
        _direction = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //calculating the extent to which the banana will spin
        _spin = transform.rotation.z;
        if (_spin <= (-0.15))
            _direction = 1;
        else if (_spin >= 0.15)
            _direction = -1;
        transform.Rotate(new Vector3(0f, 0f, (_direction)*_spinFrequency *Time.deltaTime), Space.Self);
        //Transfering the offset to our motion calculations.
        newBananaLocation = nBLOffset;
        //Changing the height of newBananaLocation using Sin
        newBananaLocation.y += Mathf.Sin(Time.fixedTime * Mathf.PI * _bounceFrequency) * _bounceAmplitude;
        //Using the location of newBananaLocation to move our banana
        transform.position = newBananaLocation;
    }
        private void OnTriggerEnter2D(Collider2D other) //Player walks through banana
        {
        if (other.tag == "Player") //Makes sure that what passed through it was indeed a player
        {
            if (_badBanana)
            {
                GameManager.instance.Restart_Level();
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.instance.UpdateBananas(); //update GameManager that another banana has been collected
                Destroy(this.gameObject); //life cycle ends, banana has transfered its value, and deletes itself.

            }
        }
        }
}