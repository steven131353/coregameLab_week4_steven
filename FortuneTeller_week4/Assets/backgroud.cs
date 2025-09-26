using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UGUI.Extend
{
    // ���彥�䷽��ö��
    [AddComponentMenu("UI/Effects/Gradient")]
    public enum Dir
    {
        Horizontal, // ˮƽ����
        Vertical,   // ��ֱ����
    }

    // �Զ����ݶ�Ч���࣬�̳���BaseMeshEffect
    public class Gradient : BaseMeshEffect
    {
        [SerializeField] // ���л��ֶΣ�����Inspector�б༭
        private Dir dir = Dir.Vertical; // ���䷽��Ĭ�ϴ�ֱ

        [SerializeField]
        public Color32 color1 = Color.white; // ������ʼ��ɫ��Ĭ�ϰ�ɫ

        [SerializeField]
        public Color32 color2 = Color.white; // ���������ɫ��Ĭ�ϰ�ɫ

        [SerializeField]
        private float range = 0f; // ���䷶Χ��������ɫ�Ĺ�������Ĭ���޷�Χ����ȫ���䣩

        [SerializeField]
        private bool isFlip = false; // �Ƿ�ת���䷽��Ĭ�ϲ���ת

        // ��дModifyMesh�����������޸�UIԪ�ص�����
        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive()) // ������δ�����ִ�к�������
            {
                return;
            }

            int count = vh.currentVertCount; // ��ȡ��ǰ��������
            if (count > 0) // ����ж��㣬����д���
            {
                List<UIVertex> vertices = new List<UIVertex>(); // ���������б�

                // �������ж��㲢��ӵ��б���
                for (int i = 0; i < count; i++)
                {
                    UIVertex uIVertex = new UIVertex();
                    vh.PopulateUIVertex(ref uIVertex, i); // ��䶥����Ϣ
                    vertices.Add(uIVertex);
                }

                // ���ݽ��䷽�������Ӧ�Ļ��Ʒ���
                switch (dir)
                {
                    case Dir.Horizontal:
                        DrawHorizontal(vh, vertices, count);
                        break;
                    case Dir.Vertical:
                        DrawVertical(vh, vertices, count);
                        break;
                    default:
                        break;
                }
            }
        }

        // ���ƴ�ֱ����Ľ���
        private void DrawVertical(VertexHelper vh, List<UIVertex> vertices, int count)
        {
            // ��ʼ�������͵ײ�Y����
            float topY = vertices[0].position.y;
            float bottomY = vertices[0].position.y;

            // �������ж��㣬�ҵ���ߺ���͵�Y����
            for (int i = 0; i < count; i++)
            {
                float y = vertices[i].position.y;
                if (y > topY) topY = y;
                else if (y < bottomY) bottomY = y;
            }

            float height = topY - bottomY; // ����߶Ȳ�

            // �������ж��㣬������ɫ����
            for (int i = 0; i < count; i++)
            {
                UIVertex vertex = vertices[i];
                Color32 color = Color.white;

                // �����Ƿ�ת�����㵱ǰ�������ɫ
                if (isFlip)
                {
                    color = Color32.Lerp(color2, color1, 1 - (vertex.position.y - bottomY) / height * (1f - range));
                }
                else
                {
                    color = Color32.Lerp(color2, color1, (vertex.position.y - bottomY) / height * (1f - range));
                }

                vertex.color = color; // ���ö�����ɫ
                vh.SetUIVertex(vertex, i); // ���������еĶ���
            }
        }

        // ����ˮƽ����Ľ���
        private void DrawHorizontal(VertexHelper vh, List<UIVertex> vertices, int count)
        {
            // ע�⣺����Ӧ�����ҵ���������ҵ�X���꣬ע���д��ڱ���
            float leftX = vertices[0].position.x;
            float rightX = vertices[0].position.x;

            // �������ж��㣬�ҵ���������ҵ�X����
            for (int i = 0; i < count; i++)
            {
                float x = vertices[i].position.x;
                if (x > rightX) rightX = x;
                else if (x < leftX) leftX = x;
            }

            float width = rightX - leftX; // �����Ȳ�

            // �������ж��㣬������ɫ����
            for (int i = 0; i < count; i++)
            {
                UIVertex vertex = vertices[i];
                Color32 color = Color.white;

                // �����Ƿ�ת�����㵱ǰ�������ɫ
                if (isFlip)
                {
                    color = Color32.Lerp(color2, color1, 1 - (vertex.position.x - leftX) / width * (1f - range));
                }
                else
                {
                    color = Color32.Lerp(color2, color1, (vertex.position.x - leftX) / width * (1f - range));
                }

                vertex.color = color; // ���ö�����ɫ
                vh.SetUIVertex(vertex, i); // ���������еĶ���
            }
        }
    }
}