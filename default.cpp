//Victoria II Editor
//Դ.cpp

#include<iostream>
#include<fstream>
#include<sstream>
#include<string>
#include<vector>
#include"ideologies_group.h"
#include"government.h"

using namespace std;

ofstream governments_output ( ".\\common\\governments.txt" , ios::app );
ofstream ideologies_output ( ".\\common\\ideologies.txt" , ios::app );
ifstream governments_input ( ".\\common\\governments.txt" );
ifstream ideologies_input ( ".\\common\\ideologies.txt" );

vector<ideologies_gruop> ideologies_gruop_vector;	//������ʶ��̬��
vector<government> governmet_vector;	//��������

void excute ( const string& cmd );	//ִ������

void load ();	//�����ļ�
void show ();	//��ӡ
void insert ();	//����

void load_ideologies_gruop ();	//������ʶ��̬��
void load_governments ();	//��������

void show_ideologies_gruop ();	//��ӡ��ʶ��̬��
void show_ideologies ();	//��ӡ��ʶ��̬
void show_governments ();	//��ӡ����

void insert_government ();	//�������

string trim ( string s );	//ȥ���ո�
bool is_in_ideology ( const string id_name );	//�ж���ʶ��̬�Ƿ����
bool ok_to_bool ( const string ok );	//��"yes","no"ת����bool����
string bool_to_ok ( const bool flag );	//��bool����ת����bool"yes","no"
flagType str_to_ft ( const string str );	//���ַ���ת����flagType����
string ft_to_str ( flagType ft );	//��flagType����ת�����ַ�������

int main ( void )
{
	string cmd;	//����
	load ();	//�����ļ�
	while ( 1 )
	{
		cout << "Victoria II Editor >  ";
		cin >> cmd;
		excute ( cmd );	//ִ������
	}
	system ( "pause" );
	return 0;
}


void excute ( const string& cmd )	//ִ������
{
	if ( cmd == "insert" )	//�������
	{
		insert ();
	}
	if ( cmd == "show" )
	{
		show ();
	}
	else if ( cmd == "quit" )	//�˳�
	{
		exit ( 0 );
	}
	else	//����ʶ��
	{
		cerr << "����ʶ��" << cmd << "�������������룡" << endl;
	}
}

void load ()	//�����ļ�
{
	load_ideologies_gruop ();
	load_governments ();
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
			ideologies_input.getline ( eat , 1000 );
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
		governmet_vector.push_back ( gov );
	}
	cout << "�����������" << endl;
}

void show ()	//��ӡ
{
	string str;
	cin >> str;
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
	for ( auto &i : governmet_vector )
	{
		cout << i.get_name () << endl;
		for ( auto &j : i.get_properties () )
		{
			cout << j.first->get_name () << "=" << bool_to_ok ( j.second ) << endl;
		}
		cout << endl;
		cout << "election=" << bool_to_ok ( i.get_election () ) << endl;
		cout << "appoint_ruling_party=" << bool_to_ok ( i.get_appoint_ruling_party () ) << endl;
		cout << "duration=" << i.get_duration () << endl;
		cout << "flagType=" << ft_to_str ( i.get_flag_type () ) << endl;
		cout << endl << endl;
	}
}

void insert ()	//����
{
	string str;
	cin >> str;
	if ( str == "government" )
	{
		insert_government ();
	}
	else
	{
		cerr << "����ʶ��" << str << "�������������룡" << endl;
	}
}

void insert_government ()	//�������
{
	try
	{
		string str;
		cin >> str;
		government gov ( str );
	}
	catch ( string name )
	{
		cerr << "��" << name << "���ǲ����ڵ���ʶ��̬��" << endl;
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
		exit ( 0 );
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
		exit ( 1 );
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