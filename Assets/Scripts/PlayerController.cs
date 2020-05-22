using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Image winLoseBG;
    public Text winLoseText;
    public GameObject winLose;
    private bool isCoroutine = true;

    private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
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
        if (isCoroutine && health == 0)
        {
            SetGameOver();
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator LoadScene(float seconds)
    {
        isCoroutine = false;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);
        isCoroutine = true;
    }

    void SetScoreText()
    {
        // new high score
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        // displays health
        healthText.text = "Health: " + health.ToString();
    }

    void SetWin()
    {
        // end msg
        winLose.SetActive(true);
        winLoseBG.color = Color.green;
        winLoseText.text = "You win!";
        winLoseText.color = Color.black;
    }

    void SetGameOver()
    {
        // end card
        winLose.SetActive(true);
        winLoseBG.color = Color.red;
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
    }
}
