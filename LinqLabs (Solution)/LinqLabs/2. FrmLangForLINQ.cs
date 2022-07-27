using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//Notes: LINQ 主要參考 
//組件 System.Core.dll,
//namespace {}  System.Linq
//public static class Enumerable
//


//public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

//1. 泛型 (泛用方法)                                                                        (ex.  void SwapAnyType<T>(ref T a, ref T b)
//2. 委派參數 Lambda Expression (匿名方法簡潔版)               (ex.  MyWhere(nums, n => n %2==0);
//3. Iterator                                                                                      (ex.  MyIterator)
//4. 擴充方法                                                                                    (ex.  MyStringExtend.WordCount(s); 

namespace Starter
{
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = 100;
            n2 = 200;

            MessageBox.Show(n1 + "," + n2);
            ClsMyUtility.Swap(ref n1, ref n2);
            MessageBox.Show(n1 + "," + n2);
            //=================
            string s1, s2;
            s1 = "aaa";
            s2 = "bbb";
            MessageBox.Show(s1 + "," + s2);
           ClsMyUtility. Swap(ref s1, ref s2);    //call method
            MessageBox.Show(s1 + "," + s2);
            //=====================

            MessageBox.Show(SystemInformation.ComputerName);
         
        }
       //
   

        private void button7_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = 100;
            n2 = 200;

            MessageBox.Show(n1 + "," + n2);
            //ClsMyUtility.SwapAnyType<int>(ref n1, ref n2);
            ClsMyUtility.SwapAnyType(ref n1, ref n2); //推斷型別
            MessageBox.Show(n1 + "," + n2);
            //========================
            string s1, s2;
            s1 = "aaa";
            s2 = "bbb";
            MessageBox.Show(s1 + "," + s2);
            ClsMyUtility.SwapAnyType(ref s1, ref s2);
            MessageBox.Show(s1 + "," + s2);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //具名方法
            this.buttonX.Click += ButtonX_Click;
            this.buttonX.Click += aaa;

            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0123  'bbb' 沒有任何多載符合委派 'EventHandler' LinqLabs C:\shared\LINQ\LinqLabs(Solution)\LinqLabs\2.FrmLangForLINQ.cs    88  作用中

            //            this.buttonX.Click += bbb;

            //=======================
            //2.0 匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
                                                                  {
                                                                      MessageBox.Show("匿名方法");
                                                                  };
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ButtonX click");
        }
        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }
        private void bbb()
        {
            MessageBox.Show("aaa");
        }
    }
}
