//party.h
//������

#ifndef PARTY_H
#define PARTY_H

#include<string>
#include"date.h"
#include"ideology.h"
#include"economic_policy.h"
#include"trade_policy.h"
#include"religious_policy.h"
#include"citizenship_policy.h"
#include"war_policy.h"

using namespace std;

class party	//������
{
public:
	party ( string name , date start_date , date end_date ,
			string ideo , string economic , string trade , string religious ,
			string citizenship , string war_policy );
	string get_name ();	//ȡ��������
private:
	string name;	//������
	date start_date;	//����ʱ��
	date end_date;	//��ɢʱ��
	ideology* ideo;	//��ʶ��̬
	economic_policy* economic;	//��������
	trade_policy* trade;	//ó������
	religious_policy* religious;	//�ڽ�����
	citizenship_policy* citizenship;	//����Ȩ����
	war_policy* war;	//ս������
};

#endif