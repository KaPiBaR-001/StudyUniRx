using UnityEngine;

namespace Scenes.InGame.Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField, Tooltip("Ball�̃v���t�@�u������")]
        GameObject _ballPrefab;

        [Header("�X�|�[���Ɋւ���p�����[�^")]
        [SerializeField, Tooltip("�X�e�B�b�N����y���ɃI�t�Z�b�g���鋗��")]
        private float _yOffsetDistance = 0.5f;

        //TODO:����InGameManager����X�|�[�������Ă��܂��B�����InGameManager����C�x���g�𔭍s�����A���̃X�N���v�g�󂯎���Ď�����Spawn������悤�ɕύX���܂��傤
        public void Spawn()
        {
            var Stick = GameObject.FindWithTag("Player");
            Instantiate(_ballPrefab, Stick.transform.position + new Vector3(0, _yOffsetDistance, 0), Quaternion.identity, transform.parent);
        }
    }
}