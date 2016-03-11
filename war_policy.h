//war_policy.h
//ս��������

#ifndef WAR_POLICY_H
#define WAR_POLICY_H

#include<string>

using namespace std;

class war_policy	//ս��������
{
public:
	war_policy ( string name , double max_military_spending ,
				 double supply_consumption , double war_exhaustion_effect ,
				 bool is_jingoism , double cb_generation_speed_modifier ,
				 int mobilization_impact , double org_regain , double reinforce_speed );
	string get_name ();	//��ȡս��������
private:
	string name;	//ս����������
	double max_military_spending;	//������Ԥ��
	double	supply_consumption;	//��������
	double	war_exhaustion_effect;	//��սӰ��
	bool	is_jingoism;	//�Ƿ�Ϊɳ������
	double	cb_generation_speed_modifier;	//��ս����ڵ��ٶ�����
	int mobilization_impact;	//��ԱӰ��
	double	org_regain;	//��֯�Ȼָ�
	double	reinforce_speed;	//��Ԯ�ٶ�
};

#endif