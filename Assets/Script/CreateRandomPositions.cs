using UnityEngine;

public class CreateRandomPositions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject createPrefab;//��������GameObject
    public Transform rangeA;//��������͈�A
    public Transform rangeB;//��������͈�B

    public float spped = 5.0f;

    // �o�ߎ���
    private float time;
    int rnd = Random.Range(1, 10);

    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;
        rnd = Random.Range(1, 500);
        //if (time > 1.0f) // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (rnd <= 1)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(rangeA.position.z, rangeB.position.z);
            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            // �o�ߎ��ԃ��Z�b�g
            time = 0f;
        }
    }
}
