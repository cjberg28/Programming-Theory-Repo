using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    protected Rigidbody rb;
    private float speed = 2.0f;
    protected MainUIHandler mainUIHandler;
    protected FatMan fatMan;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainUIHandler = GameObject.Find("UIHandler").GetComponent<MainUIHandler>();
        fatMan = GameObject.Find("Fat Man").GetComponent<FatMan>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            Destroy(gameObject);
        }
        Move();//ABSTRACTION
    }

    protected void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    protected virtual void Consume()
    {
        Destroy(gameObject);
        mainUIHandler.UpdateCount();
    }

    //The only reason I can't put the OnTriggerEnter method here is I need to be able to pass the Child type into PrintMessage(), using the "this" keyword. Perhaps there's another way around this?
}
