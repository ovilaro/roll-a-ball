using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
	private bool moveLeft, moveUp, moveRight, moveDown;

	private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {

		float moveHorizontal = 0;
		float moveVertical = 0;

		if (moveLeft && !moveRight)
        {
            moveHorizontal = -1;
        }
			//rb.AddForce(Vector3.left * speed);

		if (moveRight && !moveLeft)
        {
			moveHorizontal = 1;
		}
			//rb.AddForce(Vector3.right * speed);

		if (moveUp && !moveDown)
        {
			moveVertical = 1;
		}
			//rb.AddForce(Vector3.up * speed);

		if (moveDown && !moveUp)
        {
			moveVertical = -1;
		}
			//rb.AddForce(Vector3.down * speed);



		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);


	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
		}
    }

    private void SetCountText()
    {
		countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
	}

    public void MoveMeLeft()
    {
        moveLeft = true;
    }

	public void StopMeLeft()
	{
        moveLeft = false;
	}

	public void MoveMeUp()
	{
        moveUp = true;
	}

	public void StopMeUp()
	{
        moveUp = false;
	}

	public void MoveMeRight()
	{
        moveRight = true;
	}

	public void StopMeRight()
	{
        moveRight = false;
	}

	public void MoveMeDown()
	{
        moveDown = true;
	}

	public void StopMeDown()
	{
        moveDown = false;
	}
}
