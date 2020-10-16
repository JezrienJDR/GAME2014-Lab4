using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCon : MonoBehaviour
{
    public PlayerProjectileManager Guns;

    [SerializeField]
    float RotSpeed = 180;

    [SerializeField]
    float impulse = 4;

    Rigidbody2D rb;

    [SerializeField]
    public GameObject Blast;

    [SerializeField]
    float fireInterval = 0.2f;

    float fireTimer = 0;

    float gunOffsetHorizontal = 0.4f;
    float gunOffsetVertical = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), RotSpeed * -1 * Time.deltaTime * Input.GetAxis("Horizontal"));

        rb.AddForce(transform.up * impulse * Input.GetAxis("Vertical"));
    
        if(Input.GetAxis("Fire1") > 0)
        {
            if (fireTimer >= fireInterval)
            {
                Guns.GetShot(transform.position - transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical, transform.rotation);
                Guns.GetShot(transform.position + transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical, transform.rotation);

                //Instantiate(Blast, transform.position - transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical, transform.rotation);
                //Instantiate(Blast, transform.position + transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical,  transform.rotation);
                fireTimer = 0;
            }
        }

        if (Input.GetAxis("Fire2") > 0)
        {
            if (fireTimer >= fireInterval)
            {
                Guns.GetShot2(transform.position - transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical, transform.rotation);
                Guns.GetShot2(transform.position + transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical, transform.rotation);

                //Instantiate(Blast, transform.position - transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical, transform.rotation);
                //Instantiate(Blast, transform.position + transform.right * gunOffsetHorizontal + transform.up * gunOffsetVertical,  transform.rotation);
                fireTimer = 0;
            }
        }

        if (fireTimer < fireInterval)
        {
            fireTimer += Time.deltaTime;
        }
    
    }


}
