using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaUnionPay
{
    public interface IUnionPay
    {
        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="amount">存钱金额</param>
        void SaveMoneny(int amount);

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount">取钱金额</param>
        void WithdrawMoney(int amount);
    }
}
