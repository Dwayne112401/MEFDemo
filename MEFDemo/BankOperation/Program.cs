using ChinaUnionPay;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write($"请输入银行名称：");
                string name = Console.ReadLine();
                BlankOperation(name, 300, 100);
                Console.WriteLine("----------------------------------");
            }
        }

        static void BlankOperation(string bankName, int saveMonenyAmout, int withdrawMoneyAmount)
        {
            AggregateCatalog catelog = new AggregateCatalog();

            // 添加部件所在文件目录
            string path = $"{Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath)}\\bank\\";
            catelog.Catalogs.Add(new DirectoryCatalog(path));

            // 声明容器
            CompositionContainer container = new CompositionContainer(catelog);
            var dev = container.GetExportedValue<IUnionPay>(bankName);

            // 动作调用
            dev.SaveMoneny(saveMonenyAmout);
            dev.WithdrawMoney(withdrawMoneyAmount);
        }
    }
}
