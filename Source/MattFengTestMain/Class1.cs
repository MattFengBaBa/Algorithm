using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain
{
    /// <summary>
    /// 恩捷OCV PLC 逻辑
    /// </summary>
    class Class1
    {
        private void main()
        {
            bool R5000 = true;
            bool R5001 = true;
            bool R5002 = true;
            int channelNow = 1;
            while (true)
            {
                while (!R5000)
                {
                    //等待测试开始
                }
                //R5000 = false;
                while (true)
                {
                    //切换通道执行
                    SwitchChannel(channelNow);
                    ShowChannelConnected(channelNow);
                    while (!R5001 && !R5002)
                    {
                        //等待当前通道测试完成或全部测试完成通知
                    }
                    if (R5001)
                    {
                        //R5001 = false;
                        //继续切换通道
                        continue;
                    }
                    if (R5002)
                    {
                        //R5002 = false;
                        //R5000 = false;
                        //重新等待测试开始
                        break;
                    }
                }
            }
        }

        private void ShowChannelConnected(int channelNow)
        {
            //将R4000~R403B中对应channelNow的位置置1.其他清零
        }

        private void SwitchChannel(int channel)
        {
            //断开所有通道或当前通道

            //接通通道channel
        }
    }
}
