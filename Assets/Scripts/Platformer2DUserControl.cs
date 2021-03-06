using System;
using UnityEditor;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_OnPlatform;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }
        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.tag == "Platform")
            {
                transform.parent = col.transform;
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Platform")
            {
                transform.parent = null;
            }
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            bool roll = Input.GetKey(KeyCode.Q);
            float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump, roll);
            m_Jump = false;

            if (m_OnPlatform && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0)
            {
                
            }
        }

        private void OnPlatform()
        {
            
        }

        void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.tag == "Platform")
            {
                m_OnPlatform = true;
            }
            else
            {
                m_OnPlatform = false;
            }
        }
    }
}
