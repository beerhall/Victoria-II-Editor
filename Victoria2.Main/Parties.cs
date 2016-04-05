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
using Microsoft.VisualBasic;

namespace Victoria2.Main
{
    public partial class Parties : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument countries = new XmlDocument ( );
        XmlDocument issues = new XmlDocument ( );
        XmlDocument ideologies = new XmlDocument ( );

        public Parties ( string countryTagNamePass , string countryNamePass , MainForm mfPass )
        {
            InitializeComponent ( );
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void Parties_Load ( object sender , EventArgs e )
        {
            this.Text = countryName + " Parties";
            countries.Load ( ".\\xml\\common\\countries\\" + countryName + ".txt.xml" );
            issues.Load ( ".\\xml\\common\\issues.txt.xml" );
            ideologies.Load ( ".\\xml\\common\\ideologies.txt.xml" );
            getParties ( );
            getPolicies ( );
            getIdeologies ( );
        }

        private void getParties ( )
        {
            foreach ( XmlNode node in countries.ChildNodes [ 1 ].SelectNodes ( "party" ) )
            {
                comboBoxParties.Items.Add ( Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "name" ).InnerText ).Replace ( "\"" , "" ).Trim ( ) );
            }
        }

        private void getPolicies ( )
        {
            foreach ( XmlNode node in issues.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ) )
            {
                listBoxPolicies.Items.Add ( Victoria2.Domain.Comm.FileHelper.Unescape ( node.Name ).Replace ( "\"" , "" ).Trim ( ) );
            }
        }

        private void getIdeologies ( )
        {
            foreach ( XmlNode node1 in ideologies.ChildNodes [ 1 ] )
            {
                foreach ( XmlNode node2 in node1 )
                {
                    comboBoxIdeologies.Items.Add ( node2.Name );
                }
            }
        }

        private void listBoxPolicies_SelectedIndexChanged ( object sender , EventArgs e )
        {
            listBoxPolicyValues.Items.Clear ( );
            foreach ( XmlNode node in issues.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ).SelectSingleNode ( listBoxPolicies.SelectedItem.ToString ( ) ) )
            {
                listBoxPolicyValues.Items.Add ( node.Name );
            }
            if ( comboBoxParties.SelectedIndex != -1 )
            {
                foreach ( XmlNode node in countries.ChildNodes [ 1 ].SelectNodes ( "party" ) )
                {
                    if ( Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "name" ).InnerText ) == "\"" + comboBoxParties.SelectedItem.ToString ( ) + "\"" )
                    {
                        listBoxPolicyValues.Text = node.SelectSingleNode ( listBoxPolicies.SelectedItem.ToString ( ) ).InnerText;
                        break;
                    }
                }
            }
        }

        private void comboBoxParties_SelectedIndexChanged ( object sender , EventArgs e )
        {
            foreach ( XmlNode node in countries.ChildNodes [ 1 ].SelectNodes ( "party" ) )
            {
                if ( Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "name" ).InnerText ) == "\"" + comboBoxParties.SelectedItem.ToString ( ) + "\"" )
                {
                    if ( listBoxPolicies.SelectedIndex != -1 )
                    {
                        listBoxPolicyValues.Text = node.SelectSingleNode ( listBoxPolicies.SelectedItem.ToString ( ) ).InnerText;
                    }
                    comboBoxIdeologies.Text = node.SelectSingleNode ( "ideology" ).InnerText;
                    textBoxStartDate.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "start_date" ).InnerText );
                    textBoxEndDate.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "end_date" ).InnerText );
                    break;
                }
            }
        }


        private void buttonFinish_Click ( object sender , EventArgs e )
        {
            DateTime dt;
            if ( !DateTime.TryParse ( textBoxStartDate.Text.Replace ( "-" , "." ) , out dt ) )
            {
                MessageBox.Show ( "开始日期格式错误！" );
                return;
            }

            foreach ( XmlNode node in countries.ChildNodes [ 1 ].SelectNodes ( "party" ) )
            {
                if ( Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "name" ).InnerText ) == "\"" + comboBoxParties.SelectedItem.ToString ( ) + "\"" )
                {
                    node.SelectSingleNode ( listBoxPolicies.SelectedItem.ToString ( ) ).InnerText = listBoxPolicyValues.SelectedItem.ToString ( );
                    node.SelectSingleNode ( "start_date" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxStartDate.Text );
                    node.SelectSingleNode ( "ideology" ).InnerText = comboBoxIdeologies.SelectedItem.ToString ( );
                }
            }

            if ( MessageBox.Show ( "保存成功！要继续修改政党吗？" , "提示" , MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.No )
            {
                countries.Save ( ".\\xml\\common\\countries\\" + countryName + ".txt.xml" );
                mf.Reload ( );
                this.Close ( );
            }
        }

        private void buttonNewParty_Click ( object sender , EventArgs e )
        {
            string newPartyName = Interaction.InputBox ( "请输入新政党名" );
            if ( !Regex.IsMatch ( newPartyName , @"\w+" ) )
            {
                MessageBox.Show ( "政党名格式错误！" );
                return;
            }
            XmlElement newParty = countries.CreateElement ( "party" );

            XmlElement name = countries.CreateElement ( "name" );
            name.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( "\"" + newPartyName + "\"" );
            newParty.AppendChild ( name );

            XmlElement start_date = countries.CreateElement ( "start_date" );
            start_date.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( "1800.1.1" );
            newParty.AppendChild ( start_date );

            XmlElement end_date = countries.CreateElement ( "end_date" );
            end_date.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( "1800.1.1" );
            newParty.AppendChild ( end_date );

            XmlElement ideology = countries.CreateElement ( "ideology" );
            ideology.InnerText = comboBoxIdeologies.Items [ 0 ].ToString ( );
            newParty.AppendChild ( ideology );

            foreach ( XmlNode node in issues.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ) )
            {
                XmlElement ele = countries.CreateElement ( node.Name );
                ele.InnerText = node.ChildNodes [ 0 ].Name;
                newParty.AppendChild ( ele );
            }

            countries.ChildNodes [ 1 ].InsertAfter ( newParty , countries.ChildNodes [ 1 ].SelectSingleNode ( "party" ) );
            comboBoxParties.Items.Add ( newPartyName );
        }
    }
}
