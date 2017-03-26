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

		void Start()
		{
			controller = GetComponent<CharacterController>();
			controller.enabled = true;
		}


		void Update()
		{
			if (!GetComponent<NetworkIdentity>().isLocalPlayer)
				return;
			
			Vector3 movement = Vector3.zero;
			movement.x += CrossPlatformInputManager.GetAxis("Horizontal");
			movement.z += CrossPlatformInputManager.GetAxis("Vertical");

			movement *= speed;

			if(movement.magnitude > 0)
				transform.rotation = Quaternion.LookRotation(movement.normalized);

			movement += Physics.gravity;
			movement *= Time.deltaTime;
			controller.Move(movement);
		}
	}
}
