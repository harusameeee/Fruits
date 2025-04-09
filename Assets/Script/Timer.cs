using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class Timer : MonoBehaviour
{
    private float m_timeLimit;
    private float m_countDown = 3.4f;

    [SerializeField] TextMeshProUGUI m_timerText;
    [SerializeField] TextMeshProUGUI m_countDownText;
    [SerializeField] GameObject finishMask;

    private async void Start()
    {
        m_timeLimit = PlayOnlyData.TimeLimit;

        // �J�E���g�_�E����\��
        await CountdownStart();

        // �^�C�}�[�J�n
        await StartTimer();

        // �^�C�}�[�I����̓��͑҂�
        await WaitForSpaceKey();

        // �V�[���J��
        SceneManager.LoadScene("ResultScene");
    }

    private async UniTask CountdownStart()
    {
        while (m_countDown > 0)
        {
            m_countDownText.text = m_countDown.ToString("f0");
            m_countDown -= Time.deltaTime;
            await UniTask.Yield();
        }

        m_countDownText.text = "";
    }

    private async UniTask StartTimer()
    {
        while (m_timeLimit > 0)
        {
            m_timeLimit -= Time.deltaTime;
            m_timerText.text = "����" + m_timeLimit.ToString("f0");
            await UniTask.Yield();
        }

        m_timeLimit = 0;
        m_timerText.text = "����0";
        finishMask.SetActive(true);
    }

    private async UniTask WaitForSpaceKey()
    {
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
    }
}
