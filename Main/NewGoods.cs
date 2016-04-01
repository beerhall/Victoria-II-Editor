using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Victoria2.Main
{
    public partial class NewGoods : Form
    {
        MainForm mf;
        XmlDocument goods = new XmlDocument ( );

        public NewGoods ( MainForm mfPass )
        {
            InitializeComponent ( );
            mf = mfPass;
        }
        private void getGoods ( )
        {
            foreach ( XmlNode node1 in goods.ChildNodes [ 1 ] )
            {
                comboBoxGoodType.Items.Add ( node1.Name );
            }
        }
        private void buttonConfirm_Click ( object sender , EventArgs e )
        {
            if ( checkGoodsInput ( ) )
            {

                XmlElement ele = goods.CreateElement ( textBoxGoodsName.Text );

                XmlElement cost = goods.CreateElement ( "cost" );
                cost.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxCost.Text );
                ele.AppendChild ( cost );

                XmlElement color = goods.CreateElement ( "color" );
                color.InnerText = "{ " + textBoxGoodColorRed.Text + " " + textBoxGoodColorGreen.Text + " " + textBoxGoodColorBlue.Text + " }";
                ele.AppendChild ( color );

                if ( !checkBoxAvailableFromStart.Checked )
                {
                    XmlElement available_from_start = goods.CreateElement ( "available_from_start" );
                    available_from_start.InnerText = "no";
                    ele.AppendChild ( available_from_start );
                }

                if ( checkBoxOverseasPenalty.Checked )
                {
                    XmlElement overseas_penalty = goods.CreateElement ( "overseas_penalty" );
                    overseas_penalty.InnerText = "yes";
                    ele.AppendChild ( overseas_penalty );
                }

                if ( !checkBoxTradeable.Checked )
                {
                    XmlElement tradeable = goods.CreateElement ( "tradeable" );
                    tradeable.InnerText = "no";
                    ele.AppendChild ( tradeable );
                }

                if ( checkBoxMoney.Checked )
                {
                    XmlElement money = goods.CreateElement ( "money" );
                    money.InnerText = "yes";
                    ele.AppendChild ( money );
                }

                goods.ChildNodes [ 1 ].SelectSingleNode ( comboBoxGoodType.Text ).AppendChild ( ele );
                goods.Save ( ".\\xml\\common\\goods.txt.xml" );
                MessageBox.Show ( "保存成功！" );
                mf.Reload ( );
                this.Close ( );
            }
        }

        private bool checkGoodsInput ( )
        {
            if ( !Regex.IsMatch ( textBoxGoodsName.Text , @"\w+" ) )
            {
                MessageBox.Show ( "名字格式错误！" );
                return false;
            }

            foreach ( XmlNode node1 in goods.ChildNodes [ 1 ] )
            {
                foreach ( XmlNode node2 in node1 )
                {
                    if ( node2.Name == textBoxGoodsName.Text )
                    {
                        MessageBox.Show ( "商品名已存在！" );
                        return false;
                    }
                }
            }

            if ( !Regex.IsMatch ( textBoxCost.Text , @"(\d)+\.\d\d" ) && !Regex.IsMatch ( textBoxCost.Text , @"(\d)+\.\d" ) )
            {
                MessageBox.Show ( "花销必须保留一位或两位小数!" );
                return false;
            }

            if ( !mf.isColor ( int.Parse ( textBoxGoodColorRed.Text ) ) || !mf.isColor ( int.Parse ( textBoxGoodColorGreen.Text ) )
                || !mf.isColor ( int.Parse ( textBoxGoodColorBlue.Text ) ) )
            {
                MessageBox.Show ( "颜色格式错误！" );
                return false;
            }

            return true;
        }

        private void NewGoods_Load ( object sender , EventArgs e )
        {
            goods.Load ( ".\\xml\\common\\goods.txt.xml" );
            getGoods ( );
        }

        private void buttonCancel_Click ( object sender , EventArgs e )
        {
            this.Close ( );
        }

        private void goodColorChanged ( )
        {
            if ( Regex.IsMatch ( textBoxGoodColorRed.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxGoodColorGreen.Text , @"(\d)+" )
                && Regex.IsMatch ( textBoxGoodColorBlue.Text , @"(\d)+" ) )
            {
                if ( mf.isColor ( int.Parse ( textBoxGoodColorRed.Text ) ) && mf.isColor ( int.Parse ( textBoxGoodColorGreen.Text ) )
                    && mf.isColor ( int.Parse ( textBoxGoodColorBlue.Text ) ) )
                {
                    labelGoodColor.BackColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxGoodColorRed.Text ) ,
                        int.Parse ( textBoxGoodColorGreen.Text ) , int.Parse ( textBoxGoodColorBlue.Text ) );
                    labelGoodColor.ForeColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxGoodColorRed.Text ) ,
                        int.Parse ( textBoxGoodColorGreen.Text ) , int.Parse ( textBoxGoodColorBlue.Text ) );
                }
            }
        }

        private void textBoxGoodColorRed_TextChanged ( object sender , EventArgs e )
        {
            goodColorChanged ( );
        }

        private void textBoxGoodColorGreen_TextChanged ( object sender , EventArgs e )
        {
            goodColorChanged ( );
        }

        private void textBoxGoodColorBlue_TextChanged ( object sender , EventArgs e )
        {
            goodColorChanged ( );
        }
    }
}
