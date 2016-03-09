//Victoria II Editor
//Դ.cpp

#include<iostream>
#include<fstream>
#include<sstream>
#include<string>
#include<vector>
#include"ideologies_group.h"
#include"government.h"
#include"country.h"

using namespace std;

ofstream governments_output ( ".\\common\\governments.txt" , ios::app );	//governments.txt���
ofstream ideologies_output ( ".\\common\\ideologies.txt" , ios::app );	//ideologies.txt���
ofstream countries_output ( ".\\common\\countries.txt" , ios::app );	//countries.txt���
ofstream country_colors_output ( ".\\common\\country_colors.txt" , ios::app );	//country_colors���

ifstream governments_input ( ".\\common\\governments.txt" );	//governments.txt����
ifstream ideologies_input ( ".\\common\\ideologies.txt" );	//ideologies.txt����
ifstream countries_input ( ".\\common\\countries.txt" );	//countries.txt����
ifstream country_colors_input ( ".\\common\\country_colors.txt" );	//country_colors����

vector<ideologies_gruop> ideologies_gruop_vector;	//������ʶ��̬��
vector<government> government_vector;	//��������
vector<country> country_vector;	//�������

void excute ( const string& cmd );	//ִ������

void load ();	//�����ļ�
void show ( const string cmd );	//��ӡ
void insert ( const string cmd );	//����

void load_ideologies_gruop ();	//������ʶ��̬��
void load_governments ();	//��������
void load_countries ();	//���ع���

void show_ideologies_gruop ();	//��ӡ��ʶ��̬��
void show_ideologies ();	//��ӡ��ʶ��̬
void show_governments ();	//��ӡ����
void show_countries ();	//��ӡ����

void insert_government ( const string cmd );	//�������
void insert_country ( const string cmd );	//��ӹ���

string trim ( string s );	//ȥ���ո�
string trim_full_name ( string s );	//����country.txt���·��
bool is_in_ideology ( const string id_name );	//�ж���ʶ��̬�Ƿ����
bool is_in_government ( const string gov_name );	//�ж������Ƿ����
bool ok_to_bool ( const string ok );	//��"yes","no"ת����bool����
bool is_in_country ( const string name , const string full_name );	//�жϹ����Ƿ����
string bool_to_ok ( const bool flag );	//��bool����ת����bool"yes","no"
flagType str_to_ft ( const string str );	//���ַ���ת����flagType����
string ft_to_str ( flagType ft );	//��flagType����ת�����ַ�������

int main ( void )
{
	string cmd;	//����
	load ();	//�����ļ�
	while ( 1 )
	{
		cmd = "";
		cout << "Victoria II Editor >  ";
		char ch;
		while ( ( ch = cin.get () ) != ';' )
		{
			cmd += ch;
		}
		excute ( cmd );	//ִ������
	}
	system ( "pause" );
	return 0;
}


void excute ( const string& cmd )	//ִ������
{
	istringstream istr ( trim ( cmd ) );
	string cmd_head , cmd_obj;
	istr >> cmd_head;
	if ( cmd_head == "quit" )	//�˳�
	{
		exit ( 0 );
	}
	cmd_obj = trim ( cmd.substr ( cmd_head.length () + 1 ) );
	if ( cmd_head == "insert" )	//�������
	{
		insert ( cmd_obj );
	}
	else if ( cmd_head == "show" )
	{
		show ( cmd_obj );
	}
	else	//����ʶ��
	{
		cerr << "����ʶ��" << cmd_head << "�������������룡" << endl;
	}
}

void load ()	//�����ļ�
{
	load_ideologies_gruop ();
	load_governments ();
	load_countries ();
}

void load_ideologies_gruop ()	//������ʶ��̬��
{
	//��ʾ��Ϣ
	cout << "���ڼ�����ʶ��̬..." << endl;
	unsigned brace = 0;	//�����š�{����������������}����һ
	string str;
	string text;
	while ( ideologies_input >> str )
	{
		if ( str [ 0 ] == '#' )	//����ע��
		{
			char eat [ 1000 ];
			ideologies_input.getline ( eat , 1000 );
			continue;
		}
		else
		{
			ideologies_gruop_vector.push_back ( ideologies_gruop ( str ) );
			char ch;
			bool jump_out = false;
			while ( ideologies_input.get ( ch ) )
			{
				if ( ch == '}' )
				{
					brace--;
				}
				if ( jump_out && brace == 0 )
				{
					ideologies_gruop_vector.back ().load ( text );
					text.clear ();
					break;
				}
				if ( brace != 0 )
				{
					text += ch;
				}
				if ( ch == '{' )
				{
					brace++;
					jump_out = true;
				}
			}
		}
	}
	cout << "������ʶ��̬���" << endl;
}

