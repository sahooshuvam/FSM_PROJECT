using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health =1000;
   //public int rotationSpeed;
   //public bool isDead = false;
    //public GameObject enemyPrefabs;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false;
        //rb.freezeRotation = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            print("Collecting Coins");
            Destroy(other.gameObject);
        }
    }
    private void FixedUpdate()
    {
       // transform.Rotate(0f, Input.GetAxis("Mouse X") * rotationSpeed, 0f);
    }
}
