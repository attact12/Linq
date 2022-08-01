using LinqLabs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Data;


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

            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            //  this.button1.Text = "sdfdsf";

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
            ClsMyUtility.Swap(ref s1, ref s2);    //call method
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
            //   this.buttonX.Click += aaa; //syntax sugar
            this.buttonX.Click += new EventHandler(aaa); // aaa;

            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0123  'bbb' 沒有任何多載符合委派 'EventHandler' LinqLabs C:\shared\LINQ\LinqLabs(Solution)\LinqLabs\2.FrmLangForLINQ.cs    88  作用中

            //            this.buttonX.Click += bbb;

            //=======================
            //2.0 匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
                                                                  {
                                                                      MessageBox.Show("匿名方法");
                                                                  };

            //=========================
            //C#3.0 匿名方法 簡潔版 lambda 
            this.buttonX.Click += (object sender1, EventArgs e1) =>
                                                   {
                                                       MessageBox.Show("C#3.0 匿名方法 =>");
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

        bool Test(int n)
        {
            //if (n > 5)
            //    return true;
            //else
            //    return false;

            return n > 5;
        }
        //Step 1 create delegate class
        //Step 2 create delegate object
        //Step 3 Call Method

        internal delegate bool MyDelegate(int n);

        private void button9_Click(object sender, EventArgs e)
        {
            bool result = Test(10); //call method
            MessageBox.Show("result = " + result);

            //C# 1.0 具名方法
            MyDelegate delegateObj = Test;          //new MyDelegate(Test);
            result = delegateObj(2);                           //delegateObj.Invoke(2);      //call method / invoke method
            MessageBox.Show("result = " + result);

            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0123  'aaa' 沒有任何多載符合委派 'FrmLangForLINQ.MyDelegate'    LinqLabs C:\shared\LINQ\LinqLabs(Solution)\LinqLabs\2.FrmLangForLINQ.cs    146 作用中

            //     delegateObj = aaa;
            //====================================
            //C# 2.0 匿名方法
            delegateObj = delegate (int n)
                                                          {
                                                              return n % 2 == 0;
                                                          };
            result = delegateObj(8);
            MessageBox.Show("result = " + result);

            //====================================
            //C# 3.0 匿名方法簡潔板 labmda expression =>
            //Lambda 運算式是建立委派最簡單的方法 (參數型別也沒寫 / return 也沒寫 => 非常高階的抽象)

            delegateObj = n => n % 2 == 0;
            result = delegateObj(100);
            MessageBox.Show("result = " + result);

        }

        internal static List<int> MyWhere(int[] nums, MyDelegate delegateObj)
        {
            List<int> list = new List<int>();
            foreach (int n in nums)
            {
                if (delegateObj(n))
                {
                    list.Add(n);
                }
            }
            return list;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13 };
            List<int> result = MyWhere(nums, Test);

            List<int> oddList = MyWhere(nums, n => n % 2 == 1);
            List<int> evenList = MyWhere(nums, n => n % 2 == 0);

            foreach (int n in oddList)
            {
                this.listBox1.Items.Add(n);
            }
            foreach (int n in evenList)
            {
                this.listBox2.Items.Add(n);
            }

        }
        internal static IEnumerable<int> MyIterator(int[] nums, MyDelegate delegateObj)
        {
            foreach (int n in nums)
            {
                if (delegateObj(n))
                {
                    yield return n;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> q = MyIterator(nums, n => n % 2 == 0);

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //IEnumerable<int> q = from n in nums
            //                                        where n > 5
            //                                        select n;

            IEnumerable<int> q = nums.Where<int>(n => n > 5);

            this.listBox1.Items.Clear();
            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }

            //==================================
            string[] words = { "123", "bbb", "cccccccc", "ddddd" };
            //char ch = words[0][1];

            IEnumerable<string> q2 = words.Where(w => w.Length > 3);
            this.listBox2.Items.Clear();

            foreach (string s in q2)
            {
                this.listBox2.Items.Add(s);
            }
            this.dataGridView2.DataSource = q2.ToList();

            //======================================
            var q3 = this.nwDataSet1.Products.Where(p => p.UnitPrice > 30);  //strong DataType
            this.dataGridView1.DataSource = q3.ToList();

            //weak type
            //DataSet ds = new DataSet();
            //DataTable table1 = ds.Tables["Productsx"];
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //var 懶得寫(x)
            //========================
            //var 型別難寫
            //var for 匿名型別

            int n = 100;
            var n1 = 200;
            var s = "abcde";

            MessageBox.Show(s.ToUpper());

            var p = new Point(1, 10);
            MessageBox.Show(p.X + "," + p.Y);

        }

        private void button41_Click(object sender, EventArgs e)
        {
            MyPoint pt1 = new MyPoint();
            pt1.P1 = 100;   //set;  int w =  pt1.P1;  //get
            pt1.P2 = 200;   //set

            List<MyPoint> list = new List<MyPoint>();
            MyPoint pt2 = new MyPoint(99);            //new ( ) constructor 建構子方法
            MyPoint pt3 = new MyPoint(88, 88);
          
            list.Add(pt1);
            list.Add(pt2);
            list.Add(pt3);

            //C# 3.0  {  } object initialize 物件初始化
            list.Add(new MyPoint { P1 = 1, P2 = 2, Field1 = "aaaa", Field2 = "bbb" });
            list.Add(new MyPoint { P1 = 111 });
            list.Add(new MyPoint { P1 = 222, P2=2222 });
            
            this.dataGridView1.DataSource = list;
            //   new Font()

            //=========================
            List<MyPoint> list2 = new List<MyPoint>()
            {
                new MyPoint{ P1=1, P2=33},
                new MyPoint {P2=99},
                new MyPoint{ P1=100}
            };
            this.dataGridView2.DataSource = list2;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            var pt1 = new { P1 = 3, P2 = 44 };
            var pt2 = new { P1 = 3, P2 = 44, P3 = 88 };
            var pt3 = new { P1 = 33, P2 = 434, P3 = 88 };

            int w = pt1.P1;  //get
           // pt1.P1 = 999;    //set

            this.listBox1.Items.Add(pt1.GetType());
            this.listBox1.Items.Add(pt2.GetType());
            this.listBox1.Items.Add(pt3.GetType());

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
          
            //var  q = from n in nums
            //                where n > 5
            //                select new  { N = n, Square = n * n, Cube = n * n * n };

            var q = nums.Where(n => n > 5).Select(n => new { N = n, Square = n * n, Cube = n * n * n });

          this.dataGridView1.DataSource =      q.ToList();

            //==================================

            //var q2 = from p in this.nwDataSet1.Products
            //         where p.UnitPrice > 30
            //         select new
            //         {
            //             ID = p.ProductID,
            //             產品名稱 = p.ProductName,
            //             p.UnitPrice,
            //             p.UnitsInStock,
            //             TotalPrice = p.UnitPrice * p.UnitsInStock,
            //             Data = M1(,,,,,,,)
            //         };

            //格式化
            MessageBox.Show($"{7777:c2}   ***{333,-30}***");   //string.format(....

            var q2 = this.nwDataSet1.Products.Where(p => p.UnitPrice > 30).Select(p => new { p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock,  TotalPrice= $"{p.UnitPrice * p.UnitsInStock:c2}"  });
           this.dataGridView2.DataSource =  q2.ToList();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            //具名型別陣列
            Point[] pts = new Point[]
                                {
                                 new Point(10,10),
                                 new Point(20, 20)
                                };

            //匿名型別陣列
            var arr = new []
                             {
                                new { x = 1, y = 1 },
                                new { x = 2, y = 2 }
                             };


            foreach (var item in arr)
            {
                listBox1.Items.Add(item.x + ", " + item.y);

            }
            this.dataGridView1.DataSource = arr;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string s = "abcdlklklklklklk";
            int count = s.WordCount();
            MessageBox.Show("count = " + count);

            string s1 = "123456789";
            count = s1.WordCount();   // count = MyStringExtend.WordCount(s1);
           
            MessageBox.Show("count = " + count);

            //===================
            char ch = s1.Chars(3);
            MessageBox.Show("ch=" + ch);

        }
    }

   public static class  MyStringExtend
    {
       public static int WordCount(this string s )
        {
            return s.Length;
        }

        public static char Chars(this string s, int index)
        {
            return s[index];
        }

    }
//    嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
//錯誤  CS0509	'MyString': 無法衍生自密封類型 'string'	LinqLabs C:\shared\LINQ\LinqLabs(Solution)\LinqLabs\2. FrmLangForLINQ.cs	395	作用中

//    class MyString :String
//    {
        
//    }

    class MyPoint
    {

        public MyPoint()
        {

        }
        public MyPoint(int p1)
        {
            this.P1 = p1;
        }
        public MyPoint(int p1, int p2)
        {
            this.P1 = p1;
            this.P2 = p2;

        }

        public MyPoint(int p1, string field1)
        {

        }

        public string Field1 = "xxxx", Field2 = "yyyyy";

        private int m_p1;
        public int P1
        {
            get
            {
                //logic .....
                return m_p1;
            }
            set
            {
                //logic .....
                m_p1 = value;
            }
        }
        public int P2 { get; set; }

    }
}