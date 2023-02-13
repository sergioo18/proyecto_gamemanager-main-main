using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;

    //singleton
    public static Goomba reference;
    private void Awake()
    {
        if (reference == null)
            reference = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3 ( target.position.x , transform.position.y , transform.position.z), moveSpeed * Time.deltaTime);
    }

    public void DefeatEnemie()
    {
        Destroy (this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            collision.GetComponent<PlayerController>().ResetMario();
        }
    }


}