void load_governments ()	//��������
{
	cout << "���ڼ�������..." << endl;
	string str;
	while ( governments_input >> str )
	{
		str = trim ( str );
		if ( str [ 0 ] == '#' )	//����ע��
		{
			char eat [ 1000 ];
			governments_input.getline ( eat , 1000 );
			continue;
		}
		government gov ( str );
		for ( char ch = governments_input.get (); ch != '{'; ch = governments_input.get () );	//����
		string  property , value , equal;
		char line_c [ 1000 ];
		while ( governments_input.getline ( line_c , 1000 ) )
		{
			string line ( line_c );
			istringstream istr ( line );
			line = trim ( line );
			if ( line == "" )
			{
				continue;
			}
			if ( line [ 0 ] == '#' )	//����ע��
			{
				char eat [ 1000 ];
				ideologies_input.getline ( eat , 1000 );
				continue;
			}
			if ( line [ 0 ] == '}' )
			{
				break;
			}
			istr >> property >> equal >> value;
			if ( is_in_ideology ( property ) )
			{
				gov.set_property ( property , ok_to_bool ( value ) );
			}
			else if ( property == "election" )
			{
				gov.set_election ( ok_to_bool ( value ) );
			}
			else if ( property == "appoint_ruling_party" )
			{
				gov.set_appoint_ruling_party ( ok_to_bool ( value ) );
			}
			else if ( property == "duration" )
			{
				istringstream istr_value ( value );
				int n;
				istr_value >> n;
				gov.set_duration ( n );
			}
			else if ( property == "flagType" )
			{
				gov.set_flag_type ( str_to_ft ( value ) );
			}
		}
		government_vector.push_back ( gov );
	}
	cout << "�����������" << endl;
}

void load_countries ()	//���ع���
{
	cout << "���ڼ��ع���..." << endl;
	string str;
	bool dynamic = false;
	while ( countries_input >> str )
	{
		if ( str [ 0 ] == '#' )
		{
			char eat [ 1000 ];
			countries_input.getline ( eat , 1000 );
			continue;
		}
		if ( str == "dynamic_tags" )
		{
			dynamic = true;
			char eat [ 1000 ];
			countries_input.getline ( eat , 1000 );
			continue;
		}
		string  full_name;
		char full_name_c [ 1000 ];
		countries_input.getline ( full_name_c , 1000 );
		full_name = string ( full_name_c );
		full_name = trim_full_name ( full_name );
		country con ( str , full_name , dynamic );
		country_vector.push_back ( con );
	}
	while ( country_colors_input >> str )
	{
		if ( str [ 0 ] == '#' )
		{
			char eat [ 1000 ];
			country_colors_input.getline ( eat , 1000 );
			continue;
		}
		country *pcty = nullptr;
		for ( auto &i : country_vector )
		{
			if ( i.get_name () == str )
			{
				pcty = &i;
			}
		}
		if ( !pcty )
		{
			cerr << "���Ҳ����ڣ�" << endl;
			return;
		}
		int brace = 0;	//{����
		char ch;
		int color_num = 0;
		while ( country_colors_input >> ch )
		{
			if ( ch == '{' )
			{
				brace++;
			}
			if ( ch == '}' )
			{
				brace--;
				if ( brace == 0 )
				{
					break;
				}
			}
			if ( brace == 2 )
			{
				color_num++;
				int r , g , b;
				country_colors_input >> r >> g >> b;
				switch ( color_num % 3 )
				{
					case 0:
						pcty->set_color_coats ( r , g , b );
						break;
					case 1:
						pcty->set_color_trousers ( r , g , b );
						break;
					case 2:
						pcty->set_color_hats ( r , g , b );
						break;
				}
			}
		}
	}
	cout << "���Ҽ������" << endl;
}

