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
    public partial class NewCountryHistory : Form
    {
        MainForm mf;
        string CountryTagName;
        string CountryName;
        Dictionary<string , string> provincesDic = new Dictionary<string , string> ( );
        Dictionary<int , string> comboIndexDic = new Dictionary<int , string> ( );
        XmlDocument countries = new XmlDocument ( );
        XmlDocument countryHistory = new XmlDocument ( );

        public NewCountryHistory ( string CountrytagNamePass , string CountryNamePass , MainForm mfPass )
        {
            InitializeComponent ( );
            CountryTagName = CountrytagNamePass;
            CountryName = CountryNamePass;
            mf = mfPass;
        }

        private void NewCountryHistory_Load ( object sender , EventArgs e )
        {
            getGC ( );
            getProvinces ( );
            getCultureList ( );
            getReligion ( );
            getGovernments ( );
            getNationalValue ( );
            getTechonologies ( );
            countries.Load ( ".\\xml\\common\\countries\\" + CountryName + ".txt.xml" );
            countryHistory.Load ( ".\\xml\\history\\countries\\" + CountryTagName + " - " + CountryName + ".txt.xml" );
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
            XmlDocument government = new XmlDocument ( );
            government.Load ( ".\\xml\\common\\governments.txt.xml" );
            foreach ( XmlNode governmentNode in government.ChildNodes [ 1 ] )
            {
                comboBoxGovernment.Items.Add ( governmentNode.Name );
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

        private bool isColor ( int n )
        {
            if ( n >= 0 && n <= 255 )
            {
                return true;
            }
            return false;
        }

        private void buttonNextStep_Click ( object sender , EventArgs e )
        {
            if ( !isColor ( int.Parse ( textBoxRed.Text ) ) && isColor ( int.Parse ( textBoxGreen.Text ) ) && isColor ( int.Parse ( textBoxBlue.Text ) ) )
            {
                MessageBox.Show ( "颜色格式错误！" );
                return;
            }
            //14/16
            if ( comboBoxGraphics.SelectedIndex == -1 || comboBoxCaptial.SelectedIndex == -1
                || comboBoxPrimaryCulture.SelectedIndex == -1 || comboBoxReligion.SelectedIndex == -1 || comboBoxGovernment.SelectedIndex == -1
                || comboBoxNationalValue.SelectedIndex == -1 || string.IsNullOrEmpty ( textBoxPlurality.Text ) || string.IsNullOrEmpty ( textBoxLiteracy.Text ) )
            {
                MessageBox.Show ( "不能留空！" );
                return;
            }
            countries.ChildNodes [ 1 ].SelectSingleNode ( "color" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( "{ " + textBoxRed.Text + " " + textBoxGreen.Text + " " + textBoxBlue.Text + " }" );
            countries.ChildNodes [ 1 ].SelectSingleNode ( "graphical_culture" ).InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxGraphics.Text );
            countries.Save ( ".\\xml\\common\\countries\\" + CountryName + ".txt.xml" );

            XmlElement capital = countryHistory.CreateElement ( "capital" );
            capital.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboIndexDic [ comboBoxCaptial.SelectedIndex ] );
            countryHistory.ChildNodes [ 1 ].AppendChild ( capital );

            XmlElement primary_culture = countryHistory.CreateElement ( "primary_culture" );
            primary_culture.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxPrimaryCulture.SelectedItem.ToString ( ) );
            countryHistory.ChildNodes [ 1 ].AppendChild ( primary_culture );

            XmlElement religion = countryHistory.CreateElement ( "religion" );
            religion.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxReligion.SelectedItem.ToString ( ) );
            countryHistory.ChildNodes [ 1 ].AppendChild ( religion );

            XmlElement government = countryHistory.CreateElement ( "government" );
            government.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxGovernment.SelectedItem.ToString ( ) );
            countryHistory.ChildNodes [ 1 ].AppendChild ( government );

            XmlElement plurality = countryHistory.CreateElement ( "plurality" );
            plurality.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxPlurality.Text );
            countryHistory.ChildNodes [ 1 ].AppendChild ( plurality );

            XmlElement nationalvalue = countryHistory.CreateElement ( "nationalvalue" );
            nationalvalue.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxNationalValue.SelectedItem.ToString ( ) );
            countryHistory.ChildNodes [ 1 ].AppendChild ( nationalvalue );

            XmlElement literacy = countryHistory.CreateElement ( "literacy" );
            literacy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxLiteracy.Text );
            countryHistory.ChildNodes [ 1 ].AppendChild ( literacy );

            if ( checkBoxCivilized.Checked )
            {
                XmlElement civilized = countryHistory.CreateElement ( "civilized" );
                civilized.InnerText = "yes";
                countryHistory.ChildNodes [ 1 ].AppendChild ( civilized );
            }//is_releasable_vassal

            XmlElement is_releasable_vassal = countryHistory.CreateElement ( "is_releasable_vassal" );
            is_releasable_vassal.InnerText = checkBoxIsReleasableVassal.Checked ? "yes" : "no";
            countryHistory.ChildNodes [ 1 ].AppendChild ( is_releasable_vassal );

            if ( !string.IsNullOrEmpty ( textBoxNonStateCultureLiteracy.Text ) )
            {
                XmlElement non_state_culture_literacy = countryHistory.CreateElement ( "non_state_culture_literacy" );
                non_state_culture_literacy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxNonStateCultureLiteracy.Text );
                countryHistory.ChildNodes [ 1 ].AppendChild ( non_state_culture_literacy );
            }
            //non_state_culture_literacy
            //textBoxPrestige

            if ( !string.IsNullOrEmpty ( textBoxPrestige.Text ) )
            {
                XmlElement prestige = countryHistory.CreateElement ( "prestige" );
                prestige.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxPrestige.Text );
                countryHistory.ChildNodes [ 1 ].AppendChild ( prestige );
            }
            //school
            if ( comboBoxSchool.SelectedIndex != -1 )
            {
                XmlElement schools = countryHistory.CreateElement ( "schools" );
                schools.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( comboBoxSchool.SelectedItem.ToString ( ) );
                countryHistory.ChildNodes [ 1 ].AppendChild ( schools );
            }
            //textBoxConsciousness
            if ( !string.IsNullOrEmpty ( textBoxConsciousness.Text ) )
            {
                XmlElement consciousness = countryHistory.CreateElement ( "consciousness" );
                consciousness.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxConsciousness.Text );
                countryHistory.ChildNodes [ 1 ].AppendChild ( consciousness );
            }
            //textBoxNonstateConsciousness
            if ( !string.IsNullOrEmpty ( textBoxNonstateConsciousness.Text ) )
            {
                XmlElement nonstate_consciousness = countryHistory.CreateElement ( "nonstate_consciousness" );
                nonstate_consciousness.InnerText = Victoria2.Domain.Comm.FileHelper.Escape ( textBoxNonstateConsciousness.Text );
                countryHistory.ChildNodes [ 1 ].AppendChild ( nonstate_consciousness );
            }//ruling_party

            XmlElement ruling_party = countryHistory.CreateElement ( "ruling_party" );
            ruling_party.InnerText = "";
            countryHistory.ChildNodes [ 1 ].AppendChild ( ruling_party );

            countryHistory.Save ( ".\\xml\\history\\countries\\" + CountryTagName + " - " + CountryName + ".txt.xml" );
            NewCountryCultrues ncc = new NewCountryCultrues ( CountryTagName , CountryName , mf );
            ncc.Show ( );
            //ncc.MdiParent = this.MdiParent;
            this.Close ( );
        }

        private void buttonPreviousStep_Click ( object sender , EventArgs e )
        {
            countryHistory.ChildNodes [ 1 ].RemoveAll ( );
            countryHistory.Save ( ".\\xml\\history\\countries\\" + CountryTagName + " - " + CountryName + ".txt.xml" );
            XmlDocument countries = new XmlDocument ( );
            countries.Load ( ".\\xml\\common\\countries\\" + CountryName + ".txt.xml" );
            countries.ChildNodes [ 1 ].SelectSingleNode ( "color" ).InnerText = "";
            countries.ChildNodes [ 1 ].SelectSingleNode ( "graphical_culture" ).InnerText = "";
            File.Delete ( ".\\xml\\common\\countries\\" + CountryName + ".txt.xml" );
            File.Delete ( ".\\xml\\history\\countries\\" + CountryTagName + " - " + CountryName + ".txt.xml" );
            countries.ChildNodes [ 1 ].RemoveChild ( countries.ChildNodes [ 1 ].SelectSingleNode ( CountryTagName ) );
            countries.Save ( ".\\xml\\common\\countries.txt.xml" );

            NewCountry nc = new NewCountry ( CountryTagName , CountryName , mf );
            nc.Show ( );
            this.Close ( );
        }

    }
}
