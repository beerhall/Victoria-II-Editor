//Victoria II Editor
//源.cpp

#include<iostream>
#include<fstream>
#include<sstream>
#include<string>
#include<vector>
#include"ideologies_group.h"
#include"government.h"
#include"country.h"

using namespace std;

ofstream governments_output ( ".\\common\\governments.txt" , ios::app );	//governments.txt输出
ofstream ideologies_output ( ".\\common\\ideologies.txt" , ios::app );	//ideologies.txt输出
ofstream countries_output ( ".\\common\\countries.txt" , ios::app );	//countries.txt输出
ofstream country_colors_output ( ".\\common\\country_colors.txt" , ios::app );	//country_colors输出

ifstream governments_input ( ".\\common\\governments.txt" );	//governments.txt输入
ifstream ideologies_input ( ".\\common\\ideologies.txt" );	//ideologies.txt输入
ifstream countries_input ( ".\\common\\countries.txt" );	//countries.txt输入
ifstream country_colors_input ( ".\\common\\country_colors.txt" );	//country_colors输入

vector<ideologies_gruop> ideologies_gruop_vector;	//储存意识形态组
vector<government> government_vector;	//储存政体
vector<country> country_vector;	//储存国家

void excute ( const string& cmd );	//执行命令

void load ();	//加载文件
void show ( const string cmd );	//打印
void insert ( const string cmd );	//插入

void load_ideologies_gruop ();	//加载意识形态组
void load_governments ();	//加载政体
void load_countries ();	//加载国家

void show_ideologies_gruop ();	//打印意识形态组
void show_ideologies ();	//打印意识形态
void show_governments ();	//打印政体
void show_countries ();	//打印国家

void insert_government ( const string cmd );	//添加政体
void insert_country ( const string cmd );	//添加国家

string trim ( string s );	//去除空格
string trim_full_name ( string s );	//解析country.txt里的路径
bool is_in_ideology ( const string id_name );	//判断意识形态是否存在
bool is_in_government ( const string gov_name );	//判断政体是否存在
bool ok_to_bool ( const string ok );	//将"yes","no"转换成bool类型
bool is_in_country ( const string name , const string full_name );	//判断国家是否存在
string bool_to_ok ( const bool flag );	//将bool类型转换成bool"yes","no"
flagType str_to_ft ( const string str );	//将字符串转换成flagType类型
string ft_to_str ( flagType ft );	//将flagType类型转换成字符串类型

int main ( void )
{
	string cmd;	//命令
	load ();	//加载文件
	while ( 1 )
	{
		cmd = "";
		cout << "Victoria II Editor >  ";
		char ch;
		while ( ( ch = cin.get () ) != ';' )
		{
			cmd += ch;
		}
		excute ( cmd );	//执行命令
	}
	system ( "pause" );
	return 0;
}


void excute ( const string& cmd )	//执行命令
{
	istringstream istr ( trim ( cmd ) );
	string cmd_head , cmd_obj;
	istr >> cmd_head;
	if ( cmd_head == "quit" )	//退出
	{
		exit ( 0 );
	}
	cmd_obj = trim ( cmd.substr ( cmd_head.length () + 1 ) );
	if ( cmd_head == "insert" )	//添加政体
	{
		insert ( cmd_obj );
	}
	else if ( cmd_head == "show" )
	{
		show ( cmd_obj );
	}
	else	//不能识别
	{
		cerr << "不能识别”" << cmd_head << "“，请重新输入！" << endl;
	}
}

void load ()	//加载文件
{
	load_ideologies_gruop ();
	load_governments ();
	load_countries ();
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
		government_vector.push_back ( gov );
	}
	cout << "加载政体完成" << endl;
}

void load_countries ()	//加载国家
{
	cout << "正在加载国家..." << endl;
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
			cerr << "国家不存在！" << endl;
			return;
		}
		int brace = 0;	//{级数
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
	cout << "国家加载完成" << endl;
}

void show ( const string cmd )	//打印
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

void show_countries ()	//打印国家
{
	for ( auto &i : country_vector )
	{
		cout << i.get_name () << "\t" << i.get_full_name ();
		if ( i.is_dynamic () )
		{
			cout << "\tdynamic";
		}
		/*显示国家军服颜色
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

void insert ( const string cmd )	//插入
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
		cerr << "不能识别”" << cmd_head << "“，请重新输入！" << endl;
	}
}

void insert_government ( const string cmd )	//添加政体
{
	vector<string> property_list;
	vector<string> value_list;
	istringstream istr ( trim ( cmd ) );
	string government_name;
	istr >> government_name;
	if ( is_in_government ( government_name ) )
	{
		cerr << "“" << government_name << "”已经存在！" << endl;
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
		cerr << "前后数量不统一！" << endl;
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

void insert_country ( const string cmd )	//添加国家
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
		cerr << "国家“" << country_full_name << "”已经存在，请重新输入！" << endl;
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

string trim_full_name ( string s )	//解析country.txt里的路径
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

bool is_in_government ( const string gov_name )	//判断政体是否存在
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

bool is_in_country ( const string name , const string full_name )	//判断国家是否存在
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
		std::exit ( 0 );
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
		std::exit ( 1 );
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