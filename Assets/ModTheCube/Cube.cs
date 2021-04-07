using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	public MeshRenderer Renderer;
	public Material[] myMaterials;
	private int materialIndex;
	private Renderer cubeRenderer;
	private float timeLeft;
	private Color targetColor;
	private float rightBound = 3.0f;
	private float leftBound = -3.0f;
	private float horizontalPosition;
	private bool movingRight;

	void Start()
	{
		// Scale the cube up
		transform.localScale = Vector3.one * 1.3f;

		// Change cube's color
		cubeRenderer = GetComponent<Renderer>();
		materialIndex = Random.Range(0, myMaterials.Length);
		cubeRenderer.material = myMaterials[materialIndex];

		// Set the cube in its initial position
		transform.position = new Vector3(-3, 0, 0);

		movingRight = true;
	}

	void Update()
	{
		// Rotate the cube along the X axis
		transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

		// Transition between random colors
		if (timeLeft <= Time.deltaTime)
		{
			cubeRenderer.material.color = targetColor;
			targetColor = new Color(Random.value, Random.value, Random.value);
			timeLeft = 1.0f;
		}
		else
		{
			cubeRenderer.material.color = Color.Lerp(cubeRenderer.material.color, targetColor, Time.deltaTime / timeLeft);
			timeLeft -= Time.deltaTime;
		}

		// Move the cube left-to-right
		horizontalPosition = transform.position.x;
		if (movingRight == true)
		{
			transform.Translate(Time.deltaTime, 0, 0);
			if (transform.position.x >= rightBound)
			{
				movingRight = false;
			}
		}
		else
		{
			transform.Translate(-Time.deltaTime, 0, 0);
			if (transform.position.x <= leftBound)
			{
				movingRight = true;
			}
		}
	}
}