void show ( const string cmd )	//��ӡ
{
	istringstream istr ( cmd );
	string str;
	istr >> str;
	if ( str == "ideologies_gruop" )
	{
		show_ideologies_gruop ();
	}
	else if ( str == "ideologies" )
	{
		show_ideologies ();
	}
	else if ( str == "governments" )
	{
		show_governments ();
	}
	else if ( str == "countries" )
	{
		show_countries ();
	}
	else
	{
		cerr << "����ʶ��" << str << "�������������룡" << endl;
	}
}

void show_ideologies_gruop ()	//��ӡ��ʶ��̬��
{
	for ( auto &i : ideologies_gruop_vector )
	{
		cout << i.get_name () << endl;
	}
}

void show_ideologies ()	//��ӡ��ʶ��̬
{
	for ( auto &i : ideologies_gruop_vector )
	{
		auto list = i.get_ideology_list ();
		for ( auto &j : list )
		{
			cout << j.get_name () << endl;
		}
	}
}

void show_governments ()	//��ӡ����
{
	for ( auto &i : government_vector )
	{
		cout << i.get_name () << endl << endl << endl;
		for ( auto &j : i.get_properties () )
		{
			cout << j.first->get_name () << "=" << bool_to_ok ( j.second ) << endl;
		}
		cout << endl;
		cout << "election=" << bool_to_ok ( i.get_election () ) << endl;
		cout << "appoint_ruling_party=" << bool_to_ok ( i.get_appoint_ruling_party () ) << endl;
		if ( i.get_election () )
		{
			cout << "duration=" << i.get_duration () << endl;
		}
		cout << "flagType=" << ft_to_str ( i.get_flag_type () ) << endl;
		for ( int k = 0; k < 50; k++ )
		{
			cout << '*';
		}
		cout << endl;
	}
}

void show_countries ()	//��ӡ����
{
	for ( auto &i : country_vector )
	{
		cout << i.get_name () << "\t" << i.get_full_name ();
		if ( i.is_dynamic () )
		{
			cout << "\tdynamic";
		}
		/*��ʾ���Ҿ�����ɫ
		if ( i.is_color_seted () )
		{
		cout << "\n\t" << i.get_coats_color ().get_red () << "\t" << i.get_coats_color ().get_green () << "\t" << i.get_coats_color ().get_blue ();
		cout << "\n\t" << i.get_trousers_color ().get_red () << "\t" << i.get_trousers_color ().get_green () << "\t" << i.get_trousers_color ().get_blue ();
		cout << "\n\t" << i.get_hats_color ().get_red () << "\t" << i.get_hats_color ().get_green () << "\t" << i.get_hats_color ().get_blue ();
		cout << endl;
		}
		*/
		cout << endl;
	}
}

void insert ( const string cmd )	//����
{
	istringstream istr ( trim ( cmd ) );
	string cmd_head , cmd_obj;
	istr >> cmd_head;
	cmd_obj = trim ( cmd.substr ( cmd_head.length () + 1 ) );
	if ( cmd_head == "government" )
	{
		insert_government ( cmd_obj );
	}
	if ( cmd_head == "country" )
	{
		insert_country ( cmd_obj );
	}
	else
	{
		cerr << "����ʶ��" << cmd_head << "�������������룡" << endl;
	}
}

void insert_government ( const string cmd )	//�������
{
	vector<string> property_list;
	vector<string> value_list;
	istringstream istr ( trim ( cmd ) );
	string government_name;
	istr >> government_name;
	if ( is_in_government ( government_name ) )
	{
		cerr << "��" << government_name << "���Ѿ����ڣ�" << endl;
		return;
	}
	government gov ( government_name );
	string property;
	while ( istr >> property )
	{
		if ( property != "value" )
		{
			property_list.push_back ( property );
		}
		else
		{
			break;
		}
	}
	string value;
	while ( istr >> value )
	{
		value_list.push_back ( value );
	}
	if ( property_list.size () != value_list.size () )
	{
		cerr << "ǰ��������ͳһ��" << endl;
		return;
	}
	int len = value_list.size ();
	for ( int i = 0; i < len; i++ )
	{
		if ( is_in_ideology ( property_list [ i ] ) )
		{
			gov.set_property ( property_list [ i ] , ok_to_bool ( value_list [ i ] ) );
		}
		else if ( property_list [ i ] == "duration" )
		{
			istringstream istr_duration ( value_list [ i ] );
			int duration;
			istr_duration >> duration;
			gov.set_duration ( duration );
		}
		else if ( property_list [ i ] == "election" )
		{
			gov.set_election ( ok_to_bool ( value_list [ i ] ) );
		}
		else if ( property_list [ i ] == " appoint_ruling_party" )
		{
			gov.set_appoint_ruling_party ( ok_to_bool ( value_list [ i ] ) );
		}
		else if ( property_list [ i ] == "flag_type" )
		{
			gov.set_flag_type ( str_to_ft ( value_list [ i ] ) );
		}
	}
	gov.save ();
	government_vector.push_back ( gov );
}

