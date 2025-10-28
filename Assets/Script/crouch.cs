using UnityEngine;

public class crouch : MonoBehaviour
{
    private BoxCollider2D col;
    private Vector2 defaultSize;
    private Vector2 defaultOffset;

    public bool isCrouching = false; //���Ⴊ�ݒ��ɐ^

    private Rigidbody2D rb;
    public float defaultGravity = 2.0f;

    public Sprite walkSprite;
    public Sprite crouchSprite;
    private SpriteRenderer sr;

    private AudioSource audioSource;
    public AudioClip crouchSE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<BoxCollider2D>(); //�L�����N�^�[�̓����蔻����擾
        defaultSize = col.size; //�����蔻��̑傫������
        defaultOffset = col.offset;

        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && Time.deltaTime != 0)
        {
            //�摜��ύX�@���Ⴊ��
            sr.sprite = crouchSprite;
            if (!isCrouching)
            {
                audioSource.PlayOneShot(crouchSE);
            }
            isCrouching = true;

            //jump jumper = GetComponent<jump>();
            //jumper.Jump = 300;
            rb.gravityScale = defaultGravity*2;

            //�����蔻���ύX
            col.size = new Vector2(defaultSize.x, defaultSize.y * 0.5f); //�����蔻����f�t�H���g�̔����ɕύX
            col.offset = new Vector2(defaultOffset.x, defaultOffset.y - defaultSize.y * 0.25f);
        }
        else if (isCrouching)
        {
            //�摜��ύX�@����
            sr.sprite = walkSprite;
            isCrouching = false;

            //jump jumper = GetComponent<jump>();
            //jumper.Jump = 580;
            rb.gravityScale = defaultGravity;

            //�����蔻���ύX
            col.size = new Vector2(defaultSize.x, defaultSize.y); //�����蔻����f�t�H���g�ɐݒ�
            col.offset = defaultOffset;
        }
    }
}
