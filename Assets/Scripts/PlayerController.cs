using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
    private int score = 0;
    public int health = 5;

    private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}


	private void FixedUpdate()
	{
        // Player movement on keypress
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		Vector3 traj = new Vector3(moveX, 0.0f, moveZ);
		rb.AddForce(traj * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        // Triggers event based on collision between player and another object
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score.ToString());
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health.ToString());
        }
    }

    private void Update()
    {
        // If health equals 0, reload the scene so that the Player starts again from the beginning
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
        }
    }
}
