using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class click : MonoBehaviour
{
	public Text scoreText;
	public int score;
	private Save sv = new Save();
	public GameObject clickParent, clickText;
	private clickMove[] clickTextPool = new clickMove[15];
	private int clickNum;



	private void Awake()
	{
		if(PlayerPrefs.HasKey("SV"))
		{
			sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
			score = sv.score;
		}
	}

	private void Start()
	{
		for (int i = 0; i < clickTextPool.Length; i++)
			clickTextPool[i] = Instantiate(clickText, clickParent.transform).GetComponent<clickMove>();
	}

	private void Update()
	{
		scoreText.text = score + " ";
	}

	public void clicker()
	{
		clickTextPool[clickNum].StartMotion(1);
		clickNum = clickNum == clickTextPool.Length - 1 ? 0 : clickNum + 1;
		score++;
		scoreText.text = score + " ";
	}



	private void OnApplicationPause(bool pause)
	{
		if(pause)
		{
			sv.score = score;
			PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
		}
	}

	private void OnApplicationQuit()
	{
		sv.score = score;
		PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
	}


		
}
[Serializable]
public class Save
{
	public int score;
}
