//economic_policy
//����������

#ifndef ECONOMIC_POLICY_H
#define ECONOMIC_POLICY_H

#include<string>
#include<vector>
#include"economic_policy_rules.h"

using namespace std;

class economic_policy
{
public:
	economic_policy ( string name , double max_tax , double min_tax ,
					  double factory_throughput , double factory_owner_cost ,
					  double factory_output , economic_policy_rules rules );
	string get_name ();	//���������
private:
	string name;	//������
	double max_tax;	//���˰��
	double min_tax;	//���˰��
	double factory_throughput;	//��������
	double factory_owner_cost;	//���칤������
	double factory_output;	//��������
	economic_policy_rules rules;	//����
};

#endif