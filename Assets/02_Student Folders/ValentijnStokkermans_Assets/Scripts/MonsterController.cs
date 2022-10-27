using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class MonsterController : MonoBehaviour {
	[SerializeField] private float stoppingDistance = 3;
   private Animator anim = null;
	private UnityEngine.AI.NavMeshAgent agent = null;
	private MonsterStats stats = null;
	private bool walking = false;

	public UnityAction onDamaged;
	Health m_Health;

	[SerializeField] private Transform target;

	private int interval = 50;
	[SerializeField]private float noticeDistance = 50;
	private float visibleDistance = 10;
	private float timeOfLastAttack = 0f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponentInChildren<Animator>();
		stats = GetComponent<MonsterStats>();
	}

	float DistanceToPlayer() {
		return Vector3.Distance(target.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (stats.health > 0) {
			if (DistanceToPlayer() < noticeDistance) {
				if (Time.frameCount % interval == 0) {
					MoveToTarget();
				}
			} else {
				anim.SetTrigger("Fight_Idle_1");
				walking = false;
			}
		}
		
	}

	private void MoveToTarget() {
		agent.SetDestination(target.position);
		if(!walking) {
			anim.SetTrigger("Walk_Cycle_1");
			walking = true;
		}
		RotateToTarget();
		
		if(DistanceToPlayer() > stoppingDistance && DistanceToPlayer() < visibleDistance) {
			anim.SetTrigger("Intimidate_1");
			walking = false;
		}

		if(DistanceToPlayer() <= stoppingDistance) {
			if (Time.time >= timeOfLastAttack + stats.attackSpeed) {
				timeOfLastAttack = Time.time;
				Health playerStats = target.GetComponent<Health>();
				walking = false;
				AttackTarget(playerStats);
			}
		}

	}

	private void RotateToTarget() {
		Vector3 direction = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
		transform.rotation = rotation;
	}

	private void AttackTarget(Health statsToDamage) {
		walking = false;
		anim.SetTrigger("Attack_1");
		stats.DealDamage(statsToDamage);
	}
}
