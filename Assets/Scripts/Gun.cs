using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon
{
    [SerializeField] private int _bulletCount = 30;
    private int _shootDistance = 10000;
    private Camera _mainCamera;
    public GameObject _crossHair;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
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
        if (_bullet)
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
        }
    }
}
