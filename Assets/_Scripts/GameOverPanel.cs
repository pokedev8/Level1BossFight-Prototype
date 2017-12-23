﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour 
{
	Image m_Panel;
	Timer m_FadeTimer = new Timer();
	[SerializeField]
	float FADE_DURATION;
	[SerializeField]
	Button m_GameOver;

	void Start()
	{
		m_Panel = GetComponent<Image>();
		StartCoroutine("SetDeadTimer");
		m_GameOver.gameObject.SetActive(false);
	}

	void Update()
	{
		if (GameController.instance.ReturnPlayerStats().PlayerDead())
		{
			float alpha = (FADE_DURATION - m_FadeTimer.GetTime()) / FADE_DURATION;
			if (!m_FadeTimer.Update(Time.deltaTime))
			{
				Color currentColor = m_Panel.color;
				currentColor.a = alpha;
				m_Panel.color = currentColor;
			}
			else if (m_FadeTimer.Update(Time.deltaTime) && m_FadeTimer.HasCompleted())
			{
				m_GameOver.gameObject.SetActive(true);
			}
		}
	}

	public void SetPanelColor (Color color)
	{
		Color currentColor = m_Panel.color;
		currentColor = color;
		float alpha = 0f;
		currentColor.a = alpha;
		m_Panel.color = currentColor;
	}

	IEnumerator SetDeadTimer()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnPlayerStats().PlayerDead());
		m_FadeTimer.Set(FADE_DURATION);
		SetPanelColor(Color.black);
	}
}
