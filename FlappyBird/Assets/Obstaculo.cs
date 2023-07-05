﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {
	
	[SerializeField] private float velocidade;
	private Vector3 posicaoAviao;
	public bool pontuei = false;
	private Pontuacao pontos;

	private void Start() {
		this.posicaoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
		this.pontos = GameObject.FindObjectOfType<Pontuacao>();
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);

		if(!this.pontuei && this.transform.position.x < this.posicaoAviao.x) {
			this.pontuei = true;
			this.pontos.AdicionaPontos();
		}
	}

	private void Awake() {
		this.transform.Translate(Vector3.up * Random.Range(-2, 2));
	}

	private void OnTriggerEnter2D(Collider2D obj) {
		this.Destruir();
	}

	public void Destruir() {
		Destroy(this.gameObject);
	}
}
