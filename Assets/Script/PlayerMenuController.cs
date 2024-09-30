using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    [SerializeField] private DataHandler handler;
    [SerializeField] private TextMeshProUGUI txtDollar, txtStaminaNow, txtSpeed, txtSpeedCost, txtIncome, txtIncomeCost, txtStamina, txtStaminaCost;
    [SerializeField] private Button btnStamina, btnInCome, btnSpeed, btnRace;
    [SerializeField] CoolDown cd;
    [SerializeField] private Rigidbody rb;
    private bool move, run;
    private float staminaNow;
    private float dollar;
    public Animator animator;
    private int i = 0;


    private void Start()
    {
        handler.Load();
        cd.duration = 1.5f;
        cd.elapse = 0;
        dollar = handler.dollar;
        txtDollar.text = $"{handler.dollar} $";
        staminaNow = handler.strength;
        txtStaminaNow.text = $"{staminaNow} / {handler.strength}";
        UpdateSpeedLevel();
        UpdateStaminaLevel();
        UpdateInComeLevel();
        GameObject player = transform.Find("Player").gameObject;
        rb = player.GetComponent<Rigidbody>();
        btnInCome.onClick.AddListener(UpgradeInCome);
        btnSpeed.onClick.AddListener(UpgradeSpeed);
        btnStamina.onClick.AddListener(UpgradeStamina);
        btnRace.onClick.AddListener(PlayGame);
    }

    private void Update()
    {
        Run(false);
        Move();
    }

    private void RecoverStamina()
    {
        if (staminaNow < handler.strength)
        {
            staminaNow += 1;
            UpdateStaminaStatus();
        }
    }

    public void Run(bool touch)
    {
        if (staminaNow > 0 && touch)
        {
            GetInComme();
            staminaNow -= 1;
            cd.Restart();
            run = true;
            move = false;
            animator.SetBool("Run", true);
            UpdateStaminaStatus();
        }
        else if (touch)
        {
            GetInComme();
            cd.Restart();
            animator.SetBool("Run", false);
            move = true;
            run = false;
            animator.SetBool("Walk", true);
        }

        if (cd.isFinished)
        {
            move = false;
            run = false;
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
            cd.Restart();
            RecoverStamina();
        }
    }

    private void GetInComme()
    {
        i++;
        Debug.Log(i);
        if (i == 3 && run == true)
        {
            dollar += handler.inCome;
            handler.dollar = dollar;
            handler.Save();
            i = 0;
        }
        else if(i == 6)
        {
            dollar += handler.inCome;
            handler.dollar = dollar;
            handler.Save();
            i = 0;
        }
        UpdateMoneyStatus();
    }
    private void Move()
    {

        if (move)
        {
            rb.velocity = new Vector3(0, 0, 5f);
        }
        else
        if (run)
        {
            rb.velocity = new Vector3(0, 0, 10f);
        }
        else { rb.velocity = Vector3.zero; }

    }
    private bool CheckCost(float cost)
    {
        return dollar < cost;
    }

    private void UpdateMoneyStatus()
    {
        txtDollar.text = $"{dollar}";
    }
    private void UpdateStaminaStatus()
    {
        txtStaminaNow.text = $"{staminaNow} / {handler.strength}";
    }
    private void UpdateInComeLevel()
    {
        float incomeCost = 12 + handler.inComeLv * 2;
        if (dollar > incomeCost)
        {
            ColorBlock colors = btnInCome.colors;
            colors.normalColor = Color.blue;
            btnInCome.colors = colors;
        }
        else
        {
            ColorBlock colors = btnInCome.colors;
            colors.normalColor = Color.gray;
            btnInCome.colors = colors;
        }
        txtIncome.text = $"{handler.inCome}";
        txtIncomeCost.text = $"{incomeCost}";
    }
    private void UpdateStaminaLevel()
    {
        float staminaCost = 17 + handler.strengthLv * 2;
        if (dollar > staminaCost)
        {
            ColorBlock colors = btnStamina.colors;
            colors.normalColor = Color.blue;
            btnStamina.colors = colors;
        }
        else
        {
            ColorBlock colors = btnStamina.colors;
            colors.normalColor = Color.gray;
            btnStamina.colors = colors;
        }

        txtStaminaCost.text = $"{staminaCost}";
        txtStamina.text = $"{handler.strength}";
    }
    private void UpdateSpeedLevel()
    {
        float speedCost = 9 + handler.moveSpLv * 3;
        if (dollar > speedCost)
        {
            ColorBlock colors = btnSpeed.colors;
            colors.normalColor = Color.blue;
            btnSpeed.colors = colors;
        }
        else
        {
            ColorBlock colors = btnSpeed.colors;
            colors.normalColor = Color.gray;
            btnSpeed.colors = colors;
        }

        txtSpeedCost.text = $"{speedCost}";
        txtSpeed.text = $"{handler.moveSp}";
    }
    private void UpgradeInCome()
    {
        float cost = 12 + handler.inComeLv * 2;

        if (CheckCost(cost)) return;
        dollar -= cost;
        handler.inCome++;
        handler.dollar = dollar;
        handler.inComeLv++;
        txtDollar.text = $"{handler.dollar} $";
        UpdateSpeedLevel();
        UpdateInComeLevel();
        UpdateStaminaLevel();
        handler.Save();
    }

    private void UpgradeStamina()
    {
        float cost = 17 + handler.strengthLv * 2;
        if (CheckCost(cost)) return;
        dollar -= cost;
        handler.strengthLv += 3;
        handler.dollar = dollar;
        handler.strengthLv++;
        txtDollar.text = $"{handler.dollar} $";
        UpdateSpeedLevel();
        UpdateInComeLevel();
        UpdateStaminaLevel();
        handler.Save();
    }

    private void UpgradeSpeed()
    {
        float cost = 9 + handler.moveSpLv * 3;
        if (CheckCost(cost)) return;
        dollar -= cost;
        handler.moveSp += 0.2f;
        handler.dollar = dollar;
        handler.moveSpLv++;
        txtDollar.text = $"{handler.dollar} $";
        UpdateSpeedLevel();
        UpdateInComeLevel();
        UpdateStaminaLevel();
        handler.Save();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
