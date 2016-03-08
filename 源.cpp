//Victoria II Editor
//源.cpp

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

vector<ideologies_gruop> ideologies_gruop_vector;	//储存意识形态组
vector<government> governmet_vector;	//储存政体

void excute ( const string& cmd );	//执行命令

void load ();	//加载文件
void show ();	//打印
void insert ();	//插入

void load_ideologies_gruop ();	//加载意识形态组
void load_governments ();	//加载政体

void show_ideologies_gruop ();	//打印意识形态组
void show_ideologies ();	//打印意识形态
void show_governments ();	//打印政体

void insert_government ();	//添加政体

string trim ( string s );	//去除空格
bool is_in_ideology ( const string id_name );	//判断意识形态是否存在
bool ok_to_bool ( const string ok );	//将"yes","no"转换成bool类型
string bool_to_ok ( const bool flag );	//将bool类型转换成bool"yes","no"
flagType str_to_ft ( const string str );	//将字符串转换成flagType类型
string ft_to_str ( flagType ft );	//将flagType类型转换成字符串类型

int main ( void )
{
	string cmd;	//命令
	load ();	//加载文件
	while ( 1 )
	{
		cout << "Victoria II Editor >  ";
		cin >> cmd;
		excute ( cmd );	//执行命令
	}
	system ( "pause" );
	return 0;
}


void excute ( const string& cmd )	//执行命令
{
	if ( cmd == "insert" )	//添加政体
	{
		insert ();
	}
	if ( cmd == "show" )
	{
		show ();
	}
	else if ( cmd == "quit" )	//退出
	{
		exit ( 0 );
	}
	else	//不能识别
	{
		cerr << "不能识别”" << cmd << "“，请重新输入！" << endl;
	}
}

void load ()	//加载文件
{
	load_ideologies_gruop ();
	load_governments ();
}

void load_ideologies_gruop ()	//加载意识形态组
{
	//提示信息
	cout << "正在加载意识形态..." << endl;
	unsigned brace = 0;	//大括号‘{’的数量，遇到‘}’减一
	string str;
	string text;
	while ( ideologies_input >> str )
	{
		if ( str [ 0 ] == '#' )	//跳过注释
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
	cout << "加载意识形态完成" << endl;
}

void load_governments ()	//加载政体
{
	cout << "正在加载政体..." << endl;
	string str;
	while ( governments_input >> str )
	{
		str = trim ( str );
		if ( str [ 0 ] == '#' )	//跳过注释
		{
			char eat [ 1000 ];
			governments_input.getline ( eat , 1000 );
			continue;
		}
		government gov ( str );
		for ( char ch = governments_input.get (); ch != '{'; ch = governments_input.get () );	//跳过
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
			if ( line [ 0 ] == '#' )	//跳过注释
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
	cout << "加载政体完成" << endl;
}

void show ()	//打印
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
		cerr << "不能识别”" << str << "“，请重新输入！" << endl;
	}
}

void show_ideologies_gruop ()	//打印意识形态组
{
	for ( auto &i : ideologies_gruop_vector )
	{
		cout << i.get_name () << endl;
	}
}

void show_ideologies ()	//打印意识形态
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

void show_governments ()	//打印政体
{
	for ( auto &i : governmet_vector )
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

void insert ()	//插入
{
	string str;
	cin >> str;
	if ( str == "government" )
	{
		insert_government ();
	}
	else
	{
		cerr << "不能识别”" << str << "“，请重新输入！" << endl;
	}
}

void insert_government ()	//添加政体
{
	try
	{
		string str;
		cin >> str;
		government gov ( str );
	}
	catch ( string name )
	{
		cerr << "”" << name << "“是不存在的意识形态！" << endl;
	}
}

string trim ( string s )	//去除空格
{
	int i = 0;
	int len = s.length ();
	while ( isspace ( s [ i ] ) && i < len )//开头处为空格或者Tab，则跳过
	{
		i++;
	}
	s = s.substr ( i );
	if ( s == "" )
	{
		return s;
	}
	i = s.size () - 1;
	while ( isspace ( s [ i ] ) && i>0 )////结尾处为空格或者Tab，则跳过
	{
		i--;
	}
	s = s.substr ( 0 , i + 1 );
	return s;
}

bool is_in_ideology ( const string id_name )	//判断意识形态是否存在
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

bool ok_to_bool ( const string ok )	//将"yes","no"转换成bool类型
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
		cout << "不可预料的ok->bool转换错误" << endl;
		exit ( 0 );
	}
}

string bool_to_ok ( const bool flag )	//将bool类型转换成bool"yes","no"
{
	if ( flag )
	{
		return string ( "yes" );
	}
	return string ( "no" );
}

flagType str_to_ft ( const string str )	//将字符串转换成flagType类型
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
		cerr << "flagType类型转换错误！" << endl;
		exit ( 1 );
	}
}

string ft_to_str ( flagType ft )	//将flagType类型转换成字符串类型
{
	switch ( ft )
	{
		case 	communist:	//共产主义
			return string ( "communist" );
			break;
		case	republic:	//共和国
			return string ( "republic" );
			break;
		case	fascist:	//法西斯
			return string ( "fascist" );
			break;
		case	monarchy://君主制
			return string ( "monarchy" );
			break;
		default:
			cerr << "flagType类型转换失败" << endl;
			exit ( 1 );
	}
}
