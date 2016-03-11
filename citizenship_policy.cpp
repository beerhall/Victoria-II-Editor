//citizenship_policy.cpp
//����Ȩ����

#include<iostream>
#include"citizenship_policy.h"

citizenship_policy::citizenship_policy ( string name , double global_assimilation_rate , string citizenship_policy_rule )
{
	this->name = name;
	this->global_assimilation_rate = global_assimilation_rate;
	if ( citizenship_policy_rule == "primary_culture_voting" )
	{
		this->global_assimilation_rate = primary_culture_voting;
	}
	else if ( citizenship_policy_rule == "culture_voting" )
	{
		this->global_assimilation_rate = culture_voting;
	}
	else if ( citizenship_policy_rule == "all_voting" )
	{
		this->global_assimilation_rate = all_voting;
	}
	else
	{
		std::cerr << "����Ȩ���߹���" << global_assimilation_rate << "�������ڣ����������룡" << endl;
	}
}

string citizenship_policy::get_name ()	//��ù���Ȩ������
{
	return name;
}