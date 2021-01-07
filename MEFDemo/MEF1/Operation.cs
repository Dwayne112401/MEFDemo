using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEF1
{
    class Operation
    {
        static void Main(string[] args)
        {
            BlankOperation("CBC",300,100);
            Console.WriteLine("------------------------------");
            BlankOperation("BOC",888,666);
            Console.ReadKey();
        }

        static void BlankOperation(string bankName,int saveMonenyAmout,int withdrawMoneyAmount)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            var dev = container.GetExportedValue<IUnionPay>(bankName);
            dev.SaveMoneny(saveMonenyAmout);
            dev.WithdrawMoney(withdrawMoneyAmount);
        }
    }

  
    interface IUnionPay
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

    /// <summary>
    /// 工商银行
    /// </summary>
    [Export("CBC",typeof(IUnionPay))]
    class ICBC : IUnionPay
    {
        public void SaveMoneny(int amount)
        {
            Console.WriteLine($"把钱存入工商银行，金额为：{amount}");
        }

        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"从工商银行取钱，金额为：{amount}");
        }
    }

    /// <summary>
    /// 建设银行
    /// </summary>
    [Export("CCB", typeof(IUnionPay))]
    class CCB : IUnionPay
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

    /// <summary>
    /// 农业银行
    /// </summary>
    [Export("ABC", typeof(IUnionPay))]
    class ABC : IUnionPay
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

    /// <summary>
    /// 中国银行
    /// </summary>
    [Export("BOC", typeof(IUnionPay))]
    class BOC : IUnionPay
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
