using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
   [SerializeField] LayerMask groundLayers;

	private string groundType;

	[Space(10)]
	[Tooltip("Slippery of the character")]
	[SerializeField] float slipSpeed = 3;
	
	[Tooltip("Rays Position Maintainance")]
	[Header("Ray Pos")]
	[SerializeField] Vector2 m_wallCheck = new Vector2(0.1f, 0.2f);
	[SerializeField] Vector3 m_groundCheck = new Vector3(0.1f, 0.2f, 0.4f);


	private bool isGrounded = true;

	CharacterController cc;
	Animator anim;
	bool edg;


	private void Start(){
		anim = GetComponent<Animator>();
		cc = GetComponent<CharacterController>();
	}

	private void Update()
	{	
		MainGroundChecker();

		if (isGrounded){
			edg = false;
			anim.SetBool ("onGround", true);
		}else{
			//If not grounded
			anim.SetBool ("onGround", false);
			//If not jumping 
			if(cc.velocity.y < 0) edg = SlipCheckers(); else edg = false;
		}

	}

//This function is only going to check if the player is on ground or not.
	private void MainGroundChecker(){
		RaycastHit hit;
		Vector3 ray_pos = cc.GetComponent<Collider>().transform.position + Vector3.up * m_groundCheck.x;

		Ray ray = new Ray(ray_pos, Vector3.down * m_groundCheck.y); //m_groundCheck.y is Length of Ray
		Ray ray_back = new Ray(ray_pos - transform.forward * m_groundCheck.z, Vector3.down * m_groundCheck.y);

		if(Physics.Raycast(ray, out hit, m_groundCheck.y, groundLayers) || Physics.Raycast(ray_back, out hit, m_groundCheck.y, groundLayers)){
			if(cc.velocity.y < 0) isGrounded = true; //If the character is not jumping
			if(!hit.transform.CompareTag("Untagged")) groundType = hit.transform.tag; else groundType = "Concrete";
		}else{
			isGrounded = false;
		}

	}

	private bool SlipCheckers(){
		RaycastHit hit;
		Vector3 ray_spwan_pos = transform.position + Vector3.up * m_wallCheck.y; //Y as starting point

		Vector3 forward = transform.forward * m_wallCheck.x; //X as length of rays
		Vector3 back = -transform.forward * m_wallCheck.x;
		Vector3 right = transform.right * m_wallCheck.x;
		Vector3 left = -transform.right * m_wallCheck.x;

		Ray front_ray = new Ray(ray_spwan_pos, forward);
		Ray back_ray = new Ray(ray_spwan_pos, back);
		Ray right_ray = new Ray(ray_spwan_pos, right);
		Ray left_ray = new Ray(ray_spwan_pos, left);

		float dis = m_wallCheck.x;

		if(Physics.Raycast (front_ray, out hit, dis, groundLayers)){
			HitForSlip(transform.forward);
			return true;
		}

		if(Physics.Raycast (back_ray, out hit, dis, groundLayers) || Physics.Raycast (right_ray, out hit, dis, groundLayers) || Physics.Raycast (left_ray, out hit, dis, groundLayers)){
			HitForSlip(hit.normal);
			return true;
		}
		return false;
	}

	void HitForSlip(Vector3 slip_direction){
		cc.Move(((slip_direction * slipSpeed) + Vector3.down) * Time.deltaTime);
	}

	void OnDrawGizmos(){
		Vector3 ray_spwan_pos = transform.position + Vector3.up * m_wallCheck.y;
		
		Vector3 forward = transform.forward * m_wallCheck.x;
		Vector3 back = -transform.forward * m_wallCheck.x;
		Vector3 right = transform.right * m_wallCheck.x;
		Vector3 left = -transform.right * m_wallCheck.x;
		
	
		Gizmos.color = Color.red;
		Gizmos.DrawRay(ray_spwan_pos, forward);
		Gizmos.DrawRay(ray_spwan_pos, back);
		Gizmos.DrawRay(ray_spwan_pos, right);
		Gizmos.DrawRay(ray_spwan_pos, left);

		Gizmos.color = Color.green;
		Vector3 ray_pos = transform.position + Vector3.up * m_groundCheck.x;
		Gizmos.DrawRay(ray_pos , Vector3.down * m_groundCheck.y);
		
		//Gizmos.DrawRay(ray_pos + transform.forward * m_groundCheck.z, Vector3.down * m_groundCheck.y);
		Gizmos.DrawRay(ray_pos  - transform.forward * m_groundCheck.z, Vector3.down * m_groundCheck.y);
	}
}
