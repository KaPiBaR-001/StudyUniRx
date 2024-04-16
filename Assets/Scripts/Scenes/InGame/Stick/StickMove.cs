using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Scenes.InGame.Stick
{
    [RequireComponent(typeof(StickStatus),typeof(Rigidbody2D))]
    public class StickMove : MonoBehaviour
    {
        private StickStatus _stickStatus;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _velocity;
        private const int CORRECTIONVALUE = 10;//���l�𒲐����邽�߂̕␳�l�ł�
        void Start()
        {
            _stickStatus = GetComponent<StickStatus>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _stickStatus.OnStickStop
                .Subscribe(_ =>
                {
                    StickStop();
                }).AddTo(this);
        }

        void FixedUpdate()
        {
            //TODO:���݂�StickMove������StickStatus�ɎQ�Ƃ��Ă��܂��B���̕�����UniRx���g���āA�l���ς�����������A�N�Z�X����悤�ɂ��Ă݂܂��傤
            _velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _velocity.x--;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _velocity.x++;
            }

            //TODO:���݂�StickMove������StickStatus�ɎQ�Ƃ��Ă��܂��B���̕�����UniRx���g���āA�l���ς�����������A�N�Z�X����悤�ɂ��Ă݂܂��傤
            Vector2 _mooveVelocity = _velocity * _stickStatus.MoveSpeed;
            _rigidbody2D.velocity = _mooveVelocity * Time.fixedDeltaTime * CORRECTIONVALUE;
        }

        private void StickStop()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

    }
}