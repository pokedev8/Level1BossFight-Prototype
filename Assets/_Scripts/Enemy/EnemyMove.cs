﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
	[SerializeField]
	float m_EnemyMovement;
	float m_Timer = 0f;
	float CAN_MOVE_AMOUNT = 2f;
	float MOVE_DURATION = 4f;
	[SerializeField]
	float PUSH_BACK_AMOUNT;
	Vector2 m_DirectionValue;

	[Header("Accessor")]
	EnemyStats m_EnemyStats;

	void Start()
	{
		m_EnemyStats = GetComponent<EnemyStats>();
	}

	void FixedUpdate()
	{
		m_Timer += Time.deltaTime;
		if (m_Timer > CAN_MOVE_AMOUNT && !m_EnemyStats.IsEnemyDead())
		{
			MoveTowardsPlayer();
		}
	}

	void MoveTowardsPlayer()
	{
		//transform.localPosition;
		//Always aim to make current pos = GameController.instance.GetPlayerPos
		// + / - x pos and + / - y pos
		Vector2 currentPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
		Vector2 playerPos = GameController.instance.ReturnPlayerPos();

		if (currentPos.x < playerPos.x)
		{
			Vector2 newPos = transform.localPosition;
			newPos.x += m_EnemyMovement;
			transform.localPosition = newPos;
		}
		else
		{
			Vector2 newPos = transform.localPosition;
			newPos.x -= m_EnemyMovement;
			transform.localPosition = newPos;
		}

		if (currentPos.y < playerPos.y)
		{
			Vector2 newPos = transform.localPosition;
			newPos.y += m_EnemyMovement;
			transform.localPosition = newPos;
		}
		else
		{
			Vector2 newPos = transform.localPosition;
			newPos.y -= m_EnemyMovement;
			transform.localPosition = newPos;
		}

		if (m_Timer > MOVE_DURATION)
		{
			StopEnemyMovement();
		}
	}

	public void EnemyPushBack()
	{
		Vector3 enemyPos = new Vector3(transform.position.x, transform.position.y, 0f);
		m_DirectionValue = (GameController.instance.ReturnPlayerPos() - enemyPos).normalized;
		transform.position = new Vector3(enemyPos.x + (PUSH_BACK_AMOUNT * -m_DirectionValue.x), (enemyPos.y + (PUSH_BACK_AMOUNT * -m_DirectionValue.y)),0f);
	}

	public void StopEnemyMovement()
	{
		m_Timer = 0f;
	}
}
