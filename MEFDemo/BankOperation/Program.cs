using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BankOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation();

            Console.ReadKey();
        }

        static void Operation()
        {
            // 创建 ContainerBuilder
            ContainerBuilder builder = new ContainerBuilder();

            //实现类所在的程序集名称
            Assembly assembly = Assembly.Load("BankOperation");

            // 获取程序集所在的全部实现类
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            // t.Name.StartsWith:通过类名添加筛选条件,从类名的起始位开始匹配
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.StartsWith("B")).AsImplementedInterfaces();

            // 实例化
            IContainer container = builder.Build();
            IEnumerable<IUnionPay> banks = container.Resolve<IEnumerable<IUnionPay>>();

            foreach (var item in banks)
            {
               item.SaveMoneny(100);
               item.WithdrawMoney(20);
                Console.WriteLine("-----------------------------------------------");
            }
        }

    }

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

    public class ABank:IUnionPay
    {
        public void SaveMoneny(int amount)
        {
            Console.WriteLine($"把钱存入A银行，金额为：{amount}");
        }

        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"从A银行取钱，金额为：{amount}");
        }
    }

    public class BBank : IUnionPay
    {
        public void SaveMoneny(int amount)
        {
            Console.WriteLine($"把钱存入B银行，金额为：{amount}");
        }

        public void WithdrawMoney(int amount)
        {
            Console.WriteLine($"从B银行取钱，金额为：{amount}");
        }
    }
}
