using FileOperations;
using FileOperations.Enum;
using EfficientOffice.ByEPPlus;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using NUnit;
using NUnit.Framework;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Collections;
using System.Text;
using OfficeOpenXml;
using NUnit.Framework.Internal.Execution;
using System.Reflection.PortableExecutable;
using System.Net.Sockets;
using System.Net;
using System.Linq;
using System.ComponentModel;
using System;
using HslCommunication.Profinet.Siemens;
using System.Threading;

namespace CSharpDevelopmentExamples
{
    internal class Program
    {

        static System.Timers.Timer timer;
        static bool isFirstExecution = true;
        private static UTF8Encoding utf8BOM = new UTF8Encoding(true);
        public static void Main(string[] args)
        {

           List<Model> models =     new List<Model>();
           models.Add(new Model(){Index = 1});
           models.Add(new Model(){Index = 2});
           var a = models.Min(x => x.Index);

        }
        static string ConvertToHex(string s)
        {
            var num = int.Parse(s);
            return num.ToString("X2");
        }
    }

    class Model
    {
        public int Index { get; set; }
    }
    public class FyCheckClient
    {
        private readonly string ip;
        private readonly int port;
        private Socket clientSocket;
        public FyCheckClient(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public OperationResult Connect()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                return OperationResult.OK();
            }
            catch (Exception ex)
            {
                return OperationResult.NG($"连接失败: {ex.Message}");
            }
        }
        public OperationResult<byte[]> Read()
        {
            try
            {
                if (clientSocket == null || !clientSocket.Connected)
                {
                    return OperationResult<byte[]>.NG("负压自动检测失败，Socket未连接");
                }

                byte[] buffer = new byte[1024];
                int bytesRead = clientSocket.Receive(buffer);
                byte[] result = new byte[bytesRead];
                Array.Copy(buffer, result, bytesRead);

                return OperationResult<byte[]>.OK(result);
            }
            catch (Exception ex)
            {
                return OperationResult<byte[]>.NG($"负压自动检测失败，读取失败: {ex.Message}");
            }
        }
        public OperationResult Write(byte[] data)
        {
            try
            {
                if (clientSocket == null || !clientSocket.Connected)
                {
                    return OperationResult.NG("负压自动检测失败，Socket未连接");
                }
                clientSocket.Send(data);
                return OperationResult.OK();
            }
            catch (Exception ex)
            {
                return OperationResult.NG($"负压自动检测失败，写入失败，: {ex.Message}");
            }
        }
        public void Close()
        {
            clientSocket?.Close();
        }
    }

    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult OK()
        {
            return new OperationResult { Success = true, Message = "Operation succeeded" };
        }

        public static OperationResult NG(string message)
        {
            return new OperationResult { Success = false, Message = message };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public static OperationResult<T> OK(T data)
        {
            return new OperationResult<T> { Success = true, Data = data, Message = "Operation succeeded" };
        }

        public static new OperationResult<T> NG(string message)
        {
            return new OperationResult<T> { Success = false, Message = message };
        }


    }


    public interface ICalculationStrategy
    {
        int Calculate(int a, int b);
    }

    public class AddStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public class SubtractStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    public class MultiplyStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }
    }

    public class Calculator
    {
        private ICalculationStrategy _strategy;

        public Calculator(ICalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public int PerformCalculation(int a, int b)
        {
            return _strategy.Calculate(a, b);
        }
    }

    // 使用策略模式


    public class ChanelTempAlarmModel
    {
        public string DeviceName { get; set; }
        public int AlarmChannel { get; set; }
        public double AlamrTmep { get; set; }
        public double SettingAlamrTmep { get; set; }
        public DateTime AlarmTime { get; set; }
    }
}
