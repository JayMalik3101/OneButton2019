using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject m_Bullet;

    public float m_Projectileforce = 10;
    public float m_Addforce;
    
    private Player m_Script;
    // Start is called before the first frame update
    void Start()
    {
        //m_Script = GameObject.Find("Arrow").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            //m_Script.m_Pause = true;
            m_Addforce += 0.1f;
            if (m_Addforce >= 50)
            {
                m_Addforce = 50;
            }
        }
        if(Input.GetKeyUp("space"))
        {
            GameObject projectile = Instantiate(m_Bullet, transform.position, transform.parent.rotation) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = projectile.transform.right * m_Addforce;
            m_Addforce = 0;
            //m_Script.m_Pause = false;
        }
    }

    private void Fire()
    {

    }
}
