using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    private int numPickups = 10;
    public Text scoreText;
    public Text winText;
    public Text playerPosition;

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection;
        playerPosition.text = "X: " + gameObject.transform.position.x +" "+ "Y: " + gameObject.transform.position.y + " " + "Z: " + gameObject.transform.position.z;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count ++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups) 
        {
            winText.text = "You Win !";
        }

    }
   
 
}
