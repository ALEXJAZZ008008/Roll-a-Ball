using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void SetWinText(string winString)
    {
        winText.text = winString;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 16)
        {
            SetWinText("You Win");
        }
    }

    // Use this for initialization
    void Start()
    {
        SetWinText(string.Empty);

        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            count++;

            SetCountText();
        }
    }
}