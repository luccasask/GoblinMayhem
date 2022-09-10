using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject muzzleFire;
    public Animator animator;
    public Transform shootingPoint;

    private Rigidbody2D rb;
    public float bulletForce;

    private bool fireAnim;
    private float fireAnimCountDown;
    public float muzzleFireDuration;

    void Start()
    {

    }

    void Update()
    {
        //Shoot if mousebutton 0 is pressed.
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingPoint.right * bulletForce, ForceMode2D.Impulse);
        print("Shoot");
    }
}
