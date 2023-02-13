using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            Debug.Log("entra");
            AudioManager.reference.PlaySound(11);
        }
    }

    
}
