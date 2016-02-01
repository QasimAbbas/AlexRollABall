using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 800.0f;
    public Text textScore;
    public Text winText;
    private int count;
    private int winCount = 4; //# of pickups needed to win.

    void Start ()
    {
        count = 0;
        scoreConditions();
        winText.text = "";
    }

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);


    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            scoreConditions();
        }

    }

    void scoreConditions()
    {
        textScore.text = "Score: " + count;
        if(count >= winCount)
        {
            winText.text = "You win!";
        }
    }
}
