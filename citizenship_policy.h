//citizenship_policy.h
//����Ȩ������

#ifndef CITIZENSHIP_POLICY_H
#define CITIZENSHIP_POLICY_H

#include<string>

using namespace std;

enum citizenship_policy_rule	//����Ȩ����
{
	primary_culture_voting ,	//����Ȩ
	culture_voting ,	//���޹���Ȩ
	all_voting	//��������Ȩ
};

class citizenship_policy	//����Ȩ����
{
public:
	citizenship_policy ( string name , double global_assimilation_rate , string citizenship_policy_rule );
	string get_name ();	//ȡ�ù���Ȩ������
private:
	string name;	//����Ȩ������
	double global_assimilation_rate;	//ͬ����
	citizenship_policy_rule rules;
};

#endif