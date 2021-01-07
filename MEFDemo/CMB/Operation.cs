using ChinaUnionPay;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMB
{
    /// <summary>
    /// 招商银行
    /// </summary>
    [Export("CMB",typeof(IUnionPay))]
    public class Operation : IUnionPay
    {
        public void SaveMoneny(int amount)
        {
            Console.WriteLine($"把钱存入招商银行，金额为：{amount}");
        }

        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"从招商银行取钱，金额为：{amount}");
        }
    }
}
