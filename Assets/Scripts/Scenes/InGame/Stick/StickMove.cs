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
        private const int CORRECTIONVALUE = 10;//数値を調整するための補正値です
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
            //TODO:現在はStickMoveが毎回StickStatusに参照しています。この部分をUniRxを使って、値が変わった時だけアクセスするようにしてみましょう
            _velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _velocity.x--;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _velocity.x++;
            }

            //TODO:現在はStickMoveが毎回StickStatusに参照しています。この部分をUniRxを使って、値が変わった時だけアクセスするようにしてみましょう
            Vector2 _mooveVelocity = _velocity * _stickStatus.MoveSpeed;
            _rigidbody2D.velocity = _mooveVelocity * Time.fixedDeltaTime * CORRECTIONVALUE;
        }

        private void StickStop()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

    }
}