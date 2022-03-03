using UnityEngine;

public class StateMachineTest : MonoBehaviour
{
    StateMachine<TestState> stateMachine;

    TestState test, test2;

    // Start is called before the first frame update
    void Start()
    {
        test = new TestState();
        test.Begin = TestBegin;
        test.Update = TestUpdate;
        test.End = TestEnd;

        test2 = new TestState();
        test2.Begin = TestBeginTwo;
        test2.Update = TestUpdateTwo;
        test2.End = TestEndTwo;

        stateMachine = new StateMachine<TestState>(test);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.GetState().Update();
    }

    void TestUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(test2);
        }
    }

    void TestBegin()
    {
        Debug.Log("begin");
    }

    void TestEnd()
    {
        Debug.Log("end");
    }

    void TestBeginTwo()
    {
        Debug.Log("begin 2");
    }

    void TestEndTwo()
    {
        Debug.Log("end 2");
    }

    void TestUpdateTwo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(test);
        }
    }

    class TestState : StateBase
    {
        public StateCallback Update = () => {};
    }
}
