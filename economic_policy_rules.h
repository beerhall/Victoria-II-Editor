//economic_policy_rules.h
//�������߹�����

#ifndef ECONOMIC_POLICY_RULES_H
#define ECONOMIC_POLICY_RULES_H

#include<vector>
#include<string>

using namespace std;

class economic_policy_rules
{
public:
	economic_policy_rules ( vector<pair<string , bool>> args );
	economic_policy_rules () = default;
private:
	bool build_factory;	//���칤��
	bool	expand_factory;	//��������
	bool open_factory;	//�ؿ�����
	bool destroy_factory;	//�ݻٹ���
	bool	build_railway;	//������·
	bool	factory_priority;	//�������ȼ�
	bool	can_subsidise;	//���Բ���
	bool	pop_build_factory;	//�ʱ��ҽ��칤��
	bool	pop_expand_factory;	//�ʱ�����������
	bool	pop_open_factory;	//�ʱ����ؿ�����
	bool delete_factory_if_no_input;	//�رչ������û��ԭ��
	bool	pop_build_factory_invest;	//�ʱ���Ͷ�ʽ��칤��
	bool	pop_expand_factory_invest;	//�ʱ���Ͷ����������
	bool	open_factory_invest;	//Ͷ���ؿ�����
	bool	allow_foreign_investment;	//�������Ͷ��
	bool	build_railway_invest;	//Ͷ�ʽ�����·
	bool build_factory_invest;	//Ͷ�ʽ��칤��
	bool expand_factory_invest;	//Ͷ����������
	bool	can_invest_in_pop_projects;	//����Ͷ����佨��
};

#endif