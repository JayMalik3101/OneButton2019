using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Collider2D m_collider;

    private bool m_alive;

    private float m_aliveTimer;
    public float m_startAliveTimer;

    private void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_aliveTimer = m_startAliveTimer;
        m_alive = false;
    }
    private void Update()
    {
        if(m_alive)
        {
            if (m_aliveTimer <= 0)
            {
                m_aliveTimer = m_startAliveTimer;
                m_alive = false;
                this.gameObject.SetActive(false);
            }
            else
            {
                m_aliveTimer -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Net"))
        {
            m_collider.gameObject.SetActive(false);
        }
    }
    private void OnBecameVisible()
    {
        m_alive = true;
    }
}
