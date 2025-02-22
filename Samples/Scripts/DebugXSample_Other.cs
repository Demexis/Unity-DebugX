using DCFApixels.DebugXCore;
using UnityEngine;

namespace DCFApixels
{
    public class DebugXSample_Other : MonoBehaviour
    {
        public Gradient Gradient;
        public float GradientMultiplier = 5;
        public Transform[] Points;

        private void OnDrawGizmos()
        {
            int i = -1;
            const float RADIUS_M = 0.5f;

            i++; DebugX.Draw(GetColor(Points[i])).Cross(Points[i].position, Points[i].localScale.x);
            i++; DebugX.Draw(GetColor(Points[i])).BillboardCircle(Points[i].position, Points[i].localScale.x * RADIUS_M);
            i++; DebugX.Draw(GetColor(Points[i])).WireMesh<SphereMesh>(Points[i].position, Points[i].rotation, Points[i].localScale * RADIUS_M);
            i++; DebugX.Draw(GetColor(Points[i])).Text(Points[i].position, Points[i].name);

            i++; DebugX.Draw(GetColor(Points[i])).Dot(Points[i].position);
            i++; DebugX.Draw(GetColor(Points[i])).WireDot(Points[i].position);
            i++; DebugX.Draw(GetColor(Points[i])).DotQuad(Points[i].position);
            i++; DebugX.Draw(GetColor(Points[i])).DotDiamond(Points[i].position);
            i++; DebugX.Draw(GetColor(Points[i])).DotCross(Points[i].position);
        }
        private Color GetColor(Transform pos1)
        {
            Vector3 pos = pos1.localPosition;
            pos /= GradientMultiplier == 0 ? 1 : GradientMultiplier;
            pos += Vector3.one * 0.5f;
            float t = pos.x + pos.y + pos.z;
            t /= 3f;
            return Gradient.Evaluate(Mathf.Clamp01(t));
        }
    }
}
