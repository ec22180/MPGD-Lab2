using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    private int numPickups = 5;
    public Text scoreText;
    public Text winText;
    public Text playerPosition;
    private Rigidbody rb;
    private Vector3 prePos = Vector3.zero;
    private float objSpeed;
    public Text playerSpeed;
    public GameObject[] PickupArr;
    public float minDis = 2f;

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
        rb = GetComponent<Rigidbody>();
        prePos = transform.position;
        
    }
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        rb.AddForce(xDirection * speed * Time.fixedDeltaTime, rb.velocity.y, zDirection * speed * Time.fixedDeltaTime);
        
        foreach(GameObject go in PickupArr)
        {
            float distance = Vector3.Distance(go.transform.position , transform.position);

            if(distance<minDis)
            {
                go.GetComponent<Renderer>().material.color = new Color(0,0,255);
            }
            else if (distance>minDis)
            {
                go.GetComponent<Renderer>().material.color = new Color(0.85f, 0.807f, 0.298f);
            }
        }
       
    }
    public void FixedUpdate()
    {
        objSpeed = (transform.position - prePos).magnitude / Time.deltaTime;
        prePos = transform.position;
        playerSpeed.text = "Velocity: " + objSpeed.ToString("0.00");
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
