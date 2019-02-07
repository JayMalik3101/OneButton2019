using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject m_Bullet;

    public float m_Projectileforce = 10;
    public float m_Addforce;
    public float m_Timer = 0;
    public float m_CDtimer;
    public float m_Maxforce = 15f;

    public static float m_Charge;

    public bool m_StartTimer;

    private Player m_Script;

    [SerializeField]
    Image m_ChargeBar;

    [SerializeField] private TMP_Text m_uiText;
    [SerializeField] private float m_CooldownTimer;

    // Start is called before the first frame update 
    void Start()
    {
        m_StartTimer = false;
        m_CDtimer = m_CooldownTimer;

        m_ChargeBar = GetComponent<Image>();
        m_Charge = m_Maxforce;
    }

    // Update is called once per frame 
    void Update()
    {
        Timer();
        if (m_Timer == 0 && Input.GetKey("space"))
        {
            m_Addforce += 0.15f;
            m_ChargeBar.fillAmount = m_Maxforce / m_Maxforce; 
            if (m_Addforce >= 15)
            {
                m_Addforce = 15;
            }
        }
        if (m_Timer == 0 && Input.GetKeyUp("space"))
        {
            GameObject projectile = Instantiate(m_Bullet, transform.position, transform.parent.rotation) as GameObject;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = projectile.transform.right * m_Addforce;
            m_StartTimer = true;
            m_Addforce = 0;
        }

    }

    private void Timer()
    {
        //m_StartTimer = true; 

        if (m_StartTimer == true)
        {
            m_Timer += Time.deltaTime;
            m_uiText.text = m_Timer.ToString("F");
            if (m_Timer >= 1.5f)
            {
                m_uiText.text = "0.0";
                m_Timer = 0.0f;
                m_StartTimer = false;
            }
        }
    }
}
