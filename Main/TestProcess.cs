using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDevelopmentExamples
{
    // 定义状态枚举
    public enum State
    {
        WaitingForRequest,
        Scanning,
        Testing,
        TestCompleted,
        Cancelled
    }

    // 定义事件枚举
    public enum Event
    {
        RequestReceived,
        ScanSuccess,
        TestStarted,
        TestEnded,
        Cancel
    }

    // 定义流程类
    public class TestProcess
    {
        private State currentState;

        public TestProcess()
        {
            currentState = State.WaitingForRequest;
        }

        // 处理事件的方法，返回bool表示是否成功
        public bool HandleEvent(Event e)
        {
            Console.WriteLine();
            switch (currentState)
            {
                case State.WaitingForRequest:
                    return HandleWaitingForRequest(e);
                case State.Scanning:
                    return HandleScanning(e);
                case State.Testing:
                    return HandleTesting(e);
                case State.TestCompleted:
                    return HandleTestCompleted(e);
                case State.Cancelled:
                    // 如果流程被取消，直接返回false
                    return false;
            }
            return false; // 默认返回false
        }

        private bool HandleWaitingForRequest(Event e)
        {
            switch (e)
            {
                case Event.RequestReceived:
                    Console.WriteLine("请求测试信号已接收，准备扫描。");
                    currentState = State.Scanning;
                    return true;
                case Event.Cancel:
                    Console.WriteLine("流程被取消。");
                    currentState = State.Cancelled;
                    return false;
            }
            return false;
        }

        private bool HandleScanning(Event e)
        {
            switch (e)
            {
                case Event.ScanSuccess:
                    Console.WriteLine("扫码成功，开始测试。");
                    currentState = State.Testing;
                    return true;
                case Event.Cancel:
                    Console.WriteLine("流程被取消。");
                    currentState = State.Cancelled;
                    return false;
            }
            return false;
        }

        private bool HandleTesting(Event e)
        {
            switch (e)
            {
                case Event.TestStarted:
                    Console.WriteLine("测试开始。");
                    // 假设测试逻辑在这里，返回true表示测试可以继续
                    return true;
                case Event.TestEnded:
                    Console.WriteLine("测试结束，准备输出结果。");
                    currentState = State.TestCompleted;
                    return true;
                case Event.Cancel:
                    Console.WriteLine("流程被取消。");
                    currentState = State.Cancelled;
                    return false;
            }
            return false;
        }

        private bool HandleTestCompleted(Event e)
        {
            switch (e)
            {
                case Event.TestEnded:
                    Console.WriteLine("测试结果已输出，返回等待请求状态。");
                    currentState = State.WaitingForRequest;
                    return true;
            }
            return false;
        }
    }



}
