using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float despawnTime;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletDespawnTime(despawnTime);
        FaceShootingAngle();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    public void BulletDespawnTime(float despawnTime)
    {
        //Makes bullet despawn after given time;
        if (despawnTime > 0)
        {
            despawnTime -= Time.deltaTime;
        }
        else if (despawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void FaceShootingAngle()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
