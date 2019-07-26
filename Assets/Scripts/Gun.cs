using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon
{
    [SerializeField] private int _bulletCount = 30;
    private int _maxCountOfBullets = 30;
    private int _shootDistance = 10000;
    private Camera _mainCamera;
    public GameObject _crossHair;

    private Animator _animator;
    private int _idleHash = Animator.StringToHash("Idle");
    private int _fireHash = Animator.StringToHash("Fire");
    private int _reloadHash = Animator.StringToHash("Reload");

    private UIController _uiController;

    private void Awake()
    {
        _maxCountOfBullets = _bulletCount;
        _fire = _bulletCount > 0;
        _mainCamera = Camera.main;
        _animator = GetComponent<Animator>();
        _uiController = GetComponent<UIController>();
        _uiController.BroadcastMessage("OnBulletCountChanged", _bulletCount);
    }

    protected override void Update()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger(_fireHash);
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetTrigger(_reloadHash);
        }
    }

    private IEnumerator ShootingFX()
    {
        yield return new WaitForSeconds(0.5f);
    }

    Vector3 GetDirection(Vector3 HitPoint, Vector3 BulletPos)
    {
        Vector3 decr = HitPoint - BulletPos;
        float dist = decr.magnitude;
        return decr / dist;
    }

    public override void Fire()
    {
        if (_bullet && _fire)
        {
            _bulletCount--;

            Bullet tempbullet = Instantiate(_bullet, _gunT.position, _gunT.rotation) as Bullet;
            if (tempbullet)
            {
                RaycastHit hit;
                Ray ray = _mainCamera.ScreenPointToRay(_crossHair.transform.position);
                Rigidbody _bulletRB = tempbullet.GetRB;

                if (Physics.Raycast(ray, out hit, _shootDistance))
                {
                    _bulletRB.AddForce(GetDirection(hit.point, tempbullet.Position) * 1000, ForceMode.Impulse);

                }
                else
                {

                    _bulletRB.AddForce(GetDirection(ray.GetPoint(100000f), tempbullet.Position) * 1000, ForceMode.Impulse);
                }

                tempbullet.gunT = _gunT;
                tempbullet.Force = _force;
                tempbullet.name = "bullet";
            }

            if (_bulletCount == 0)
            {
                _fire = false;
            }

            if (_uiController)
            {
                _uiController.BroadcastMessage("OnBulletCountChanged", _bulletCount);
            }
        }
    }

    public override void Reload()
    {
        _bulletCount = _maxCountOfBullets;
        _fire = _bulletCount > 0;
        if (_uiController)
        {
            _uiController.BroadcastMessage("OnBulletCountChanged", _bulletCount);
        }
    }
}
