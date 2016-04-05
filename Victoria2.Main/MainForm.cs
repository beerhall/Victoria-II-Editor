using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        XmlDocument countries_txt_xml = new XmlDocument ( );
        XmlDocument ideologies_txt_xml = new XmlDocument ( );
        XmlDocument issues_txt_xml = new XmlDocument ( );
        XmlDocument governments = new XmlDocument ( );
        XmlDocument goods = new XmlDocument ( );
        Dictionary<string , string> countriesDic = new Dictionary<string , string> ( );
        Dictionary<string , string> countriesHistoryDic = new Dictionary<string , string> ( );
        Dictionary<string , string> provincesDic = new Dictionary<string , string> ( );
        Dictionary<int , string> comboIndexDic = new Dictionary<int , string> ( );
        IDictionary<string , int> ideoIndexDic = new Dictionary<string , int> ( );
        string lastPolicy;
        int index = 0;

        public MainForm ( )
        {
            InitializeComponent ( );
            //this.IsMdiContainer = true;
        }

        private void MainForm_Load ( object sender , EventArgs e )
        {
            if ( File.Exists ( ".\\xml\\common\\countries.txt.xml" ) )
            {
                ideologies_txt_xml.Load ( ".\\xml\\common\\ideologies.txt.xml" );
                issues_txt_xml.Load ( ".\\xml\\common\\issues.txt.xml" );
                governments.Load ( ".\\xml\\common\\governments.txt.xml" );
                goods.Load ( ".\\xml\\common\\goods.txt.xml" );
                getCountriesNames ( );
                getGC ( );
                getProvinces ( );
                getCountriesHistoryDic ( );
                getCultureList ( );
                getReligion ( );
                getGovernments ( );
                getNationalValue ( );
                getTechonologies ( );
                getIdeologies ( );
                getGoods ( );
                getPolicies ( );
            }
        }

        public void listBoxCountries_SelectedIndexChanged ( object sender , EventArgs e )
        {
            comboBoxParties.Text = "";
            comboBoxParties.Items.Clear ( );

            string str = listBoxCountries.SelectedItem.ToString ( ).Trim ( );
            textBoxCountryTagName.Text = countriesDic [ str ];
            XmlDocument country = new XmlDocument ( );
            XmlDocument countryHistory = new XmlDocument ( );
            if ( !Regex.IsMatch ( countriesDic [ str ] , @"\S\d\d" ) )
            {
                countryHistory.Load ( ".\\xml\\history\\countries\\" + countriesDic [ str ] + " - " + countriesHistoryDic [ countriesDic [ str ] ] + ".txt.xml" );
            }
            else
            {
                countryHistory.Load ( ".\\xml\\history\\countries\\" + countriesDic [ str ] + ".txt.xml" );
            }
            country.Load ( ".\\xml\\common\\countries\\" + str + ".txt.xml" );

            string [ ] color = Victoria2.Domain.Comm.FileHelper.Unescape ( country.ChildNodes [ 1 ].SelectSingleNode ( "color" ).InnerText ).Replace ( "{" , "" ).Replace ( "}" , "" ).Trim ( ).Replace ( "  " , " " ).Split ( ' ' );
            textBoxRed.Text = color [ 0 ];
            textBoxGreen.Text = color [ 1 ];
            textBoxBlue.Text = color [ 2 ];
            labelColor.BackColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
            labelColor.ForeColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );

            comboBoxGraphics.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( country.ChildNodes [ 1 ].SelectSingleNode ( "graphical_culture" ).InnerText );
            foreach ( XmlNode node in country.ChildNodes [ 1 ] )
            {
                string partyName = "";
                if ( node.Name == "party" )
                {
                    partyName = Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "name" ).InnerText );
                    partyName = partyName.Replace ( "\"" , "" );
                    comboBoxParties.Items.Add ( partyName );
                }
            }
            comboBoxParties.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "ruling_party " ).InnerText );
            comboBoxCaptial.Text = provincesDic [ Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "capital " ).InnerText ) ];
            comboBoxPrimaryCulture.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "primary_culture" ).InnerText );
            comboBoxReligion.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "religion" ).InnerText );
            comboBoxGovernment.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "government" ).InnerText );
            comboBoxNationalValue.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "nationalvalue" ).InnerText );
            comboBoxSchool.Text = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "schools" ) != null ) ? Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "schools" ).InnerText ) : "traditional_academic";
            textBoxPlurality.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "plurality" ).InnerText );
            textBoxLiteracy.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "literacy" ).InnerText );
            textBoxNonStateCultureLiteracy.Text = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "non_state_culture_literacy" ) != null ) ? Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "non_state_culture_literacy" ).InnerText ) : "";
            textBoxPrestige.Text = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "prestige" ) != null ) ? Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "prestige" ).InnerText ) : "";
            textBoxConsciousness.Text = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "consciousness" ) != null ) ? Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "consciousness" ).InnerText ) : "";
            textBoxNonstateConsciousness.Text = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "nonstate_consciousness" ) != null ) ? Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "nonstate_consciousness" ).InnerText ) : "";
            checkBoxCivilized.Checked = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized " ) != null ) ? ( Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized " ).InnerText ) == "yes" ) : false;
            checkBoxIsReleasableVassal.Checked = ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "is_releasable_vassal " ) != null ) ? ( Victoria2.Domain.Comm.FileHelper.Unescape ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "is_releasable_vassal " ).InnerText ) == "yes" ) : true;
        }

        public void Reload ( )
        {
            listBoxCountries.Items.Clear ( );
            countriesDic.Clear ( );
            comboBoxGraphics.Items.Clear ( );
            provincesDic.Clear ( );
            comboIndexDic.Clear ( );
            comboBoxCaptial.Items.Clear ( );
            countriesHistoryDic.Clear ( );
            comboBoxPrimaryCulture.Items.Clear ( );
            comboBoxReligion.Items.Clear ( );
            comboBoxGovernment.Items.Clear ( );
            listBoxGovernments.Items.Clear ( );
            comboBoxNationalValue.Items.Clear ( );
            comboBoxSchool.Items.Clear ( );
            checkedListBoxIdeologies.Items.Clear ( );
            ideoIndexDic.Clear ( );
            comboBoxGoodType.Items.Clear ( );
            listBoxGoods.Items.Clear ( );

            ideologies_txt_xml.Load ( ".\\xml\\common\\ideologies.txt.xml" );
            issues_txt_xml.Load ( ".\\xml\\common\\issues.txt.xml" );
            governments.Load ( ".\\xml\\common\\governments.txt.xml" );
            goods.Load ( ".\\xml\\common\\goods.txt.xml" );
            treeViewPolicies.Nodes.Clear ( );

            getCountriesNames ( );
            getGC ( );
            getProvinces ( );
            getCountriesHistoryDic ( );
            getCultureList ( );
            getReligion ( );
            getGovernments ( );
            getNationalValue ( );
            getTechonologies ( );
            getIdeologies ( );
            getGoods ( );
            getPolicies ( );
        }

        public void getCountriesNames ( )
        {
            countries_txt_xml.Load ( ".\\xml\\common\\countries.txt.xml" );
            foreach ( XmlNode node in countries_txt_xml.ChildNodes [ 1 ] )
            {
                string str = Victoria2.Domain.Comm.FileHelper.Unescape ( node.InnerText );
                if ( str == "yes" || str.Contains ( "rebels" ) || Regex.IsMatch ( str , @"\S\d\d" ) )
                {
                    continue;
                }
                StringBuilder sb = new StringBuilder ( str );
                sb = sb.Replace ( "\"" , "" );
                sb = sb.Replace ( "countries/" , "" );
                sb = sb.Replace ( ".txt" , "" );
                listBoxCountries.Items.Add ( sb.ToString ( ) );
                countriesDic.Add ( sb.ToString ( ) , Victoria2.Domain.Comm.FileHelper.Unescape ( node.Name ) );
            }
        }

        private bool checkCountryInput ( )
        {
            if ( !isColor ( int.Parse ( textBoxRed.Text ) ) || !isColor ( int.Parse ( textBoxGreen.Text ) ) || !isColor ( int.Parse ( textBoxBlue.Text ) ) )
            {
                MessageBox.Show ( "颜色格式错误！" );
                return false;
            }

            if ( !Regex.IsMatch ( textBoxPlurality.Text , @"^\d+(\.\d{1,2})?$" ) )
            {
                MessageBox.Show ( "多元格式错误！" );
                return false;
            }

            if ( !Regex.IsMatch ( textBoxLiteracy.Text , @"^0(\.\d{1,2})?$" ) ||
                ( !Regex.IsMatch ( textBoxNonStateCultureLiteracy.Text , @"0.\d{1,2}" ) &&
                !string.IsNullOrEmpty ( textBoxNonStateCultureLiteracy.Text ) ) )
            {
                MessageBox.Show ( "识字率格式错误！" );
                return false;
            }

            if ( !Regex.IsMatch ( textBoxPrestige.Text , @"\d+" ) && !string.IsNullOrEmpty ( textBoxPrestige.Text ) )
            {
                MessageBox.Show ( "威望格式错误！" );
                return false;
            }

            if ( !Regex.IsMatch ( textBoxConsciousness.Text , @"\d+" )
                || ( !Regex.IsMatch ( textBoxNonstateConsciousness.Text , @"\d+" )
                && !string.IsNullOrEmpty ( textBoxNonstateConsciousness.Text ) ) )
            {
                MessageBox.Show ( "觉醒度格式错误！" );
                return false;
            }

            return true;
        }

        private void buttonSave_Click ( object sender , EventArgs e )
        {
            if ( checkCountryInput ( ) )
            {
                string str = listBoxCountries.SelectedItem.ToString ( ).Trim ( );
                XmlDocument countryHistory = new XmlDocument ( );
                if ( !Regex.IsMatch ( countriesDic [ str ] , @"\S\d\d" ) )
                {
                    countryHistory.Load ( ".\\xml\\history\\countries\\" + countriesDic [ str ] + " - " + countriesHistoryDic [ countriesDic [ str ] ] + ".txt.xml" );
                }
                else
                {
                    countryHistory.Load ( ".\\xml\\history\\countries\\" + countriesDic [ str ] + ".txt.xml" );
                }
                XmlDocument country = new XmlDocument ( );
                country.Load ( ".\\xml\\common\\countries\\" + listBoxCountries.SelectedItem.ToString ( ) + ".txt.xml" );

                country.ChildNodes [ 1 ].SelectSingleNode ( "color" ).InnerText = "{ " + textBoxRed.Text + "  " + textBoxGreen.Text + "  " + textBoxBlue.Text + " }";
                country.ChildNodes [ 1 ].SelectSingleNode ( "graphical_culture" ).InnerText = comboBoxGraphics.Text;

                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "ruling_party" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxParties.Text );
                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "capital" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboIndexDic [ comboBoxCaptial.SelectedIndex ] );
                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "primary_culture" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxPrimaryCulture.SelectedItem.ToString ( ) );
                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "religion" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxReligion.SelectedItem.ToString ( ) );
                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "government" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxGovernment.SelectedItem.ToString ( ) );
                if ( comboBoxSchool.Enabled )
                {
                    if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "schools" ) != null )
                    {
                        countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "schools" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxSchool.SelectedItem.ToString ( ) );
                    }
                    else
                    {
                        XmlElement ele = countryHistory.CreateElement ( "schools" );
                        ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxSchool.SelectedItem.ToString ( ) );
                        countryHistory.ChildNodes [ 1 ].InsertAfter ( ele , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "upper_house" ) );
                    }
                }

                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "plurality" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxPlurality.Text );
                countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "literacy" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxLiteracy.Text );

                if ( !string.IsNullOrEmpty ( textBoxNonStateCultureLiteracy.Text ) )
                {
                    if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "non_state_culture_literacy" ) != null )
                    {
                        countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "non_state_culture_literacy" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxNonStateCultureLiteracy.Text );
                    }
                    else
                    {
                        XmlElement ele = countryHistory.CreateElement ( "non_state_culture_literacy" );
                        ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxNonStateCultureLiteracy.Text );
                        countryHistory.ChildNodes [ 1 ].InsertAfter ( ele , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "literacy" ) );
                    }
                }//textBoxPrestige

                if ( !string.IsNullOrEmpty ( textBoxPrestige.Text ) )
                {
                    if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "prestige" ) != null )
                    {
                        countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "prestige" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxPrestige.Text );
                    }
                    else
                    {
                        XmlElement ele = countryHistory.CreateElement ( "prestige" );
                        ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxPrestige.Text );
                        countryHistory.ChildNodes [ 1 ].InsertAfter ( ele , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized" ) );
                    }
                }//textBoxConsciousness

                if ( !string.IsNullOrEmpty ( textBoxConsciousness.Text ) )
                {
                    if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "consciousness" ) != null )
                    {
                        countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "consciousness" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxConsciousness.Text );
                    }
                    else
                    {
                        XmlElement ele = countryHistory.CreateElement ( "consciousness" );
                        ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxConsciousness.Text );
                        countryHistory.ChildNodes [ 1 ].InsertAfter ( ele , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "upper_house" ) );
                    }
                }//textBoxNonstateConsciousness

                if ( !string.IsNullOrEmpty ( textBoxNonstateConsciousness.Text ) )
                {
                    if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "nonstate_consciousness" ) != null )
                    {
                        countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "nonstate_consciousness" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxNonstateConsciousness.Text );
                    }
                    else
                    {
                        XmlElement ele = countryHistory.CreateElement ( "nonstate_consciousness" );
                        ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxNonstateConsciousness.Text );
                        countryHistory.ChildNodes [ 1 ].InsertAfter ( ele , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "consciousness" ) != null ? countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "consciousness" ) : countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "upper_house" ) );
                    }
                }//checkBoxCivilized

                if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized" ) != null )
                {
                    XmlNode civilized = countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized" );
                    countryHistory.ChildNodes [ 1 ].RemoveChild ( civilized );
                }

                if ( checkBoxCivilized.Checked )
                {
                    XmlElement civ = countryHistory.CreateElement ( "civilized" );
                    civ.InnerText = "yes";
                    countryHistory.ChildNodes [ 1 ].InsertAfter ( civ , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "literacy" ) );
                }
                //checkBoxIsReleasableVassal

                if ( countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "is_releasable_vassal" ) != null )
                {
                    XmlNode civilized = countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "is_releasable_vassal" );
                    countryHistory.ChildNodes [ 1 ].RemoveChild ( civilized );
                }

                if ( checkBoxIsReleasableVassal.Checked )
                {
                    XmlElement civ = countryHistory.CreateElement ( "is_releasable_vassal" );
                    civ.InnerText = "yes";
                    countryHistory.ChildNodes [ 1 ].InsertAfter ( civ , countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized" ) != null ? countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "civilized" ) : countryHistory.ChildNodes [ 1 ].SelectSingleNode ( "literacy" ) );
                }

                if ( !Regex.IsMatch ( countriesDic [ str ] , @"\S\d\d" ) )
                {
                    countryHistory.Save ( ".\\xml\\history\\countries\\" + countriesDic [ str ] + " - " + countriesHistoryDic [ countriesDic [ str ] ] + ".txt.xml" );
                }
                else
                {
                    countryHistory.Save ( ".\\xml\\history\\countries\\" + countriesDic [ str ] + ".txt.xml" );
                }
                MessageBox.Show ( "保存成功！" );
            }
        }

        private void ToolStripMenuItemExit_Click ( object sender , EventArgs e )
        {
            Application.Exit ( );
        }

        private void ToolStripMenuItemLoad_Click_1 ( object sender , EventArgs e )
        {
            progressBarLoad.Visible = true;
            progressBarLoad.Value = 0;
            Victoria2.Main.Program.translate_to_xml ( "units" );    //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "common" );  //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "common\\countries" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "decisions" );    //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "events" );   //通过测试
            progressBarLoad.PerformStep ( );
            //translate_to_xml("inventions");    //通过测试
            //translate_to_xml("map");    //初版无测试计划
            //translate_to_xml("news");    //初版无测试计划
            Victoria2.Main.Program.translate_to_xml ( "history\\countries" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "history\\diplomacy" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml_double_folder ( "history\\pops" );  //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml_double_folder ( "history\\provinces" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "history\\units" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml_double_folder ( "history\\units" );   //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "history\\wars" );  //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_xml ( "technologies" );
            progressBarLoad.PerformStep ( );
            progressBarLoad.Value = 100;
            progressBarLoad.Visible = false;
            MessageBox.Show ( "载入成功!" );
            Reload ( );
        }

        private void ToolStripMenuItemSave_Click ( object sender , EventArgs e )
        {
            progressBarLoad.Visible = true;
            progressBarLoad.Value = 0;
            Victoria2.Main.Program.translate_to_txt ( "units" );    //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "common" );   //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "common\\countries" );   //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "decisions" );   //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "events" );   //通过测试
            progressBarLoad.PerformStep ( );
            //translate_to_txt("inventions");   //测试失败：奇异的编码
            //translate_to_txt("map");    //初版无测试计划
            //translate_to_txt("news");   //初版无测试计划
            Victoria2.Main.Program.translate_to_txt ( "history\\countries" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "history\\diplomacy" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt_double_folder ( "history\\pops" );  //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt_double_folder ( "history\\provinces" );    //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "history\\units" ); //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt_double_folder ( "history\\units" );   //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "history\\wars" );  //通过测试
            progressBarLoad.PerformStep ( );
            Victoria2.Main.Program.translate_to_txt ( "technologies" );
            progressBarLoad.PerformStep ( );
            progressBarLoad.Value = 100;
            progressBarLoad.Visible = false;
            MessageBox.Show ( "保存成功!" );
        }

        private void textBoxRed_TextChanged ( object sender , EventArgs e )
        {
            if ( Regex.IsMatch ( textBoxRed.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxGreen.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxBlue.Text , @"(\d)+" ) )
            {
                if ( isColor ( int.Parse ( textBoxRed.Text ) ) && isColor ( int.Parse ( textBoxGreen.Text ) ) && isColor ( int.Parse ( textBoxBlue.Text ) ) )
                {
                    labelColor.BackColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
                    labelColor.ForeColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
                }
            }
        }

        public bool isColor ( int n )
        {
            if ( n >= 0 && n <= 255 )
            {
                return true;
            }
            return false;
        }

        private void textBoxGreen_TextChanged ( object sender , EventArgs e )
        {
            if ( Regex.IsMatch ( textBoxRed.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxGreen.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxBlue.Text , @"(\d)+" ) )
            {
                if ( isColor ( int.Parse ( textBoxRed.Text ) ) && isColor ( int.Parse ( textBoxGreen.Text ) ) && isColor ( int.Parse ( textBoxBlue.Text ) ) )
                {
                    labelColor.BackColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
                    labelColor.ForeColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
                }
            }
        }

        private void textBoxBlue_TextChanged ( object sender , EventArgs e )
        {
            if ( Regex.IsMatch ( textBoxRed.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxGreen.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxBlue.Text , @"(\d)+" ) )
            {
                if ( isColor ( int.Parse ( textBoxRed.Text ) ) && isColor ( int.Parse ( textBoxGreen.Text ) ) && isColor ( int.Parse ( textBoxBlue.Text ) ) )
                {
                    labelColor.BackColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
                    labelColor.ForeColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxRed.Text ) , int.Parse ( textBoxGreen.Text ) , int.Parse ( textBoxBlue.Text ) );
                }
            }
        }

        private void getGC ( )
        {
            string [ ] line = File.ReadAllLines ( "..\\common\\graphicalculturetype.txt" , Encoding.Default );
            foreach ( string str in line )
            {
                comboBoxGraphics.Items.Add ( str );
            }
        }

        private void getProvinces ( )
        {
            string folderpath = "..\\history\\provinces";
            string [ ] foldernames = Directory.GetDirectories ( folderpath );
            foreach ( string fon in foldernames )
            {
                string [ ] filenames = Directory.GetFiles ( fon );
                foreach ( string fin in filenames )
                {
                    string filename = fin.Substring ( fin.LastIndexOf ( "\\" ) + 1 ).Replace ( ".txt" , "" );
                    if ( Regex.IsMatch ( filename , @"(\d)+(\s)+-(\s)+(\S+)" ) )
                    {
                        string [ ] provincePair = filename.Split ( '-' );
                        if ( provincesDic.ContainsKey ( provincePair [ 0 ].Trim ( ) ) )
                        {
                            continue;
                        }
                        provincesDic.Add ( provincePair [ 0 ].Trim ( ) , provincePair [ 1 ].Trim ( ) );
                        comboIndexDic.Add ( comboBoxCaptial.Items.Count , provincePair [ 0 ].Trim ( ) );
                        comboBoxCaptial.Items.Add ( provincePair [ 1 ].Trim ( ) );
                    }
                    else if ( Regex.IsMatch ( filename , @"(\d)+(\s)+(\S+)" ) )
                    {
                        while ( filename.Contains ( "  " ) )
                        {
                            filename = filename.Replace ( "  " , " " );
                        }
                        string [ ] provincePair = filename.Split ( ' ' );
                        if ( provincesDic.ContainsKey ( provincePair [ 0 ].Trim ( ) ) )
                        {
                            continue;
                        }
                        provincesDic.Add ( provincePair [ 0 ].Trim ( ) , provincePair [ 1 ].Trim ( ) );
                        comboIndexDic.Add ( comboBoxCaptial.Items.Count , provincePair [ 0 ].Trim ( ) );
                        comboBoxCaptial.Items.Add ( provincePair [ 1 ].Trim ( ) );
                    }
                }
            }
        }

        public void getCountriesHistoryDic ( )
        {
            string [ ] files = Directory.GetFiles ( ".\\xml\\history\\countries" );
            foreach ( string fn in files )
            {
                string filename = fn.Substring ( fn.LastIndexOf ( "\\" ) + 1 ).Replace ( ".txt.xml" , "" );
                if ( filename.Contains ( '-' ) )
                {
                    string tagName = filename.Substring ( 0 , 3 );
                    string historyName = filename.Substring ( filename.IndexOf ( "-" ) + 1 );
                    countriesHistoryDic.Add ( tagName.Trim ( ) , historyName.Trim ( ) );
                }
            }
        }

        private void getCultureList ( )
        {
            XmlDocument cultures = new XmlDocument ( );
            cultures.Load ( ".\\xml\\common\\cultures.txt.xml" );
            foreach ( XmlNode cultureGruop in cultures.ChildNodes [ 1 ] )
            {
                foreach ( XmlNode cultureNode in cultureGruop )
                {
                    if ( cultureNode.Name != "leader" && cultureNode.Name != "unit" && cultureNode.Name != "union" && cultureNode.Name != "is_overseas" )
                    {
                        comboBoxPrimaryCulture.Items.Add ( cultureNode.Name );
                    }
                }
            }
        }

        private void getReligion ( )
        {
            XmlDocument religion = new XmlDocument ( );
            religion.Load ( ".\\xml\\common\\religion.txt.xml" );
            foreach ( XmlNode religionGruop in religion.ChildNodes [ 1 ] )
            {
                foreach ( XmlNode religionNode in religionGruop )
                {
                    comboBoxReligion.Items.Add ( religionNode.Name );
                }
            }
        }

        private void getGovernments ( )
        {
            governments.Load ( ".\\xml\\common\\governments.txt.xml" );
            foreach ( XmlNode governmentNode in governments.ChildNodes [ 1 ] )
            {
                comboBoxGovernment.Items.Add ( governmentNode.Name );
                listBoxGovernments.Items.Add ( governmentNode.Name );
            }
        }

        private void getNationalValue ( )
        {
            XmlDocument nationalValue = new XmlDocument ( );
            nationalValue.Load ( ".\\xml\\common\\nationalvalues.txt.xml" );
            foreach ( XmlNode nationalValueNode in nationalValue.ChildNodes [ 1 ] )
            {
                comboBoxNationalValue.Items.Add ( nationalValueNode.Name );
            }
        }

        private void getTechonologies ( )
        {
            XmlDocument technology = new XmlDocument ( );
            technology.Load ( ".\\xml\\common\\technology.txt.xml" );
            foreach ( XmlNode technologyNode in technology.ChildNodes [ 1 ].SelectSingleNode ( "schools" ) )
            {
                comboBoxSchool.Items.Add ( technologyNode.Name );
            }
        }

        private void getIdeologies ( )
        {
            XmlDocument ideologies = new XmlDocument ( );
            ideologies.Load ( ".\\xml\\common\\ideologies.txt.xml" );
            foreach ( XmlNode node1 in ideologies.ChildNodes [ 1 ] )
            {
                foreach ( XmlNode node2 in node1 )
                {
                    checkedListBoxIdeologies.Items.Add ( node2.Name );
                    ideoIndexDic.Add ( node2.Name , index++ );
                }
            }
        }

        private void getGoods ( )
        {
            goods.Load ( ".\\xml\\common\\goods.txt.xml" );
            foreach ( XmlNode node1 in goods.ChildNodes [ 1 ] )
            {
                comboBoxGoodType.Items.Add ( node1.Name );
                foreach ( XmlNode node2 in node1 )
                {
                    listBoxGoods.Items.Add ( node2.Name );
                }
            }
        }

        private void checkBoxCivilized_CheckedChanged ( object sender , EventArgs e )
        {
        }

        private void buttonCulture_Click ( object sender , EventArgs e )
        {
            Cultrues nc = new Cultrues ( listBoxCountries.SelectedItem.ToString ( ) );
            nc.Show ( );
        }

        private void buttonPoliticalReforms_Click ( object sender , EventArgs e )
        {
            PoliticalReforms pr = new PoliticalReforms ( listBoxCountries.SelectedItem.ToString ( ) );
            pr.Show ( );
        }

        private void buttonSocialReforms_Click ( object sender , EventArgs e )
        {
            SocialReforms sr = new SocialReforms ( listBoxCountries.SelectedItem.ToString ( ) );
            sr.Show ( );
        }

        private void buttonTechnologies_Click ( object sender , EventArgs e )
        {
            Technology tech = new Technology ( listBoxCountries.SelectedItem.ToString ( ) );
            tech.Show ( );
        }

        private void buttonUpperHouse_Click ( object sender , EventArgs e )
        {
            UpperHouse uh = new UpperHouse ( listBoxCountries.SelectedItem.ToString ( ) );
            uh.Show ( );
        }

        private void listBoxGovernments_SelectedIndexChanged ( object sender , EventArgs e )
        {
            if ( checkBoxElection.Checked )
            {
                numericUpDownDuration.Enabled = true;
            }
            else
            {
                numericUpDownDuration.Enabled = false;
            }

            int count = checkedListBoxIdeologies.Items.Count;
            for ( int i = 0 ; i < count ; i++ )
            {
                checkedListBoxIdeologies.SetItemChecked ( i , false );
            }

            if ( listBoxGovernments.SelectedIndex == -1 )
            {
                return;
            }
            foreach ( XmlNode node in governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ) )
            {
                foreach ( var ideoName in checkedListBoxIdeologies.Items )
                {
                    if ( node.Name == ideoName.ToString ( ) )
                    {
                        checkedListBoxIdeologies.SetItemChecked ( ideoIndexDic [ node.Name ] , true );
                        break;
                    }
                }
            }

            if ( governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).SelectSingleNode ( "election" ).InnerText.ToString ( ) == "yes" )
            {
                checkBoxElection.Checked = true;
            }
            else
            {
                checkBoxElection.Checked = false;
            }//appoint_ruling_party 

            if ( governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).SelectSingleNode ( "appoint_ruling_party" ).InnerText.ToString ( ) == "yes" )
            {
                checkBoxAppointRulingParty.Checked = true;
            }
            else
            {
                checkBoxAppointRulingParty.Checked = false;
            }

            if ( checkBoxElection.Checked )
            {
                numericUpDownDuration.Enabled = true;
                numericUpDownDuration.Value = int.Parse ( Victoria2.Domain.Comm.FileHelper.Unescape ( governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).SelectSingleNode ( "duration" ).InnerText.ToString ( ) ) );
            }
            else
            {
                numericUpDownDuration.Value = 0;
                numericUpDownDuration.Enabled = false;
            }

            comboBoxFlagType.Text = governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).SelectSingleNode ( "flagType" ) != null ? governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).SelectSingleNode ( "flagType" ).InnerText.ToString ( ) : "默认";

        }

        private void buttonSaveGovernments_Click ( object sender , EventArgs e )
        {
            governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).RemoveAll ( );

            foreach ( var ideos in checkedListBoxIdeologies.CheckedItems )
            {
                XmlElement ele = governments.CreateElement ( ideos.ToString ( ) );
                ele.InnerText = "yes";
                governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).AppendChild ( ele );
            }

            XmlElement election = governments.CreateElement ( "election" );
            election.InnerText = checkBoxElection.Checked ? "yes" : "no";
            governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).AppendChild ( election );

            if ( checkBoxElection.Checked )
            {
                XmlElement duration = governments.CreateElement ( "duration" );
                duration.InnerText = numericUpDownDuration.Value.ToString ( );
                governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).AppendChild ( duration );
            }

            XmlElement appoint_ruling_party = governments.CreateElement ( "appoint_ruling_party" );
            appoint_ruling_party.InnerText = checkBoxAppointRulingParty.Checked ? "yes" : "no";
            governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).AppendChild ( appoint_ruling_party );

            if ( comboBoxFlagType.Text != "默认" )
            {
                XmlElement flagType = governments.CreateElement ( "flagType" );
                flagType.InnerText = comboBoxFlagType.Text;
                governments.ChildNodes [ 1 ].SelectSingleNode ( listBoxGovernments.SelectedItem.ToString ( ) ).AppendChild ( flagType );
            }

            governments.Save ( ".\\xml\\common\\governments.txt.xml" );
            MessageBox.Show ( "保存成功！" );
        }

        private void buttonNewGovernment_Click ( object sender , EventArgs e )
        {
            NewGovernment ng = new NewGovernment ( this );
            ng.Show ( );
        }

        private void checkBoxElection_CheckedChanged ( object sender , EventArgs e )
        {
            if ( checkBoxElection.Checked )
            {
                numericUpDownDuration.Enabled = true;
            }
            else
            {
                numericUpDownDuration.Enabled = false;
            }
        }

        private void listBoxGoods_SelectedIndexChanged ( object sender , EventArgs e )
        {
            if ( listBoxGoods.SelectedIndex == -1 )
            {
                return;
            }
            foreach ( XmlNode node1 in goods.ChildNodes [ 1 ] )
            {
                if ( node1.SelectSingleNode ( listBoxGoods.SelectedItem.ToString ( ) ) != null )
                {
                    comboBoxGoodType.Text = node1.Name;
                    XmlNode node2 = node1.SelectSingleNode ( listBoxGoods.SelectedItem.ToString ( ) );
                    textBoxCost.Text = Victoria2.Domain.Comm.FileHelper.Unescape ( node2.SelectSingleNode ( "cost" ).InnerText );
                    checkBoxAvailableFromStart.Checked = ( node2.SelectSingleNode ( "available_from_start" ) != null ) ? false : true;
                    checkBoxOverseasPenalty.Checked = ( node2.SelectSingleNode ( "overseas_penalty" ) != null ) ? true : false;//overseas_penalty
                    checkBoxTradeable.Checked = ( node2.SelectSingleNode ( "tradeable" ) != null ) ? false : true;//tradeable
                    checkBoxMoney.Checked = ( node2.SelectSingleNode ( "money" ) != null ) ? true : false;//money
                    string [ ] colors = Victoria2.Domain.Comm.FileHelper.Unescape ( node2.SelectSingleNode ( "color" ).InnerText ).Replace ( "{" , "" ).Replace ( "}" , "" ).Trim ( ).Split ( ' ' );//color
                    textBoxGoodColorRed.Text = colors [ 0 ];
                    textBoxGoodColorGreen.Text = colors [ 1 ];
                    textBoxGoodColorBlue.Text = colors [ 2 ];
                }
                else
                {
                    continue;
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

        private void goodColorChanged ( )
        {
            if ( Regex.IsMatch ( textBoxGoodColorRed.Text , @"(\d)+" ) && Regex.IsMatch ( textBoxGoodColorGreen.Text , @"(\d)+" )
                && Regex.IsMatch ( textBoxGoodColorBlue.Text , @"(\d)+" ) )
            {
                if ( isColor ( int.Parse ( textBoxGoodColorRed.Text ) ) && isColor ( int.Parse ( textBoxGoodColorGreen.Text ) )
                    && isColor ( int.Parse ( textBoxGoodColorBlue.Text ) ) )
                {
                    labelGoodColor.BackColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxGoodColorRed.Text ) ,
                        int.Parse ( textBoxGoodColorGreen.Text ) , int.Parse ( textBoxGoodColorBlue.Text ) );
                    labelGoodColor.ForeColor = System.Drawing.Color.FromArgb ( int.Parse ( textBoxGoodColorRed.Text ) ,
                        int.Parse ( textBoxGoodColorGreen.Text ) , int.Parse ( textBoxGoodColorBlue.Text ) );
                }
            }
        }

        private void buttonGoodsSave_Click ( object sender , EventArgs e )
        {
            if ( checkGoodsInput ( ) )
            {
                foreach ( XmlNode node1 in goods.ChildNodes [ 1 ] )
                {
                    if ( node1.SelectSingleNode ( listBoxGoods.SelectedItem.ToString ( ) ) != null )
                    {
                        node1.RemoveChild ( node1.SelectSingleNode ( listBoxGoods.SelectedItem.ToString ( ) ) );
                        break;
                    }
                }

                XmlElement ele = goods.CreateElement ( listBoxGoods.SelectedItem.ToString ( ) );

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
            }
        }

        private bool checkGoodsInput ( )
        {
            if ( !Regex.IsMatch ( textBoxCost.Text , @"(\d)+\.\d\d" ) && !Regex.IsMatch ( textBoxCost.Text , @"(\d)+\.\d" ) )
            {
                MessageBox.Show ( "花销必须保留一位或两位小数!" );
                return false;
            }
            if ( !isColor ( int.Parse ( textBoxGoodColorRed.Text ) ) || !isColor ( int.Parse ( textBoxGoodColorGreen.Text ) )
                || !isColor ( int.Parse ( textBoxGoodColorBlue.Text ) ) )
            {
                MessageBox.Show ( "颜色格式错误！" );
                return false;
            }
            return true;
        }

        private void buttonNewGoods_Click ( object sender , EventArgs e )
        {
            NewGoods ng = new NewGoods ( this );
            ng.Show ( );
        }

        private void buttonParties_Click ( object sender , EventArgs e )
        {
            Parties p = new Parties ( textBoxCountryTagName.Text , listBoxCountries.SelectedItem.ToString ( ) , this );
            p.Show ( );
        }

        private void getPolicies ( )
        {
            foreach ( XmlNode policies in issues_txt_xml.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ) )
            {
                TreeNode node = new TreeNode ( policies.Name );

                foreach ( XmlNode policyValue in policies )
                {
                    node.Nodes.Add ( policyValue.Name );
                }
                treeViewPolicies.Nodes.Add ( node );
            }
        }

        private void treeViewPolicies_AfterSelect ( object sender , TreeViewEventArgs e )
        {
            if ( treeViewPolicies.SelectedNode.Parent == null )
            {
                lastPolicy = treeViewPolicies.SelectedNode.Text;
                return;
            }
            XmlNode node = issues_txt_xml.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ).SelectSingleNode ( treeViewPolicies.SelectedNode.Parent.Text ).SelectSingleNode ( treeViewPolicies.SelectedNode.Text );
            textBoxMaxTariff.Text = node.SelectSingleNode ( "max_tariff" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "max_tariff" ).InnerText ) : "NULL";
            textBoxMinTariff.Text = node.SelectSingleNode ( "min_tariff" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "min_tariff" ).InnerText ) : "NULL";
            textBoxMaxTax.Text = node.SelectSingleNode ( "max_tax" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "max_tax" ).InnerText ) : "NULL";
            textBoxMinTax.Text = node.SelectSingleNode ( "min_tax" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "min_tax" ).InnerText ) : "NULL";
            textBoxFactoryOwnerCost.Text = node.SelectSingleNode ( "factory_owner_cost" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "factory_owner_cost" ).InnerText ) : "NULL";
            textBoxFactoryOutput.Text = node.SelectSingleNode ( "factory_output" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "factory_output" ).InnerText ) : "NULL";
            textBoxFactoryThroughput.Text = node.SelectSingleNode ( "factory_throughput" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "factory_throughput" ).InnerText ) : "NULL";
            textBoxGlobalAssimilationRate.Text = node.SelectSingleNode ( "global_assimilation_rate" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "global_assimilation_rate" ).InnerText ) : "NULL";
            textBoxMaxMilitarySpending.Text = node.SelectSingleNode ( "max_military_spending" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "max_military_spending" ).InnerText ) : "NULL";
            textBoxSupplyConsumption.Text = node.SelectSingleNode ( "supply_consumption" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "supply_consumption" ).InnerText ) : "NULL";
            textBoxWarExhaustionEffect.Text = node.SelectSingleNode ( "war_exhaustion_effect" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "war_exhaustion_effect" ).InnerText ) : "NULL";
            comboBoxIsJingoism.Text = ( node.SelectSingleNode ( "is_jingoism" ) != null ) ? ( node.SelectSingleNode ( "is_jingoism" ).InnerText == "yes" ? "是" : "否" ) : ( "NULL" );
            textBoxCBGenerationSpeedModifier.Text = node.SelectSingleNode ( "cb_generation_speed_modifier" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "cb_generation_speed_modifier" ).InnerText ) : "NULL";
            textBoxMobilizationImpact.Text = node.SelectSingleNode ( "mobilization_impact" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "mobilization_impact" ).InnerText ) : "NULL";
            textBoxOrgRegain.Text = node.SelectSingleNode ( "org_regain" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "org_regain" ).InnerText ) : "NULL";
            textBoxReinforceSpeed.Text = node.SelectSingleNode ( "reinforce_speed" ) != null ? Victoria2.Domain.Comm.FileHelper.Unescape ( node.SelectSingleNode ( "reinforce_speed" ).InnerText ) : "NULL";

            if ( node.SelectSingleNode ( "rules" ) != null )
            {
                XmlNode rules = node.SelectSingleNode ( "rules" );
                if ( rules.SelectSingleNode ( "primary_culture_voting" ) != null )
                {
                    comboBoxVoting.Text = "主体民族拥有投票权";
                }
                else if ( rules.SelectSingleNode ( "culture_voting" ) != null )
                {
                    comboBoxVoting.Text = "被接受民族拥有投票权";
                }
                else if ( rules.SelectSingleNode ( "all_voting" ) != null )
                {
                    comboBoxVoting.Text = "所有民族拥有投票权";
                }
                else
                {
                    comboBoxVoting.Text = "NULL";
                }

                if ( rules.ChildNodes.Count > 1 )
                {
                    checkBoxUseRules.Checked = true;
                    foreach ( CheckBox cb in groupBoxRules.Controls )
                    {
                        StringBuilder sb = new StringBuilder ( );
                        string foreHandle = cb.Name.Replace ( "checkBox" , "" );

                        foreach ( char ch in foreHandle )
                        {
                            if ( char.IsUpper ( ch ) )
                            {
                                sb.Append ( "_" + char.ToLower ( ch ) );
                            }
                            else
                            {
                                sb.Append ( ch );
                            }
                        }
                        string cbName = sb.ToString ( ).Substring ( 1 );
                        cb.Checked = ( rules.SelectSingleNode ( cbName ) != null ) ? ( rules.SelectSingleNode ( cbName ).InnerText == "yes" ? true : false ) : ( false );
                    }
                }
                else
                {
                    checkBoxUseRules.Checked = false;
                }
            }
            else
            {
                comboBoxVoting.Text = "NULL";
            }
        }

        private void checkBoxUseRules_CheckedChanged ( object sender , EventArgs e )
        {
            groupBoxRules.Enabled = checkBoxUseRules.Checked;
        }

        private void buttonPolicySave_Click ( object sender , EventArgs e )
        {
            if ( checkPolicyInput ( ) )
            {
                XmlNode node = issues_txt_xml.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ).
                    SelectSingleNode ( treeViewPolicies.SelectedNode.Parent.Text ).SelectSingleNode ( treeViewPolicies.SelectedNode.Text );
                node.RemoveAll ( );
                foreach ( Control ctrl in tabPagePolicies.Controls )
                {
                    if ( ctrl is TextBox )
                    {
                        if ( ctrl.Text != "NULL" )
                        {
                            StringBuilder sb = new StringBuilder ( );
                            string foreHandle = ctrl.Name.Replace ( "textBox" , "" );

                            foreach ( char ch in foreHandle )
                            {
                                if ( char.IsUpper ( ch ) )
                                {
                                    sb.Append ( "_" + char.ToLower ( ch ) );
                                }
                                else
                                {
                                    sb.Append ( ch );
                                }
                            }
                            string elementName = sb.ToString ( ).Substring ( 1 );
                            XmlElement ele = issues_txt_xml.CreateElement ( elementName );
                            ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( ctrl.Text );
                            node.AppendChild ( ele );
                        }
                    }
                }
                if ( comboBoxIsJingoism.Text != "NULL" )
                {
                    XmlElement is_jingoism = issues_txt_xml.CreateElement ( "is_jingoism" );
                    if ( comboBoxIsJingoism.Text == "是" )
                    {
                        is_jingoism.InnerText = "yes";
                    }
                    else if ( comboBoxIsJingoism.Text == "否" )
                    {
                        is_jingoism.InnerText = "no";
                    }
                    node.AppendChild ( is_jingoism );
                }
                if ( comboBoxVoting.Text != "NULL" || checkBoxUseRules.Checked == true )
                {
                    XmlElement rules = issues_txt_xml.CreateElement ( "rules" );
                    XmlElement voting;
                    switch ( comboBoxVoting.Text )
                    {
                        case "主体民族拥有投票权":
                            voting = issues_txt_xml.CreateElement ( "primary_culture_voting" );
                            voting.InnerText = "yes";
                            rules.AppendChild ( voting );
                            break;
                        case "被接受民族拥有投票权":
                            voting = issues_txt_xml.CreateElement ( "culture_voting" );
                            voting.InnerText = "yes";
                            rules.AppendChild ( voting );
                            break;
                        case "所有民族拥有投票权":
                            voting = issues_txt_xml.CreateElement ( "all_voting" );
                            voting.InnerText = "yes";
                            rules.AppendChild ( voting );
                            break;
                    }
                    if ( checkBoxUseRules.Checked == true )
                    {
                        foreach ( CheckBox cb in groupBoxRules.Controls )
                        {
                            StringBuilder sb = new StringBuilder ( );
                            string foreHandle = cb.Name.Replace ( "checkBox" , "" );

                            foreach ( char ch in foreHandle )
                            {
                                if ( char.IsUpper ( ch ) )
                                {
                                    sb.Append ( "_" + char.ToLower ( ch ) );
                                }
                                else
                                {
                                    sb.Append ( ch );
                                }
                            }
                            string cbName = sb.ToString ( ).Substring ( 1 );
                            XmlElement ele = issues_txt_xml.CreateElement ( cbName );
                            ele.InnerText = cb.Checked ? "yes" : "no";
                            rules.AppendChild ( ele );
                        }
                    }
                    node.AppendChild ( rules );
                }
                issues_txt_xml.Save ( ".\\xml\\common\\issues.txt.xml" );
                MessageBox.Show ( "保存成功！" );
            }
        }

        private bool checkPolicyInput ( )
        {
            foreach ( Control ctrl in tabPagePolicies.Controls )
            {
                if ( ctrl is TextBox )
                {
                    if ( !Regex.IsMatch ( ctrl.Text , @"^-?\d+(.\d{1,2})?$" ) && ctrl.Text != "NULL" )
                    {
                        MessageBox.Show ( "数字格式错误！" );
                        return false;
                    }
                }
            }

            if ( treeViewPolicies.SelectedNode.Parent == null )
            {
                MessageBox.Show ( "无法保存！" );
                return false;
            }
            return true;
        }

        private void buttonNewCountry_Click_1 ( object sender , EventArgs e )
        {
            NewCountry nc = new NewCountry ( this );
            nc.Show ( );
        }

        private void buttonNewPolicy_Click ( object sender , EventArgs e )
        {
            string policyName = Interaction.InputBox ( "请输入新政策名" );
            if ( !Regex.IsMatch ( policyName , @"\w+" ) )
            {
                MessageBox.Show ( "政策名格式才错误！" );
                return;
            }
            if ( string.IsNullOrEmpty ( lastPolicy ) )
            {
                MessageBox.Show ( "请选择一个政策类别！" );
                return;
            }
            XmlElement emptyEle = issues_txt_xml.CreateElement ( policyName );
            emptyEle.InnerText = "{\n}";
            issues_txt_xml.ChildNodes [ 1 ].SelectSingleNode ( "party_issues" ).SelectSingleNode ( lastPolicy ).AppendChild ( emptyEle );
            issues_txt_xml.Save ( ".\\xml\\common\\issues.txt.xml" );
            MessageBox.Show ( "新建成功！" );
            this.Reload ( );
        }
    }
}
