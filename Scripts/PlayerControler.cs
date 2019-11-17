using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    //находится ли персонаж на земле или в прыжке?
    private bool isGrounded = false;
    //ссылка на компонент Transform объекта
    //для определения соприкосновения с землей
    public Transform groundCheck;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.2f;
    //ссылка на слой, представляющий землю
    public LayerMask whatIsGround;
    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 10f;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;
    public bool attack;
    public float score;
    /// <summary>
    /// Начальная инициализация
    /// </summary>
	private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    /// <summary>
    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    /// </summary>
    private void FixedUpdate()
    {     
        //определяем, на земле ли персонаж
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        float move = Input.GetAxis("Horizontal");
        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        anim.SetFloat("Speed", Mathf.Abs(move));
        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if (move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
        HandleAttacks();
    }
    private void Update()
    {
        //если персонаж на земле и нажат пробел...
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            
            //прикладываем силу вверх, чтобы персонаж подпрыгнул
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 650));
            
        }
        HandleInput();
    }
    private void HandleAttacks()
    {
        if(attack)
        {
            anim.SetTrigger("Attack");
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack = true;
        }
       else if (attack)
        
            attack = false;
        
        
    }
    /// <summary>
    /// Метод для смены направления движения персонажа и его зеркального отражения
    /// </summary>
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Gems")
        {
            score++;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Enemy")
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 950));


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void OnGUI()
    {
        
        GUI.contentColor = Color.yellow;
        GUI.backgroundColor = Color.yellow;
        GUI.Box(new Rect(400, 0, 200, 50), "Рубінчики: " + score);
        
    }
}
    


