﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTile : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "PlayerBody")
		{
			GameController.instance.ReturnFollowPlayer().NormalCameraView();
		}
	}

}
