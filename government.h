#ifndef GOVERNMENT_H
#define GOVERNMENT_H

//government.h
//������

#include<string>
#include<vector>
#include"ideology.h"

using namespace std;

enum flagType	//���ķ��
{
	communist ,	//��������
	republic ,	//���͹�
	fascist ,	//����˹
	monarchy ,	//������
};

class government
{
public:
	government ( const string name );
	void set_property ( const string , bool );	//������ʶ��̬	
	void set_election ( bool ok );	//�����Ƿ����ѡ��
	void set_duration ( short dur );	//����ѡ�ټ��
	void set_appoint_ruling_party ( bool ok );	//�����Ƿ�����ָ��ִ����
	void set_flag_type ( flagType flag_type );	//�������ķ��

	string get_name ();	//�������
	short get_duration ();	//���ѡ�ټ��
	bool get_election ();	//����Ƿ�����ѡ��
	bool get_appoint_ruling_party ();	//����Ƿ�����ָ��ִ����
	flagType get_flag_type ();	//������ķ��
	vector<pair<ideology* , bool>> get_properties ();	//�����ʶ��̬�Ƿ�����
	void save ();	//���浽�ļ�
private:
	string name;	//����
	short duration;	//ѡ�ټ�����£�
	vector<pair<ideology* , bool>> properties;	//��ʶ��̬�Ƿ�����
	bool election;	//�Ƿ�����ѡ��
	bool appoint_ruling_party;	//�Ƿ�����ָ��ִ����
	flagType flag_type;	//���ķ��
};

#endif