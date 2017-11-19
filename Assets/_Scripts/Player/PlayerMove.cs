﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
	[SerializeField]
	float m_PlayerSpeed;
	[SerializeField]
	float KNOCK_BACK_AMOUNT;
	int FACING_LEFT = -1;
	int FACING_RIGHT = 1;

	PlayerStats m_PlayerStats;
	[SerializeField]
	Animator m_PlayerAnimator;

	void Start()
	{
		m_PlayerStats = GameController.instance.ReturnPlayerStats();
	}

	void FixedUpdate () 
	{
		//Move Player with WASD / UDLR
		transform.Translate(Input.GetAxis("Horizontal") * m_PlayerSpeed, Input.GetAxis("Vertical") * m_PlayerSpeed, 0f);
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.localScale = new Vector2(FACING_LEFT, transform.localScale.y);
			m_PlayerAnimator.SetBool("IsWalking", true);
		}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.localScale = new Vector2(FACING_RIGHT, transform.localScale.y);
			m_PlayerAnimator.SetBool("IsWalking", true);
		}

		if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
		{
			m_PlayerAnimator.SetBool("IsWalking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Enemy" && !GameController.instance.ReturnPlayerAttackScript().PlayerAttacking())
		{
			Vector2 enemyPos = new Vector2(myCol.gameObject.transform.position.x, myCol.gameObject.transform.position.y);
			int enemyAttackDamage = myCol.gameObject.GetComponent<EnemyStats>().DealDamage();
			PlayerKnockBack(enemyAttackDamage, enemyPos);
		}
	}

	public void PlayerKnockBack(int damage, Vector2 enemyPos)
	{
		Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
		Vector2 knockBackDirection = (enemyPos - playerPos).normalized;
		transform.position = new Vector2 (playerPos.x + (KNOCK_BACK_AMOUNT * -knockBackDirection.x), playerPos.y + (KNOCK_BACK_AMOUNT * knockBackDirection.y));
		m_PlayerStats.OnPlayerHit(damage);
	}
}