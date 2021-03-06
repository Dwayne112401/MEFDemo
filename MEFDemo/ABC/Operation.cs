﻿using ChinaUnionPay;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    /// <summary>
    /// 农业银行
    /// </summary>
    [Export("ABC", typeof(IUnionPay))]
    public class Operation: IUnionPay
    {
        public void SaveMoneny(int amount)
        {
            Console.WriteLine($"把钱存入农业银行，金额为：{amount}");
        }

        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"从农行银行取钱，金额为：{amount}");
        }
    }
}
