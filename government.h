#ifndef GOVERNMENT_H
#define GOVERNMENT_H

//government.h
//政体类

#include<string>
#include<vector>
#include"ideology.h"

using namespace std;

enum flagType	//旗帜风格
{
	communist ,	//共产主义
	republic ,	//共和国
	fascist ,	//法西斯
	monarchy ,	//君主制
};

class government
{
public:
	government ( const string name );
	void set_property ( const string , bool );	//设置意识形态	
	void set_election ( bool ok );	//设置是否可以选举
	void set_duration ( short dur );	//设置选举间隔
	void set_appoint_ruling_party ( bool ok );	//设置是否允许指定执政党
	void set_flag_type ( flagType flag_type );	//设置旗帜风格

	string get_name ();	//获得名字
	short get_duration ();	//获得选举间隔
	bool get_election ();	//获得是否允许选举
	bool get_appoint_ruling_party ();	//获得是否允许指定执政党
	flagType get_flag_type ();	//获得旗帜风格
	vector<pair<ideology* , bool>> get_properties ();	//获得意识形态是否允许
private:
	string name;	//名字
	short duration;	//选举间隔（月）
	vector<pair<ideology* , bool>> properties;	//意识形态是否允许
	bool election;	//是否允许选举
	bool appoint_ruling_party;	//是否允许指定执政党
	flagType flag_type;	//旗帜风格
};

#endif