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
        }

        if (other.gameObject.tag == "coin")
        {
            health += 5;
            coinCollected += 1;
            coinText.text = coinCollected.ToString() + " Coins!"; 
            Destroy(other.gameObject);
            if (coinCollected >= 20)
            {
                Debug.Log("Moving to level2" + health);
                SceneManager.LoadScene("Level2");
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
