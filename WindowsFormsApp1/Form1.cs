using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region DataList

        private class Outputlbl
        {
            public string Start { get; set; }
            public string End { get; set; }
            public double Days { get; set; }
            public double totalDays { get; set; }

            public double Rate
            {
                get { return  (double)(this.Days / this.totalDays); }
            }
        }

        List<Outputlbl> _oplist = new List<Outputlbl>();

        private class CarType
        {
            public string Name { get; set; }

            public List<CCType> ccList { get; set; }

        }

        private class CCType
        {
            public string ccName { get; set; }
            public int Price { get; set; }
        }

        List<CarType> _carlist = new List<CarType>()
        {
            new CarType()
            {
                Name = "機車",
                ccList = new List<CCType>()
                {
                    new CCType(){ccName = "150以下 / 12HP以下(12.2PS以下)", Price = 0},
                    new CCType(){ccName = "151-250 / 12.1-20HP(12.3-20.3PS)", Price = 800},
                    new CCType(){ccName = "251-500 / 20.1HP以上(20.4PS以上)", Price = 1620},
                    new CCType(){ccName = "501-600", Price = 2160},
                    new CCType(){ccName = "601-1200", Price = 4320},
                    new CCType(){ccName = "1201-1800", Price = 7120},
                    new CCType(){ccName = "1801或以上", Price = 11230},
                }
            },

            new CarType()
            {
                Name = "貨車",
                ccList = new List<CCType>()
                {
                    new CCType(){ccName = "500以下", Price = 900},
                    new CCType(){ccName = "501-600", Price = 1080},
                    new CCType(){ccName = "601-1200", Price = 1800},
                    new CCType(){ccName = "1201-1800", Price = 2700},
                    new CCType(){ccName = "1801-2400", Price = 3600},
                    new CCType(){ccName = "2401-3000 / 138HP以下(140.1PS以下)", Price = 4500},
                    new CCType(){ccName = "3001-3600", Price = 5400},
                    new CCType(){ccName = "3601-4200 / 138.1-200HP(140.2-203.0PS)", Price = 6300},
                    new CCType(){ccName = "4201-4800", Price = 7200},
                    new CCType(){ccName = "4801-5400 / 200.1-247HP(203.1-250.7PS)", Price = 8100},
                    new CCType(){ccName = "5401-6000", Price = 9000},
                    new CCType(){ccName = "6001-6600 / 247.1-286HP(250.8-290.3PS)", Price = 9900},
                    new CCType(){ccName = "6601-7200", Price = 10800},
                    new CCType(){ccName = "7201-7800 / 286.1-336HP(290.4-341.0PS)", Price = 11700},
                    new CCType(){ccName = "7801-8400", Price = 12600},
                    new CCType(){ccName = "8401-9000 / 336.1-361HP(341.1-366.4PS)", Price = 13500},
                    new CCType(){ccName = "9001-9600", Price = 14400},
                    new CCType(){ccName = "9601-10200 / 361.1HP以上(366.5PS以上)", Price = 15300},
                    new CCType(){ccName = "10201以上", Price = 16200},
                }
            },

            new CarType()
            {
                Name = "大客車",
                ccList = new List<CCType>()
                {
                    new CCType(){ccName = "600以下", Price = 1080},
                    new CCType(){ccName = "601-1200", Price = 1800},
                    new CCType(){ccName = "1201-1800", Price = 2700},
                    new CCType(){ccName = "1801-2400", Price = 3600},
                    new CCType(){ccName = "2401-3000 / 138HP以下(140.1PS以下)", Price = 4500},
                    new CCType(){ccName = "3001-3600", Price = 5400},
                    new CCType(){ccName = "3601-4200 / 138.1-200HP(140.2-203.0PS)", Price = 6300},
                    new CCType(){ccName = "4201-4800", Price = 7200},
                    new CCType(){ccName = "4801-5400 / 200.1-247HP(203.1-250.7PS)", Price = 8100},
                    new CCType(){ccName = "5401-6000", Price = 9000},
                    new CCType(){ccName = "6001-6600 / 247.1-286HP(250.8-290.3PS)", Price = 9900},
                    new CCType(){ccName = "6601-7200", Price = 10800},
                    new CCType(){ccName = "7201-7800 / 286.1-336HP(290.4-341.0PS)", Price = 11700},
                    new CCType(){ccName = "7801-8400", Price = 12600},
                    new CCType(){ccName = "8401-9000 / 336.1-361HP(341.1-366.4PS)", Price = 13500},
                    new CCType(){ccName = "9001-9600", Price = 14400},
                    new CCType(){ccName = "9601-10200 / 361.1HP以上(366.5PS以上)", Price = 15300},
                    new CCType(){ccName = "10201以上", Price = 16200},
                }
            },

            new CarType()
            {
                Name = "自用小客車",
                ccList = new List<CCType>()
                {
                    new CCType(){ccName = "500以下 / 38HP以下(38.6PS以下)", Price = 1620},
                    new CCType(){ccName = "501~600 / 38.1-56HP(38.7-56.8PS)", Price = 2160},
                    new CCType(){ccName = "601~1200 / 56.1-83HP(56.9-84.2PS)", Price = 4320},
                    new CCType(){ccName = "1201~1800 / 83.1-182HP(84.3-184.7PS)", Price = 7120},
                    new CCType(){ccName = "1801~2400 / 182.1-262HP(184.8-265.9PS)", Price = 11230},
                    new CCType(){ccName = "2401~3000 / 262.1-322HP(266-326.8PS)", Price = 15210},
                    new CCType(){ccName = "3001-4200 / 322.1-414HP(326.9-420.2PS", Price = 28220},
                    new CCType(){ccName = "4201-5400 / 414.1-469HP(420.3-476.0PS)", Price = 46170},
                    new CCType(){ccName = "5401-6600 / 469.1-509HP(476.1-516.6PS)", Price = 69690},
                    new CCType(){ccName = "6601-7800 / 509.1HP以上(516.7PS以上)", Price = 117000},
                    new CCType(){ccName = "7801以上", Price = 151200},
                }
            },

            new CarType()
            {
                Name = "營業用小客車",
                ccList = new List<CCType>()
                {
                    new CCType(){ccName = "500以下 / 38HP以下(38.6PS以下)", Price = 900},
                    new CCType(){ccName = "501~600 / 38.1-56HP(38.7-56.8PS)", Price = 1260},
                    new CCType(){ccName = "601~1200 / 56.1-83HP(56.9-84.2PS)", Price = 2160},
                    new CCType(){ccName = "1201~1800 / 83.1-182HP(84.3-184.7PS)", Price = 3060},
                    new CCType(){ccName = "1801~2400 / 182.1-262HP(184.8-265.9PS)", Price = 6480},
                    new CCType(){ccName = "2401~3000 / 262.1-322HP(266-326.8PS)", Price = 9900},
                    new CCType(){ccName = "3001-4200 / 322.1-414HP(326.9-420.2PS", Price = 16380},
                    new CCType(){ccName = "4201-5400 / 414.1-469HP(420.3-476.0PS)", Price = 24300},
                    new CCType(){ccName = "5401-6600 / 469.1-509HP(476.1-516.6PS)", Price = 33660},
                    new CCType(){ccName = "6601-7800 / 509.1HP以上(516.7PS以上)", Price = 44460},
                    new CCType(){ccName = "7801以上", Price = 56700},
                }
            }
        };

        private enum Car
        {
            機車,
            貨車,
            大客車,
            自用小客車,
            營業用小客車
        }
        #endregion

        #region Helper

        private void GetDaylist(DateTime startDate, DateTime endDate)
        {
            if (startDate.Year == endDate.Year)
            {   //如果起始日與結束日年份相同

                string sd = startDate.ToString("yyyy-MM-dd"); //取得起始日字串
                string ed = endDate.ToString("yyyy-MM-dd"); //取得結束日字串
                double cdays = (endDate - startDate).Days + 1; //取得計算天數(結束日-起始日) + 1
                double tdays = new DateTime(startDate.Year, 12, 31).DayOfYear; //取得當年度總天數(12月31日+DayOfYear可算出當年總天數)
                //加入資料集合
                this._oplist.Add(new Outputlbl()
                {
                    Start = sd,
                    End = ed,
                    Days = cdays,
                    totalDays = tdays,
                });
            }
            else
            {   //如果起始日與結束日年份 不 相同

                //建立起始日那一年的資料集合
                var endOfYear = new DateTime(startDate.Year, 12, 31);
                string sd = startDate.ToString("yyyy-MM-dd");
                string ed = endOfYear.ToString("yyyy-MM-dd");

                double cdays = (endOfYear - startDate).Days + 1;
                double tdays = endOfYear.DayOfYear;
                this._oplist.Add(new Outputlbl()
                {
                    Start = sd,
                    End = ed,
                    Days = cdays,
                    totalDays = tdays,
                });

                //建立中間年分的資料集合
                for (var i = startDate.Year + 1; i < endDate.Year; i++)
                {
                    var startOfthisYear = new DateTime(i, 1, 1);
                    var endOfthisYear = new DateTime(i, 12, 31);
                    string ssd = startOfthisYear.ToString("yyyy-MM-dd");
                    string eed = endOfthisYear.ToString("yyyy-MM-dd");
                    double mdays = endOfthisYear.DayOfYear;

                    this._oplist.Add(new Outputlbl()
                    {
                        Start = ssd,
                        End = eed,
                        Days = mdays,
                        totalDays = mdays,
                    });
                }

                //建立結束日那一年的資料集合
                var firstOflYear = new DateTime(endDate.Year, 1, 1);
                var endOflYear = new DateTime(endDate.Year, 12, 31);

                string lsd = firstOflYear.ToString("yyyy-MM-dd");
                string led = endDate.ToString("yyyy-MM-dd");
                double ldays = (endDate - firstOflYear).Days + 1;
                double ltdays = endOflYear.DayOfYear;

                this._oplist.Add(new Outputlbl()
                {
                    Start = lsd,
                    End = led,
                    Days = ldays,
                    totalDays = ltdays,
                });

            }

        }

        #endregion

        #region Event

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.radioButton1.Checked = true;
            DateTime now = DateTime.Now;
            this.startDate.Value = new DateTime(now.Year, 1, 1);
            this.endDate.Value = new DateTime(now.Year, 12, 31);
            foreach(var item in _carlist)
            {
                this.CarTypecomboBox.Items.Add(item.Name);
            }
            this.CarTypecomboBox.SelectedIndex = 0;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.groupBox1.Visible = false;
            }
            else
            {
                this.groupBox1.Visible = true;
            }
        }

        private void CarTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CCcomboBox.Items.Clear();

            var query =
                from n in _carlist
                select n;
                
            string car = CarTypecomboBox.SelectedItem as string;
            Car ecar = (Car)Enum.Parse(typeof(Car), car);
            switch (ecar)
            {
                case Car.機車:
                    var morto =
                        query.Where(obj => obj.Name == "機車").SelectMany(obj => obj.ccList);
                    foreach (var item in morto)
                        this.CCcomboBox.Items.Add(item.ccName);
                    break;
                case Car.貨車:
                    var truck =
                        query.Where(obj => obj.Name == "貨車").SelectMany(obj => obj.ccList);
                    foreach (var item in truck)
                        this.CCcomboBox.Items.Add(item.ccName);
                    break;
                case Car.大客車:
                    var coach =
                        query.Where(obj => obj.Name == "大客車").SelectMany(obj => obj.ccList);
                    foreach (var item in coach)
                        this.CCcomboBox.Items.Add(item.ccName);
                    break;
                case Car.自用小客車:
                    var pasCar =
                        query.Where(obj => obj.Name == "自用小客車").SelectMany(obj => obj.ccList);
                    foreach (var item in pasCar)
                        this.CCcomboBox.Items.Add(item.ccName);
                    break;
                case Car.營業用小客車:
                    var bussCar =
                        query.Where(obj => obj.Name == "營業用小客車").SelectMany(obj => obj.ccList);
                    foreach (var item in bussCar)
                        this.CCcomboBox.Items.Add(item.ccName);
                    break;
                default:
                    break;
            }
            this.CCcomboBox.SelectedIndex = 0;

        }

        private void opbutton_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel1.Controls.Clear();
            this._oplist.Clear();

            DateTime sdate = this.startDate.Value;
            DateTime edate = this.endDate.Value;
            this.GetDaylist(sdate, edate);//Create oplist

            string carVal = CarTypecomboBox.SelectedItem as string;
            string ccVal = CCcomboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(carVal) || string.IsNullOrEmpty(ccVal))
            {
                MessageBox.Show("請輸入完整查詢資訊");
                return;
            }

            //LINQ 找出carlist中的子集合cclist
            var query =
                (from d in this._carlist
                 where d.Name == carVal
                 select d)
                 .SelectMany(obj => obj.ccList);
            //找出與輸入值相符合的Price稅價
            var price = query
                .Where(n => n.ccName == ccVal)
                .FirstOrDefault();
            //宣告變數放Price
            double Price = price.Price;

            
            //使用準備的資料集合oplist動態生成label
            int i = 0;
            foreach (var item in this._oplist)
            {
                this.panel1.Controls.Add(new Label()
                {
                    Text =$"使用期間: {item.Start} ~ {item.End}"+ Environment.NewLine +
                           $"計算天數: {item.Days} 天" + Environment.NewLine +
                           $"汽缸CC數:{this.CCcomboBox.SelectedItem.ToString()}" + Environment.NewLine +
                           $"用途: {this.CarTypecomboBox.SelectedItem.ToString()}" + Environment.NewLine +
                           $"計算公式: {Price} * {item.Days} / {item.totalDays} = {Price * item.Rate : 0} 元" + Environment.NewLine +
                           $"應納稅額: 共 {Price * item.Rate : 0} 元",
                    Font = new Font("新細明體", 12, FontStyle.Regular),
                    AutoSize = true,//讓label能依照字數量變大小
                    Top = i//設定位置,沒設定會重疊變成看起來像是只有跑一筆
                });
                i += 110;
            }
          
        }

        #endregion
    }
}
