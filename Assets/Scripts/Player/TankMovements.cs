﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

namespace TankFighters.Player
{
	[RequireComponent (typeof(CharacterController))]
	public class TankMovements : MonoBehaviour
	{

		public int speed = 1;

		private CharacterController controller;

		void Start ()
		{
			controller = GetComponent<CharacterController>();
			controller.enabled = true;
		}

		// Update is called once per frame
		void Update ()
		{
			if (!GetComponent<NetworkIdentity>().isLocalPlayer)
				return;
			
			Vector3 movement = Vector3.zero;
			movement.x += CrossPlatformInputManager.GetAxis("Horizontal");
			movement.z += CrossPlatformInputManager.GetAxis("Vertical");

			//movement = transform.TransformDirection(movement);

			movement *= speed;
			movement += Physics.gravity;
			movement *= Time.deltaTime;
			Debug.Log("movement: " + movement);
			controller.Move(movement);
		}
	}
}
