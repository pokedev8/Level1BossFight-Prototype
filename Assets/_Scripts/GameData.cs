﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour 
{
	public Vector2 LoadPlayerPos()
	{
		return GetPlayerPrefsPlayerPos();
	}

	public float LoadPlayerHealth()
	{
		return GetPlayerPrefsHealth();
	}

	public void SaveCurrentGameState()
	{
		int health = GetPlayerPrefsHealth();
		Vector2 playerPos = GameController.instance.GetPlayerPos();
		SavePlayerCurrentHealth(health);
		float x = playerPos.x;
		float y = playerPos.y;
		SavePlayerCurrentXPos(x);
		SavePlayerCurrentYPos(y);

		print(health);
		print(x + " " + y);
	}

	public void SavePlayerCurrentHealth(int hp)
	{
		PlayerPrefs.SetInt("PlayerHealth", hp);
	}

	public int GetPlayerPrefsHealth()
	{
		return PlayerPrefs.GetInt("PlayerHealth");
	}

	public void SavePlayerCurrentXPos(float XPos)
	{
		PlayerPrefs.SetFloat("PlayerXPos", XPos);
	}

	public void SavePlayerCurrentYPos(float YPos)
	{
		PlayerPrefs.SetFloat("PlayerYPos", YPos);
	}

	public Vector2 GetPlayerPrefsPlayerPos()
	{
		return new Vector2(PlayerPrefs.GetFloat("PlayerXPos"), PlayerPrefs.GetFloat("PlayerYPos"));
	}

	public void SavePlayerCurrentStrength(int strength)
	{
		PlayerPrefs.SetInt("PlayerStrength", strength);
	}

	public int GetPlayerCurrentStrength()
	{
		return PlayerPrefs.GetInt("PlayerStrength");
	}

	public void SavePlayerCurrentDefence(int defence)
	{
		PlayerPrefs.SetInt("PlayerDefence", defence);
	}

	public int GetPlayerCurrentDefence()
	{
		return PlayerPrefs.GetInt("PlayerDefence");
	}
}