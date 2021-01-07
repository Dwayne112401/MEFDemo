using ChinaUnionPay;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOC
{
    /// <summary>
    /// 中国银行
    /// </summary>
    [Export("BOC", typeof(IUnionPay))]
    public class Operation: IUnionPay
    {
        public void SaveMoneny(int amount)
        {
            Console.WriteLine($"把钱存入建设银行，金额为：{amount}");
        }

        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"从建设银行取钱，金额为：{amount}");
        }
    }
}
