using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using ServiceReference1;

namespace MattFengTestMain
{
    class Program
    {
        private const string EncryptKey = "uKKppxiK1lR/CjdrVM9mt10bsNORRdJGdHjbdzlHSBE=";
        private const string EncryptIV = "izGnUpD3F3BggVhrvhlsFw==";
        static void Main(string[] args)
        {
            #region des 加密
            //var str = "Data Source=127.0.0.1;Port=3307;User ID=fengQinTest;Password=123456;DataBase=batmes_client;Allow Zero Datetime=true;Charset=utf8;pooling=true;";
            //Console.WriteLine(XY.Security.AesEncrypt(str, EncryptKey, EncryptIV));
            //Console.WriteLine("冯骎测试哦");

            //var a = true;
            //Console.WriteLine(a.ToString());

            //var test = Test.DecryptOne("KUj/GHcmQ7dZNn1wWfTOapeFKkNA4TfCLk8X1awPmqs=");
            //Console.WriteLine(test);
            #endregion

            #region 事件测试
            //EventTest e = new EventTest(); /* 实例化对象,第一次没有触发事件 */
            //subscribEvent v = new subscribEvent(); /* 实例化对象 */
            //e.ChangeNum += new EventTest.NumManipulationHandler(v.printf); /* 注册 */
            //e.SetValue(7);
            //e.SetValue(11);
            #endregion

            #region WCF测试

            //UserClient user = new UserClient();
            //var result = string.Empty;
            //Task.Run(async () =>
            //{
            //    result = await user.PlusNumberAsync(1, 2);
            //});
            //Console.WriteLine(result);

            #endregion

            #region Csv测试
            //var test = new CsvFileTools("D:\\feng", "testCsv");
            //var data = new List<string[]>();
            //test.ReadTable(out data);
            //var data = new List<string[]>() { new string[] { "序号", "电压", "内阻" }, new string[] { "0", "10", "10" } };

            //test.EditCell("1", 1, 0);
            //var test1 = new CsvFileTools("D:\\feng", "testCsv");
            //test1.EditCell("序号", 0, 0);
            //var test2 = new CsvFileTools("D:\\feng", "testCsv");
            //test2.EditCell("电压", 0, 1);
            //var test3 = new CsvFileTools("D:\\feng", "testCsv");
            //test3.EditCell("内阻", 0, 2);



            //string name = string.Format($"btnAsync_Click_1");
            //Console.WriteLine(name);

            //var a = Newtonsoft.Json.JsonConvert.SerializeObject(null);

            //StreamReader sr = new StreamReader("要写入的文件名", Encoding.Default);
            //StreamWriter sw =   new StreamWriter("临时bai文件", Encoding.Default);
            //string[] a = { "aaa"，"bbb"，"ccc" };
            //string   temp = string.Join(" ", a);
            ////
            //int
            //i = 0;
            //while (!sr.EndOfStream)
            //{
            //    if (i++ < 3)
            //        sw.WriteLine(sr.ReadLine()+temp);
            //    //头三行加上aaa  bbb ccc
            //    else
            //        sw.WriteLine( sr.ReadLine());
            //}
            //sr.Dispose();
            //sw.Dispose();
            //File.Move("临时文件","要写入的文件名" );
            #endregion


            #region 测试
            //var test = new DrinkMinMoney();
            //Console.WriteLine(test.GetMinMoney());
            //var target = 7;
            //int[][]  array = new int[][] {  new int []{ 1, 2, 8, 9 }, new int[] { 4, 7, 10, 13 } };
            //var result=  FindContains.Find(target, array);//判断二维数组中是否有某值

            //FindContains.AddSingal();

            //foreach (var item in FindContains.signalDic)
            //{
            //    Console.WriteLine(item.Key+":"+item.Value);
            //}
            //Console.WriteLine(DecryptTest.GetCpuInfo());

            //ReplaceSpace replaceSpace = new ReplaceSpace();
            //var result=  replaceSpace.replaceSpace("We Are Happy");
            //Console.WriteLine(result);

            //int[] before = { 1, 2, 4, 7, 3, 5, 6, 8 };
            //int[] middle = { 4, 7, 2, 1, 5, 3, 8, 6 };
            //var result= new ReConstructBinaryTree().reConstructBinaryTree(before,middle);
            #endregion

            Console.ReadKey();
        }

    }

    #region 事件测试
    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();

        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum(); /* 事件被触发 */
            }
            else
            {
                Console.WriteLine("event not fire");
                Console.ReadKey(); /* 回车继续 */
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }


        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
    /***********订阅器类***********/

    public class subscribEvent
    {
        public void printf()
        {
            Console.WriteLine("event fire");
            Console.ReadKey(); /* 回车继续 */
        }
    }
    #endregion

    #region 加密
    public class DecryptTest
    {
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string DecryptOne(string code)
        {
            try
            {
                //解码用向量
                byte[] rgbKey = { 0x43, 0x6F, 0x64, 0x65, 0x42, 0x79, 0x52, 0x37 };
                byte[] rgbIV = { 0x4E, 0x65, 0x77, 0x61, 0x72, 0x65, 0x52, 0x37 };
                //解码内容
                byte[] inputByteArray = Convert.FromBase64String(code);
                //DES解码
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return code;
            }
        }

        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCpuInfo()
        {
            //CPU序列号需要BIOS配置系统可读？
            string cpuInfo = " ";
            using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))
            {
                ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    mo.Dispose();
                }
            } 
            return cpuInfo.ToString();
        }
        #endregion

    }
}

