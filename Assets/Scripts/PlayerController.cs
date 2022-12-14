using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 15f;                          // Amount of force added when the player jumps.
	[SerializeField] private float m_water_JumpForce = 8f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public Animator animator;
	private int max_jumping_times = 2;
	private int times_jumped = 0;
	private bool in_water = false;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private AudioManager audioManager;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		audioManager = FindObjectOfType<AudioManager>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		in_water = false;
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject && (colliders[i].gameObject.tag == "Ground" || colliders[i].gameObject.tag == "BoatPlatform"))
			{
				m_Grounded = true;
				times_jumped = 0;
				in_water = false;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
			if (colliders[i].gameObject != gameObject && (colliders[i].gameObject.tag == "Water"))
			{
				m_Grounded = false;
				in_water = true;
				times_jumped = 0;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl )
		{
			if(m_Grounded && move != 0){
				audioManager.Play("Footsteps", false);
			}
			else{
				audioManager.Stop("Footsteps");
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
				animator.SetBool("Is_Right", m_FacingRight);
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
				animator.SetBool("Is_Right", m_FacingRight);
			}
			
		}
		// Debug.Log("jumping times " + times_jumped);
		// If the player should jump...
		if ((jump && m_Grounded) || (jump && times_jumped< max_jumping_times) || (jump && in_water))
		{
			// Add a vertical force to the player.
			Debug.Log("jump " + jump);
			audioManager.Play("Jump", true);
			times_jumped++;
			m_Grounded = false;
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
		}
        
    }


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		// Vector3 theScale = transform.localScale;
		// theScale.x *= -1;
		// transform.localScale = theScale;
	}
}