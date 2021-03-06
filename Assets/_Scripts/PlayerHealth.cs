using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public int coinCollected;
    public Text coinText;
    public Transform level2SpawnPoint;
    public AudioSource coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        coinCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            health -= 20;
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        if (other.gameObject.tag == "coin")
        {
            coinAudio.Play();

            //health should not be more than 100
            if (health < 100)
            {
                health += 5;
            }
            coinCollected += 1;
            coinText.text = coinCollected.ToString() + " Coins!"; 
            Destroy(other.gameObject);
            if (coinCollected >= 2)
            {
                Debug.Log("Moving to level2" + health);

                var controller = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
                // turn controller off
                controller.enabled = false;
                // move the player to the spawnpoint
                GameObject.FindWithTag("Player").transform.position = level2SpawnPoint.position;
                // turn controller on
                controller.enabled = true;

                //SceneManager.LoadScene("Level2");
                //Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
