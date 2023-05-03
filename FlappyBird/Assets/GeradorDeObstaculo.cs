﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculo : MonoBehaviour {
	
	[SerializeField] private float tempoParaGerar;
	[SerializeField] private GameObject obstaculo;
	private float cronometro;

	private void Awake() 
	{
		this.cronometro = this.tempoParaGerar;
	}

	// Update is called once per frame
	private void Update () 
	{
		this.cronometro -= Time.deltaTime;

		if(this.cronometro < 0) 
		{
			// gerar o obstaculo
			GameObject.Instantiate(this.obstaculo, this.transform.position, Quaternion.identity);
			this.cronometro = this.tempoParaGerar;
		}
	}
}
