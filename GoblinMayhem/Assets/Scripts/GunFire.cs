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

    public bool isShooting;

    void Start()
    {
        isShooting = false;
        muzzleFire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootingPoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            isShooting = false;
        }

        if(isShooting == true)
        {
            muzzleFire.SetActive(true);
            animator.SetBool("IsShooting", true);
        }
        if(!isShooting)
        {
            muzzleFire.SetActive(false);
            animator.SetBool("IsShooting", false);
        }

    }
}
