using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickMove : MonoBehaviour
{
	private bool move;
	private Vector2 randomVector;

	private void Update()
	{
		if(!move) return;
		transform.Translate(randomVector*Time.deltaTime);
	}

	public void StartMotion(int scoreIncrease)
	{
		transform.localPosition = Vector2.zero;
		GetComponent<Text>().text = "+" + scoreIncrease;
		randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
		move = true;
        GetComponent<Animation>().Play("clickTextFade");
	}

   
}