void insert_country ( const string cmd )	//��ӹ���
{
	istringstream istr ( cmd );
	string country_name , country_full_name;
	istr >> country_name >> country_full_name;
	if ( !is_in_country ( country_name , country_full_name ) )
	{
		country con ( country_name , country_full_name , false );
		country_vector.push_back ( con );
	}
	else
	{
		cerr << "���ҡ�" << country_full_name << "���Ѿ����ڣ����������룡" << endl;
	}
}

string trim ( string s )	//ȥ���ո�
{
	int i = 0;
	int len = s.length ();
	while ( isspace ( s [ i ] ) && i < len )//��ͷ��Ϊ�ո����Tab��������
	{
		i++;
	}
	s = s.substr ( i );
	if ( s == "" )
	{
		return s;
	}
	i = s.size () - 1;
	while ( isspace ( s [ i ] ) && i>0 )////��β��Ϊ�ո����Tab��������
	{
		i--;
	}
	s = s.substr ( 0 , i + 1 );
	return s;
}

string trim_full_name ( string s )	//����country.txt���·��
{
	s = trim ( s );
	while ( s [ 0 ] == '=' || isspace ( s [ 0 ] ) || s [ 0 ] == '"' )
	{
		s = s.substr ( 1 );
	}
	while ( s [ 0 ] != '/' )
	{
		s = s.substr ( 1 );
	}
	s = s.substr ( 1 );
	s = trim ( s );
	s = s.substr ( 0 , s.length () - 5 );
	return s;
}

bool is_in_ideology ( const string id_name )	//�ж���ʶ��̬�Ƿ����
{
	bool id_exists = false;
	for ( auto &i : ideologies_gruop_vector )
	{
		auto list = i.get_ideology_list ();
		for ( auto &j : list )
		{
			if ( id_name == j.get_name () )
			{
				id_exists = true;
			}
		}
	}
	return id_exists;
}

bool is_in_government ( const string gov_name )	//�ж������Ƿ����
{
	bool gov_exists = false;
	for ( auto &i : government_vector )
	{
		if ( gov_name == i.get_name () )
		{
			gov_exists = true;
		}
	}
	return gov_exists;
}

bool is_in_country ( const string name , const string full_name )	//�жϹ����Ƿ����
{
	for ( auto &i : country_vector )
	{
		if ( i.get_name () == name )
		{
			return true;
		}
		if ( i.get_full_name () == full_name )
		{
			return true;
		}
	}
	return false;
}

bool ok_to_bool ( const string ok )	//��"yes","no"ת����bool����
{
	if ( ok == "yes" )
	{
		return true;
	}
	else if ( ok == "no" )
	{
		return false;
	}
	else
	{
		cout << "����Ԥ�ϵ�ok->boolת������" << endl;
		std::exit ( 0 );
	}
}

string bool_to_ok ( const bool flag )	//��bool����ת����bool"yes","no"
{
	if ( flag )
	{
		return string ( "yes" );
	}
	return string ( "no" );
}

flagType str_to_ft ( const string str )	//���ַ���ת����flagType����
{
	if ( str == "communist" )
	{
		return communist;
	}
	if ( str == "republic" )
	{
		return republic;
	}
	if ( str == "fascist" )
	{
		return fascist;
	}
	if ( str == "monarchy" )
	{
		return monarchy;
	}
	else
	{
		cerr << "flagType����ת������" << endl;
		std::exit ( 1 );
	}
}

string ft_to_str ( flagType ft )	//��flagType����ת�����ַ�������
{
	switch ( ft )
	{
		case 	communist:	//��������
			return string ( "communist" );
			break;
		case	republic:	//���͹�
			return string ( "republic" );
			break;
		case	fascist:	//����˹
			return string ( "fascist" );
			break;
		case	monarchy://������
			return string ( "monarchy" );
			break;
		default:
			cerr << "flagType����ת��ʧ��" << endl;
			exit ( 1 );
	}
}