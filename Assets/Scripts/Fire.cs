using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{   
    private Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript=FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy(other.gameObject);
            playerScript.Death();
        }
    }
}
