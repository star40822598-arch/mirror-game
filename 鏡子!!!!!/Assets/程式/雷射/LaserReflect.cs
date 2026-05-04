using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserReflect : MonoBehaviour
{
    public int maxReflections = 5;   // 最多反射次數
    public float maxDistance = 50f;  // 每段距離

    private LineRenderer line;

    [Header("Circle Laser")]
    public bool useCircleLaser = false;   // 是否啟用圓形雷射
    public float circleRadius = 3f;       // 半徑
    public int circleSegments = 50;       // 圓的平滑度

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (useCircleLaser)
        {
            DrawCircle();
        }
        else
        {
            ShootLaser();
        }
    }

    void DrawCircle()
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = i * Mathf.PI * 2 / circleSegments;

            float x = Mathf.Cos(angle) * circleRadius;
            float z = Mathf.Sin(angle) * circleRadius;

            Vector3 point = transform.position + new Vector3(x, 0, z);
            points.Add(point);
        }

        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }

    void ShootLaser()
    {
        List<Vector3> points = new List<Vector3>();

        Vector3 direction = transform.forward;
        Vector3 position = transform.position;

        points.Add(position);

        for (int i = 0; i < maxReflections; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                // 加入碰撞點
                points.Add(hit.point);

                // ⭐ 檢測是否有可被雷射觸發的物件
                LaserTarget target = hit.collider.GetComponent<LaserTarget>();
                if (target != null)
                {
                    target.HitByLaser();
                }

                LaserTargetRoom2 target2 = hit.collider.GetComponent<LaserTargetRoom2>();
                if (target2 != null)
                {
                    target2.HitByLaser_Room2();
                }

                // ⭐ 如果是鏡子 → 反射
                if (hit.collider.CompareTag("Mirror"))
                {
                    direction = Vector3.Reflect(direction, hit.normal);

                    // ⭐ 偏移避免卡住
                    position = hit.point + direction * 0.01f;
                }
                else
                {
                    // 打到非鏡子 → 停止
                    break;
                }
            }
            else
            {
                // ⭐ 沒打到任何東西 → 雷射延伸出去（關鍵！）
                points.Add(position + direction * maxDistance);
                break;
            }
        }

        // ⭐ 更新 LineRenderer
        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }
}