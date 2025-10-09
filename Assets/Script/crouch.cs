using UnityEngine;

public class crouch : MonoBehaviour
{
    private BoxCollider2D col;
    private Vector2 defaultSize;

    private bool isCrouching = false; //���Ⴊ�ݒ��ɐ^

    public Sprite walkSprite;
    public Sprite crouchSprite;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<BoxCollider2D>(); //�L�����N�^�[�̓����蔻����擾
        defaultSize = col.size; //�����蔻��̑傫������

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //�摜��ύX�@���Ⴊ��
            sr.sprite = crouchSprite;
            isCrouching = true;

            //�����蔻���ύX
            col.size = new Vector2(defaultSize.x, defaultSize.y * 0.5f); //�����蔻����f�t�H���g�̔����ɕύX
        }
        else if (isCrouching)
        {
            //�摜��ύX�@����
            sr.sprite = walkSprite;
            isCrouching = true;

            //�����蔻���ύX
            col.size = new Vector2(defaultSize.x, defaultSize.y); //�����蔻����f�t�H���g�ɐݒ�
        }
    }
}
