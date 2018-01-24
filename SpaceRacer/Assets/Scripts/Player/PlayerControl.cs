using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : IUpdatable
{
	PlayerModel playerModel;
	PlayerView playerView;
	IInputHandler input;
	private bool isAlive;

	public PlayerControl (PlayerView view, PlayerModel model, IInputHandler inputhandler)
	{
		playerView = view;
		playerView.OnCollided += DeathCollision;
		playerModel = model;
		isAlive = true;
		this.input = inputhandler;
		UpdateManager.Subscribe (this);
	}

	public void MyUpdate ()
	{
		UpdateView ();
	}

	private void UpdateView ()
	{
		playerView.ShipRotation += playerModel.rotationSpeed * -input.HorizontalAxis () * Time.deltaTime;
		playerView.ShipPosition += Vector2.right * playerModel.moveSpeed * input.HorizontalAxis () * Time.deltaTime;
		playerView.MyUpdate ();
	}

	public bool IsAlive ()
	{
		return isAlive;
	}

	public void DestroyThis ()
	{
		UpdateManager.UnSubscribe (this);
	}

	public void DeathCollision ()
	{
		isAlive = false;
//		Debug.Log ("collision");
	}
}
