﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour {
    Rigidbody2D fisica;
	[SerializeField] private float pulo;
    private Diretor diretor;
    private Vector3 posicaoInicial;

    private void Start() {
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        this.fisica = this.GetComponent<Rigidbody2D>();
    }

    private void Update () { 
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            this.Impulsionar();
        }
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * pulo, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D colisao) {
        this.fisica.simulated = false;
        this.diretor.stop();
    }

    public void Reiniciar() {
        this.transform.position = posicaoInicial; 
        this.fisica.simulated = true;
    }
}