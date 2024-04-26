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
                   OnValueChanged();
                }).AddTo(this);

        }

        void FixedUpdate()
        {
            //TODO:現在はStickMoveが毎回StickStatusに参照しています。この部分をUniRxを使って、値が変わった時だけアクセスするようにしてみましょう ok
            
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _velocity.x--;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _velocity.x++;
            }

            //TODO:現在はStickMoveが毎回StickStatusに参照しています。この部分をUniRxを使って、値が変わった時だけアクセスするようにしてみましょう
        }

        void OnValueChanged() // 変数が変わったときの処理
        {
            _rigidbody2D.velocity = Vector2.zero;
            _velocity = Vector2.zero;
        }

        void OnValueChanged2()
        {
            Vector2 _mooveVelocity = _velocity * _stickStatus.MoveSpeed;
            _rigidbody2D.velocity = _mooveVelocity * Time.fixedDeltaTime * CORRECTIONVALUE;
        }

    }
}