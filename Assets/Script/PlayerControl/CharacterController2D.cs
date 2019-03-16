using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController2D : MonoBehaviour
{
   
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [Range(0, 100f)] [SerializeField] private float m_MovementBaseSpeed = 10f;  // How much to smooth out the movement


    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;

    private bool m_FacingRight = true;

    public Transform PlayerImage;
    public Transform PlayerAttackHand;


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

    public void Motor(Vector2 move,Vector3 targetVectors)
    {
        Move(move);
        Flip(targetVectors);
        LockTarget(targetVectors);

    }

    private void Move(Vector2 move)
    {
       
        Vector3 targetVelocity = move * m_MovementBaseSpeed;
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

    }


    private void LockTarget(Vector3 targetVectors)
    {
        float zAngle = Mathf.Atan2(Mathf.Abs(targetVectors.y), Mathf.Abs(targetVectors.x))* Mathf.Rad2Deg;
        if(targetVectors.y>0)
        {
            zAngle = -zAngle;
        }
        PlayerAttackHand.localEulerAngles = new Vector3(0, 0, zAngle);

    }

    private void Flip(Vector3 targetVectors)
    {
        
        if ((m_FacingRight && !(targetVectors.x > 0))|| (!m_FacingRight && (targetVectors.x > 0)))
        {
            m_FacingRight = !m_FacingRight;

            float y = PlayerImage.localEulerAngles.y;
            y = (y + 180) % 360;
            PlayerImage.localEulerAngles = new Vector3(0, y, 0);
        }
    }

}


